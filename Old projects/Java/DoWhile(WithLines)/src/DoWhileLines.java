//Need to finish, bug in counting (?).

import java.util.Scanner;
public class DoWhileLines {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		int n1, n2;
		System.out.println("Insert the amount of lines that you want");
		Scanner readlines = new Scanner(System.in);
		n1 = readlines.nextInt();
		
		System.out.println("Insert the quantity of '*' that you want");
		Scanner readast = new Scanner(System.in);
		n2 = readast.nextInt();
		for (int j = 0; j <= n2; j++)
			System.out.print("*");
		for (int i = 0; i <= n1; i++)
			System.out.println("*");
		
	}

}
