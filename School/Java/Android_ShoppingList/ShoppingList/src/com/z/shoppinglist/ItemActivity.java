package com.z.shoppinglist;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.CheckBox;

public class ItemActivity extends Activity implements OnClickListener{
	
	Button test, purchase;
	CheckBox testcheck;
	double total;
	int itemcount;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_items);
		
test= (Button) findViewById(R.id.btntest);
purchase = (Button)findViewById(R.id.btnpurchase);
testcheck = (CheckBox)findViewById(R.id.checktest);

test.setOnClickListener(this);
purchase.setOnClickListener(this);

	}
	
	public void onClick(View v) {
		
		switch (v.getId()) {
		
		case R.id.btntest: 
		{
			
		if (testcheck.isChecked()) {
		total = total + 1.05;
		itemcount++;
		showSelectedAlert();
		}
		
		else {
			showNotSelectedAlert();
		}
		
		break;
		}
		
		case R.id.btnpurchase: 
		{
			if (total == 0.00) {
				showNothingAlert();
			}
		
			else {
		showAlert();
			}
			
			break;
		}
		
		}
		
	}
	
	public void showNothingAlert()
	{
		final android.app.AlertDialog.Builder alert = new android.app.AlertDialog.Builder(ItemActivity.this);
   	 	alert.setTitle("There are no items added for purchase.");
   	 	alert.setPositiveButton("ok", null);
   	 	alert.show();
	}
	
	public void showSelectedAlert()
	{
		final android.app.AlertDialog.Builder alert = new android.app.AlertDialog.Builder(ItemActivity.this);
   	 	alert.setTitle("Item added.");
   	 	alert.setPositiveButton("ok", null);
   	 	alert.show();
	}
	
	public void showNotSelectedAlert()
	{
		final android.app.AlertDialog.Builder alert = new android.app.AlertDialog.Builder(ItemActivity.this);
   	 	alert.setTitle("Item not selected. Please use the checkbox");
   	 	alert.setPositiveButton("ok", null);
   	 	alert.show();
	}
	
	public void showAlert()
	{
		final android.app.AlertDialog.Builder alert = new android.app.AlertDialog.Builder(ItemActivity.this);
   	 	alert.setTitle("Total: " + String.format("%.2f", total));
   	 	alert.setMessage("Item count: " + itemcount);
   	 	alert.setPositiveButton("ok", null);
   	 	alert.show();
	}
	
	
}
