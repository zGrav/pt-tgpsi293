/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package football;

// exception handling
import java.util.InputMismatchException;

// reader
import java.util.Scanner;

/**
 *
 * @author 0103629
 */

public class Main extends Player{

    /**
     * @param args the command line arguments
     */

    // read input
    public static Scanner keyboard;

    // objects
    public static Player player1 = new Player();

    public static void createPlayer() {

        // player related
        int speed;
        int strength;
        int direction;
        boolean ball = false;
        String hasBall;

        try {

        keyboard = new Scanner(System.in);

        System.out.println("Input player speed");
        speed = keyboard.nextInt();

        if (speed == 0 || speed < 0) {

            System.out.println("");
            System.out.println("Incorrect value.");

            playerMenu();
        }

        System.out.println("");
        System.out.println("Input player strength");
        strength = keyboard.nextInt();

         if (strength == 0 || strength < 0) {
            System.out.println("");
            System.out.println("Incorrect value.");

            playerMenu();
        }

        System.out.println("");
        System.out.println("Input player direction");
        direction = keyboard.nextInt();

        System.out.println("");
        System.out.println("Does the player have the ball (Y/N)");
        hasBall = keyboard.next();
        hasBall = hasBall.toLowerCase();

        if (hasBall.equals("y")) {
            ball = true;
        }

        else if (hasBall.equals("n")) {
            ball = false;
        }

        else if (!hasBall.equals("y") || !hasBall.equals("n")) {
            System.out.println("");
            System.out.println("Incorrect value.");

            playerMenu();
        }

        player1.loadPlayer(speed, strength, direction, ball);

        System.out.println("");
        System.out.println("Player loaded.");
    
        playerMenu();

    }

    catch ( InputMismatchException inputMismatchException ) {
        System.out.println("Invalid input detected. Integer only.");
        playerMenu();
    }

    }

    public static void changeSpeed(int speed) {
        try {
            
        int newValue;

        if (player1.speed == 0) {
            System.out.println("");
            System.out.println("Player not loaded.");

            playerMenu();
        }

        else if (player1.speed > 0) {

        System.out.println("");
        System.out.println("Input new player speed");

        keyboard = new Scanner(System.in);
        newValue = keyboard.nextInt();

        if (newValue == 0 || newValue < 0) {

            System.out.println("");
            System.out.println("Incorrect value.");

            playerMenu();
        }

        player1.speed = newValue;

        System.out.println("");
        System.out.println("Player's new speed is: " + newValue);

        playerMenu();
    }

    }

            catch ( InputMismatchException inputMismatchException ) {
        System.out.println("Invalid input detected. Integer only.");
        playerMenu();
    }

    }



    public static void changeStrength(int strength) {
        try {

        int newValue;

       if (player1.strength == 0) {
            System.out.println("");
            System.out.println("Player not loaded.");

            playerMenu();
        }

       else if (player1.strength > 0) {

        System.out.println("");
        System.out.println("Input new player strength");

        keyboard = new Scanner(System.in);
        newValue = keyboard.nextInt();

        if (newValue == 0 || newValue < 0) {

            System.out.println("");
            System.out.println("Incorrect value.");

            playerMenu();
        }

        player1.strength = newValue;

        System.out.println("");
        System.out.println("Player's new strength is: " + newValue);

        playerMenu();

    }

    }

     catch ( InputMismatchException inputMismatchException ) {
        System.out.println("Invalid input detected. Integer only.");
        playerMenu();
    }

    }

    public static void changeDirection(int direction) {

       try {

        int newValue;
        
        if (player1.strength == 0) {

            System.out.println("");
            System.out.println("Player not loaded.");

            playerMenu();
        }
        
        else if(player1.strength > 1) {

        System.out.println("");
        System.out.println("Input new player direction");

        keyboard = new Scanner(System.in);
        newValue = keyboard.nextInt();

        player1.direction = newValue;

        if (newValue == 0 || newValue < 90) {

        System.out.println("");
        System.out.println("Player's new direction is: " + newValue + " heading right");
            }

        else if (newValue == 90 || newValue < 180) {

            System.out.println("");
            System.out.println("Player's new direction is: " + newValue + " heading to the front");
        }

        else if (newValue == 180 || newValue < 360) {

            System.out.println("");
           System.out.println("Player's new direction is: " + newValue + " heading to the left"); 
        }

        else if (newValue == 360) {

            System.out.println("");
            System.out.println("Player's new direction is: " + newValue + " heading to the back");
        }

        else if (newValue > 360 || newValue < 0) {

            System.out.println("");
            System.out.println("Player's new direction is: " + newValue + " // not implemented direction");
        }

        playerMenu();

    }

    }

    catch ( InputMismatchException inputMismatchException ) {
        System.out.println("Invalid input detected. Integer only.");
        playerMenu();
    }

    }

    public static void ballOptions() {

        try {

        int option;

        if (player1.speed == 0) {

            System.out.println("");
            System.out.println("Player not loaded.");

            playerMenu();
        }

        else if (player1.speed > 0) {
        System.out.println("");
        System.out.println("1 - Pass");
        System.out.println("2 - Receive");

        keyboard = new Scanner(System.in);
        option = keyboard.nextInt();

        switch (option) {

            case 1: 
                if (player1.ball == true) {
                System.out.println("");
                System.out.println("Player has passed the ball.");

                player1.ball = false;

                playerMenu();
                break;
            }

            else if (player1.ball == false) {
                System.out.println("");
                System.out.println("You cannot pass the ball since you don't have it.");

                playerMenu();
                break;
            }

                break;

            case 2: if (player1.ball == true) {
                System.out.println("");
                System.out.println("You already have the ball.");

                playerMenu();
                break;
            }

            else if (player1.ball == false) {
                System.out.println("");
                System.out.println("Player has received the ball.");

                player1.ball = true;

                playerMenu();
                break;
            }

                break;

            default: playerMenu();
            break;
        }

        }
    }
   catch ( InputMismatchException inputMismatchException ) {
        System.out.println("Invalid input detected. Integer only.");
        playerMenu();
    }

    }

    public static void printValues() {

        System.out.println("");
        System.out.println("Speed: " + player1.speed);
        System.out.println("Strength: " + player1.strength);
        System.out.println("Direction: " + player1.direction);
        System.out.println("Has Ball: " + player1.ball);

        playerMenu();
    }

    public static void playerMenu() {
        try {

        int option;

        System.out.println("1 - Create Player");
        System.out.println("2 - Change Speed");
        System.out.println("3 - Change Strength");
        System.out.println("4 - Change Direction");
        System.out.println("5 - Pass/Receive the Ball");
        System.out.println("6 - Print Player state");
        System.out.println("7 - Exit");

        keyboard = new Scanner(System.in);
        option = keyboard.nextInt();

        switch (option) {

            case 1: createPlayer();

            case 2: changeSpeed(player1.speed);

            case 3: changeStrength(player1.strength);

            case 4: changeDirection(player1.direction);

            case 5: ballOptions();
            
            case 6: printValues();

            case 7: System.exit(0);

            default: playerMenu();
            break;
        }

    }

      catch ( InputMismatchException inputMismatchException ) {
        System.out.println("Invalid input detected. Integer only.");
        playerMenu();
    }
        
    }

    public static void main(String[] args) {
        // TODO code application logic here

        playerMenu();

    }

}