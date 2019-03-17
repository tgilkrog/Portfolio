package ModelLayer;
import java.util.*;

/**
 * Write a description of class ProductContainer here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class ProductContainer
{
    private ArrayList<Product> products;
    private static ProductContainer instance;
    /**
     * Constructor for objects of class ProductContainer
     * @constructor
     */
    private ProductContainer()
    {
        products = new ArrayList<Product>();
    }

    public static ProductContainer getInstance()
    {
        if(instance == null)
        {
            instance = new ProductContainer();
        }
        return instance;
    }

    /**
     * Method for adding a product to the products arraylist
     * @addProduct
     */
    public void addProduct(Product p)
    {
        products.add(p);
    }

    /**
     * Method for searching a product in the products arraylist, return the product
     * @getProduct
     */
    public Product getProduct(String barcode) {
        Product product = null;      
        int index = 0;     
        boolean found = false; 
        while(index < products.size() && !found) {  
            product = products.get(index); 
            if(product.getBarcode().equals(barcode)) {
                found = true;
            }
            else {
                index++;  
            }
        } 
        if (found) {
            return products.get(index);
        }
        else {   
            return null;
        }
    }
}
