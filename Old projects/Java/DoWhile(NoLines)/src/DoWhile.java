import java.util.Scanner;
public class DoWhile {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		int n, count = 0;
		System.out.println("Insert a value.");
		Scanner read = new Scanner(System.in);
		n = read.nextInt();
		do {
		System.out.print("*");
		count++;
		} while (n > count);
	}

}
