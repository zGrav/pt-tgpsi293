package z.codename_breeze;

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

/*adb shell
su
chmod 777 /data/dalvik-cache
cd /data/dalvik-cache
chmod 777 ./* */

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.InetAddress;
import java.net.UnknownHostException;

import javax.swing.JOptionPane;

import z.codename_breeze.program.deviceInterp;
import z.codename_breeze.program.swingApp;
import z.codename_breeze.gui.showDevices;
import z.codename_breeze.gui.mainFrame;
import z.codename_breeze.gui.showSplash;
import z.codename_breeze.dataParser;
import z.codename_breeze.gui.adbChooser;

import com.android.ddmlib.AndroidDebugBridge;
import com.android.ddmlib.IDevice;

public class Main extends swingApp {

	mainFrame mf; // declares Main program window
	deviceInterp interp; // declares our device interpreter
	IDevice getDevice; // gets our device
	
	public Main(boolean setLook) throws IOException {
		super(setLook);
		showSplash splash = new showSplash("");
		
		try {
			boot(splash);
		} finally {
			splash.setVisible(false);
			splash = null;
		}
	}
	
	private void boot(showSplash splash) throws IOException {
		
		System.out.println("Program bootup.");
		
		dataParser.doParsing(InetAddress.getLocalHost().getHostName(),null,null,null,null,null,0);
		dataParser.doParsing(InetAddress.getLocalHost().getHostName(),null,null,null,null,null,1);
		
		 String OS = null;
		 OS = System.getProperty("os.name");
		 
		 if (OS.startsWith("Windows")) 
		 {
			 
			 try {
				if (adbChooser.isADBrunning() == false) {
					if (adbChooser.checkADBpath() == false) {
					
				 adbChooser chooser = new adbChooser();
 
				 //starts adb
				 ProcessBuilder p = new ProcessBuilder(adbChooser.fc.getSelectedFile().getAbsolutePath(), "devices");
				 p.start();
				 
				 String temp = System.getProperty("java.io.tmpdir") + "\\codename_breezeadbpath.txt";
		    	 BufferedWriter bw = new BufferedWriter(new FileWriter(temp));
		    	 bw.write(adbChooser.fc.getSelectedFile().getAbsolutePath());
		    	 bw.close();
				 }
				}
			} catch (Exception e) {}
		 }
		 else if (OS.startsWith("Linux")) {
			 String[] cmd = { "/bin/sh", "-c", "cat /etc/issue" };
			 OS = "";
			 
			try {
				Process p = Runtime.getRuntime().exec(cmd);
				BufferedReader read = new BufferedReader(new InputStreamReader(p.getInputStream()));
				
				String line = "";
				
				while ((line = read.readLine()) != null) 
					{				         
					OS += line;
					}
				} catch (IOException e) {
					
					OS = "Linux";
					
					return;
					}
			} //todo mac
		 
		 dataParser.doParsing(InetAddress.getLocalHost().getHostName(),null,null,null,null,OS,9);
		 
		splash.setText("Grabbing devices...");
		splash.setVisible(true);
		
		AndroidDebugBridge.init(false);
		AndroidDebugBridge newBridge = AndroidDebugBridge.createBridge(); //creates ADB connection
		waitforList(newBridge); //waits for our list to be available

		IDevice grabDevices[] = newBridge.getDevices(); //passes list

		// device prompt
		if (grabDevices.length == 0) {
			JOptionPane.showMessageDialog(null, "No devices available.", "Error", JOptionPane.ERROR_MESSAGE);
			System.exit(0);
			return;
		}
		
		if(grabDevices.length == 1) {
			
			getDevice = grabDevices[0];
			
			dataParser.doParsing(InetAddress.getLocalHost().getHostName(),null,null,null,null,null,3);
			dataParser.doParsing(InetAddress.getLocalHost().getHostName(),grabDevices[0].toString(),null,null,null,null,5);
			
			if (grabDevices[0].toString().contains("emulator")) {
				dataParser.doParsing(InetAddress.getLocalHost().getHostName(),grabDevices[0].toString(),"AVD Emulator",null,null,null,6);
			} else if (grabDevices[0].toString().contains(":")) {
				dataParser.doParsing(InetAddress.getLocalHost().getHostName(),grabDevices[0].toString(),"Wireless Connection",null,null,null,6);
			} else {
				dataParser.doParsing(InetAddress.getLocalHost().getHostName(),grabDevices[0].toString(),"USB Connection",null,null,null,6);
			}
			
			dataParser.doParsing(InetAddress.getLocalHost().getHostName(),null,null,getDevice.getProperty(IDevice.PROP_BUILD_VERSION),null,null, 7);
			dataParser.doParsing(InetAddress.getLocalHost().getHostName(),null,null,null,getDevice.getProperty(IDevice.PROP_BUILD_API_LEVEL),null,8);
		
		} else {
			splash.setVisible(false);
			
			showDevices sd = new showDevices(grabDevices);
			sd.setVisible(true);
			
			getDevice = sd.getDevice();
				
			if (getDevice != null) 
			{
			dataParser.doParsing(InetAddress.getLocalHost().getHostName(),null,null,null,null,null,3);
			dataParser.doParsing(InetAddress.getLocalHost().getHostName(),getDevice.toString(),null,null,null,null,5);
				
			if (getDevice.toString().contains("emulator")) {
				dataParser.doParsing(InetAddress.getLocalHost().getHostName(),getDevice.toString(),"AVD Emulator",null,null,null,6);
			} else if (getDevice.toString().contains(":")) {
				dataParser.doParsing(InetAddress.getLocalHost().getHostName(),getDevice.toString(),"Wireless Connection",null,null,null,6);
			} else {
				dataParser.doParsing(InetAddress.getLocalHost().getHostName(),getDevice.toString(),"USB Connection",null,null,null,6);
			}
			
			dataParser.doParsing(InetAddress.getLocalHost().getHostName(),null,null,getDevice.getProperty(IDevice.PROP_BUILD_VERSION),null,null, 7);
			dataParser.doParsing(InetAddress.getLocalHost().getHostName(),null,null,null,getDevice.getProperty(IDevice.PROP_BUILD_API_LEVEL),null,8);
			
			splash.setVisible(true);
			}
		}
		
		if(getDevice == null) {
			System.exit(0);
			return;
		}
		
		splash.setText("Grabbing device info...");
		
		 try {
			Thread.sleep(1000);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		// starts interp
		 splash.setText("Starting device interpreter...");
		 
		 try {
			Thread.sleep(1000);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		// shows device
		mf = new mainFrame(getDevice);
		mf.setTitle("Codename Breeze - "+getDevice);
		mf.setVisible(true);

		interp = new deviceInterp(getDevice);
		interp.start();
		mf.setInterp(interp);	
	}
	
	private void waitforList(AndroidDebugBridge newBridge) {
		int count = 0;
		
		while (newBridge.hasInitialDeviceList() == false) {
			try {
				Thread.sleep(100);
				count++;
			} catch (InterruptedException e) {
				// good to go.
			}
			// over 10 secs, throw exception
			if (count > 300) {
				throw new RuntimeException("Timeout getting device list!");
			}
		}
	}
	
	protected void close() throws UnknownHostException {
		
		System.out.println("Terminating and cleaning.");
		
		if(interp != null) {
			interp.close(); //terminates our interpreter
		}
		
		if(getDevice != null) {
			synchronized (getDevice) {
				dataParser.doParsing(InetAddress.getLocalHost().getHostName(),null,null,null,null,null,4);
				AndroidDebugBridge.terminate(); //terminates our device connection
			}
		}
		
		dataParser.doParsing(InetAddress.getLocalHost().getHostName(),null,null,null,null,null,2);
		
		System.out.println("Program terminated.");
		super.close();
	}

	public static void main(String args[]) throws IOException {
		boolean setLook = args.length == 0 || !args[0].equalsIgnoreCase("nonativelook");
		new Main(setLook);
	}

}
