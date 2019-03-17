package TuiLayer;

import java.util.Scanner;
import ControllerLayer.*;
import ModelLayer.*;

/**
 * Write a description of class PersonMenu here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class PersonUi
{
    private PersonController pCtr;
    Scanner keyboard = new Scanner(System.in);
    /**
     * Constructor for objects of class PersonMenu
     * @constructor
     */
    public PersonUi()
    {
        pCtr = new PersonController();
    }

    /**
     * Method for creating a Customer, with given attributes
     * @createCustomer
     */
    public void CreateCustomer()
    {
        System.out.println("Enter ID" );
        int id = keyboard.nextInt();
        keyboard.nextLine();

        System.out.println("Enter name ");
        String name = keyboard.nextLine();

        System.out.println("Enter Address ");
        String address = keyboard.nextLine();

        System.out.println("Enter phonenumber ");
        String phone = keyboard.nextLine();

        System.out.println("Enter Email ");
        String email = keyboard.nextLine();

        pCtr.CreateCustomer(id, name, address, phone, email);
    }

    /**
     * Method for creating a Coworker, with given attributes
     * @createCoworker
     */
    public void CreateCoworker()
    {
        System.out.println("Enter ID" );
        int id = keyboard.nextInt();
        keyboard.nextLine();

        System.out.println("Enter name ");
        String name = keyboard.nextLine();

        System.out.println("Enter address ");
        String address = keyboard.nextLine();

        System.out.println("Enter phone ");
        String phone = keyboard.nextLine();

        System.out.println("Enter email ");
        String email = keyboard.nextLine();

        System.out.println("Enter workstatus ");
        String workStatus = keyboard.nextLine();

        System.out.print("Enter wages ");
        double wages = keyboard.nextDouble();

        pCtr.CreateCoworker(id, name, address, phone, email, workStatus, wages);
    }

    /**
     * Method for printing a specific Customer, with given ID
     * @getCustomer
     */
    public void getCustomer()
    {
        System.out.println("Enter Customers ID ");
        int id = keyboard.nextInt();

        if(pCtr.getCustomer(id) == null)
        {
            System.out.println("The Customer id does not exist");
        }
        else{
            System.out.println("\n** Customer informaiton **" + "\n" +
                "Name: " + pCtr.getCustomer(id).getName() + "\n" +
                "Address " + pCtr.getCustomer(id).getAddress() + "\n" +
                "Phonenumber " + pCtr.getCustomer(id).getPhone() + "\n" +
                "email: " + pCtr.getCustomer(id).getEmail());
        }
    }

    /**
     * Method for printing a specific Coworker, with given ID
     * @getCoworker
     */
    public void getCoworker()
    {
        System.out.println("Enter Coworker ID ");
        int id = keyboard.nextInt();

        if(pCtr.getCoworker(id) == null)
        {
            System.out.println("The Coworker id does not exist");
        }
        else{
            System.out.println("\n** Coworker informaiton **" + "\n" +
                "Name: " + pCtr.getCoworker(id).getName() + "\n" +
                "Address " + pCtr.getCoworker(id).getAddress() + "\n" +
                "Phonenumber " + pCtr.getCoworker(id).getPhone() + "\n" +
                "email: " + pCtr.getCoworker(id).getEmail() + "\n" +
                "Work Status: " + pCtr.getCoworker(id).getWorkStatus() + "\n" +
                "Wages: " + pCtr.getCoworker(id).getWages());
        }
    }
}
