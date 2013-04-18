package z.codename_breeze.gui;

import java.awt.Component;
import java.awt.Container;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.InputStreamReader;

import javax.swing.JFileChooser;
import javax.swing.JOptionPane;
import javax.swing.JTextField;
import javax.swing.filechooser.FileFilter;

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

public class adbChooser {
	
	public static int returnVal;
	public static JFileChooser fc = new JFileChooser(System.getProperty("user.home"));
	
	public adbChooser() {
		
		fc.setAcceptAllFileFilterUsed(false);
		
		fc.setDialogTitle("Navigate to SDK/platform-tools path.");
		
		fc.setFileFilter(new fileType());
		
		disableInput(fc);
		
		returnVal = fc.showOpenDialog(null);
		
		if (returnVal != JFileChooser.APPROVE_OPTION) {
			JOptionPane.showMessageDialog(null, "You need to select ADB executable! \n Program terminated.", "Error", JOptionPane.ERROR_MESSAGE);
	 		System.exit(0);
	 		return;
		}
	}
	
	public static boolean checkADBpath() throws FileNotFoundException {
		
		File f2 = new File(System.getProperty("java.io.tmpdir") + "\\codename_breezeadbpath.txt");
		
		if (f2.exists()) {
			FileReader fr2 = new FileReader(f2);
			BufferedReader br2 = new BufferedReader(fr2);
			
			try {
			 ProcessBuilder p = new ProcessBuilder(br2.readLine(), "devices");
			 br2.close();
			 p.start();
			 return true;
			 
			} catch (Exception ex) {
				JOptionPane.showMessageDialog(null, "Invalid ADB.exe detected.", "Error", JOptionPane.ERROR_MESSAGE);
				return false;
			}
	}
		return false;
	}
	
	public boolean disableInput(Container c) {
		
	    Component[] multicmp = c.getComponents();
	    
	    for (Component singlecmp : multicmp) {
	        if (singlecmp instanceof JTextField) 
	        {
	            ((JTextField)singlecmp).setEnabled(false);
	            return true;
	        }
	        
	        if (singlecmp instanceof Container) 
	        {
	            if(disableInput((Container) singlecmp)) return true;
	        }
	    }
	    return false;
	}
	
	public static boolean isADBrunning() throws Exception {
		 
		 Process p = Runtime.getRuntime().exec("tasklist");
		 
		 BufferedReader bf = new BufferedReader(new InputStreamReader(p.getInputStream()));
		 String text;
		 
		 while ((text = bf.readLine()) != null) {
		  
		  if (text.contains("adb.exe")) {
		   return true;
		  }
		 }
		 return false;
		}
	
	class fileType extends FileFilter {
		
		public boolean accept(File f) {
			return f.isDirectory() || f.getName().toLowerCase().equals("adb.exe");
		}
		
		public String getDescription() {
			return "adb.exe";
		}
	}
	
	public static void main(String[] args) {
		new adbChooser();
	}
}
