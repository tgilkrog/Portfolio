package ControllerLayer;

import ModelLayer.*;

/**
 * Write a description of class InventoryController here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class InventoryController
{
    private InventoryContainer iCon;
    private ProductController pCtr;
    /**
     * Constructor for objects of class InventoryController
     * @constructor
     */
    public InventoryController()
    {
        iCon = InventoryContainer.getInstance();
        pCtr = new ProductController();
    }

    /**
     * Method for creating an Inventory, with given values from the parameters, calls a method from Inventory Container
     * @createInventory
     */
    public void createInventory(String barcode, int amount, int max, int min, String placement)
    {
        Inventory i = new Inventory(pCtr.getProduct(barcode), amount, max, min, placement);
        iCon.addInventory(i);
    }

    /**
     * Method for returning an Inventory with the value from the parameter, calls a method from Inventory container
     * @getInventory
     */
    public Inventory getInventory(String barcode)
    {
        return iCon.getInventory(barcode);
    }
    
    /**
     * Method for printing an Inventory, calls a method from Inventory Container
     * @printInventory
     */
    public void printInventory()
    {
        iCon.printInventory();
    }
    
    /**
     * Method for printing product with low amount in inventory, calls a method from Inventory Container
     * @printLowInventory
     */
    public void printLowInventory()
    {
        iCon.printLowInventory();
    }
}
