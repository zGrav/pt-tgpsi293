package com.z.calc;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends Activity implements OnClickListener {
	EditText firstnum, secondnum;
	int val1, val2, res;
	Button plus, minus, div, mul;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		firstnum = (EditText) findViewById(R.id.firstnumEdit);
		secondnum = (EditText) findViewById(R.id.secondnumEdit);
		plus = (Button) findViewById(R.id.plusBtn);
		minus = (Button) findViewById(R.id.minusBtn);
		div = (Button) findViewById(R.id.divBtn);
		mul = (Button) findViewById(R.id.mulBtn);
		
		plus.setOnClickListener(this);
		minus.setOnClickListener(this);
		div.setOnClickListener(this);
		mul.setOnClickListener(this);
	
	}
	
	public void showAlert()
	{
		final android.app.AlertDialog.Builder alert = new android.app.AlertDialog.Builder(MainActivity.this);
   	 	alert.setTitle("Result: " + res);
   	 	alert.setPositiveButton("ok", null);
   	 	alert.show();
	}
	
	public void onClick(View v) {
		
		val1 = Integer.parseInt(firstnum.getText().toString());
        val2 = Integer.parseInt(secondnum.getText().toString());
        
	      
        switch (v.getId()) {
	         case R.id.plusBtn: 
	        	 res = val1 + val2;
	        	 showAlert();
	          break;
	          
	         case R.id.minusBtn:
		          res = val1 - val2;
		          showAlert();
	          break;
	          
	         case R.id.divBtn:
		          res = val1 / val2;
		        	 showAlert();
	        	 break;
	        	 
	         case R.id.mulBtn:
		          res = val1 * val2;
		        	 showAlert();
	        	 break;
	      
	         default:
	        	 final android.app.AlertDialog.Builder alert = new android.app.AlertDialog.Builder(MainActivity.this);
	        	 alert.setTitle("Invalid operation detected.");
	        	 alert.setPositiveButton("ok", null);
	        	 alert.show();
	        	 break;
	      }
	      
	      }

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.activity_main, menu);
		return true;
	}

}
