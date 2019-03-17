package ControllerLayer;

import ModelLayer.*;

/**
 * Write a description of class OrderController here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class OrderController
{
    private OrderContainer oCon;
    private ProductController pCtr;
    private PersonController peCtr;
    private InventoryController iCtr;

    /**
     * Constructor for objects of class OrderController
     * @constructor
     */
    public OrderController()
    {
        oCon = oCon.getInstance();
        pCtr = new ProductController();
        peCtr = new PersonController();
        iCtr = new InventoryController();
    }

    /**
     * Method for creating an Order, with values from the paramters, calls several methods from other classes
     * @createOrder
     */
    public void createOrder(int id, int idCu, int idCo, String date, double discount)
    {
        Order o = new Order(id, peCtr.getCustomer(idCu), peCtr.getCoworker(idCo), date, discount);
        oCon.addOrder(o);
        peCtr.getCoworker(idCo).addOrder(o);
        peCtr.getCustomer(idCu).addOrder(o);
    }

    /**
     * Method for creating delOrder, with values from the parameters, calls several methods from other classes
     * @createDelOrder
     */
    public void createDelOrder(int amount, String barcode, int id)
    {
        DelOrder del = new DelOrder(amount, pCtr.getProduct(barcode), oCon.getOrder(id));
        oCon.getOrder(id).addDelOrder(del);
    }

    /**
     * Method for returning an Order, with the value from the parameter, calls method from Order Container
     * @getOrder
     */
    public Order getOrder(int id)
    {
        return oCon.getOrder(id);
    }

    /**
     * Method for deleting an Order, with the value from the parameter, calls method from Order Container
     * @deleteOrder
     */
    public void deleteOrder(int id)
    {
        oCon.deleteOrder(id);
    }

}
