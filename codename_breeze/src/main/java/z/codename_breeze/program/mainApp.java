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

import java.lang.Thread.UncaughtExceptionHandler;
import java.net.UnknownHostException;

public class mainApp {

	public mainApp() {
		Runtime.getRuntime().addShutdownHook(new Thread() {
			public void run() {
				try {
					close();
				} catch (UnknownHostException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
		});
		Thread.setDefaultUncaughtExceptionHandler(new UncaughtExceptionHandler() {
			public void uncaughtException(Thread t, Throwable ex) {
				try {
					handleException(t,ex);
				} catch(Exception ex2) {
					ex2.printStackTrace();
				}
			}
		});
	}

	protected void handleException(Thread thread, Throwable ex) {
	}
	
	protected void close() throws UnknownHostException {
		
	}
	
}
