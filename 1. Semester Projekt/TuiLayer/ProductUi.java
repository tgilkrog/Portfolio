package TuiLayer;

import java.util.Scanner;
import ControllerLayer.*;
import ModelLayer.*;


/**
 * Write a description of class ProductMenu here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class ProductUi
{
    private ProductController pCtr;
    private InventoryUi iUi;
    Scanner keyboard = new Scanner(System.in);
    /**
     * Constructor for objects of class ProductMenu
     * @constructor
     */
    public ProductUi()
    {
        pCtr = new ProductController();
        iUi = new InventoryUi();
    }
    
    /**
     * Method for creating a Product, with given attributes
     * @createProduct
     */
    public void createProduct()
    {
        System.out.println("Enter barcode ");
        String barcode = keyboard.nextLine();
        
        System.out.println("Enter name ");
        String name = keyboard.nextLine();
        
        System.out.println("Enter description");
        String description = keyboard.nextLine();
        
        System.out.println("Enter price ");
        int price = keyboard.nextInt();
        
        System.out.println("Enter height");
        int height = keyboard.nextInt();
        
        System.out.println("Enter weight ");
        int weight = keyboard.nextInt();
        
        pCtr.createProduct(barcode, name, description, price, height, weight);
        
        iUi.createInventory(barcode);
        keyboard.nextLine();
    }
}
