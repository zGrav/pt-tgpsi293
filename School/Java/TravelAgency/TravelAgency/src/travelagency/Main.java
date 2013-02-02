    /*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package travelagency;

import java.util.Scanner;

/**
 *
 * @author 0103629
 */
public class Main extends travel {

    /**
     * @param args the command line arguments
     */

    // objects
    public static travel client1 = new travel();
    public static travel client2 = new travel();

    public static void mainMenu() {

    // read input
      Scanner keyboard;

    // mainMenu related
      int option;

        System.out.println("1 - Load clients");
        System.out.println("2 - Print client values");
        System.out.println("3 - Change flight destination/departure");
        System.out.println("4 - Discounts");
        System.out.println("5 - Exit");

        keyboard = new Scanner(System.in);
        option = keyboard.nextInt();

        switch (option) {
            case 1: clientMenu();
                break;

            case 2: printValues();
                break;

            case 3: changeFlight();
                break;

            case 4: discountOptions();
                break;

            case 5: System.exit(0);
                break;

        }

    }

    public static void clientMenu() {
     // read input
      Scanner keyboard;

    //clientMenu related
     int cMenuoption;

    // object related
    int id;
    String name;
    String go_to;
    String from;
    double value;

        System.out.println("1 - Insert data for Client 1");
        System.out.println("2 - Insert data for Client 2");
        keyboard = new Scanner(System.in);
        cMenuoption = keyboard.nextInt();

        switch (cMenuoption) {

            case 1:
                System.out.println("Insert ID for client 1");
                id = keyboard.nextInt();

                System.out.println("Insert name for client 1");
                name = keyboard.next();

                System.out.println("Insert destination for client 1");
                go_to = keyboard.next();

                System.out.println("Insert departure for client 1");
                from = keyboard.next();

                System.out.println("Insert flight cost for client 1");
                value = keyboard.nextDouble();

                client1.loadClient(id, name, go_to, from, value);
                
            break;

            case 2:
                System.out.println("Insert ID for client 2");
                id = keyboard.nextInt();

                System.out.println("Insert name for client 2");
                name = keyboard.next();

                System.out.println("Insert destination for client 2");
                go_to = keyboard.next();

                System.out.println("Insert departure for client 2");
                from = keyboard.next();

                System.out.println("Insert flight cost for client 2");
                value = keyboard.nextDouble();

                client2.loadClient(id, name, go_to, from, value);

            break;

            default: mainMenu();
                break;
        }
      mainMenu();
    }

     public static void printValues() {
        System.out.println("Client 1 values:");
        System.out.println("ID: " + client1.id);
        System.out.println("Name: " + client1.name);
        System.out.println("Destination: " + client1.go_to);
        System.out.println("Departure: " + client1.from);
        System.out.println("Value of flight: " + client1.value);
        
        System.out.println();
        
        System.out.println("Client 2 values:");
        System.out.println("ID: " + client2.id);
        System.out.println("Name: " + client2.name);
        System.out.println("Destination: " + client2.go_to);
        System.out.println("Departure: " + client2.from);
        System.out.println("Value of flight: " + client2.value);

        mainMenu();
    }
     
     public static void changeFlight() {
         // read input
         Scanner keyboard;
         
         // changeFlight() related
         int menuopt;
         int read_id;
         String new_flight;
         double new_price;
         
         if (client1.id == 0 && client2.id == 0) {
         System.out.println("There are no clients to change flight.");
         
         mainMenu();
     }
         
         System.out.println("1 - Change destination");
         System.out.println("2 - Change departure");
         keyboard = new Scanner(System.in);
         menuopt = keyboard.nextInt();
         
         switch(menuopt) {
         
        case 1: System.out.println("Insert Client ID");

         read_id = keyboard.nextInt();
         
         if (read_id == client1.id) {
             System.out.println("Insert new flight destination for " + client1.name);
             new_flight = keyboard.next();
             
             client1.go_to = new_flight;
             
             System.out.println("New flight destination set.");
             
             System.out.println("Do you want to change flight value? (y/n)");
             new_flight = keyboard.next();
             
             if (new_flight.equals("y")) {
                 System.out.println("Insert new flight value.");
                 new_price = keyboard.nextDouble();
                 
                 client1.value = new_price;
                 
                 System.out.println("Flight value updated.");
                 
                 mainMenu();
             }
             else if (new_flight.equals("n")) {
                 System.out.println("Flight value not updated.");
                 
                 mainMenu();
             }
             
             }
         
         
         else if (read_id == client2.id) {
             System.out.println("Insert new flight destination for " + client2.name);
             new_flight = keyboard.next();
             
             client2.go_to = new_flight;
             
             System.out.println("New flight destination set.");
             
             System.out.println("Do you want to change flight value? (y/n)");
             new_flight = keyboard.next();
             
             if (new_flight.equals("y")) {
                 System.out.println("Insert new flight value.");
                 new_price = keyboard.nextDouble();
                 
                 client2.value = new_price;
                 
                 System.out.println("Flight value updated.");
                 
                 mainMenu();
             }
             else if (new_flight.equals("n")) {
                 System.out.println("Flight value not updated.");
                 
                 mainMenu();
             }
             
         }
         
         else {
                 System.out.println("Invalid ID.");
                 
                 mainMenu();
         }
         
        break;
            
        case 2:
            System.out.println("Insert Client ID");

         read_id = keyboard.nextInt();
         
         if (read_id == client1.id) {
             System.out.println("Insert new flight departure for " + client1.name);
             new_flight = keyboard.next();
             
             client1.from = new_flight;
             
             System.out.println("New flight departure set.");
             
             System.out.println("Do you want to change flight value? (y/n)");
             new_flight = keyboard.next();
             
             if (new_flight.equals("y")) {
                 System.out.println("Insert new flight value.");
                 new_price = keyboard.nextDouble();
                 
                 client1.value = new_price;
                 
                 System.out.println("Flight value updated.");
                 
                 mainMenu();
             }
             else if (new_flight.equals("n")) {
                 System.out.println("Flight value not updated.");
                 
                 mainMenu();
             }
             
             }
         
         
         else if (read_id == client2.id) {
             System.out.println("Insert new flight departure for " + client2.name);
             new_flight = keyboard.next();
             
             client2.from = new_flight;
             
             System.out.println("New flight departure set.");
             
             System.out.println("Do you want to change flight value? (y/n)");
             new_flight = keyboard.next();
             
             if (new_flight.equals("y")) {
                 System.out.println("Insert new flight value.");
                 new_price = keyboard.nextDouble();
                 
                 client2.value = new_price;
                 
                 System.out.println("Flight value updated.");
                 
                 mainMenu();
             }
             else if (new_flight.equals("n")) {
                 System.out.println("Flight value not updated.");
                 
                 mainMenu();
             }
             
         }
       else {
        System.out.println("Invalid ID.");
                 
         mainMenu();
         }
            break;
            
        default: mainMenu();
            break;
         }
     }
     
     public static void discountOptions() {
        
         // read input
         Scanner keyboard;
         
         // discountOptions() related
         int read_id;
         double discount;
        if (client1.id == 0 && client2.id == 0) {
         System.out.println("There are no clients to do a discount.");

            mainMenu();
        
     }
        
         System.out.println("Insert client ID");
         keyboard = new Scanner(System.in);
         read_id = keyboard.nextInt();
         
         if (read_id == client1.id) {
             System.out.println("Now performing a discount on " + client1.name + " flight value");
             System.out.println();
             System.out.println("Please insert the amount that you want to deduct from original flight value.");
             
             discount = keyboard.nextDouble();
             client1.value -= discount;
             
             System.out.println("You've discounted " + discount + " from " + client1.name + " flight value.");
             
             mainMenu();
         }
        else if (read_id == client2.id) {
                              System.out.println("Now performing a discount on " + client2.name + "'s flight value");
             System.out.println();
             System.out.println("Please insert the amount that you want to deduct from original flight value.");
             
             discount = keyboard.nextDouble();
             client2.value -= discount;
             
             System.out.println("You've discounted " + discount + " from " + client2.name + "'s flight value.");
             
             mainMenu();
        }
        
        else {
            System.out.println("Invalid ID.");
            mainMenu();
        
        }
         
         }


    public static void main(String[] args) {
        // TODO code application logic here
        mainMenu();
        
    }

}
