package GUI.Renderes;

import java.awt.Component;

import javax.swing.DefaultListCellRenderer;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.ListCellRenderer;

import ModelLayer.Route;

public class RouteListRenderer  implements ListCellRenderer<Route>   {
	private DefaultListCellRenderer dlcr = new DefaultListCellRenderer();

    public Component getListCellRendererComponent(JList<? extends Route> list, Route route, int index,
        boolean isSelected, boolean cellHasFocus) {
          
		JLabel renderer = (JLabel) dlcr.getListCellRendererComponent(list, routeText(route), index, isSelected, cellHasFocus);
		return renderer;
    }
    
    public String routeText(Route route){
    	String text = "";
    	
    	text = route.getDriver().getFirstName() + " " + route.getDriver().getLastName() + " : " + route.getOrder().getId()
    			+ " " + route.getOrder().getProduct(); 
    	return text;
    }
}
