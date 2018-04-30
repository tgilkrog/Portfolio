package GUI.Renderes;

import java.awt.Component;

import javax.swing.DefaultListCellRenderer;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.ListCellRenderer;

import ModelLayer.Order;

public class OrderListRenderer implements ListCellRenderer<Order>   {
	private DefaultListCellRenderer dlcr = new DefaultListCellRenderer();

    public Component getListCellRendererComponent(JList<? extends Order> list, Order order, int index,
        boolean isSelected, boolean cellHasFocus) {
          
		JLabel renderer = (JLabel) dlcr.getListCellRendererComponent(list, orderText(order), index, isSelected, cellHasFocus);
		return renderer;
    }
    
    public String orderText(Order order){
    	String text = "";
    	
    	text = order.getId()+ ": " + order.getProduct() + ", Fra: " + order.getStartAddress() + " Til: " + order.getEndAddress();
    	return text;
    }
}
