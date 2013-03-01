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

import java.io.PrintWriter;
import java.io.StringWriter;
import java.net.UnknownHostException;

import javax.swing.SwingUtilities;
import javax.swing.UIManager;

import z.codename_breeze.gui.showError;

public class swingApp extends mainApp {

	showError jd = null;

	public swingApp(boolean nativeLook) {
		try {
			if(nativeLook)
				UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
		} catch(Exception ex) {
			throw new RuntimeException(ex);
		}
	}
	
	@Override
	protected void close() throws UnknownHostException {
		super.close();
	}

	@Override
	protected void handleException(Thread thread, Throwable ex) {
		try {
			StringWriter sw = new StringWriter();
			ex.printStackTrace(new PrintWriter(sw));
			if(sw.toString().contains("SynthTreeUI"))
				return;
			ex.printStackTrace(System.err);
			if(jd != null && jd.isVisible())
				return;
			jd = new showError(ex);
			SwingUtilities.invokeLater(new Runnable() {
				
				public void run() {
					jd.setVisible(true);
					
				}
			});
		} catch(Exception ex2) {
			
		}
	}
	
	

}
