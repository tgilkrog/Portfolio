package ControllerLayer;

import ModelLayer.*;


/**
 * Write a description of class ProductController here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class ProductController
{
    private ProductContainer pCon;
    
    /**
     * Constructor for objects of class ProductController
     * @constructor
     */
    public ProductController()
    {
        pCon = ProductContainer.getInstance();
    }
    
    /**
     * Method for creating a product, with the values given in the paramters, and then call a method from Product Container
     * @createProduct
     */
    public void createProduct(String barcode, String name, String description, double price, double height, double weight)
    {
        Product p = new Product(barcode, name, description, price, height, weight);
        pCon.addProduct(p);
        System.out.println("You have created the Product" + name);
    }
    
    /**
     * Method that returns a Product with the value in the parameter, calls method from Product Container
     * @getProduct
     */
    public Product getProduct(String barcode)
    {
        return pCon.getProduct(barcode);
    }
    
}
