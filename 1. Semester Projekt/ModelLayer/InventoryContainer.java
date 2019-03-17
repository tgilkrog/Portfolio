package ModelLayer;

import java.util.ArrayList;

/**
 * Write a description of class InventoryContainer here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class InventoryContainer
{
    private static InventoryContainer instance;
    private ArrayList<Inventory> inventories;
    /**
     * Constructor for objects of class InventoryContainer
     * @constructor
     */
    private InventoryContainer()
    {
        inventories = new ArrayList<>();
    }

    public static InventoryContainer getInstance()
    {
        if(instance == null)
        {
            instance = new InventoryContainer();
        }
        return instance;
    }

    /**
     * Method for addin an Inventory to the inventories arraylist
     * @addInventory
     */
    public void addInventory(Inventory inv)
    {
        inventories.add(inv);
    }

    /**
     * Method for searching for prodct in the inventories arraylist, return inventory
     * @getInventory
     */
    public Inventory getInventory(String barcode) {
        Inventory inventory = null;      
        int index = 0;     
        boolean found = false; 
        while(index < inventories.size() && !found) {  
            inventory = inventories.get(index); 
            if(inventory.getProduct().getBarcode().equals(barcode)) {
                found = true;
            }
            else {
                index++;  
            }
        } 
        if (found) {
            return inventories.get(index);
        }
        else {   
            return null;
        }
    }

    /**
     * Method for printing product and inventory values
     * @printInventory
     */
    public void printInventory()
    {
        for(Inventory inv: inventories)
        {
            System.out.println("Product Name: " + inv.getProduct().getName() + "\n" +
                "amount: " + inv.getAmount() + "\n" + 
                "max: " + inv.getMax() + "\n" +
                "min: " + inv.getMin() + "\n" + 
                "Placement " + inv.getPlacement());
        }
    }

    /**
     * Method for printing product with low amount in inventory
     * @printLowInventory
     */
    public void printLowInventory()
    {
        for(Inventory inv: inventories)
        {
            if(inv.getAmount() <= inv.getMin())
            {
                System.out.println("Product Name: " + inv.getProduct().getName() + "\n" +
                    "amount: " + inv.getAmount() + "\n" + 
                    "max: " + inv.getMax() + "\n" +
                    "min: " + inv.getMin() + "\n" + 
                    "Placement: " + inv.getPlacement());            
            }
        }
    }

}
