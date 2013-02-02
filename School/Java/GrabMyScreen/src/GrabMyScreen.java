/* 
TBD:
path - done
filename - done (user input)
warning if there's a jpg with same name (overwrite/delete) - done

IMPORTANT:
grab from screen - done
write to file - done
*/

import java.util.Properties;
import java.util.Scanner;
import java.io.*;
import java.awt.*;
import java.awt.image.*;
import javax.imageio.ImageIO;

public class GrabMyScreen {

	/**
	 * @param args
	 */

	static int optionchoose; // main() menu reader
	
	// setSaveLocation() variables
	static Properties OSprops = System.getProperties(); // used to get System Properties
	static String username = OSprops.getProperty("user.name"); // used to get current User
	static String OSname = OSprops.getProperty("os.name"); // used to get current OS name
	static String path; // save file path
	// end setSaveLocation() variables
	
	// ScreenshotManagement() variables
	static BufferedImage dat_image; // used to capture image
	static Scanner readscreen; // reads screen w, h and passes to rectangle on case 2.
	// end ScreenshotManagement() variables
	
	// FileManagement() variables
	static String filename; // file name (user input)
	static Scanner filenameread; // used to read filename from user
	static Scanner overwriteopt; // used for overwrite switch
	static int overwrite; // used for overwrite warning
	// FileManagement() variables
	
	// ScreenshotDump() variables
	static Toolkit dat_toolkit;  // ton of GUI related options (?)
	static Dimension dat_size; // width, height of screen
	static Rectangle screen_rect; // receives dat_size and makes a "rectangle"
	static Robot grabme; // screen grabber (seems useful.)
	// end ScreenshotDump() variables
	
	static void setSaveLocation() // sets the location for the jpg file to be stored
	{
		if (!OSname.contains("Windows"))
		{
			System.out.println("");
			System.out.println("WARNING: YOUR OPERATING SYSTEM IS NOT SUPPORTED BY THIS PROGRAM.");
			System.out.println("PLEASE RUN THIS PROGRAM ON A WINDOWS ENVIRONMENT");
			System.out.println("");
		}
		else {
			path = "C:\\Users\\" + username + "\\Desktop\\";
			if (OSname.equals("Windows XP")) {
				path = "C:\\"; // used to avoid errors due to Windows XP regional settings having different paths for Desktop, user folder, etc.
			}
		}
	}
	
	static void ScreenshotDump() // Passes screen dimensions and creates Screenshot Dump "Robot"
	{
		dat_toolkit = Toolkit.getDefaultToolkit();
		dat_size = dat_toolkit.getScreenSize();
		screen_rect = new Rectangle(dat_size);
		try {
			grabme = new Robot();
		} catch (AWTException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	static void ScreenshotManagement() // Dumps screenshot from memory to file according to the chosen option 
	{
		switch (optionchoose) {
		
		//fullscreen
		case 1:
			
			ScreenshotDump();
			
		    dat_image = grabme.createScreenCapture(screen_rect);
		    
			FileManagement();

			filenameread.close();
			
		break;
		
		// specified region of screen (determined by w, h)
		
		case 2:
			
			int w, h; // width, height
			
			Rectangle rectwh;
			
			readscreen = new Scanner(System.in);
			
			System.out.println("");
			System.out.println("Input width.");
			w = readscreen.nextInt();
			
			System.out.println("");
			System.out.println("Input height.");
			h = readscreen.nextInt();
			
			ScreenshotDump();
			
			rectwh = new Rectangle(w,h);
			
		   dat_image = grabme.createScreenCapture(rectwh);
			
		   FileManagement();
			
			filenameread.close();
			readscreen.close();
			
			break;
			
			// active window w/ sleep to choose
			
		case 3:
		
			System.out.println("");
			System.out.println("Program halted for 5 seconds so user can choose active window.");
			System.out.println("");
			
			try {
				Thread.sleep(5000);
			} catch (InterruptedException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
			
			ScreenshotDump();
			
				dat_image = grabme.createScreenCapture(screen_rect);
				
				FileManagement();
				
				filenameread.close();
				
				break;
	}
	}

	static void FileManagement() // Handles file writing/overwriting
	{
		System.out.println("");
		System.out.println("Please input a filename for image: (no need to add .jpg extension on end of filename)");
		System.out.println("");
		
		filenameread = new Scanner(System.in);
		
		filename = filenameread.next();
		
		File searchforfile = new File(path + filename + ".jpg"); // checks if file exists
		
		if (!searchforfile.exists())
		{
			
		try {
			ImageIO.write(dat_image, "jpg", new File(path + filename + ".jpg"));
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		}
		
		else
		{
			System.out.println("");
			System.out.println("File exists with the same name.");
			System.out.println("Do you want to overwrite it? (1 for Y, 2 for N)");
			System.out.println("");
			
			overwriteopt = new Scanner(System.in);
			
			overwrite = overwriteopt.nextInt();
			
			switch (overwrite)
			{
			case 1: 
				try {
				ImageIO.write(dat_image, "jpg", new File(path + filename + ".jpg"));
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			break;
			
			case 2: main(null);
			break;
			
			default: System.out.println("Invalid option.");
			break;
			
			}
			overwriteopt.close();
		}
		filenameread.close();
	}
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		setSaveLocation();
		
		System.out.println("Welcome to Grab My Screen.");
		System.out.println("");
		System.out.println("This program is in beta phase.");
		System.out.println("");

		// menu
		System.out.println("1 - Take screenshot");
		System.out.println("2 - Take screenshot of specified area");
		System.out.println("3 - Take screenshot of active window");
		System.out.println("4 - Info");
		System.out.println("5 - Exit");
		System.out.println("");

		Scanner option = new Scanner(System.in);
		
		optionchoose = option.nextInt();
		
		switch (optionchoose) {
		
		case 1: ScreenshotManagement();
		break;
		
		case 2: ScreenshotManagement();
		break;
		
		case 3: ScreenshotManagement();
		break;
		
		case 4:
			System.out.println(""); 
			System.out.println("This Java project was developed for class presentation.");
			try {
				Thread.sleep(250);
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			System.out.println("");
			System.out.println("Developed by: David 'z' Samuel and Diogo 'EvilMonstah' Alexandre");
			System.out.println("");
			
		main(args);
		break;
		
		case 5: System.exit(0);
		break;
		
		default: 
			System.out.println("");
			System.out.println("Invalid option");
			System.out.println(""); 
		main(args);
		break;
		}
		
		option.close();
	}

}
