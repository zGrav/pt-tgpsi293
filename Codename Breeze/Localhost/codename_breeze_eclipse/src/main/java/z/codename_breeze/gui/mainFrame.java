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
import java.awt.KeyEventDispatcher;
import java.awt.KeyboardFocusManager;
import java.awt.Point;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseWheelEvent;
import java.awt.image.BufferedImage;
import java.io.IOException;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JScrollPane;
import javax.swing.JToolBar;

import z.codename_breeze.program.getDevice;
import z.codename_breeze.program.keyMap;
import z.codename_breeze.program.motionMap;
import z.codename_breeze.program.deviceInterp;
import z.codename_breeze.program.keyConverter;
import z.codename_breeze.program.screenThread.screenCap;
import z.codename_breeze.gui.showDeviceInfo;

import com.android.ddmlib.IDevice;

public class mainFrame extends JFrame {
	
	private showScreen devScreen = new showScreen(); //declares our device screen
	private JToolBar topBar = new JToolBar(); //declares our top menu bar
	private JButton btnAbout = new JButton("About"); //top menu button
	private JButton btnShoutouts = new JButton("Shoutouts"); //top menu button
	private JButton btndevInfo = new JButton("Device Info"); //top menu button
	
	private JToolBar hardKeys = new JToolBar(); //declares our "home, back" buttons
	JScrollPane scroll;

	private JButton btnHome = new JButton("Home");
	private JButton btnMenu = new JButton("Menu");
	private JButton btnBack = new JButton("Back");
	private JButton btnSearch = new JButton("Search");
	private JButton btnPhoneOn = new JButton("Call");
	private JButton btnPhoneOff = new JButton("End call");
	private JButton btnVolUp = new JButton("Vol+");
	private JButton btnVolDown = new JButton("Vol-");

	public class keyListener implements ActionListener { //reads our key input and passes to interpreter

		int key;

		public keyListener(int key) {
			this.key = key;
		}
		
		public void actionPerformed(ActionEvent e) {
			if (interp == null)
				return;
			interp.interpKey(keyMap.ACTION_DOWN, key); //sends our key input to device
			interp.interpKey(keyMap.ACTION_UP, key);
		}
	}
	
	private IDevice getDevice; //declares our device
	private deviceInterp interp; //declares our device interpreter
	private Dimension oldDimension = null; //declares our old Image Dimension
	
	public void setInterp(deviceInterp interp) {
		this.interp = interp; //sets our interpreter
		
		interp.screen.newListener(new screenCap() { //sets our Screen Listener

			public void newImageHandler(Dimension getSize, BufferedImage getImage, boolean getLandscape) {
				
				if(oldDimension == null ||
						!getSize.equals(oldDimension)) {
					scroll.setPreferredSize(getSize);
					mainFrame.this.pack();
					oldDimension = getSize;
				}
				devScreen.newImageHandler(getSize, getImage, getLandscape); //gets our new image
			}
		});
	}

	public mainFrame(IDevice getDevice) throws IOException {
		this.getDevice = getDevice; //gets our device
		
		initialize(); //initializes our window
		
		KeyboardFocusManager.getCurrentKeyboardFocusManager().addKeyEventDispatcher(new KeyEventDispatcher() {

					public boolean dispatchKeyEvent(KeyEvent e) { //reads our input and interps it
						if (!mainFrame.this.isActive()) 
						{
							return false; 
						}
						
						if (interp == null) 
						{
							return false;
						}
						
						if (e.getID() == KeyEvent.KEY_PRESSED) {
							int code = keyConverter.getKeyCode(e);
							
							interp.interpKey(keyMap.ACTION_DOWN,
									code);
						}
						
						if (e.getID() == KeyEvent.KEY_RELEASED) {
							int code = keyConverter.getKeyCode(e);
							
							interp.interpKey(keyMap.ACTION_UP, code);
						}
						return false;
					}
				});
	}

	public void initialize() throws IOException {
		topBar.setFocusable(false);
		btnAbout.setFocusable(false);
		btnShoutouts.setFocusable(false);
		btndevInfo.setFocusable(false);
		btnHome.setFocusable(false);
		btnMenu.setFocusable(false);
		btnVolUp.setFocusable(false);
		btnVolDown.setFocusable(false);
		btnBack.setFocusable(false);
		btnSearch.setFocusable(false);
		btnPhoneOn.setFocusable(false);
		btnPhoneOff.setFocusable(false);

		btnHome.addActionListener(new keyListener(keyMap.KEYCODE_HOME));
		btnMenu.addActionListener(new keyListener(keyMap.KEYCODE_MENU));
		btnVolUp.addActionListener(new keyListener(keyMap.KEYCODE_VOLUME_UP));
		btnVolDown.addActionListener(new keyListener(keyMap.KEYCODE_VOLUME_DOWN));
		btnBack.addActionListener(new keyListener(keyMap.KEYCODE_BACK));
		btnSearch.addActionListener(new keyListener(keyMap.KEYCODE_SEARCH));
		btnPhoneOn.addActionListener(new keyListener(keyMap.KEYCODE_CALL));
		btnPhoneOff.addActionListener(new keyListener(keyMap.KEYCODE_ENDCALL));

		hardKeys.add(btnHome);
		hardKeys.add(btnMenu);
		hardKeys.add(btnBack);
		hardKeys.add(btnSearch);
		hardKeys.add(btnPhoneOn);
		hardKeys.add(btnPhoneOff);
		hardKeys.add(btnVolUp);
		hardKeys.add(btnVolDown);
		
		btndevInfo.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				showDeviceInfo info = new showDeviceInfo(getDevice);
			}
		});
		
		topBar.add(btndevInfo);
		
		btnShoutouts.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				JOptionPane.showMessageDialog(null, "Shoutouts to: \n Classmates and teachers that watched this project grow \n Family that gave me support \n My girlfriend for putting up with me <3 \n Some online mates that tested this since 0.1", "Codename Breeze - Shoutouts", JOptionPane.INFORMATION_MESSAGE);
			}
		});
		
		topBar.add(btnShoutouts);
		
		btnAbout.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				JOptionPane.showMessageDialog(null, "Version 0.9 - revision 7 - build date: 17/03/2013 \n For bug reports or ideas please contact via email: zgrav@null.net \n Thank you for trying out this software.", "Codename Breeze - About", JOptionPane.INFORMATION_MESSAGE);
			}
		});
		
		topBar.add(btnAbout);

		setIconImage(Toolkit.getDefaultToolkit().getImage(getClass().getResource("/mainicon.png")));
		setDefaultCloseOperation(3);
		setLayout(new BorderLayout());
		
		add(topBar, BorderLayout.NORTH);
		
		add(hardKeys, BorderLayout.SOUTH);
		
		scroll = new JScrollPane(devScreen);
		
		add(scroll, BorderLayout.CENTER);

		scroll.setPreferredSize(new Dimension(800, 600));
		
		pack();
		
		setLocationRelativeTo(null);

		MouseAdapter mAdapter = new MouseAdapter() { //initializes our mouse reader and interps it

			@Override
			public void mouseDragged(MouseEvent arg0) {
				if (interp == null)
					return;
				try {
					Point p2 = devScreen.getPointer(arg0.getPoint());
					interp.interpMouse(motionMap.ACTION_MOVE, p2.x, p2.y);
				} catch (IOException e) {
					throw new RuntimeException(e);
				}
			}

			@Override
			public void mousePressed(MouseEvent arg0) {
				if (interp == null)
					return;
				try {
					Point p2 = devScreen.getPointer(arg0.getPoint());
					interp.interpMouse(motionMap.ACTION_DOWN, p2.x, p2.y);
				} catch (IOException e) {
					throw new RuntimeException(e);
				}
			}

			@Override
			public void mouseReleased(MouseEvent arg0) {
				if (interp == null)
					return;
				try {
					if (arg0.getButton() == MouseEvent.BUTTON3) {
						interp.screen.switchOrientation();
						arg0.consume();
						return;
					}
					Point p2 = devScreen.getPointer(arg0.getPoint());
					interp.interpMouse(motionMap.ACTION_UP, p2.x, p2.y);
				} catch (IOException e) {
					throw new RuntimeException(e);
				}
			}

			@Override
			public void mouseWheelMoved(MouseWheelEvent arg0) {
				if (interp == null)
					return;
				try {
					interp.interpTrackball(arg0.getWheelRotation() < 0 ? -1f
							: 1f);
				} catch (IOException e) {
					throw new RuntimeException(e);
				}
			}
		};

		devScreen.addMouseMotionListener(mAdapter); //sets our mouse listener
		devScreen.addMouseListener(mAdapter);
		devScreen.addMouseWheelListener(mAdapter);
	}
}
