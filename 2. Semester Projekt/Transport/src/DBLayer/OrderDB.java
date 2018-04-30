package DBLayer;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import ModelLayer.Driver;
import ModelLayer.Order;

public class OrderDB {
	
	private static final String createOrderQ =
			"insert into torder (product, order_weight, height, startAddress, endAddress, order_date) "
				+ " values (?, ?, ?, ?, ?, ?)";
	
	private static final String findAllOrderQ =
			"select * FROM torder";
	
	private static final String findOrderByIdQ =
			findAllOrderQ + " where id = ?";
	
	private static final String deleteOrderQ = "delete from torder Where id = ?";
	
	private static final String updateOrderQ =
			"update torder set product = ?, order_weight = ?, height = ?, startAddress = ?, endAddress = ?, order_date = ? where id = ?";
	
	private PreparedStatement createOrder, findAllOrders, findOrderById, deleteOrder, updateOrder;
	
	public OrderDB() {
		try{
			createOrder = DBConnection.getInstance().getConnection()
					.prepareStatement(createOrderQ, Statement.RETURN_GENERATED_KEYS);
			findAllOrders = DBConnection.getInstance().getConnection()
					.prepareStatement(findAllOrderQ);
			findOrderById = DBConnection.getInstance().getConnection()
					.prepareStatement(findOrderByIdQ);
			deleteOrder = DBConnection.getInstance().getConnection()
					.prepareStatement(deleteOrderQ);
			updateOrder = DBConnection.getInstance().getConnection()
					.prepareStatement(updateOrderQ);

		}
		catch (SQLException e) {
		}
	}
	
	public Order create(Order order) throws SQLException {
		createOrder.setString(1, order.getProduct());
		createOrder.setDouble(2, order.getWeight());
		createOrder.setDouble(3, order.getHeight());
		createOrder.setString(4, order.getStartAddress());
		createOrder.setString(5, order.getEndAddress());
		createOrder.setString(6, order.getDate());
		
		int id = DBConnection.getInstance().executeInsertWithIdentity(createOrder);
		order.setId(id);
		return order;
	}
	public void updateOrder(String product, double weight, double height, String startAddress, String endAddress, String date,
			int id) throws SQLException {		
			updateOrder.setString(1, product);
			updateOrder.setDouble(2, weight);
			updateOrder.setDouble(3, height);
			updateOrder.setString(4, startAddress);
			updateOrder.setString(5, endAddress);
			updateOrder.setString(6, date);
			updateOrder.setInt(7, id);
			updateOrder.executeUpdate();			
	}
	
	public void deleteOrder(int id) throws SQLException{
		deleteOrder.setInt(1, id);
		deleteOrder.executeUpdate();
	}
	
	public List<Order> findAll() throws SQLException  {
		ResultSet rs;

			rs = findAllOrders.executeQuery();
			List<Order> res = buildObjects(rs);
			return res;
	} 
	
	public Order findOrderByID(int id) throws SQLException{
		findOrderById.setInt(1, id);
		ResultSet rs = findOrderById.executeQuery();
		Order o = null;
		if(rs.next()) {
			o = buildObject(rs);
		}
		return o;
	}
	
	private Order buildObject(ResultSet rs) throws SQLException {
		Order o = null;
		o = new Order();
		o.setProduct(rs.getString("product"));
		o.setWeight(rs.getDouble("order_weight"));
		o.setHeight(rs.getDouble("height"));
		o.setStartAddress(rs.getString("startAddress"));
		o.setEndAddress(rs.getString("endAddress"));
		o.setDate(rs.getString("order_date"));
		o.setId(rs.getInt("id"));
		return o;
	}
	
	private ArrayList<Order> buildObjects(ResultSet rs) throws SQLException {
		ArrayList<Order> res = new ArrayList<>();
		while(rs.next()) {
			Order o = buildObject(rs);
			res.add(o);
		}
		return res;
	}
}
