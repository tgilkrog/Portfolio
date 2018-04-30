package DBLayer;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import javax.swing.JOptionPane;

import ModelLayer.Route;
import ModelLayer.Driver;
import ModelLayer.Order;
import DBLayer.DriverDB;
import DBLayer.OrderDB;

public class RouteDB {
	private DriverDB driDB;
	private OrderDB ordDB;
	
	private static final String createRouteQ =
			"insert into troute (driver_id, order_id, route_length, route_time) values (?, ?, ?, ?)";
	
	private static final String findAllRouteQ =
			"select * FROM troute";
	
	private static final String deleteRouteQ = "delete from troute Where id = ?";
	
	private PreparedStatement createRoute, findAllRoute, deleteRoute;
	
	public RouteDB(){
		driDB = new DriverDB();
		ordDB = new OrderDB();
		
		try {
			createRoute = DBConnection.getInstance().getConnection()
					.prepareStatement(createRouteQ, Statement.RETURN_GENERATED_KEYS);
			findAllRoute = DBConnection.getInstance().getConnection()
					.prepareStatement(findAllRouteQ);
			deleteRoute = DBConnection.getInstance().getConnection()
					.prepareStatement(deleteRouteQ);
		} 
		catch (SQLException e) {
		}
	}
	
	public Route create(Route route) throws SQLException {
		createRoute.setInt(1, route.getDriver().getId());
		createRoute.setInt(2, route.getOrder().getId());
		createRoute.setDouble(3, route.getLength());
		createRoute.setDouble(4, route.getTime());
		
		int id = DBConnection.getInstance().executeInsertWithIdentity(createRoute);
		route.setId(id);
		return route;
	}
	
	public void deleteRoute(int id) throws SQLException{
		deleteRoute.setInt(1, id);
		deleteRoute.executeUpdate();
	}
	
	public List<Route> findAllRoute() throws SQLException  {
		ResultSet rs;

			rs = findAllRoute.executeQuery();
			List<Route> res = buildObjects(rs);
			return res;
	} 
	
	private Route buildObject(ResultSet rs) throws SQLException {
		Route r = null;
		r = new Route();
		r.setId(rs.getInt("id"));
		r.setDriver(driDB.findDriverByID((rs.getInt("driver_id"))));
		//r.setDriver(rs.getStatement(driDB.findDriverByID(Integer.parseInt("driver_id"))));
		r.setOrder(ordDB.findOrderByID((rs.getInt("order_id"))));
		//r.setOrder(ordDB.findOrderByID(Integer.parseInt("order_id")));
		r.setLength(rs.getDouble("route_length"));
		r.setTime(rs.getDouble("route_time"));
		
		return r;
	}
	
	private List<Route> buildObjects(ResultSet rs) throws SQLException {
		List<Route> res = new ArrayList<>();
		while(rs.next()) {
			Route r = buildObject(rs);
			res.add(r);
		}
		return res;
	}
}