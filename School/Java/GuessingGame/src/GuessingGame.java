import java.util.Scanner;
import java.util.Random;

public class GuessingGame {

	/**
	 * @param args
	 */
	
	// variables
	static int inputnum, randomnum, chances;
	static Scanner inputscan = new Scanner(System.in);
	// end variables
	
	static void startGame()
	{
		do {
			chances +=1;
			
			if (chances == 5)
			{
				System.out.println("");
				System.out.println("You lost!");
				System.out.println("");
				System.exit(0);
			}
			

			if (inputnum > randomnum) {
				System.out.println("");
				System.out.println("Your input number is greater than the generated number.");
				System.out.println("Used chances: " + chances);
				System.out.println("");
			}
			else if (inputnum < randomnum) {
				System.out.println("");
				System.out.println("Your input number is lesser than the generated number.");
				System.out.println("Used chances: " + chances);
				System.out.println("");
			}
			else if (inputnum == randomnum) {
				System.out.println("");
				System.out.println("Your input number is equal to the generated number.");
				System.out.println("You win!");
				System.out.println("Used chances: " + chances);
				System.out.println("");
				System.exit(0);
			}
			System.out.println("");
			System.out.println("Reinsert number.");
			System.out.println("");
			
			inputscan  = new Scanner(System.in);

			inputnum = inputscan.nextInt();
		}
			while (chances != 5);
		
	}
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		Random randomGenerator = new Random();
		randomnum = randomGenerator.nextInt(101);
		
		System.out.println("Insert a number (0 to 100), you have five chances.");
		System.out.println("");
		
		inputscan  = new Scanner(System.in);

		inputnum = inputscan.nextInt();

		do {
		if (inputnum > 100) {
			System.out.println("");
			System.out.println("Incorrect value. Reinput number.");
			System.out.println("");
			inputscan = new Scanner(System.in);
			inputnum = inputscan.nextInt();
		}
		else if (inputnum < 0) {
			System.out.println("");
			System.out.println("Incorrect value. Reinput number.");
			System.out.println("");
			inputscan = new Scanner(System.in);
			inputnum = inputscan.nextInt();
		}
		}
		while (inputnum < 0 || inputnum >100);
	
		startGame();

	}

}
