/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package atm_guiv2;

import javax.swing.JOptionPane;

/**
 *
 * @author David
 */
public class changePIN extends javax.swing.JFrame {

    /**
     * Creates new form changePIN
     */
    public changePIN() {
        initComponents();
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        PINLabel = new javax.swing.JLabel();
        newpinTxt = new javax.swing.JTextField();
        changeBtn = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        PINLabel.setText("Insert new PIN:");

        changeBtn.setText("Change PIN");
        changeBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                changeBtnActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(PINLabel)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(newpinTxt, javax.swing.GroupLayout.PREFERRED_SIZE, 89, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(39, Short.MAX_VALUE))
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addComponent(changeBtn)
                .addGap(71, 71, 71))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap(18, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(PINLabel)
                    .addComponent(newpinTxt, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(changeBtn))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void changeBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_changeBtnActionPerformed
        // TODO add your handling code here:
        if (cashManagement.client1.flag == true) {
          
            try {
            cashManagement.client1.pin = Integer.parseInt(newpinTxt.getText());
            
          JOptionPane.showMessageDialog(this, "Pin changed successfully. \n New PIN is: " + newpinTxt.getText(), "Info", JOptionPane.INFORMATION_MESSAGE);
         
          setVisible(false);
          new startATM().setVisible(true);
           startATM.helloLabel.setText("Hello, " + cashManagement.client1.clientname + "!");
          }
          catch (Exception e) {
             JOptionPane.showMessageDialog(this, "Invalid PIN format. ", "Error", JOptionPane.ERROR_MESSAGE); 
             newpinTxt.setText("");
          }
        }
        
        else if (cashManagement.client2.flag == true) {
          try {
            cashManagement.client2.pin = Integer.parseInt(newpinTxt.getText());
            
          JOptionPane.showMessageDialog(this, "Pin changed successfully. \n New PIN is: " + newpinTxt.getText(), "Info", JOptionPane.INFORMATION_MESSAGE);
          
          setVisible(false);
          new startATM().setVisible(true);
           startATM.helloLabel.setText("Hello, " + cashManagement.client2.clientname + "!");
          
        }
          catch (Exception e) {
             JOptionPane.showMessageDialog(this, "Invalid PIN format. ", "Error", JOptionPane.ERROR_MESSAGE); 
             newpinTxt.setText("");
          }
        }
    }//GEN-LAST:event_changeBtnActionPerformed

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(changePIN.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(changePIN.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(changePIN.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(changePIN.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new changePIN().setVisible(true);
            }
        });
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel PINLabel;
    private javax.swing.JButton changeBtn;
    private javax.swing.JTextField newpinTxt;
    // End of variables declaration//GEN-END:variables
}
