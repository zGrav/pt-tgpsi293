/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * Saldo - Deposito, Levantamento, Transferencia, Consulta/
 * Estado de conta (?), Saldo (?), Alterar PIN (?), montante disponivel, nome titular
 * Main - Menu,
 */

package atm;

import java.util.Scanner;
/**
 *
 * @author 0103629
 */
public class atm_Main extends atm_cashManagement {

    // menu
    public static int option;
    public static Scanner keyboardmain = new Scanner(System.in);

    /**
     * @param args the command line arguments
     */

    public static void main(String[] args) {
        // TODO code application logic here
        System.out.println("ATM - Debug menu");
        System.out.println("Client management - 1");

        option = keyboardmain.nextInt();

    switch (option) {
            case 1: client2.clientManagement();
            break;
        default: System.out.println("Invalid option.");
    }

    }

}
