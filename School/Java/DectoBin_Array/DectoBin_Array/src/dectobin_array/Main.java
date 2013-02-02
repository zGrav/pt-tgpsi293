/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package dectobin_array;

import java.util.Scanner;

/**
 *
 * @author 0103629
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here

        int arr[] = {0,1};
        int num;
        int rest;
        int i = 0;
        arr = new int[10];

        Scanner keyboard = new Scanner(System.in);

        System.out.println("Insert a number.");
        num = keyboard.nextInt();

        System.out.println();
        System.out.println("Reverse order:");

        do {
            
            //1st try

            /*rest = num % 2;

            if (rest > 0 ) {
                System.out.println(arr[1]);
            }

            else {
                System.out.println(arr[0]);
            }

            num = num / 2; */

            rest = num % 2;

            num = num / 2;

            arr[i] = rest;

            System.out.println(arr[i]);
            i++;
            
        } while (num > 0);

            System.out.println();
            System.out.println("Correct order:");

            for (int j = arr.length-1; j >= 0; j--) {
                System.out.println(arr[j]);
            }
    }

}