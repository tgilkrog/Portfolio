package TuiLayer;

import ControllerLayer.*;
import ModelLayer.*;
import java.util.Scanner;

/**
 * Write a description of class InventoryUi here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class InventoryUi
{
    Scanner keyboard = new Scanner(System.in);
    private InventoryController iCtr;
    /**
     * Constructor for objects of class InventoryUi
     * @constructor
     */
    public InventoryUi()
    {
        iCtr = new InventoryController();
    }

    /**
     * Method for creating an inventory, with given attributes
     * @createInventory
     */
    public void createInventory(String barcode)
    {
        System.out.println("Enter amount of products ");
        int amount = keyboard.nextInt();

        System.out.println("Enter max amount in inventory ");
        int max = keyboard.nextInt();

        System.out.println("Enter min amount in inventory ");
        int min = keyboard.nextInt();

        keyboard.nextLine();

        System.out.println("Enter placement of product ");
        String placement = keyboard.nextLine();

        iCtr.createInventory(barcode, amount, max, min, placement);
    }

    /**
     * Method for adding more product to an Inventory
     * @addMoreInventory
     */
    public void addMoreInventory()
    {
        System.out.println("Enter the product(barcode), you wish too add more inventory to ");
        String barcode = keyboard.nextLine();

        System.out.println("Enter the amount you wish to add ");
        int amount = keyboard.nextInt();
        if((iCtr.getInventory(barcode).getAmount() + amount) > iCtr.getInventory(barcode).getMax())
        {
            System.out.println("You are trying to add more inventory than your max allows");
        }
        else{
            iCtr.getInventory(barcode).addAmount(amount);
        }
        keyboard.nextLine();
    }

    /**
     * Method for printing inventory, called from Inventory Controller
     * @printInventory
     */
    public void printInventory()
    {
        iCtr.printInventory();
    }

    /**
     * Method for printing product with low amount from Inventory, called from Inventory controller
     * @printLowInventory
     */
    public void printLowInventory()
    {
        iCtr.printLowInventory();
    }
}
