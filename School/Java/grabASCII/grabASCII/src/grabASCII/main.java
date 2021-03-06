package grabASCII;

import javax.swing.JOptionPane;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * main.java
 *
 * Created on 30/Nov/2012, 10:24:24
 */

/**
 *
 * @author 0103629
 */
public class main extends javax.swing.JFrame {

    /** Creates new form main */
    public main() {
        initComponents();
    }

    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        insLbl = new javax.swing.JLabel();
        chrTxt = new javax.swing.JTextField();
        cnvtBtn = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        txtArea = new javax.swing.JTextArea();
        viewTableBtn = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        insLbl.setText("Insert characters:");

        cnvtBtn.setText("Convert");
        cnvtBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cnvtBtnActionPerformed(evt);
            }
        });

        txtArea.setColumns(20);
        txtArea.setRows(5);
        jScrollPane1.setViewportView(txtArea);

        viewTableBtn.setText("View complete ASCII table");
        viewTableBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                viewTableBtnActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 261, Short.MAX_VALUE))
                    .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                        .addGap(19, 19, 19)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(cnvtBtn)
                            .addComponent(insLbl))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(viewTableBtn)
                            .addComponent(chrTxt, javax.swing.GroupLayout.DEFAULT_SIZE, 159, Short.MAX_VALUE))))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(chrTxt, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(insLbl))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(cnvtBtn)
                    .addComponent(viewTableBtn))
                .addGap(18, 18, 18)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 137, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    static boolean isOpen;

    private void cnvtBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cnvtBtnActionPerformed
        // TODO add your handling code here:

        txtArea.setText("" + "Welcome to the ASCII Value Grabber. \n");

        String grab = chrTxt.getText(); // grabs text from textbox

        for (int i = 0; i < grab.length(); i++) { // reads grabbed text length
            txtArea.setText(txtArea.getText() + "The value of the character: " + "'" + grab.charAt(i) + "'" + " is:"
                    + (int) grab.charAt(i) + "\n"); // reads chars 1 by 1 according to length and returns correct ASCII value
        }

        txtArea.setText(txtArea.getText() + "Program terminated.");
    }//GEN-LAST:event_cnvtBtnActionPerformed

    private void viewTableBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_viewTableBtnActionPerformed
        // TODO add your handling code here:

        if (isOpen == false) {
        new showTable().setVisible(true);

        showTable.tableArea.setText("" + " Printing ASCII table from 33 to 126: \n");

        for (int j = 33; j <= 126; j++) {

            char toString = (char) j; //converts the current position to j (ASCII) to it's corresponding char and from char to String

            showTable.tableArea.setText(showTable.tableArea.getText() + "Value of " + j + " is: " + "'" + toString + "'" + "\n");
        }

        showTable.tableArea.setText(showTable.tableArea.getText() + "Print complete.");

        isOpen = true;
        }

        else {
            JOptionPane.showMessageDialog(this, "The table is already open!", "Information", JOptionPane.INFORMATION_MESSAGE);
        }
    }//GEN-LAST:event_viewTableBtnActionPerformed

    /**
    * @param args the command line arguments
    */
    public static void main(String args[]) {
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new main().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JTextField chrTxt;
    private javax.swing.JButton cnvtBtn;
    private javax.swing.JLabel insLbl;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextArea txtArea;
    private javax.swing.JButton viewTableBtn;
    // End of variables declaration//GEN-END:variables

}
