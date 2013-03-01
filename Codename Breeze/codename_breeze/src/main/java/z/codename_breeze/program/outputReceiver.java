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

import java.io.IOException;
import java.io.OutputStream;

import com.android.ddmlib.IShellOutputReceiver;

public class outputReceiver implements IShellOutputReceiver {

	OutputStream out; //our output data receiver
	
	public outputReceiver(OutputStream os) {
		this.out = os;
	}
	
	public boolean isCancelled() {
		return false;
	}
	
	public void flush() {
	}
	
	public void addOutput(byte[] buf, int off, int len) {
		try {
			out.write(buf,off,len);
		} catch(IOException ex) {
			throw new RuntimeException(ex);
		}
	}

}
