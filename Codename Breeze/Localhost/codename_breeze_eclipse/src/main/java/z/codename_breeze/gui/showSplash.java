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

import java.awt.BorderLayout;

import javax.swing.BorderFactory;
import javax.swing.ImageIcon;
import javax.swing.JLabel;
import javax.swing.JWindow;

public class showSplash extends JWindow {
	JLabel label = new JLabel("Initializing...", new ImageIcon(mainFrame.class.getResource("/icon.png")),(int)JLabel.CENTER_ALIGNMENT);

	public showSplash(String text) {
		initialize();
		setText(text);
	}
	
	public void setText(String text) {
		label.setText(text);
		pack();
		setLocationRelativeTo(null);
	}
	
	private void initialize() {
		setLayout(new BorderLayout());
		label.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));
		add(label,BorderLayout.CENTER);
	}
	
}
