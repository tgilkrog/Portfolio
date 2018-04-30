use master
use dmaa0916_196566

drop table troute;
drop table driver;
drop table cities;
drop table torder;


--create Table cities--
create table cities(
	zipcode int Primary key not null,
	city varchar(50) not null
);

-- Create Table Driver --
create table driver(
	id int Primary Key identity(1,1) not null,
	firstname varchar(50) not null,
	lastname varchar(50) not null,
	phonenumber int not null,
	driver_address varchar(50) not null,
	zipcode int Foreign Key references cities(zipcode) on delete set null on update Cascade,
	registreringsNr int not null,
	carNr int not null,
	available bit not null
	);

-- Create Table Order --
create table torder(
	id int Primary Key identity(1,1) not null,
	product varchar(50) not null,
	order_weight decimal not null,
	height decimal(5,2) not null,
	startAddress varchar(50) not null,
	endAddress varchar(50) not null,
	order_date date not null
);

-- Create Table Route --
create table troute(
	id int Primary Key identity(1,1) not null,
	driver_id int Foreign Key references driver(id) on delete cascade on update Cascade not null, 
	order_id int Foreign Key references torder(id) on delete cascade on update Cascade not null,
	route_length decimal(5,2),
	route_time decimal(5,2)
);