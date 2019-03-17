package TuiLayer;

import java.util.Scanner;
import ControllerLayer.*;
import ModelLayer.*;

/**
 * Write a description of class MainMenu here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class MainUi
{
    Scanner keyboard = new Scanner(System.in);

    private PersonUi perUi;
    private ProductUi proUi;
    private OrderUi ordUi;
    private InventoryUi iUi;
    /**
     * Constructor for objects of class MainMenu
     * @constructor
     */
    public MainUi()
    {
        perUi = new PersonUi();
        proUi = new ProductUi();
        ordUi = new OrderUi();
        iUi = new InventoryUi();

    }

    public void Start()
    {
        Menu();
    }

    /**
     * Main Menu method, which call other methods by a switch statement
     * @Menu
     */
    public void Menu()
    {
        boolean exit = false;
        while(!exit)
        {
            int choice = writeMainMenu();
            switch(choice){
                case 1: PersonMenu();
                    break;
                case 2: ProductMenu();
                    break;
                case 3: OrderMenu();
                    break;
                default: exit = true;
            }
        }
    }

    /**
     * Person Menu, which call other methods from the Person UI class
     * @PersonMenu
     */
    public void PersonMenu()
    {
        boolean exitP = false;
        while(!exitP)
        {
            int choice = writePersonMenu();
            switch(choice){
                case 1: perUi.CreateCustomer();
                    break;
                case 2: perUi.CreateCoworker();
                    break;
                case 3: perUi.getCustomer();
                    pause();
                    break;
                case 4: perUi.getCoworker();
                    pause();
                    break;
                default: exitP = true;
            }
        }
    }

    /**
     * Product Menu, which calls other methods from both Product UI and Inventory UI
     * @productMenu
     */
    public void ProductMenu()
    {
        boolean exitPro = false;

        while(!exitPro)
        {
            int choice = writeProductMenu();
            switch(choice){
                case 1: proUi.createProduct();
                    break;
                case 2: iUi.addMoreInventory();
                    pause();
                    break;
                case 3: iUi.printInventory();
                    pause();
                    break;
                case 4: iUi.printLowInventory();
                    pause();
                    break;
                default: exitPro = true;
            }
        }
    }

    /**
     * Order menu, which calls method from OrderUI
     * @OrderMenu
     */
    public void OrderMenu()
    {
        boolean exitOrd = false;

        while(!exitOrd)
        {
            int choice = writeOrderMenu();
            switch(choice){
                case 1: ordUi.CreateOrder();
                    pause();
                    break;
                case 2: ordUi.getOrder();
                    pause();
                    break;
                case 3: ordUi.deleteOrder();
                    break;
                case 4: ordUi.createDelOrder();
                    pause();
                    break;
                default: exitOrd = true;
            }
        }
    }

    /**
     * write Main Menu method, which prints the menu, and returns an int
     * @writeMainMenu
     */
    public int writeMainMenu()
    {
        System.out.println('\f');
        System.out.println("*** Main Menu ***" + "\n" +
            " (1) Person Menu " + "\n" +
            " (2) Product and Inventory Menu " + "\n" +
            " (3) Order Menu ");

        int choice = keyboard.nextInt();
        return choice;
    }

    /**
     * Write Person menu, which prints the menu, and returns an int
     * @writePersonMenu
     */
    public int writePersonMenu()
    {
        System.out.println('\f');
        System.out.println("*** Person Menu ***" + "\n" +
            " (1) Create Customer " + "\n" +
            " (2) Create Coworker " + "\n" +
            " (3) Get Customer " + "\n" +
            " (4) get Coworker ");

        int choice = keyboard.nextInt();
        return choice;
    }

    /**
     * Write Product menu, which prints the menu, and returns an int
     * @writeProductMenu
     */
    public int writeProductMenu()
    {
        System.out.println('\f');
        System.out.println("** Product Menu **" + "\n" +
            " (1) Create Product " + "\n" + 
            " (2) Order More inventory to a product " + "\n" +
            " (3) Print inventory" + "\n" +
            " (4) Print low inventory");

        int choice = keyboard.nextInt();
        return choice;
    }

    /**
     * Write Order menu, which prints the menu, and returns an int
     * @writeOrderMenu
     */
    public int writeOrderMenu()
    {
        System.out.println('\f');
        System.out.println("** Order Menu **" + "\n" +
            " (1) Create Order " + "\n" +
            " (2) Get Order " + "\n" +
            " (3) Delete Order " + "\n" +
            " (4) Add another product to an order");

        int choice = keyboard.nextInt();
        return choice;
    }

    /**
     * Method for pausing the terminal, which is used when printing, 
     * so the terminal doesnt instantanously overwrite it
     * @pause
     */
    private void pause()
    {
        Scanner keyboard = new Scanner(System.in);
        System.out.println("Press Enter to continue ");
        String een = keyboard.nextLine();
    }
}
