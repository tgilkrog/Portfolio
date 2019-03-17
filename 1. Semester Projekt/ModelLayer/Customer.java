package ModelLayer;

import java.util.ArrayList;

/**
 * Write a description of class Customer here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Customer extends Person
{
    private ArrayList<Order> orders;
    /**
     * Constructor for objects of class Customer
     * @constructor
     */
    public Customer(int id, String name, String address, String phone, String email)
    {
        super(id, name, address, phone, email);
        orders = new ArrayList<Order>();
    }
    
    /**
     * Get and Set methods
     * @Gets&Sets
     */
    public int getId()
    {
        return super.getId();
    }
    
    public String getName()
    {
        return super.getName();
    }
    
    public String getAddress()
    {
        return super.getAddress();
    }
    
    public String getPhone()
    {
        return super.getPhone();
    }
    
    public String getEmail()
    {
        return super.getEmail();
    }
    
    public void addOrder(Order o)
    {
        orders.add(o);
    }
    
}
