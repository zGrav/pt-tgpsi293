/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package football;

/**
 *
 * @author 0103629
 */
public class Player {

    // player related
   public int speed;
   public int strength;
   public int direction;
   public boolean ball;

    public void loadPlayer(int s, int st, int d, boolean b)
    {
        speed = s;
        strength = st;
        direction = d;
        ball = b;
    }

}
