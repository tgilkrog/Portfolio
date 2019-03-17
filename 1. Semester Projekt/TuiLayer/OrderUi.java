package TuiLayer;
import ModelLayer.*;
import ControllerLayer.*;
import java.util.Scanner;
import java.io.IOException;

/**
 * Write a description of class OrderMenu here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class OrderUi
{
    private OrderController oCtr;
    Scanner keyboard = new Scanner(System.in);
    private ProductController pCtr;
    private InventoryController iCtr;
    private PersonController peCtr;

    /**
     * Constructor for objects of class OrderMenu
     * @constructor
     */
    public OrderUi()
    {
        oCtr = new OrderController();
        pCtr = new ProductController();
        iCtr = new InventoryController();
        peCtr = new PersonController();
    }

    /**
     * Method for creating an Order, with given attributes
     * @createOrder
     */
    public void CreateOrder()
    {
        System.out.println("Enter Id ");
        int id = keyboard.nextInt();

        System.out.println("Enter Customer ID ");
        int idCu = keyboard.nextInt();
        if(peCtr.getCustomer(idCu) == null){System.out.println("The customer id does not exist");}
        else{
            System.out.println("Enter Coworker ID ");
            int idCo = keyboard.nextInt();
            keyboard.nextLine();
            if(peCtr.getCoworker(idCo) == null){System.out.println("The Coworker id does not exist");}
            else{
                System.out.println("Enter date ");
                String date = keyboard.nextLine();

                System.out.println("Enter discount ");
                double discount = keyboard.nextDouble();

                boolean dis = false;
                while(!dis){
                    if(discount > 30 && !peCtr.getCoworker(idCo).getWorkStatus().equals("Chef"))
                    {
                        System.out.println("you cannot make a discount bigger than 30%"); 
                        System.out.println("Enter discount of 30 or lower");
                        discount = keyboard.nextDouble();
                    }
                    else{dis = true;}
                }
                oCtr.createOrder(id, idCu, idCo, date, discount);
                System.out.println("you Order has been created with the id " + id);

                boolean state = false;
                while(!state){
                    oCtr.getOrder(id);
                    keyboard.nextLine();
                    System.out.println("Enter Product barcode ");
                    String barcode = keyboard.nextLine();
                    if(pCtr.getProduct(barcode) == null){System.out.println("The Product barcode does not exist"); state = true;}
                    else{
                        System.out.println("Enter amount ");
                        int amount = keyboard.nextInt();
                        if(iCtr.getInventory(barcode).getAmount() >= amount){
                            oCtr.createDelOrder(amount, barcode, id);
                            iCtr.getInventory(barcode).detractAmount(amount);

                            System.out.println(" Current amount of products left in the inventory =  " + iCtr.getInventory(barcode).getAmount() );
                            System.out.println(" Amount of products available for sale before an order for new products will be made = " + (iCtr.getInventory(barcode).getAmount() - iCtr.getInventory(barcode).getMin()));

                            System.out.println("Press 1 to add another product, 2 to stop");
                            int choice = keyboard.nextInt();
                            if(choice == 2){state = true;}
                        }
                        else{System.out.println("You dont have enough amount of products, you only have: " + iCtr.getInventory(barcode).getAmount()); state = true;}

                    }
                }
            }
        }
    }

    /**
     * Method for creating a DelOrder, by finding an Order, and give attributes
     * @createDelOrder
     */
    public void createDelOrder()
    {
        boolean state = false;
        while(!state){
            System.out.println("Enter Id Of the order you wish to add a product to");
            int id = keyboard.nextInt();
            keyboard.nextLine();
            if(oCtr.getOrder(id) == null){System.out.println("The order id does not exist"); state = true;}       
            else{
                System.out.println("Enter Product barcode ");
                String barcode = keyboard.nextLine();
                if(pCtr.getProduct(barcode) == null){System.out.println("The product barcode does not exist"); state = true;}
                else{
                    System.out.println("Enter amount ");
                    int amount = keyboard.nextInt();
                    if(iCtr.getInventory(barcode).getAmount() > amount){
                        oCtr.createDelOrder(amount, barcode, id);

                        iCtr.getInventory(barcode).detractAmount(amount);

                        System.out.println("Press 1 to add another product, 2 to stop");
                        int choice = keyboard.nextInt();
                        if(choice == 2){state = true;
                        }
                    }
                    else{System.out.println("You dont have enough amount of products, you only have: " + iCtr.getInventory(barcode).getAmount()); state = true;}
                }
            }
        }
    }

    /**
     * Method for printing a specific Order, with given ID
     * @getOrder
     */
    public void getOrder()
    {
        System.out.println("Enter Order ID ");
        int id = keyboard.nextInt();

        if(oCtr.getOrder(id) == null)
        {
            System.out.println(" The Order Id does not exist");
        }
        else{
            System.out.println("Order ID: " + oCtr.getOrder(id).getId() + "\n" +
                "Customer Name: "+ oCtr.getOrder(id).getCustomerer().getName() + "\n" +
                "Coworker Name: " + oCtr.getOrder(id).getCoworker().getName() + ", WorkStatus: " + oCtr.getOrder(id).getCoworker().getWorkStatus() + "\n" +
                "Discount: " + oCtr.getOrder(id).getDiscount() + "%");
            oCtr.getOrder(id).printDelOrder();

            System.out.println("Sum " + oCtr.getOrder(id).getSum() + "\n" + 
                "Sum with discount " + (oCtr.getOrder(id).getSum() - ((oCtr.getOrder(id).getSum()/100) * oCtr.getOrder(id).getDiscount())));
        }
    }

    /**
     * Method for Deleting an Order, with given ID
     * @deleteOrder
     */
    public void deleteOrder()
    {
        System.out.print("Enter order ID ");
        int id = keyboard.nextInt();

        oCtr.deleteOrder(id);
    }

}
