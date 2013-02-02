import java.util.Scanner;
public class ParImpar {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		int read;
		int result;
		System.out.println("Insert a number");
		Scanner Reader = new Scanner(System.in);
		read = Reader.nextInt();
		result = read % 2;
		if (result == 0)
		{
			System.out.println("Par");
		}
		else
		{
			System.out.println("Impar");
		}
	}

}
