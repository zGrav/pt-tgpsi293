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
import java.io.PrintWriter;
import java.io.StringWriter;

import javax.swing.JDialog;
import javax.swing.JTextArea;

public class showError extends JDialog {

	public showError(Throwable ex) {
		getRootPane().setLayout(new BorderLayout());
		JTextArea l = new JTextArea();
		StringWriter w = new StringWriter();
		
		if(ex.getClass() == RuntimeException.class && ex.getCause() != null) 
		{
			ex = ex.getCause(); 
		}
		
		ex.printStackTrace(new PrintWriter(w));
		l.setText(w.toString());
		getRootPane().add(l,BorderLayout.CENTER);
		pack();
		
		setLocationRelativeTo(null);
		setAlwaysOnTop(true);
		setAlwaysOnTop(false);
	}
	
}
