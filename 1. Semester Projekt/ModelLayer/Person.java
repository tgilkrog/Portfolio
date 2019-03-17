package ModelLayer;


/**
 * Write a description of class Person here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public abstract class Person
{
    private int id;
    private String name;
    private String address;
    private String phone;
    private String email;
    
    /**
     * Constructor for objects of class Person
     * @constructor
     */
    public Person(int id, String name, String address, String phone, String email)
    {
        this.id = id;
        this.name = name;
        this.address = address;
        this.phone = phone;
        this.email = email;
    }
    
    /**
     * Get and Set methods
     * @Gets&Sets
     */
    public int getId()
    {
        return id;
    }
    
    public String getName()
    {
        return name;
    }
    
    public String getAddress()
    {
        return address;
    }
    
    public String getPhone()
    {
        return phone;
    }
    
    public String getEmail()
    {
        return email;
    }
}
