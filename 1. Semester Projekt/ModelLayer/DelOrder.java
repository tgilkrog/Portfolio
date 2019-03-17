package ModelLayer;


/**
 * Write a description of class DelOrder here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class DelOrder
{
    private int amount;
    private Product product;
    private Order order;
    
    /**
     * Constructor for objects of class DelOrder
     * @constructor
     */
    public DelOrder(int amount, Product product, Order order)
    {
        this.amount = amount;
        this.product = product;
        this.order = order;
    }
    
    /**
     * Get and Set methods
     * @Gets&Sets
     */
    public Product getProduct()
    {
        return product;
    }
    
    public int getAmount()
    {
        return amount;
    }
}
