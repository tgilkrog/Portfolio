package Test;

import static org.junit.Assert.*;

import java.sql.SQLException;

import org.junit.Before;
import org.junit.Test;

import ControlLayer.OrderController;
import DBLayer.OrderDB;
import ModelLayer.Order;
import ModelLayer.Route;

public class OrderTest {
	OrderDB oDB;
	OrderController oCtr;

	@Before
	public void setUp() throws SQLException {
		DBCleanup.cleanDB();
		oDB = new OrderDB();
		oCtr = new OrderController();
	}
	
	@Test
	public void testCreateOrder() {	
		Order o;
		try {
			o = oCtr.createOrder("K�l", 4, 4.20, "S�rup", "Aalborg", "2017/06/06", 3);
			assertNotNull(o);
			assertEquals("K�l", o.getProduct());
			assertEquals(4, o.getWeight(), 0);
			assertEquals(4.20, o.getHeight(), 0);
			assertEquals("S�rup", o.getStartAddress());
			assertEquals("Aalborg", o.getEndAddress());
			assertEquals("2017/06/06", o.getDate());
			assertEquals(3, o.getId());
		} catch (SQLException e) {
			System.out.print("Something in route is not what you expected it to be");
		}
	}

}
