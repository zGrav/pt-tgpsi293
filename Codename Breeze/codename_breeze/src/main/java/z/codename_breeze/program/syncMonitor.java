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

import com.android.ddmlib.SyncService.ISyncProgressMonitor; //our sync monitor

public class syncMonitor implements ISyncProgressMonitor {

	public void advance(int arg0) {
	}

	public boolean isCanceled() {
		return false;
	}

	public void start(int arg0) {
	}

	public void startSubTask(String arg0) {
		
	}

	public void stop() {
	}

}
