package z.codename_breeze.gui;

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

import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JFormattedTextField;
import javax.swing.JList;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextField;
import javax.swing.ListModel;

import com.android.ddmlib.IDevice;

public class showDevices extends JDialog implements ActionListener {

	private static final String devHost = "127.0.0.1"; //sets our host
	private static final int devPort = 1337; //sets our port
	
	JList listDevices = new JList(); //declares our device list
	JScrollPane scrollDevices = new JScrollPane(listDevices); //allows us to scroll through device list
	JPanel panelButtons = new JPanel();
	JButton btnOk = new JButton("OK");
	JButton btnQuit = new JButton("Quit");

	boolean isCancelled = false; //if we clicked quit
	IDevice[] grabDevices; //declares our ADB device list
	
	public showDevices(IDevice[] grabDevices) {
		super();
		setModal(true);
		this.grabDevices = grabDevices; //gets devices
		initialize();
	}
	
	private void initialize() { //initializes our window
		setTitle("Choose a device:");
		listDevices.setListData(grabDevices);
		listDevices.setPreferredSize(new Dimension(400,300));
		if(grabDevices.length != 0)
			listDevices.setSelectedIndex(0);
		btnOk.setEnabled(!listDevices.isSelectionEmpty());
		
		panelButtons.setLayout(new FlowLayout(FlowLayout.RIGHT));
		panelButtons.add(btnOk,BorderLayout.CENTER);
		panelButtons.add(btnQuit,BorderLayout.SOUTH);
		
		JPanel panelBottom = new JPanel();
		panelBottom.setLayout(new BorderLayout());
		panelBottom.add(panelButtons,BorderLayout.SOUTH);
		
		setLayout(new BorderLayout());
		add(listDevices,BorderLayout.CENTER);
		add(panelBottom,BorderLayout.SOUTH);
		
		pack();
		setLocationRelativeTo(null);
		
		btnOk.addActionListener(this);
		btnQuit.addActionListener(this);
		listDevices.addMouseListener(new MouseAdapter() {

			@Override
			public void mouseClicked(MouseEvent e) {
				if(e.getClickCount() == 2) {
					int index = listDevices.locationToIndex(e.getPoint());
				     ListModel dlm = listDevices.getModel();
				     Object item = dlm.getElementAt(index);;
				     listDevices.ensureIndexIsVisible(index);
				     isCancelled = false;
				     setVisible(false);
				}
			}
			
		});
	}

	public IDevice getDevice() {
		if(isCancelled)
			return null;
		return (IDevice)listDevices.getSelectedValue();
	}

	public void actionPerformed(ActionEvent arg0) {
		isCancelled = arg0.getSource() == btnQuit;
		
		setVisible(false);
	}
}
