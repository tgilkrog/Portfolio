package ControllerLayer;

import ModelLayer.*;

/**
 * Write a description of class PersonController here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class PersonController
{
    
  private CoworkerContainer cowCon;
  private CustomerContainer cusCon;
  private OrderController oCtr;
    /**
     * Constructor for objects of class PersonController
     * @constructor
     */
    public PersonController()
    {
        cusCon = cusCon.getInstance();
        cowCon = cowCon.getInstance();
    }
    /**
     * Method for creating a Customer, with the values from the paramters, and then calls a method from customer container
     * @createCustomer
     */
    public void CreateCustomer(int id, String name, String address, String phone, String email)
    {
        Customer cow = new Customer(id, name, address, phone, email);
        cusCon.addCustomer(cow);
        System.out.println("You have created the Customer:" + name);
    }
    /**
     * Method for creating a Coworker, with the values from the paramters, and then calls a method from coworker container
     * @createCoworker
     */
    public void CreateCoworker(int id, String name, String address, String phone, String email, String workStatus, double wages)
    {
        Coworker cow = new Coworker(id, name, address, phone, email, workStatus, wages);
        cowCon.addCoworker(cow);
        System.out.println("You have created the Coworker:" + name);
    }
    
    /**
     * Method for returning a Customer with the value in the paramter, calls a method from the customer container
     * @getCustomer
     */
    public Customer getCustomer(int id)
    {
        return cusCon.getCustomer(id);
    }
    /**
     * Method for returning a Coworker with the value in the paramter, calls a method from the coworker container
     * @getCoworker
     */
    public Coworker getCoworker(int id)
    {
        return cowCon.getCoworker(id);
    }
}
