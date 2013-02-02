/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package bintodec;

import java.util.Scanner;

/**
 * @platform Any
 * @author 0103629
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        
        String input;
        
        System.out.println("Insert a binary number.");
        System.out.println();

        Scanner keyboard = new Scanner(System.in);
        
        input = keyboard.next();

        keyboard.close();

        System.out.println();
        System.out.println(Integer.parseInt(input, 2));

    }
}
