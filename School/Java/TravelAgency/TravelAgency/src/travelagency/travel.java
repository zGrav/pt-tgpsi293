/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package travelagency;

/**
 *
 * @author 0103629
 */

public class travel {
    
    // client related
    public int id;
    public String name;
    public String go_to;
    public String from;
    public double value;

    public void loadClient(int i, String n, String g, String f, double v)
    {
       id = i;
       name = n;
       go_to = g;
       from = f;
       value = v;
    }


}
