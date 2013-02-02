import java.util.Scanner;
public class DrawTriangle {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		int n;
		System.out.println("Insert your desired size.");
		Scanner read = new Scanner(System.in);
		n = read.nextInt();
		 for (int i=0; i<n;i++ ){
			  for (int j=0; j<=i;j++ ){
			  System.out.print("*");
			  }
			  System.out.println("");
			  }
			  }
	}

