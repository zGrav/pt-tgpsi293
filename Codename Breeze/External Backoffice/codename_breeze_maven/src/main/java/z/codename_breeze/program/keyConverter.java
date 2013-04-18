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

import java.awt.event.KeyEvent;

public class keyConverter {

	public static int getKeyCode(KeyEvent e) { //our keycode converter
		
		char c = e.getKeyChar();
		int code = 0;
		
		if(Character.isLetter(c)) 
		{		
			code = keyMap.KEYCODE_A + (Character.toLowerCase(c)-'a');
		}
		
		if(Character.isDigit(c)) 
		{
			code = keyMap.KEYCODE_0 + (c-'0');
		}
		
		if(c == '\n') 
		{
			code = keyMap.KEYCODE_ENTER;
		}
		
		if(c == ' ')
		{
			code = keyMap.KEYCODE_SPACE; 
		}
		
		if(c == '\b')
		{
			code = keyMap.KEYCODE_DEL; 
		}
		
		if(c == '\t')
		{
			code = keyMap.KEYCODE_TAB; 
		}
		
		if(c == '/')
		{
			code = keyMap.KEYCODE_SLASH; 
		}
		if(c == '\\')
		{
			code = keyMap.KEYCODE_BACKSLASH; 
		}
		
		if(c == ',')
		{
			code = keyMap.KEYCODE_COMMA; 
		}
		
		if(c == ';')
		{
			code = keyMap.KEYCODE_SEMICOLON; 
		}
		
		if(c == '.')
		{
			code = keyMap.KEYCODE_PERIOD; 
		}
		
		if(c == '*')
		{
			code = keyMap.KEYCODE_STAR; 
		}
		
		if(c == '+')
		{
			code = keyMap.KEYCODE_PLUS; 
		}
		
		if(c == '-')
		{
			code = keyMap.KEYCODE_MINUS; 
		}
		
		if(c == '=')
		{
			code = keyMap.KEYCODE_EQUALS; 
		}
		
		if(e.getKeyCode() == KeyEvent.VK_HOME)
		{
			code = keyMap.KEYCODE_HOME; 
		}
		
		if(e.getKeyCode() == KeyEvent.VK_PAGE_UP)
		{
			code = keyMap.KEYCODE_MENU; 
		}
		
		if(e.getKeyCode() == KeyEvent.VK_PAGE_DOWN)
		{
			code = keyMap.KEYCODE_STAR; 
		}
		
		if(e.getKeyCode() == KeyEvent.VK_ESCAPE)
		{
			code = keyMap.KEYCODE_BACK; 
		}

		if(e.getKeyCode() == KeyEvent.VK_F3)
		{
			code = keyMap.KEYCODE_CALL; 
		}
		
		if(e.getKeyCode() == KeyEvent.VK_F4)
		{
			code = keyMap.KEYCODE_ENDCALL; 
		}

		if(e.getKeyCode() == KeyEvent.VK_F5)
		{
			code = keyMap.KEYCODE_SEARCH; 
		}

		if(e.getKeyCode() == KeyEvent.VK_F7)
		{
			code = keyMap.KEYCODE_POWER; 
		}

		if(e.getKeyCode() == KeyEvent.VK_RIGHT)
		{
			code = keyMap.KEYCODE_DPAD_RIGHT; 
		}
		
		if(e.getKeyCode() == KeyEvent.VK_LEFT)
		{
			code = keyMap.KEYCODE_DPAD_LEFT; 
		}

		if(e.getKeyCode() == KeyEvent.VK_UP)
		{
			code = keyMap.KEYCODE_DPAD_UP; 
		}

		if(e.getKeyCode() == KeyEvent.VK_DOWN)
		{
			code = keyMap.KEYCODE_DPAD_DOWN; 
		}
		
		if(e.getKeyCode() == KeyEvent.VK_SHIFT)
		{
			code = keyMap.KEYCODE_SHIFT_LEFT; 
		}
		
		return code;
	}
	
}
