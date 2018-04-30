package DBLayer;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import DBLayer.DBConnection;
import ModelLayer.Driver;

public class DriverDB {
	
	private static final String createDriverQ =
			"insert into driver (firstname, lastname, phonenumber, driver_address, zipcode, "
				+ "registreringsNr, carNr, available) values (?, ?, ?, ?, ?, ?, ?, ?)";
	
	private static final String findAllQ =
			"select * From driver, cities Where driver.zipcode = cities.zipcode";
	
	private static final String findByIdQ =
			"select * from driver, cities where id = ? and driver.zipcode = cities.zipcode";
	
	private static final String findAllByAvailableQ =
			"select * from driver, cities where available = ? and driver.zipcode = cities.zipcode";
	
	private static final String deleteDriverQ = "delete from driver Where id = ?";
	
	private static final String updateDriverQ = 
			"update driver set firstname = ?, lastname = ?, phonenumber = ?, driver_address = ?, "
			+ "zipcode = ?, registreringsNr = ?, carNr = ? where id = ?";
	
	private static final String updateAvailableQ =  "update driver set available = ? where id = ?";
	
	private PreparedStatement createDriver, findAll, findById, findAllByAvailable, deleteDriver, updateDriver, 
	updateAvailable;
	
	public DriverDB(){
		try {
			createDriver = DBConnection.getInstance().getConnection()
					.prepareStatement(createDriverQ, Statement.RETURN_GENERATED_KEYS);
			findAll = DBConnection.getInstance().getConnection()
					.prepareStatement(findAllQ);
			findById = DBConnection.getInstance().getConnection()
					.prepareStatement(findByIdQ);
			findAllByAvailable = DBConnection.getInstance().getConnection()
					.prepareStatement(findAllByAvailableQ);
			deleteDriver = DBConnection.getInstance().getConnection()
					.prepareStatement(deleteDriverQ);
			updateDriver = DBConnection.getInstance().getConnection()
					.prepareStatement(updateDriverQ);
			updateAvailable = DBConnection.getInstance().getConnection()
					.prepareStatement(updateAvailableQ);
		} 	
		catch (SQLException e) {
		}
	}
	
	public Driver create(Driver driver) throws SQLException {
		createDriver.setString(1,  driver.getFirstName());
		createDriver.setString(2,  driver.getLastName());
		createDriver.setInt(3, driver.getPhonenumber());
		createDriver.setString(4, driver.getAddress());
		createDriver.setInt(5, driver.getZipCode());
		createDriver.setInt(6,  driver.getRegistreringsNr());
		createDriver.setInt(7, driver.getCarNr());
		createDriver.setBoolean(8, driver.getAvailable());
		
		
		int id = DBConnection.getInstance().executeInsertWithIdentity(createDriver);
		driver.setId(id);
		return driver;
	}
	
	public void updateDriver(String firstName, String lastName, int phonenumber, String address, int zipcode,
			int registreringsNr, int carNr, int id) throws SQLException {		
			updateDriver.setString(1, firstName);
			updateDriver.setString(2, lastName);
			updateDriver.setInt(3, phonenumber);
			updateDriver.setString(4, address);
			updateDriver.setInt(5, zipcode);
			updateDriver.setInt(6, registreringsNr);
			updateDriver.setInt(7, carNr);
			updateDriver.setInt(8, id);
			updateDriver.executeUpdate();			
	}
	public void updateAvailable(boolean av, int id) throws SQLException{
		updateAvailable.setBoolean(1, av);
		updateAvailable.setInt(2, id);
		updateAvailable.executeUpdate();
	}
	
	public void deleteDriver(int id) throws SQLException{
		deleteDriver.setInt(1, id);
		deleteDriver.executeUpdate();
	}
	
	public List<Driver> findAll() throws SQLException  {
		ResultSet rs;

			rs = findAll.executeQuery();
			List<Driver> res = buildObjects(rs);
			return res;
	} 
	
	public Driver findDriverByID(int id) throws SQLException{
		findById.setInt(1, id);
		ResultSet rs = findById.executeQuery();
		Driver d = null;
		if(rs.next()) {
			d = buildObject(rs);
		}
		return d;
	}
	
	public List<Driver> findAllAvailableDrivers(boolean av)throws SQLException{
		findAllByAvailable.setBoolean(1, av);
		ResultSet rs;

		rs = findAllByAvailable.executeQuery();
		List<Driver> res = buildObjects(rs);
		return res;
	}
	
	private Driver buildObject(ResultSet rs) throws SQLException {
		Driver d = null;
		d = new Driver();
		d.setFirstName(rs.getString("firstname"));
		d.setLastName(rs.getString("lastname"));
		d.setPhonenumber(rs.getInt("phonenumber"));
		d.setAddress(rs.getString("driver_address"));
		d.setCity(rs.getString("city"));
		d.setZipCode(rs.getInt("zipcode"));
		d.setRegistreringsNr(rs.getInt("registreringsNr"));
		d.setCarNr(rs.getInt("carNr"));
		d.setAvailable(rs.getBoolean("available"));
		d.setId(rs.getInt("id"));
		return d;
	}
	
	private List<Driver> buildObjects(ResultSet rs) throws SQLException {
		List<Driver> res = new ArrayList<>();
		while(rs.next()) {
			Driver d = buildObject(rs);
			res.add(d);
		}
		return res;
	}
}
