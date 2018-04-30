package Test;

import java.sql.SQLException;

import DBLayer.DBConnection;

public class DBCleanup {
	public static void main(String[] args) throws SQLException {
		cleanDB(); // call to the utility class that resets the database
		System.out.println("cleaned");
	}
	public static void cleanDB() throws SQLException {
		e("drop table troute");
		e("drop table driver");
		e("drop table cities");
		e("drop table torder");
		for(int i = 0 ; i < script.length; i++) {
			e(script[i]);
		}
	}

	private static void e(String sql) throws SQLException {
		DBConnection.getInstance().getConnection().createStatement().executeUpdate(sql);
	}
	
	private static final String[] script = {
			//Create Tables			
			"create table cities(zipcode int Primary key not null, city varchar(50) not null)",
			"create table driver(id int Primary Key identity(1,1) not null, firstname varchar(50) not null, lastname varchar(50) not null, phonenumber int not null, driver_address varchar(50) not null, zipcode int Foreign Key references cities(zipcode) on delete set null on update Cascade, registreringsNr int not null, carNr int not null, available bit not null)",
			"create table torder(id int Primary Key identity(1,1) not null, product varchar(50) not null, order_weight decimal not null, height decimal(5,2) not null,startAddress varchar(50) not null, endAddress varchar(50) not null, order_date date not null)",
			"create table troute(id int Primary Key identity(1,1) not null, driver_id int Foreign Key references driver(id) on delete cascade on update Cascade not null,  order_id int Foreign Key references torder(id) on delete cascade on update Cascade not null, route_length decimal(5,2),route_time decimal(5,2))",

			//Create cities --
			"Insert into cities values(9240, 'Nibe')",
			"Insert into cities values(9000, 'Aalborg')",
			"Insert into cities values(9541, 'Suldrup')",
			"Insert into cities values(9530, 'Støvring')",
			"Insert into cities values(9600, 'Aars')",

			//create drivers
			"Insert Into driver values('Jens', 'Hansen', 10239343, 'vej 32', 9240, 1111, 3, 1)",
			"Insert Into driver values('Per', 'Karlsen', 54656545, 'vej 65', 9000, 2222, 4, 1)",

			//create Orders
			"Insert Into torder values('Beton', 50.2, 4.2, 'Sørup', 'Aalborg', '2020-03-03')",
			"Insert Into torder values('Sten', 20, 4.2, 'Sørup', 'Holstebro', '2019-02-05')"
	};
}
