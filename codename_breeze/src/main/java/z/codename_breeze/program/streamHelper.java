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

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

public class streamHelper {

	public static void push(InputStream in, OutputStream out) { //pushes data to file
		try {
			while(true) {
				int data = in.read();
				if(data <= -1)
					break;
				out.write(data);
			}
		} catch(IOException io) {
			throw new RuntimeException(io);
		}
	}
	
	public static void pushData(Class c, String resource, File out) { //pushes data to device
		InputStream stream = c.getResourceAsStream(resource);
		if(stream == null)
			throw new RuntimeException("Cannot find resource "+resource);
		try {
			FileOutputStream fout = new FileOutputStream(out);
			push(stream,fout);
			fout.close();
			stream.close();
		} catch(Exception ex) {
			throw new RuntimeException(ex);
		}
	}
}
