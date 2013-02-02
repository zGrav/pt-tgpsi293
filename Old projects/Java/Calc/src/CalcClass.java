import java.util.*;

public class CalcClass {

	public static void main(String[] args)
	{
		System.out.println("Add - 1");
		System.out.println("Sub - 2");
		System.out.println("Multiply - 3");
		System.out.println("Divide - 4");
	Scanner input = new Scanner(System.in);
	int choose;
	choose = input.nextInt();
	if (choose == 1)
	{
		Add();
	}
	if (choose == 2)
	{
		Sub();
	}
	if (choose == 3)
	{
		Multiply();
	}
	if (choose == 4)
	{
		Divide();
	}
	else {
		System.out.println("Invalid option.");
		Retry();
	}
	}
	
	public static void Retry()
	{
		System.out.println("Add - 1");
		System.out.println("Sub - 2");
		System.out.println("Multiply - 3");
		System.out.println("Divide - 4");
	Scanner input = new Scanner(System.in);
	int choose;
	choose = input.nextInt();
	if (choose == 1)
	{
		Add();
	}
	if (choose == 2)
	{
		Sub();
	}
	if (choose == 3)
	{
		Multiply();
	}
	if (choose == 4)
	{
		Divide();
	}
	else {
		System.out.println("Invalid option.");
		Retry();
	}
	}
	
	public static void Add()
	{
		int num1;
		int num2;
		int res;
		
		Scanner input = new Scanner(System.in);
		System.out.println("First number?");
		num1 = input.nextInt();
		
		System.out.println("Second number?");
		num2 = input.nextInt();
		
		res = num1 + num2;
		System.out.println(num1 + " + " + num2 + " = " + res);
	}
	public static void Sub()
	{
		int num1;
		int num2;
		int res;
		
		Scanner input = new Scanner(System.in);
		System.out.println("First number?");
		num1 = input.nextInt();
		
		System.out.println("Second number?");
		num2 = input.nextInt();
		
		res = num1 - num2;
		System.out.println(num1 + " - " + num2 + " = " + res);
	}
	public static void Multiply()
	{
		int num1;
		int num2;
		int res;
		
		Scanner input = new Scanner(System.in);
		System.out.println("First number?");
		num1 = input.nextInt();
		
		System.out.println("Second number?");
		num2 = input.nextInt();
		
		res = num1 * num2;
		System.out.println(num1 + " * " + num2 + " = " + res);
	}
	public static void Divide()
	{
		int num1;
		int num2;
		int res;
		
		Scanner input = new Scanner(System.in);
		System.out.println("First number?");
		num1 = input.nextInt();
		
		System.out.println("Second number?");
		num2 = input.nextInt();
		
		res = num1 / num2;
		System.out.println(num1 + " / " + num2 + " = " + res);
	}
	
	}
