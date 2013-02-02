package atm_guiv2;

import javax.swing.JOptionPane;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * startATM.java
 *
 * Created on 9/Nov/2012, 11:48:58
 */

/**
 *
 * @author 0103629
 */
public class startATM extends javax.swing.JFrame {

    /** Creates new form startATM */
    public startATM() {
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

        depositBtn = new javax.swing.JButton();
        withdrawBtn = new javax.swing.JButton();
        transferBtn = new javax.swing.JButton();
        checkBalancebtn = new javax.swing.JButton();
        accountStatusbtn = new javax.swing.JButton();
        changePINbtn = new javax.swing.JButton();
        logoutBtn = new javax.swing.JButton();
        shutdownBtn = new javax.swing.JButton();
        helloLabel = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        depositBtn.setText("Deposit");
        depositBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                depositBtnActionPerformed(evt);
            }
        });

        withdrawBtn.setText("Withdraw");
        withdrawBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                withdrawBtnActionPerformed(evt);
            }
        });

        transferBtn.setText("Transfer");
        transferBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                transferBtnActionPerformed(evt);
            }
        });

        checkBalancebtn.setText("Check Balance");
        checkBalancebtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                checkBalancebtnActionPerformed(evt);
            }
        });

        accountStatusbtn.setText("Account Status");
        accountStatusbtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                accountStatusbtnActionPerformed(evt);
            }
        });

        changePINbtn.setText("Change PIN");
        changePINbtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                changePINbtnActionPerformed(evt);
            }
        });

        logoutBtn.setText("Logout");
        logoutBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                logoutBtnActionPerformed(evt);
            }
        });

        shutdownBtn.setText("Shutdown");
        shutdownBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                shutdownBtnActionPerformed(evt);
            }
        });

        helloLabel.setText("Hello, $username");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(depositBtn)
                            .addComponent(withdrawBtn)
                            .addComponent(transferBtn)
                            .addComponent(checkBalancebtn))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(accountStatusbtn)
                            .addComponent(changePINbtn)
                            .addComponent(logoutBtn)
                            .addComponent(shutdownBtn)))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(71, 71, 71)
                        .addComponent(helloLabel)))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(8, 8, 8)
                .addComponent(helloLabel)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(accountStatusbtn)
                    .addComponent(depositBtn))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(changePINbtn)
                    .addComponent(withdrawBtn))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(logoutBtn)
                    .addComponent(transferBtn))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(shutdownBtn)
                    .addComponent(checkBalancebtn))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void shutdownBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_shutdownBtnActionPerformed
        // TODO add your handling code here:
        System.exit(0);
    }//GEN-LAST:event_shutdownBtnActionPerformed

    private void logoutBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_logoutBtnActionPerformed
        // TODO add your handling code here:
        setVisible(false);
        
        if (cashManagement.client1.flag == true) {
            cashManagement.client1.flag = false;
        }
        
        else if (cashManagement.client2.flag == true) {
            cashManagement.client2.flag = false;
        }
        
        new Login().setVisible(true);
    }//GEN-LAST:event_logoutBtnActionPerformed

    private void checkBalancebtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_checkBalancebtnActionPerformed
        // TODO add your handling code here:
        if (cashManagement.client1.flag == true) {
        JOptionPane.showMessageDialog(this, "Your current balance is: " + cashManagement.client1.balance, "Info", JOptionPane.INFORMATION_MESSAGE);
        }
        
        if (cashManagement.client2.flag == true) {
          JOptionPane.showMessageDialog(this, "Your current balance is: " + cashManagement.client2.balance, "Info", JOptionPane.INFORMATION_MESSAGE);  
        }
    }//GEN-LAST:event_checkBalancebtnActionPerformed

    private void accountStatusbtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_accountStatusbtnActionPerformed
        // TODO add your handling code here:
        if (cashManagement.client1.flag == true) {
        JOptionPane.showMessageDialog(this, "Account status: \n" + "Account name: " + cashManagement.client1.clientname + 
                "\n Account number: " + cashManagement.client1.accountnumber + "\n PIN Code: " 
                + cashManagement.client1.pin + "\n Account Balance: " + 
                cashManagement.client1.balance, "Info", JOptionPane.INFORMATION_MESSAGE);
        }
        
        else if (cashManagement.client2.flag == true) {
        JOptionPane.showMessageDialog(this, "Account status: \n" + "Account name: " + cashManagement.client2.clientname + 
                "\n Account number: " + cashManagement.client2.accountnumber + "\n PIN Code: " 
                + cashManagement.client2.pin + "\n Account Balance: " + 
                cashManagement.client2.balance, "Info", JOptionPane.INFORMATION_MESSAGE);
        }
    }//GEN-LAST:event_accountStatusbtnActionPerformed

    private void changePINbtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_changePINbtnActionPerformed
        // TODO add your handling code here:
        setVisible(false);
        new changePIN().setVisible(true);
    }//GEN-LAST:event_changePINbtnActionPerformed

    private void depositBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_depositBtnActionPerformed
        // TODO add your handling code here:
        setVisible(false);
        new Deposit().setVisible(true);
    }//GEN-LAST:event_depositBtnActionPerformed

    private void withdrawBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_withdrawBtnActionPerformed
        // TODO add your handling code here:
        setVisible(false);
        new Withdraw().setVisible(true);
    }//GEN-LAST:event_withdrawBtnActionPerformed

    private void transferBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_transferBtnActionPerformed
        // TODO add your handling code here:
        setVisible(false);
        new Transfer().setVisible(true);
    }//GEN-LAST:event_transferBtnActionPerformed

    /**
    * @param args the command line arguments
    */
    public static void main(String args[]) {
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new startATM().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton accountStatusbtn;
    private javax.swing.JButton changePINbtn;
    private javax.swing.JButton checkBalancebtn;
    private javax.swing.JButton depositBtn;
    public static javax.swing.JLabel helloLabel;
    private javax.swing.JButton logoutBtn;
    private javax.swing.JButton shutdownBtn;
    private javax.swing.JButton transferBtn;
    private javax.swing.JButton withdrawBtn;
    // End of variables declaration//GEN-END:variables

}
