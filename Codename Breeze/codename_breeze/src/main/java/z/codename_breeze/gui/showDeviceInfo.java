package z.codename_breeze.gui;

import java.awt.Dimension;
import java.awt.event.MouseEvent;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.TreeSet;

import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.JTextArea;
import javax.swing.ListSelectionModel;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;
import javax.swing.table.AbstractTableModel;

import com.android.ddmlib.IDevice;


public class showDeviceInfo extends JFrame {
	
	IDevice getDevice;
	
	public showDeviceInfo(IDevice getDevice) {
		this.getDevice = getDevice;
		
		Map<String, String> getProps = getDevice.getProperties();
		
		propModel create = new propModel(getProps);
		
		JTable table = new JTable(create);

        table.setRowSelectionAllowed(true);
		table.getSelectionModel().addListSelectionListener(create);
		table.setAutoResizeMode(JTable.AUTO_RESIZE_ALL_COLUMNS);
		table.setShowHorizontalLines(true);
		table.setFillsViewportHeight(true);
		table.setPreferredScrollableViewportSize(new Dimension(400, 200));

        JScrollPane scroll = new JScrollPane(table);
        JOptionPane.showMessageDialog(null, scroll, "Codename Breeze - Device Info", JOptionPane.PLAIN_MESSAGE);
	}
	
    class propModel extends AbstractTableModel implements ListSelectionListener {
    	
        private List<String> getName = new ArrayList<String>();
        private List<String> getValue = new ArrayList<String>();

        propModel(Map<String, String> getProps) {
            for (String name : new TreeSet<String>(getProps.keySet())) {
                getName.add(name);
                getValue.add(getProps.get(name));
            }
        }

        @Override
        public void valueChanged(ListSelectionEvent e) {
            if (e.getValueIsAdjusting()) return;
            ListSelectionModel lsm = (ListSelectionModel) e.getSource();
            if (lsm.isSelectionEmpty()) return;
            int row = lsm.getMinSelectionIndex();

            JTextArea txtarea = new JTextArea((String) getValueAt(row, 1));
            txtarea.setRows(6);
            txtarea.setColumns(36);
            txtarea.setLineWrap(true);
            txtarea.setWrapStyleWord(true);
            txtarea.setEditable(false);
            
            JOptionPane.showMessageDialog(null, txtarea, (String) getValueAt(row, 0), JOptionPane.PLAIN_MESSAGE);
        }

        @Override
        public Object getValueAt(int row, int col) {
            if (col == 0) return getName.get(row);
            if (col == 1) return getValue.get(row);
            return null;
        }

        @Override
        public String getColumnName(int col) {
            if (col == 0) return "Name";
            if (col == 1) return "Value";
            return "";
        }

        @Override
        public int getRowCount() {
            return getName.size();
        }

        @Override
        public int getColumnCount() {
            return 2;
        }

        @Override
        public boolean isCellEditable(int row, int col) {
            return false;
        }

        @Override
        public Class<?> getColumnClass(int col) {
            if (col == 0) return String.class;
            if (col == 1) return String.class;
            return Object.class;
        }

    }

}
