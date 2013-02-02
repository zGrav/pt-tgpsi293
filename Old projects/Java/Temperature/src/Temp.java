import java.util.Scanner;
public class Temp {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		int temp;
		System.out.println("Insert a temperature (Celsius)");
		Scanner keyboard = new Scanner(System.in);
		temp = keyboard.nextInt();
		if (temp < 0)
		{
			System.out.println("FREEZING!");
		}
		if (temp >= 0 & temp <= 10)
		{
			System.out.println("Cold!");
		}
		if (temp > 10 & temp <= 20)
		{
			System.out.println("Decent!");
		}
		if (temp > 20 && temp <= 30)
		{
			System.out.println("Hot!");
		}
		if (temp > 30)
		{
			System.out.println("SUPER HOT!");
		}
	}

}
