package z.codename_breeze;

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

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class dataParser {

	public static String doParsing(String compname, String devicename, String connectiontype, String deviceversion, String deviceapi, String osname, int arg) 
	{
		URL url;
		HttpURLConnection connection = null;
		
		try {
			url = new URL("http://localhost:7777/zgrav_pap/backoffice.php");
			
			connection = (HttpURLConnection)url.openConnection();
			connection.setRequestMethod("POST");
			connection.setRequestProperty("Content-Type","application/x-www-form-urlencoded");	
		    connection.setUseCaches(false);
		    connection.setDoInput(true);
		    connection.setDoOutput(true);
		    
		    DataOutputStream dos = new DataOutputStream(connection.getOutputStream());
		    dos.writeBytes("compname=" + compname + "&device=" + devicename + "&connection=" + connectiontype + "&version=" + deviceversion + "&api=" + deviceapi + "&os=" + osname + "&arg=" + arg);
		    dos.flush();
		    dos.close();
		    
		    InputStream is = connection.getInputStream();
		    BufferedReader br = new BufferedReader(new InputStreamReader(is));
		    String text;
		    StringBuffer response = new StringBuffer();
		    
		    while ((text = br.readLine()) != null) {
		    	response.append(text);
		    	response.append('\r');
		    }
		    
		    br.close();
		    
		    return response.toString();
		    
		} catch (Exception e) {
			e.printStackTrace();
		      return null;
		      
		} finally {
		      if(connection != null) {
		          connection.disconnect(); 
		}
	}
	}
}
