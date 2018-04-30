package ModelLayer;

public class Driver {
	private String firstName;
	private String lastName;
	private int phonenumber;
	private String address;
	private String city;
	private int zipCode;
	private int registreringsNr;
	private int carNr;
	private boolean available;
	int id;
	
	public Driver(String firstName, String lastName, int phonenumber, String address, int zipCode,
			int registreringsNr, int carNr, boolean available, int id) {
		super();
		this.firstName = firstName;
		this.lastName = lastName;
		this.phonenumber = phonenumber;
		this.address = address;
		this.zipCode = zipCode;
		this.registreringsNr = registreringsNr;
		this.carNr = carNr;
		this.available = available;
		this.id = id;
	}
	
	public Driver() {
		
	}
	
	public boolean getAvailable() {
		return available;
	}

	public void setAvailable(boolean available) {
		this.available = available;
	}


	public Driver(int id){
		this.id = id;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getFirstName() {
		return firstName;
	}

	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}

	public String getLastName() {
		return lastName;
	}

	public void setLastName(String lastName) {
		this.lastName = lastName;
	}

	public int getPhonenumber() {
		return phonenumber;
	}

	public void setPhonenumber(int phonenumber) {
		this.phonenumber = phonenumber;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getCity() {
		return city;
	}

	public void setCity(String city) {
		this.city = city;
	}

	public int getZipCode() {
		return zipCode;
	}

	public void setZipCode(int zipCode) {
		this.zipCode = zipCode;
	}

	public int getRegistreringsNr() {
		return registreringsNr;
	}

	public void setRegistreringsNr(int registreringsNr) {
		this.registreringsNr = registreringsNr;
	}

	public int getCarNr() {
		return carNr;
	}

	public void setCarNr(int carNr) {
		this.carNr = carNr;
	}
	
	@Override
	public String toString(){
		return firstName;
	}
}
