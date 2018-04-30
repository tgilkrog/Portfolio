package ControlLayer;

import java.sql.SQLException;
import java.util.List;

import ModelLayer.*;
import DBLayer.DriverDB;

public class DriverController {
	private DriverDB driverDB = new DriverDB();
	
	/**
	 * Method for creating a Driver
	 * @createDriver
	 */
	public void createDriver(String firstName, String lastName, int phonenumber, String address, int zipCode,
			int registreringsNr, int carNr, boolean available, int id) throws SQLException {
		
		Driver dri = new Driver(firstName, lastName, phonenumber, address, zipCode,
				registreringsNr, carNr, available, id);
		dri = new DriverDB().create(dri);
	}
	
	/**
	 * Method for updating driver, takes several parameters.
	 * @updateDriver
	 */
	public void updateDriver(String firstName, String lastName, int phonenumber, String address, int zipcode,
			int registreringsNr, int carNr, int id) throws SQLException{
		
		driverDB.updateDriver(firstName, lastName, phonenumber, address, zipcode, registreringsNr, carNr, id);
	}
	
	/**
	 * Method for updating only the Availability of a driver.
	 * @updateAvailable
	 */
	public void updateAvailable(boolean av, int id) throws SQLException{
		driverDB.updateAvailable(av, id);
	}
	
	/**
	 * Method for deleting a driver by its ID, takes int as a parameter.
	 * @deleteDriver
	 */
	public void deleteDriver(int id) throws SQLException{
		try {
			driverDB.deleteDriver(id);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	/**
	 * Method for returning a list of Drivers
	 * @findAllDrivers
	 */
	public List<Driver> findAllDrivers() throws SQLException{
		return driverDB.findAll();
	}
	
	/**
	 * Method for returning a list with driver, takes a boolean parameter.
	 * So it returns only true or false available drivers.
	 * @pfindAllAvailableDrivers
	 */
	public List<Driver> findAllAvailableDrivers(boolean av) throws SQLException{
		return driverDB.findAllAvailableDrivers(av);
	}
	
	public Driver findDriverById(int id) throws SQLException{
		return driverDB.findDriverByID(id);
	}
}
