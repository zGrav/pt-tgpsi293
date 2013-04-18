 package z.codename_breezeclient;
 
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
 
 import android.os.IBinder;
 import android.os.RemoteException;
 import android.os.ServiceManager;
 import android.os.SystemClock;
 import android.view.IWindowManager;
 import android.view.IWindowManager.Stub;
 import android.view.KeyEvent;
 import android.view.MotionEvent;
 import java.io.BufferedReader;
 import java.io.IOException;
 import java.io.InputStream;
 import java.io.InputStreamReader;
 import java.io.OutputStream;
 import java.io.PrintStream;
 import java.net.Socket;
 
 public class handleClient
 {
   IBinder binder = ServiceManager.getService("window");
  final IWindowManager wmanager = IWindowManager.Stub.asInterface(this.binder);
   Socket mainSocket;
 
   public handleClient(Socket s) throws IOException, RemoteException
   {
    this.mainSocket = s; //our client socket
    
     Thread frameBuffer = new Thread() { //our image thread
       public void run() {
        handleClient.this.startframeBuffer();
       }
     };
     
     Thread cmdHandler = new Thread() { //our cmd thread
       public void run() {
         handleClient.this.interpCmd();
       }
     };
     
     frameBuffer.start(); //starts image thread
     cmdHandler.start(); //starts cmd thread
     
     try
     {
      frameBuffer.join();
      cmdHandler.join();
     } catch (InterruptedException e) {
    	 
     }
   }
 
   private void startframeBuffer() { //our image method
     try {
    Process getBuffer = Runtime.getRuntime().exec("/system/bin/cat /dev/graphics/fb0");
    
      InputStream in = getBuffer.getInputStream();
      
      System.out.println("Fetching screen");
     
      OutputStream out = this.mainSocket.getOutputStream();
      
     byte[] buff = new byte[344064];
     
       while (true)
       {
         int data = in.read(buff);
         
         if (data < -1) 
         {
           break;
         }
         
         out.write(buff, 0, data);
         
        Thread.sleep(10L);
       }
       
       in.close();
       
      System.out.println("End thread");
     }
     catch (Exception ex) {
     }
   }
 
   private void interpCmd() { //our cmd method
     try {
       InputStream in = this.mainSocket.getInputStream();
       
       BufferedReader read = new BufferedReader(new InputStreamReader(in));
       
       while (true) {
    	   
        String text = read.readLine();
        
         if (text == null) 
         {
         read.close();
         
           this.mainSocket.close();
           
          break;
         }
         
        if (Main.isDebugging) 
        {
          System.out.println("Received : " + text);
        }
        
         try
         {
        cmdParser(text);
         } catch (Exception ex) {
         }
       }
     } catch (Exception ex) {
     }
   }
 
   private void cmdParser(String text) throws RemoteException { //our cmd interp
	   
     String[] parameters = text.split("/");
     String type = parameters[0];
 
    if (type.equals("quit")) {
       System.exit(0);
      return;
     }
 
     if (type.equals("pointer")) {
       this.wmanager.injectPointerEvent(decodeMotionEvent(parameters), true);
       return;
     }
    if (type.equals("key")) {
       this.wmanager.injectKeyEvent(decodeKeyEvent(parameters), false);
       return;
     }
     if (type.equals("trackball")) {
      this.wmanager.injectTrackballEvent(decodeMotionEvent(parameters), false);
      return;
     }
 
     throw new RuntimeException("Invalid command type : " + type);
   }
 
   private static MotionEvent decodeMotionEvent(String[] args) //our mouse interp
   {
     int action = Integer.parseInt(args[3]);
     
     float x = Float.parseFloat(args[4]);
    
     float y = Float.parseFloat(args[5]);
     
     int state = Integer.parseInt(args[6]);
     
    return MotionEvent.obtain(SystemClock.uptimeMillis(), SystemClock.uptimeMillis(), action, x, y, state);
 }
 
private static KeyEvent decodeKeyEvent(String[] args) //our key interp
   {
     int action = Integer.parseInt(args[1]);
     
     int code = Integer.parseInt(args[2]);
   
    return new KeyEvent(action, code);
  }
 }
