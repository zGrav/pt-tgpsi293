import java.util.Scanner;
public class Grade {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Only does 3 grades at the moment.
		
		int grade1, grade2, grade3, average;
		System.out.println("Insert the 1st grade value (0 to 20.)");
		Scanner readgrade1 = new Scanner(System.in);
		grade1 = readgrade1.nextInt();
		if (grade1 < 0 || grade1 > 20)
		{
			System.out.println("Invalid grade.");
			System.exit(0);
		}
		else
		{
			System.out.println("Insert the 2nd grade value (0 to 20.)");
			Scanner readgrade2 = new Scanner(System.in);
			grade2 = readgrade2.nextInt();
			if (grade2 < 0 || grade2 > 20)
			{
				System.out.println("Invalid grade.");
				System.exit(0);
			}
			else
			{
				System.out.println("Insert the 3rd grade value (0 to 20.)");
				Scanner readgrade3 = new Scanner(System.in);
				grade3 = readgrade3.nextInt();
				if (grade3 < 0 || grade3 > 20)
				{
					System.out.println("Invalid grade.");
					System.exit(0);
				}
				else
				{
					average = grade1 + grade2 + grade3 / 3;
					System.out.println("The average grade is: " + average);
					if (grade1 > grade2 && grade2 > grade3)
					{
						System.out.println("The highest grade is: " + grade1);
						System.out.println("The lowest grade is: " + grade3);
					}
					else if (grade3 > grade2 && grade2 > grade1)
					{
						System.out.println("The highest grade is: " + grade3);
						System.out.println("The lowest grade is: " + grade1);
					}
					else if (grade2 > grade1 && grade2 > grade3 && grade1 > grade3)
					{
						System.out.println("The highest grade is: " + grade2);
						System.out.println("The lowest grade is: " + grade3);
					}
					else if (grade2 > grade1 && grade2 > grade3 && grade3 > grade1)
					{
						System.out.println("The highest grade is: " + grade2);
						System.out.println("The lowest grade is: " + grade1);
					}
					else if (grade1 > grade2 && grade3 > grade2)
					{
						
							System.out.println("The highest grade is: " + grade1);
							System.out.println("The lowest grade is: " + grade2);
					}
				}
			}
		}

	}

}
