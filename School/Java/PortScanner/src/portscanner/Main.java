/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package portscanner;

import java.net.*;
import java.util.Scanner;

/**
 * @platform Any
 * @author David
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws MalformedURLException, UnknownHostException {
        
        int startPort;
        int stopPort;
        String read;
        int r_port;
        
        Scanner keyboard = new Scanner(System.in);
        
        System.out.println("Insert a IP or hostname.");
        read = keyboard.next();
           
        if ( read.contains("://")) {
            InetAddress address = InetAddress.getByName(new URL(read).getHost());
            String getHost = address.getHostAddress().toString();
            String getIP = getHost.substring(getHost.indexOf("/")+1,getHost.length());
            read = getIP;
        }
        
        System.out.println("Insert start port:");
        r_port = keyboard.nextInt();
        startPort = r_port;
                
        System.out.println("Insert end port:");
        r_port = keyboard.nextInt();
        stopPort = r_port;
        
        for (int i = startPort; i <= stopPort; i++) {
            try {
                Socket isOpen;
                
                isOpen = new Socket(read, i);
                
                System.out.println("Port is open: " + i);
                
                isOpen.close();
            }
            catch (Exception e) {
                System.out.println("Port is not open: " + i);
            }
        }
    }
}
