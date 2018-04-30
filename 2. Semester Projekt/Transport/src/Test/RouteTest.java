package Test;

import static org.junit.Assert.*;

import java.sql.SQLException;
import java.util.List;

import org.junit.Before;
import org.junit.Test;

import ControlLayer.RouteController;
import DBLayer.*;
import ModelLayer.*;

public class RouteTest {
	RouteController rCtr;
	DriverDB dDB;
	OrderDB oDB;

	@Before
	public void setUp() throws SQLException {
		DBCleanup.cleanDB();
		rCtr = new RouteController();
		dDB = new DriverDB();
		oDB = new OrderDB();
	}
	
	@Test
	public void testCreateRoute() {	
		Route r;
		try {
			r = rCtr.createRoute(dDB.findDriverByID(1), oDB.findOrderByID(1), 10, 10);
			assertNotNull(r);
			assertEquals("Jens", r.getDriver().getFirstName());
			assertEquals("Beton", r.getOrder().getProduct());
			assertEquals(10, r.getTime(), 0);
			assertEquals(10, r.getLength(), 0);
			dDB.updateAvailable(false, 1);
		} catch (SQLException e) {
			System.out.print("Something in route is not what you expected it to be");
		}
	}
	
	@Test
	public void testCreateRouteFalse() {	
		Route r;
		try {
			r = rCtr.createRoute(dDB.findDriverByID(2), oDB.findOrderByID(1), 10, 10);
			assertNotNull(r);
			assertNotSame("Forkert", r.getDriver().getFirstName());
			assertNotSame("Forkert", r.getOrder().getProduct());
			assertEquals(10, r.getTime(), 0);
			assertEquals(10, r.getLength(), 0);
			dDB.updateAvailable(false, 1);
		} catch (SQLException e) {
			System.out.print("Something in route is not what you expected it to be");
		}
	}
}












