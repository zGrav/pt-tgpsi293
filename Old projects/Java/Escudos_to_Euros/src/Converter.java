import java.util.Scanner;
public class Converter {
public static void main(String[] args)
{
	double euro, escudo;
	
	Scanner keyboard = new Scanner(System.in);
	
	System.out.print("What's the value in escudos? ");
	escudo = keyboard.nextDouble();
	euro = escudo / 200.482;
	System.out.println("Value in euros = " + euro + "€");
}
}
