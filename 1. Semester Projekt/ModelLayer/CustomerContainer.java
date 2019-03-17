package ModelLayer;
import java.util.*;

/**
 * Write a description of class CustomerContainer here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class CustomerContainer
{
    private static CustomerContainer instance;
    private ArrayList<Customer> customers;
    /**
     * Constructor for objects of class CustomerContainer
     * @constructor
     */
    private CustomerContainer()
    {
        customers = new ArrayList<Customer>();
    }

    public static CustomerContainer getInstance()
    {
        if(instance == null)
        {
            instance = new CustomerContainer();

        }
        return instance;
    }

    /**
     * Method for adding a customer to the customers arraylist
     * @addCustomer
     */
    public void addCustomer (Customer cus)
    {
        customers.add(cus);
    }

    /**
     * Method for searching Customer in the customers arraylist, returns a customer
     * @getCustomer
     */
    public Customer getCustomer(int id) {
        Customer customer = null;      
        int index = 0;     
        boolean found = false; 
        while(index < customers.size() && !found) {  
            customer = customers.get(index); 
            if(customer.getId()==id) {
                found = true;
            }
            else {
                index++;  
            }
        } 
        if (found) {
            return customers.get(index);
        }
        else {   
            return null;
        }
    }
}
