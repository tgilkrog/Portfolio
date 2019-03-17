package ModelLayer;

import java.util.ArrayList;


/**
 * Write a description of class Coworker here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Coworker extends Person
{
    
    private ArrayList<Order> orders;
    private String workStatus;
    private double wages;
    private Order order;
    /**
     * Constructor for objects of class Coworker
     * @constructor
     */
    public Coworker(int id, String name, String address, String phone, String email, String workStatus, double wages)
    {
        super(id, name, address, phone, email);
        orders = new ArrayList<Order>();
        this.workStatus = workStatus;
        this.wages = wages;
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
    
    public String getWorkStatus()
    {
        return workStatus;
    }
    
    public double getWages()
    {
        return wages;
    }
    
    public void addOrder(Order o)
    {
        orders.add(o);
    }
}
