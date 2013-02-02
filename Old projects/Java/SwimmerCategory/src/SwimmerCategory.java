import java.util.Scanner;
public class SwimmerCategory {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		int age;
		System.out.println("Insert a age.");
		Scanner read = new Scanner(System.in);
		age = read.nextInt();
		if (age >= 5 & age <= 7)
		{
			System.out.println("Kids A class");
		}
		else if (age >= 8 & age <= 10)
		{
			System.out.println("Kids B class");
		}
		else if (age >= 11 & age <= 13)
		{
			System.out.println("Juvenile A class");
		}
		else if (age >= 14 & age <= 17)
		{
			System.out.println("Juvenile B class");
		}
		else if (age >= 18 & age <= 60)
		{
			System.out.println("Adult class");
		}
		else if (age > 60)
		{
			System.out.println("Senior class");
		}
		else if (age < 5)
		{
			System.out.println("No class available.");
		}
	}

}
