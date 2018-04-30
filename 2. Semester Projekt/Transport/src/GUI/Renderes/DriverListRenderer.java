package GUI.Renderes;

import java.awt.Component;
import ModelLayer.Driver;

import javax.swing.*;

public class DriverListRenderer implements ListCellRenderer<Driver>  {
	private DefaultListCellRenderer dlcr = new DefaultListCellRenderer();

	    public Component getListCellRendererComponent(JList<? extends Driver> list, Driver driver, int index,
	        boolean isSelected, boolean cellHasFocus) {
	          
			JLabel renderer = (JLabel) dlcr.getListCellRendererComponent(list, driverText(driver), index, isSelected, cellHasFocus);
			return renderer;
	    }
	   
	    public String driverText(Driver driver){
	    	String text = "";
	    
	    	text = driver.getFirstName() + " " + driver.getLastName() + ", Mobil: " + driver.getPhonenumber() + 
	    			 ", Bil-Nr: " + driver.getCarNr();
	    	
	    	return text;
	    }

}
