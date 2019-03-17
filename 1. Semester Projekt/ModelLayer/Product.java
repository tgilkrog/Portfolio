package ModelLayer;

/**
 * Write a description of class Product here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Product
{
    private String barcode;
    private String name;
    private String description;
    private double price;
    private double height;
    private double weight;
    /**
     * Constructor for objects of class Product
     * @constructor
     */
    public Product(String barcode, String name, String description, double price, double height, double weight)
    {
        this.barcode = barcode;
        this.name = name;
        this.description = description;
        this.price = price;
        this.height = height;
        this.weight = weight;

    }

    /**
     * Get and Set methods
     * @Gets&Sets
     */
    public String getBarcode()
    {
        return barcode;
    }

    public String getName()
    {
        return name;
    }

    public String getDescription()
    {
        return description;
    }

    public double getPrice()
    {
        return price;
    }

    public double getHeight()
    {
        return height;
    }

    public double getWeight()
    {
        return weight;
    }
}
