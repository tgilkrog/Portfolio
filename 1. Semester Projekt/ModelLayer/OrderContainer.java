package ModelLayer;
import java.util.*;
import java.util.Iterator;

/**
 * Write a description of class OrderContainer here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class OrderContainer
{
    private static OrderContainer instance;
    private ArrayList<Order> orders;
    
    /**
     * Constructor for objects of class OrderContainer
     * @constructor
     */
    private OrderContainer()
    {
        orders = new ArrayList<Order>();
    }

    public static OrderContainer getInstance()
    {
        if(instance == null)
        {
            instance = new OrderContainer();
        }
        return instance;
    }

    /**
     * Method for adding an Order to the orders arraylist
     * @addOrder
     */
    public void addOrder(Order o)
    {
        orders.add(o);
    }

    /**
     * Method for searching Order in the orders arraylist, return the Order
     * @getOrder
     */
    public Order getOrder(int id)
    {
        Order order = null;      
        int index = 0;     
        boolean found = false; 
        while(index < orders.size() && !found) {  
            order = orders.get(index); 
            if(order.getId()== id) {
                found = true;
            }
            else {
                index++;  
            }
        } 
        if (found) {
            return orders.get(index);
        }
        else {   
            return null;
        }
    }

    /**
     * Method for deleting an Order, with the value from the parameter
     * @deleteOrder
     */
    public void deleteOrder(int id)
    {
        Iterator<Order> it = orders.iterator();
        while(it.hasNext())
        {
            Order o = it.next();
            int i = o.getId();

            if(i == id)
            {
                it.remove();
            }
        }
    }

}
