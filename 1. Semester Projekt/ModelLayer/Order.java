package ModelLayer;

import java.util.ArrayList;

/**
 * Write a description of class Order here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Order
{
    private int id;
    private Customer customer;
    private Coworker coworker;
    private DelOrder delOrder;
    private InventoryContainer iCon;
    private ArrayList<DelOrder> delOrders;
    private String date;
    private double discount;
    private double sum;

    /**
     * Constructor for objects of class Order
     * @constructor
     */
    public Order(int id, Customer customer, Coworker coworker, String date, double discount)
    {
        this.id = id;
        this.customer = customer;
        this.coworker = coworker;
        this.date = date;
        this.discount = discount;
        delOrders = new ArrayList<>();
    }

    /**
     * Method for adding a delorder to the delOrders arraylist
     * @addDelOrder
     */
    public void addDelOrder(DelOrder d)
    {
        delOrders.add(d);
    }

    /**
     * Get and Set methods
     * @Gets&Sets
     */
    public int getId()
    {
        return id;
    }

    public Customer getCustomerer()
    {
        return customer;
    }

    public Coworker getCoworker()
    {
        return coworker;
    }

    public DelOrder getDelorder()
    {
        return delOrder;
    }

    public String getDate()
    {
        return date;
    }

    public double getDiscount()
    {
        return discount;
    }

    /**
     * Method for calculating the sum, of all products in the delOrders arraylist
     * @getSum
     */
    public double getSum()
    {
        double sum = 0;
        for(DelOrder delO: delOrders)
        {
            sum= delO.getAmount() * delO.getProduct().getPrice() +sum;
        }
        return sum;
    }

    /**
     * Method for printing all delorder in the delOrders arraylist
     * @printDelOrder
     */
    public void printDelOrder()
    {
        iCon = InventoryContainer.getInstance();
        for(DelOrder delO: delOrders)
        {
            System.out.println("   Product: " + delO.getProduct().getName());
            System.out.println("   Price: " + delO.getProduct().getPrice());
            System.out.println("   Amount: " + delO.getAmount());
            System.out.println("   Placement: " + iCon.getInventory(delO.getProduct().getBarcode()).getPlacement());
        }
    }

    /**
     * Method for searching delOrder in the delorders arraylist, return the delorder
     * @getDelOrder
     */
    public DelOrder getDelOrder(String barcode) {
        DelOrder delOrder = null;      
        int index = 0;     
        boolean found = false; 
        while(index < delOrders.size() && !found) {  
            delOrder = delOrders.get(index); 
            if(delOrder.getProduct().getBarcode().equals(barcode)) {
                found = true;
            }
            else {
                index++;  
            }
        } 
        if (found) {
            return delOrders.get(index);
        }
        else {   
            return null;
        }
    }
}
