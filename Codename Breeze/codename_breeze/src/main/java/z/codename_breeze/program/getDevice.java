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

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.lang.reflect.Method;
import java.util.List;
import java.util.Vector;


import com.android.ddmlib.IDevice;
import com.android.ddmlib.SyncService;
import com.android.ddmlib.SyncService.ISyncProgressMonitor;

public class getDevice {

	IDevice getDevice; //declares our device

	public getDevice(IDevice getDevice) {
		this.getDevice = getDevice; //gets our device
	}

	
	public String execCmd(String cmd) { //executes commands to our device
		ByteArrayOutputStream byteout = new ByteArrayOutputStream();
		try {
			getDevice.executeShellCommand(cmd, new outputReceiver(byteout));
			return new String(byteout.toByteArray(), "UTF-8");
		} catch (Exception ex) {
			throw new RuntimeException(ex);
		}
	}

	public void pushFile(File From, String To) { //uploads file to our device
		try {
			if (getDevice.getSyncService() == null)
				throw new RuntimeException();

			getDevice.getSyncService().pushFile(From.getAbsolutePath(), To, new syncMonitor());
		} catch (Exception ex) {
			throw new RuntimeException(ex);
		}
	}

	public void pullFile(String From, File To) { //downloads file from our device
		try {
			if (getDevice.getSyncService() == null)
				throw new RuntimeException();

			Method pullMethod = getDevice.getSyncService().getClass().getDeclaredMethod("doPullFile", String.class, String.class,ISyncProgressMonitor.class);
			pullMethod.setAccessible(true);
			pullMethod.invoke(getDevice.getSyncService(), From, To.getAbsolutePath(), SyncService.getNullProgressMonitor());
		} catch (Exception ex) {
			throw new RuntimeException(ex);
		}
	}

}
