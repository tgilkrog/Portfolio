use master;
if exists (select * from sys.databases where name='Final')
	drop database Final;
go
create database Final;
go

use Final;

CREATE TABLE CustomerType(
	id int primary key identity(1,1),
	TypeName varchar(50) NOT NULL
);

CREATE TABLE Customer(
	id int primary key identity(1,1),
	CusName varchar(50) NOT NULL,
	CusIMG varchar(MAX),
	CusCity varchar(50) NOT NULL,
	CusAddress varchar(50) NOT NULL,
	CusPostal int NOT NULL,
	CusPhone varchar(50) NOT NULL,
	CusEmail varchar(50) NOT NULL,
	CusTypeId int NOT NULL foreign key references CustomerType(id) 
);

CREATE TABLE CustomerFilters(
	id int primary key identity(1,1),
	CustomerId int NOT NULL foreign key references Customer(id),
	Gambling bit NOT NULL,
	Dancing bit NOT NULL,
	Food bit NOT NULL,
	Sleep bit NOT NULL
);

CREATE TABLE DrinkUser(
	id int primary key identity(1,1),
	Username varchar(50) not null,
	UserPassword varchar(MAX) not null,
	UserSalt varchar(MAX) not null,
	Email varchar(50) not null,
	CusId int NOT NULL
);

CREATE TABLE Notifications(
	id int primary key identity(1,1),
	UserId int not null foreign key references DrinkUser(id),
	NoteText varchar(max) not null
);

CREATE TABLE Subscription(
	id int primary key identity(1,1),
	drinkUserID int not null foreign key references DrinkUser(id),
	customerID int not null foreign key references Customer(id),
	subNotification bit not null
);

CREATE TABLE CustomerEvents(
	id int primary key identity(1,1),
	Title varchar(50) NOT NULL,
	EventDescription varchar(MAX) NOT NULL,
	EventDate date NOT NULL,
	customerID int NOT NULL foreign key references Customer(id)
);

CREATE TABLE CustomerNews(
	id int primary key identity(1,1),
	Title varchar(50) NOT NULL,
	NewsDescription varchar(MAX) NOT NULL,
	NewsDate date NOT NULL,
	customerID int NOT NULL foreign key references Customer(id)
);

CREATE TABLE UserEvent(
	EventId int NOT NULL foreign key references CustomerEvents(id),
	UserId int NOT NULL foreign key references DrinkUser(id)
);

CREATE TABLE Drink(
	id int primary key identity(1,1),
	DriName varchar(50) NOT NULL,
	DriIMG varchar(MAX) NOT NULL,
	DriDescription varchar(MAX) NOT NUll
);

CREATE TABLE Menucard(
	id int primary key identity(1,1),
	customerID int NOT NULL foreign key references Customer(id)
);

CREATE TABLE MenucardDrinks(
	menuID int NOT NULL foreign key references Menucard(id),
	drinkid int NOT NULL foreign key references Drink(id)
);

INSERT INTO CustomerType values('Bar');
INSERT INTO CustomerType values('Kro');
INSERT INTO CustomerType values('Klub');

INSERT INTO Customer values('Hesten', 'https://cdn.trendhunterstatic.com/phpthumbnails/340/340058/340058_2_800.jpeg', 'Jylland', 'hejvej', 9541, '20202020', 'email', 1);
INSERT INTO Customer values('Lokes Ølstue', 'https://static1.squarespace.com/static/562945b7e4b053bbb61bb6f8/t/574e01f0d210b8bdf5fefdd0/1464730123491/?format=1500w', 'Suldrup', 'Aarestrupvej 2', 9541, '9541', 'mail', 2);
INSERT INTO Customer values('Crazy Dazy', 'http://www.londontips.dk/wp-content/uploads/2013/06/natklubber_london_diskotek.jpg', 'Aars', 'Aarsvej 5', 4356, '9234', 'mail', 3);

INSERT INTO CustomerFilters values(1, 1, 1, 0, 0);
INSERT INTO CustomerFilters values(2, 0, 1, 1, 0);
INSERT INTO CustomerFilters values(3, 0, 0, 1, 1);

INSERT INTO Drink values('Rom og Cola', 'https://cdn.liquor.com/wp-content/uploads/2015/10/19223251/b-20110420145340.jpg', 'En dejlig cola med rom i');
INSERT INTO Drink values('Whiskey og Cola', 'https://d2zcsajde7b23y.cloudfront.net/m/e026837ca0e5cc9f4b739b2a15325bcfe62894ed.jpg', 'En god Jack Daniels med Cola');
INSERT INTO Drink values('Dry Martini', 'https://cdn.liquor.com/wp-content/uploads/2018/09/05093330/dry-martini-720x720-recipe.jpg', 'En classic dry martini');
INSERT INTO Drink values('Sex On The Beach', 'https://cdn.liquor.com/wp-content/uploads/2017/09/01105701/sex-on-the-beach-720x720-Molly.jpeg', 'Severes iskold');

INSERT INTO Menucard values(1);
INSERT INTO Menucard values(2);
INSERT INTO Menucard values(3);

INSERT INTO MenucardDrinks values(1,1);
INSERT INTO MenucardDrinks values(1,2);
INSERT INTO MenucardDrinks values(1,3);
INSERT INTO MenuCardDrinks values(1,4);
INSERT INTO MenucardDrinks values(2,1);
INSERT INTO MenucardDrinks values(2,2);
INSERT INTO MenucardDrinks values(3,1);
INSERT INTO MenucardDrinks values(3,2);

INSERT INTO CustomerEvents values('Happy Hour', 'Der er happy hour på torsdag fra 18.00 til 20.00', GETDATE(), 1);
INSERT INTO CustomerEvents values('Fødselsdag', 'Lokalerne er reservert fra 19.00 til 22.00, så dørene vil være lukket for uinviteret', GETDATE(), 1);

INSERT INTO CustomerNews values('Ny breezer', 'Den nye fra breezer kan du få for kun 35 kr.', GETDATE(), 1);
INSERT INTO CustomerNews values('Ombygning', 'Der bliver bygget om på førstesal', GETDATE(), 1);

INSERT INTO DrinkUser values('TG', 'hejsa', 'jh', 'tgilkrog@gmail.com', 0);
INSERT INTO DrinkUser VALUES('lokeHanne', '1234', 'jk', 'loke@hanne.dk', 2);

INSERT INTO UserEvent values(1, 1);
INSERT INTO UserEvent values(2, 1);

INSERT INTO Subscription values(1, 1, 0);
INSERT INTO Subscription values(1, 2, 1);
INSERT INTO Subscription values(1, 3, 0);