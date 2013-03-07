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
 
 import java.io.IOException;
 import java.net.ServerSocket;
 import java.net.Socket;
 
 public class Main
 {
   static boolean isDebugging = false; //if we're debugging
   int port = 1337; //our listen port
 
   public Main(int port, boolean areweDebugging)
   {
    this.port = port;
    areweDebugging = false;
   }
 
   public void execute() throws IOException {
    ServerSocket ss = new ServerSocket(this.port); //starts a listen socket
     while (true) {
    	 
      final Socket s = ss.accept();
      
      if ((s == null) || (ss.isClosed()))
      {
    	  break;
      }
      
    if (isDebugging)
    {
    	System.out.println("A new client has connected ! ");
    }
    
      Thread t = new Thread() {
         public void run() {
        	 
           try {
          new handleClient(s); //starts our client thread
          
           } catch (Exception ex) {
           }
           
           try {
           s.close();
           }
           
           catch (Exception ex)
           {
           }
         }
       };
      t.start();
     }
   }
 
   public static void main(String[] args)
   {
   System.out.println("Client starting ...");
     try
     {
      if (args.length == 0){
         throw new RuntimeException("Need param >= 1");
      }
      
       int port = Integer.parseInt(args[0]);
       
       boolean isDebugging = (args.length >= 2) && (args[1].equals("areweDebugging"));
       
      new Main(port, isDebugging).execute();
     } catch (Exception ex) {
      //ex.printStackTrace();
     }
   }
 }
