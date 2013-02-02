/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package atm;

import java.util.Scanner;

/**
 *
 * @author 0103629
 */
public class atm_cashManagement {

    //money related
   public double balance, amountinput, transferamount;
   public int pin, accountinput;
    
    //client related
   public int accountnumber;
   public String clientname;
   public int newPIN;
   boolean clientflag1, clientflag2;
    
    //input related
   public Scanner keyboard = new Scanner(System.in);
   public int menuopt, pincheck;

       // objects
    public static atm_cashManagement client1 = new atm_cashManagement();
    public static atm_cashManagement client2 = new atm_cashManagement();

    public void startATM() {
        System.out.println("Insert your PIN:");
            pincheck = keyboard.nextInt();
            if (pincheck == client1.pin) {
                System.out.println("Welcome " + client1.clientname);
                System.out.println("Your account number is:" + client1.accountnumber);
                System.out.println("Your balance is: " + client1.balance);
                clientflag1 = true;
                cashMenu();
            }

        else if(pincheck == client2.pin) {
                 System.out.println("Welcome " + client2.clientname);
                 System.out.println("Your account number is:" + client2.accountnumber);
                 System.out.println("Your balance is: " + client2.balance);
                 clientflag2 = true;
                cashMenu();
            }
            else {
                System.out.println("Invalid PIN.");
                clientflag1 = false;
                clientflag2 = false;
                System.exit(0);
            }
    }

    public void clientManagement() {

        client1.pin = 1234;
        client1.clientname = "Josh";
        client1.accountnumber = 1;
        client1.balance = 9000;

        client2.pin = 9876;
        client2.clientname = "John";
        client2.accountnumber = 2;
        client2.balance = 1000;

        System.out.println("Clients added:");
        System.out.println("Client 1:");
        System.out.println("Pin: " + client1.pin);
        System.out.println("Client name: " + client1.clientname);
        System.out.println("Account number: " + client1.accountnumber);
        System.out.println("Account balance: " + client1.balance);
        System.out.println();
        System.out.println("Client 2:");
        System.out.println("Pin: " + client2.pin);
        System.out.println("Client name: " + client2.clientname);
        System.out.println("Account number: " + client2.accountnumber);
        System.out.println("Account balance: " + client2.balance);
        startATM();
    }

   public void cashMenu() {
       System.out.println("1 - Deposit");
       System.out.println("2 - Withdraw");
       System.out.println("3 - Transfer");
       System.out.println("4 - Check Balance");
       System.out.println("5 - Account status");
       System.out.println("6 - Change PIN");
       System.out.println("7 - Logout");
       System.out.println("8 - Shutdown");
       System.out.println();
       System.out.println("Choose your option: ");
       menuopt = keyboard.nextInt();
       switch (menuopt) {
           case 1: depositMoney();
           break;
           case 2: withdrawMoney();
           break;
           case 3: transferMoney();
           break;
           case 4: checkBalance();
           break;
           case 5: accountStatus();
           break;
           case 6: changePIN();
           break;
           case 7: Logout();
           break;
           case 8: Exit();
           break;
           default: System.out.println("Invalid option.");
           break;
       }
   }

    public void depositMoney() {
        System.out.println("Please insert your desired amount to deposit:");
        amountinput = keyboard.nextDouble();
        balance += amountinput;
        System.out.println("You've deposited " + amountinput + "$");
        cashMenu();
    }

    public void withdrawMoney() {
        if (balance == 0)
        {
            System.out.println("No money to withdraw.");
            cashMenu();
        }

        System.out.println("Please insert your desired amount to withdraw:");
        amountinput = keyboard.nextDouble();
        if (balance < amountinput) {
           System.out.println("Not enough money to withdraw.");
           cashMenu();
        }
        else {
        balance -= amountinput;
        System.out.println("You've withdrawn " + amountinput + "$");
        cashMenu();
        }
    }

    public void transferMoney() {
         if (balance == 0)
        {
            System.out.println("No money to transfer.");
            cashMenu();
        }
    System.out.println("Please insert the account number you want to transfer to:");
    accountinput = keyboard.nextInt();
   if (accountinput == client1.accountnumber) {
   System.out.println("Transferring to: " + client1.clientname);
   System.out.println("Insert amount: ");
   transferamount = keyboard.nextDouble();
           if (balance < transferamount) {
           System.out.println("Not enough money to transfer.");
           cashMenu();
        }
        else {
   client1.balance += transferamount;
   client2.balance -= transferamount;
   System.out.println("Transferred " + transferamount + " to " + client1.clientname);
   cashMenu();
    }
        }
        else if(accountinput == client2.accountnumber) {
    System.out.println("Transferring to: " + client2.clientname);
    System.out.println("Insert amount: ");
   transferamount = keyboard.nextDouble();
           if (balance < transferamount) {
           System.out.println("Not enough money to transfer.");
           cashMenu();
        }
        else {
   client2.balance += transferamount;
   client1.balance -= transferamount;
   System.out.println("Transferred " + transferamount + " to " + client2.clientname);
   cashMenu();
   }
   }
    }

    public void checkBalance() {
        System.out.println("Your current balance is: " + balance);
        cashMenu();
    }

    public void accountStatus() {
        System.out.println("Account Status:");
        System.out.println("Current balance: " + balance);
        System.out.println("Account name: " + clientname);
        System.out.println("Account number: " + accountnumber);
        System.out.println("Current PIN number: " + pin);
        cashMenu();
    }

    public void changePIN() {
        System.out.println("Insert your new PIN:");
        newPIN = keyboard.nextInt();
        if (clientflag1 == true)
        {
            client1.pin = newPIN;
        }
        else if (clientflag2 == true)
        {
            client2.pin = newPIN;
        }
        cashMenu();
    }

    public void Logout()
    {
        client1.clientManagement();
    }

    public void Exit()
    {
        System.exit(0);
    }

}

