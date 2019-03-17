package ModelLayer;


/**
 * Write a description of class Inventory here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Inventory
{
    private Product product;
    private int amount;
    private int max;
    private int min;
    private String placement;
    
    /**
     * Constructor for objects of class Inventory
     * @constructor
     */
    public Inventory(Product product, int amount, int max, int min, String placement)
    {
        this.product = product;
        this.amount = amount;
        this.max = max;
        this.min = min;
        this.placement = placement;
    }
    
    /**
     * Method for adding to the amount
     * @addAmount
     */
    public void addAmount(int addAmount)
    {
        amount += addAmount;
    }
    
    /**
     * Method for detracting from the amount
     * @detractAmount
     */
    public void detractAmount(int dAmount)
    {
        amount -= dAmount;
    }
    
    /**
     * Get and set methods
     * @Gets&Sets
     */
    public int getAmount()
    {
        return amount;
    }
    
    public Product getProduct()
    {
        return product;
    }
    
    public int getMin()
    {
        return min;
    }
    
    public int getMax()
    {
        return max;
    }
    
    public String getPlacement()
    {
        return placement;
    }
   
}
