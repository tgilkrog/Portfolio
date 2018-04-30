package ModelLayer;

public class Order {
	private String product;
	private double weight;
	private double height;
	private String startAddress;
	private String endAddress;
	private String date;
	private int id;
	
	public Order(String product, double weight, double height, String startAddress, String endAddress, String date, int id) {
		this.product = product;
		this.weight = weight;
		this.height = height;
		this.startAddress = startAddress;
		this.endAddress = endAddress;
		this.date = date;
		this.id = id;
	}
	
	public Order(){
		
	}
	
	public Order(int id){
		this.id = id;
	}
	

	public int getId() {
		return id;
	}


	public void setId(int id) {
		this.id = id;
	}


	public String getProduct() {
		return product;
	}

	public void setProduct(String product) {
		this.product = product;
	}

	public double getWeight() {
		return weight;
	}

	public void setWeight(double weight) {
		this.weight = weight;
	}

	public double getHeight() {
		return height;
	}

	public void setHeight(double height) {
		this.height = height;
	}

	public String getStartAddress() {
		return startAddress;
	}

	public void setStartAddress(String startAddress) {
		this.startAddress = startAddress;
	}

	public String getEndAddress() {
		return endAddress;
	}

	public void setEndAddress(String endAddress) {
		this.endAddress = endAddress;
	}

	public String getDate() {
		return date;
	}

	public void setDate(String date) {
		this.date = date;
	}

}
