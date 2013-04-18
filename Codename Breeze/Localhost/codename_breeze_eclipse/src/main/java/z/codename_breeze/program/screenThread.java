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

import java.awt.Dimension;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.swing.SwingUtilities;


import com.android.ddmlib.IDevice;
import com.android.ddmlib.RawImage;

public class screenThread extends Thread {

	public static final String API = "12"; //honeycomb
	
	private BufferedImage getImage;
	private Dimension getSize;
	private IDevice getDevice;
	private qtStream qStream = null;
	private boolean isLandscape = false;
	private boolean isHoneycomb = false;
	private screenCap screenlistener = null; //screen capture

	public screenCap getListener() {
		return screenlistener;
	}

	public void newListener(screenCap screenlistener) {
		this.screenlistener = screenlistener;
	}

	public interface screenCap { //returns our new image
		public void  newImageHandler(Dimension getSize, BufferedImage getImage, boolean isLandscape);
	}

	public screenThread(IDevice device) {
		super("Screen capture");
		this.getDevice = device;
		getImage = null;
		getSize = new Dimension();
		
		if(API.equals(device.getProperty(IDevice.PROP_BUILD_API_LEVEL))){
			switchOrientation(); //switches orientation if is a honeycomb device
			isHoneycomb = true; //our honeycomb checker
		}
	}

	public Dimension getPreferredSize() {
		return getSize; //gets image size
	}

	public void run() { //runs our screen capture
		do {
			try {
				boolean ok = grabImage();
				if(!ok)
					break;
			} catch (java.nio.channels.ClosedByInterruptException closedex) {
				break;
			} catch (Exception e) {
				System.err.println((new StringBuilder()).append(
						"Exception: ").append(e.toString()).toString());
			}

		} while (true);
	}


	private boolean grabImage() throws IOException{ //fetches our screen
		if (getDevice == null) {
			// not ready
			
			try {
				Thread.sleep(100);
			} catch (InterruptedException e) {
				return false;
			}
			return true;
		}

		RawImage rawImage = null;
		
		synchronized (getDevice) {
			rawImage = getDevice.getScreenshot();
		}
		
		if (rawImage != null) {
			redrawImage(rawImage);
		} else {
			System.out.println("Screenshot failed.");
		}

		return true;
	}
	
	public void switchOrientation() { //switches our orientation
		isLandscape = !isLandscape;
	}

	public void redrawImage(RawImage rawImage) { //displays our image
		
		int width2 = isLandscape ? rawImage.height : rawImage.width;
		int height2 = isLandscape ? rawImage.width : rawImage.height;
		
		if (getImage == null) {
			getImage = new BufferedImage(width2, height2, BufferedImage.TYPE_INT_RGB);
			getSize.setSize(getImage.getWidth(), getImage.getHeight());
		} else {
			if (getImage.getHeight() != height2 || getImage.getWidth() != width2) {
				getImage = new BufferedImage(width2, height2, BufferedImage.TYPE_INT_RGB);
				getSize.setSize(getImage.getWidth(), getImage.getHeight());
			}
		}
		
		int index = 0;
		int indexInc = rawImage.bpp >> 3;
		
		if(isHoneycomb)
		{ //special method for honeycomb devices

			for (int y = (rawImage.height - 1); y > -1; y--) {
				
				for (int x = (rawImage.width - 1); x > -1; x--, index += indexInc) {
					
					int value = rawImage.getARGB(index);
					
					if (isLandscape)
					{
						getImage.setRGB(y, rawImage.width - x - 1, value);
					}
					else
					{
						getImage.setRGB(x, y, value);
					}
				}
			}
		} else { //regular devices
			for (int y = 0; y < rawImage.height; y++) {
				
				for (int x = 0; x < rawImage.width; x++, index += indexInc) {
					
					int value = rawImage.getARGB(index);
					
					if (isLandscape)
					{
						getImage.setRGB(y, rawImage.width - x - 1, value);
					}
						else 
					{
						getImage.setRGB(x, y, value);
					}
					}
			}
		}
		

		try {
			if (qStream != null)
			{
				qStream.writeFrame(getImage, 10);
			}
			} catch (IOException e) {
			throw new RuntimeException(e);
		}

		if (screenlistener != null) {
			SwingUtilities.invokeLater(new Runnable() {

				public void run() {
					screenlistener.newImageHandler(getSize, getImage, isLandscape);
				}
			});
		}
	}

}
