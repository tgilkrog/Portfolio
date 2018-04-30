package ControlLayer;

import java.sql.SQLException;
import java.util.List;

import DBLayer.OrderDB;
import ModelLayer.Order;

public class OrderController {
	private OrderDB oDB = new OrderDB();
	
	/**
	 * Method for creating an Order
	 * @createOrder
	 */
	public Order createOrder(String product, double weight, double height, String startAddress, String endAddress, String date, int id) throws SQLException {
		
		Order order = new Order(product, weight, height, startAddress, endAddress, date, id);
		order = new OrderDB().create(order);
		
		return order;
	}
	
	/**
	 * Method for updating an Order, takes several parameters.
	 * @updateOrder
	 */
	public void updateOrder(String product, double weight, double height, String startAddress, String endAddress, String date, int id) throws SQLException{
		oDB.updateOrder(product, weight, height, startAddress, endAddress, date, id);
	}
	
	/**
	 * Method for deleting an Order by its ID, takes an int as a parameter.
	 * @deleteOrder
	 */
	public void deleteOrder(int id) throws SQLException{
		oDB.deleteOrder(id);
	}
	
	/**
	 * Method for making a List with Orders, and then returning it.
	 * @getAllOrders
	 */
	public List<Order> getAllOrders() throws SQLException{
		return oDB.findAll();
	}
	
	/**
	 * Method for getting a order by its ID, and then returning it.
	 * @getOrderByID
	 */
	public Order getOrderByID(int id) throws SQLException{
		return oDB.findOrderByID(id);
	}
}
