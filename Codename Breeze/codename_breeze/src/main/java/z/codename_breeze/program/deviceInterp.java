package z.codename_breeze.program;

/*
 * @author David "z" Samuel"
 * 
 * Don't steal Source Code, read it, learn it, adapt it and give credit to original owner.
 * Check out my Github if you're interested on any other project that I might have - http://github.com/zGrav
 * Contact me at zgrav@null.net for more information
 * Please contribute and report bugs or any new features you would like to be implemented.
 * 
 * (c) z/David Samuel - 2nd February 2013
 */

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.Socket;
import java.net.UnknownHostException;


import com.android.ddmlib.IDevice;

public class deviceInterp {
	private static final int interpPort = 1337; //sets our interp port
	private static final String local = "/codename_breezeclient.jar"; //gets our local interp jar
	private static final String remote = "/data/local/tmp/codename_breezeclient.jar"; //sets remote interp jar
	IDevice getDevice; //our device

	public static Socket mainSocket; //creates socket
	OutputStream out; //creates output stream
	BufferedReader buffReader; //creates buffered reader

	Thread t = new Thread("Interp init") {
		public void run() {
			try {
				init(); //starts our interp
			} catch (Exception e) {
				throw new RuntimeException(e);
			}
		}
	};

	public screenThread screen; //our screen capture thread

	public deviceInterp(IDevice d) throws IOException {
		this.getDevice = d;
		this.screen = new screenThread(d); //starts thread according to our device.
	}

	public void start() {
		t.start();
	}

	private void pushClient() throws IOException {
		try {
			File temp = File.createTempFile("client", ".jar"); //creates temp interp on our system
			streamHelper.pushData(getClass(), local,temp); //parses data onto our temp file
			new getDevice(getDevice).pushFile(temp,remote); //uploads to our remote device
			temp.deleteOnExit(); //once we are done, no longer need temp file.
		} catch (Exception ex) {
			throw new RuntimeException(ex);
		}
	}

	private static boolean killOld() { //terminates old interp if existant.
		try {
			Socket socket = new Socket("127.0.0.1", interpPort);
			OutputStream outs = socket.getOutputStream();
			outs.write("quit\n".getBytes());
			outs.flush();
			outs.close();
			socket.getInputStream().close();
			socket.close();
			return true;
		} catch (Exception ex) {
			
		}
		return false;
	}

	public void close() { //terminates our connection and buffers.
		try {
			if (out != null) {
				out.write("quit\n".getBytes());
				out.flush();
				out.close();
			}
			if(buffReader != null){
				buffReader.close();
			}
			mainSocket.close();
		} catch (Exception ex) {

		}
		screen.interrupt();
		try {
			mainSocket.close();
		} catch (Exception ex) {
		
		}
		try {
			synchronized (getDevice) {
				//todo: deviceforward
			}
		} catch (Exception ex) {
			
		}
	}

	public void interpMouse(int action, float x, float y) throws IOException { //our mouse interpreter
		long clickTime = 50;
		long eventTime = 50;

		int state = 0;

		String cmd = "pointer/" + clickTime + "/" + eventTime + "/" + action + "/" + x + "/" + y + "/" + state;
		interpData(cmd);
	}

	public void interpTrackball(float amount) throws IOException { //our mouse wheel interpreter
		long clickTime = 0;
		long eventTime = 0;
		float x = 0;
		float y = amount;
		int state = -1;

		String cmd1 = "trackball/" + clickTime + "/" + eventTime + "/" + motionMap.ACTION_MOVE + "/" + x + "/" + y + "/"+ state;
		interpData(cmd1);
		
		String cmd2 = "trackball/" + clickTime + "/" + eventTime + "/"+ motionMap.ACTION_CANCEL + "/" + x + "/" + y + "/" + state;
		interpData(cmd2);
	}

	public void interpKey(int type, int key) { //our key interpreter
		String cmd = "key/" + type + "/" + key;
		interpData(cmd);
	}

	private void interpData(String data) { //our interpreter
		try {
			if (out == null) {
				System.out.println("Interpreter not running.");
				return;
			}
			out.write((data + "\n").getBytes());
			out.flush();
		} catch (Exception sex) {
			try {
				mainSocket = new Socket("127.0.0.1", interpPort);
				out = mainSocket.getOutputStream();
				out.write((data + "\n").getBytes());
				out.flush();
			} catch(Exception ex) {
				
			}
		}
	}
	
	private void init() throws UnknownHostException, IOException, InterruptedException {
		
		getDevice.createForward(interpPort, interpPort); //creates a portforward to our device and machine

		if (killOld()) { //kills old interp if existent
			System.out.println("Old client terminated.");
		}

		pushClient(); //uploads our interpreter

		Thread threadRunClient = new Thread("Running Client") { //launches our interpreter
			public void run() {
				try {
					launchClient("" + interpPort + " debug");
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		};
		threadRunClient.start();
		Thread.sleep(4000); //sleep while we upload
		connectClient(); //connects to our interpreter
		System.out.println("Client uploaded !");
	}

	private void connectClient() { //initiates connection
		for (int i = 0; i < 10; i++) {
			try {
				mainSocket = new Socket("127.0.0.1", interpPort);
				break;
			} catch (Exception s) {
				try {
					Thread.sleep(1000);
				} catch (InterruptedException e) {
					return;
				}
			}
		}
		System.out.println("Client connected!");
		screen.start();
		
		try {
			out = mainSocket.getOutputStream(); //our data output
			
			buffReader = new BufferedReader(new InputStreamReader(mainSocket.getInputStream())); //data from device
			
			 Thread reader = new Thread() { //our text reader
		            public void run() {
		            	String text = new String();
		            	
		        		try {
		        			while((text = buffReader.readLine()) != null ){
			            		//System.out.println("\t\t[output]:" + text);
			            	}
		        		} catch (IOException e) {
		        			text = e.getMessage();
		        			//System.out.println("\t\t[output]:" + text);
		        		}
		            }
		        };
		        
		        reader.start();
	} catch (IOException e) {
			throw new RuntimeException(e);
		}
	}

	private void launchClient(String cmd) throws IOException{ //launches our interpreter on remote device
		String full = "export CLASSPATH=" + remote + ";" + "exec app_process /system/bin " + "z.codename_breezeclient.Main" + " " + cmd;
		
		System.out.println("Launching client.");
		getDevice.executeShellCommand(full, new outputReceiver(System.out));
		
		System.out.println("Client terminated.");
		
		getDevice.executeShellCommand("rm " + remote, new outputReceiver(System.out));
	}
}
