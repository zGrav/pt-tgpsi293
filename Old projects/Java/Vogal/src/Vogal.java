import java.util.Scanner;

public class Vogal {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
	char read;
	System.out.println("Insert a character.");
	Scanner reader = new Scanner(System.in);
	String toString = reader.next();
	read = toString.charAt(0);
	
	switch(read){
	case 'a': case 'e': case 'i': case 'o': case 'u':
		System.out.println("Vogal character"); break;
	case 'A': case 'E': case 'I': case 'O': case 'U':
		System.out.println("Capitalized vogal character"); break;
	case '@':
		System.out.println("You've typed a @ char."); break;
	default:
		System.out.println("No option available for your char.");
	}
	
	}
	

	}

