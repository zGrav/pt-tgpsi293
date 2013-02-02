package com.z.shoppinglist;

import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class MainActivity extends Activity implements OnClickListener {

	Button btnItems, btnExit;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		btnExit = (Button) findViewById(R.id.exitbtn);
		btnItems = (Button) findViewById(R.id.addbtn);
		
		btnExit.setOnClickListener(this);
		btnItems.setOnClickListener(this);
	}
	
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.exitbtn:
			finish();
			break;
		case R.id.addbtn:
            Intent intentApp = new Intent(MainActivity.this, 
                    ItemActivity.class);

            MainActivity.this.startActivity(intentApp);
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
