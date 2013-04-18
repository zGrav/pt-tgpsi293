package z.codename_breeze.gui;

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
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Point;

import javax.swing.JPanel;

public class showScreen extends JPanel {

	public float hw = 1;
	double x;
	double y;
	boolean isLandscape;
	
	Dimension getSize = null;
	Image getImage = null;
	
	public showScreen() {
		this.setFocusable(true);
	}
	
	public void newImageHandler(Dimension getSize, Image getImage, boolean isLandscape) {
		this.isLandscape = isLandscape;
		this.getSize = getSize;
		this.getImage = getImage;
		repaint(); //repaints device screen window with new image.
	}
	
	protected void paintComponent(Graphics g) {
		if(getSize == null)
		{
			return;
		}
		
		if(getSize.height == 0)
			{
				return;
			}
			
		g.clearRect(0, 0, getWidth(), getHeight());
				
		double width = Math.min(getWidth(), getSize.width*getHeight()/getSize.height);
		
		hw = (float)width / (float)getSize.width;
		
		double height = width*getSize.height/getSize.width;
		
		x = (getWidth() - width) / 2;
		
		y = (getHeight() - height) / 2;
		
		g.drawImage(getImage, (int)x, (int)y, (int)width, (int)height, this);
	}
	
	
	public Point getPointer(Point p1) {
		Point p2 = new Point();
		
		p2.x = (int)((p1.x - x)/hw);
		
		p2.y = (int)((p1.y - y)/hw);
		
		return p2;
	}
	
}
