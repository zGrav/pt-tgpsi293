    /*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package array_random;

import java.util.Random;

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

        int[] randomArray;
        int[] copyArray;
        int num;
        int sum = 0;
        int avg = 0;
        int max = 0;
        int min = 101;

        randomArray = new int[100];
        copyArray = new int[50];
        
        Random randomgen = new Random();

        for(int i = 0; i < 100; i++) {
            num = randomgen.nextInt(100);
            randomArray[i] = num;
        }

        for (int j = 0; j < randomArray.length; j++) {
         sum += randomArray[j];
        }

        for (int h = 0; h < randomArray.length; h++) {
         while (randomArray[h] < min) {
             min=randomArray[h];
            }

         while (randomArray[h] > max) {
             max=randomArray[h];
            }
        }

        System.arraycopy(randomArray, 0, copyArray, 0, 50);

        avg = sum / randomArray.length;

        System.out.println("Average: " + avg);
        System.out.println("Max: " + max);
        System.out.println("Min: " + min);
        System.out.println("1st position on random: " + randomArray[0]);
        System.out.println("1st position on copy: " + copyArray[0]);

        }

    }
