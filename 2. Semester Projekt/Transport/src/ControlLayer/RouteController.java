package ControlLayer;

import java.sql.SQLException;
import java.util.List;

import DBLayer.RouteDB;
import ModelLayer.Driver;
import ModelLayer.Order;
import ModelLayer.Route;
import ModelLayer.AStarPath.MapTransport;;

public class RouteController {
	private RouteDB routeDB;
	private MapTransport mapTransport;
	private OrderController ordCtr;
	private DriverController driCtr;
	
	public RouteController() {
		mapTransport = new MapTransport();
		routeDB = new RouteDB();
		ordCtr = new OrderController();
		driCtr = new DriverController();
	}
	
	/**
	 * Method for creating a Route, takes several parameters.
	 * @createRoute
	 */
	public Route createRoute( Driver d, Order o, double time, double length) throws SQLException{	
		Route route = new Route(d, o, time, length);
			return route = new RouteDB().create(route);
	}
	
	/**
	 * Method for updating a drivers availability, read from driverController
	 * @updateDriverAvailable
	 */
	public void updateDriverAvailable(boolean av, int id) throws SQLException{
		driCtr.updateAvailable(av, id);
	}
	
	/**
	 * Method for deleting a Route by its ID, takes an int as parameter.
	 * @deleteRoute
	 */
	public void deleteRoute(int id) throws SQLException{
		routeDB.deleteRoute(id);
	}
	
	/**
	 * Method for getting all routes, and then return them.
	 * @getAllRoutes
	 */
	public List<Route> getAllRoutes() throws SQLException{
		return routeDB.findAllRoute();
	}
	
	/**
	 * Method for getting all Orders, then return them.
	 * @getAllOrders
	 */
	public List<Order> getAllOrders() throws SQLException{
		return ordCtr.getAllOrders();
	}
	
	/**
	 * Method for getting all drivers, then return them.
	 * @getAllDrivers
	 */
	public List<Driver> getAllDrivers() throws SQLException{
		return driCtr.findAllDrivers();
	}
	
	/**
	 * Method for returning a list with Drivers, takes a boolean as a parameter.
	 * Reads from driverController. 
	 * @gettAllAvailableDrivers
	 */
	public List<Driver> gettAllAvailableDrivers(boolean av) throws SQLException{
		return driCtr.findAllAvailableDrivers(av);
	}
	
	/**
	 * Method for printing a Route, return a string.
	 * @printRoute
	 */
	public String printRoute(String start, String end, double weight, double height){
		 return mapTransport.routePlan(start, end, weight, height);
	}
	
	/**
	 * Method for getting Length of a route, returns a double.
	 * @getLength
	 */
	public double getLength(String start, String end, double weight, double height){
		return mapTransport.getLength(start, end, weight, height);
	}
	
	public Driver findDriverById(int id) throws SQLException{
		return driCtr.findDriverById(id);
	}
}
