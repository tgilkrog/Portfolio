package ModelLayer;
import java.util.*;

/**
 * Write a description of class CoworkerContainer here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class CoworkerContainer
{
    private static CoworkerContainer instance;
    private ArrayList<Coworker> coworkers;
    
    /**
     * Constructor for objects of class CoworkerContainer
     * @constructor
     */
    private CoworkerContainer()
    {
        coworkers = new ArrayList<Coworker>();
    }
    
    public static CoworkerContainer getInstance()
    {
        if(instance == null)
        {
            instance = new CoworkerContainer();
        }
        return instance;
    }
    
    /**
     * Method for adding a Coworker to the coworkers arraylist
     * @addCoworker
     */
    public void addCoworker(Coworker cow)
    {
        coworkers.add(cow);
    }
    
    /**
     * Method for searching a coworker in the coworkers arraylist, returns a coworker
     * @getCoworker
     */
    public Coworker getCoworker(int id) {
        Coworker coworker = null;      
        int index = 0;     
        boolean found = false; 
        while(index < coworkers.size() && !found) {  
            coworker = coworkers.get(index); 
            if(coworker.getId()==id) {
                found = true;
            }
            else {
                index++;  
            }
        } 
        if (found) {
            return coworkers.get(index);
        }
        else {   
            return null;
        }
    }
}
