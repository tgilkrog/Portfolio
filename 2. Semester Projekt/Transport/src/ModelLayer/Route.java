package ModelLayer;

public class Route {
	private int id;
	private Driver driver;
	private Order order;
	private double length;
	private double time;
	
	public Route(Driver driver, Order order, double time, double length) {
		super();
		this.driver = driver;
		this.order = order;
		this.length = length;
		this.time = time;
	}
	
	public Route(){
		
	}

	public int getId() {
		return id;
	}


	public void setId(int id) {
		this.id = id;
	}


	public Driver getDriver() {
		return driver;
	}

	public void setDriver(Driver driver) {
		this.driver = driver;
	}

	public Order getOrder() {
		return order;
	}

	public void setOrder(Order order) {
		this.order = order;
	}

	public double getLength() {
		return length;
	}

	public void setLength(double length) {
		this.length = length;
	}

	public double getTime() {
		return time;
	}

	public void setTime(double time) {
		this.time = time;
	}

}
