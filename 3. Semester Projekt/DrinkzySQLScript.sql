use master;
if exists (select * from sys.databases where name='Drinkzy')
	drop database Drinkzy;
go
create database Drinkzy;
go

use Drinkzy;

CREATE TABLE Drink(
	id int primary key identity(1,1),
	driName varchar(50) NOT NULL,
	driDescription varchar(50) NOT NULL,
	driPrice decimal(8,2) NOT NULL,
	driImg varchar(max)
);

CREATE TABLE Alchohol(
	id int primary key identity(1,1),
	alcName varchar(50) NOT NULL,
	alcProcent decimal(8,2) NOT NULL,
	alcPrice decimal(8,2) NOT NULL,
	alcImg varchar(max)
);

CREATE TABLE NonAlchohol(
	Id int primary key identity(1,1),
	nonAlcName varchar(50) NOT NULL,
	nonAlcPrice decimal(8,2) NOT NULL,
	nonAlcImg varchar(max)
);

CREATE TABLE Helflask(
	id int primary key identity(1,1),
	helName varchar(50) NOT NULL,
	helProcent decimal(8,2) NOT NULL,
	helPrice decimal(8,2) NOT NULL,
	helImg varchar(max)
);

CREATE TABLE Ingredient(
	id int primary key identity(1,1),
	ingName varchar(50) NOT NULL,
	Procent decimal(8,2)
);

CREATE TABLE DrinkIngredient(
	drinkID int NOT NULL foreign key references Drink(id) ON DELETE CASCADE,
	ingredientID int NOT NULL foreign key references Ingredient(id)
);

CREATE TABLE DrinkzyUser(
	id int primary key identity(1,1),
	userName varchar(50) NOT NULL,
	firstName varchar(50) NOT NULL,
	lastName varchar(50) NOT NULL,
	gender varchar(50) NOT NULL,
	birthday datetime NOT NULL,
	userPassword varchar(MAX) NOT NULL,
	Salt varchar(MAX) NOT NULL,
	email varchar(50) NOT NULL,
	phone varchar(50) NOT NULL
);

CREATE TABLE DrinkzyCustomer(
	id int primary key identity(1,1),
	cusName varchar(50) NOT NULL,
	cusIMG varchar(MAX),
	cusRegion varchar(50) NOT NULL,
	cusAddress varchar(50) NOT NULL,
	cusPhone varchar(50) NOT NULL,
	cusEmail varchar(50) NOT NULL,
	cusPassword varchar(MAX),
	cusSalt varchar(MAX)
);

CREATE TABLE Storage(
	id int primary key identity(1,1),
	customerID int NOT NULL foreign key references DrinkzyCustomer(id)
);

CREATE TABLE drinkStorage(
	Amount int NOT NULL,
	MaxAmount int NOT NULL,
	MinAmount int NOT NULL,
	drinkID int NOT NULL foreign key references Drink(id),
	storageID int NOT NULL foreign key references Storage(id)
);

CREATE TABLE alchoholStorage(
	Amount int NOT NULL,
	MaxAmount int NOT NULL,
	MinAmount int NOT NULL,
	alchoholID int NOT NULL foreign key references Alchohol(id),
	storageID int NOT NULL foreign key references Storage(id)
);

CREATE TABLE helflaskStorage(
	Amount int NOT NULL,
	MaxAmount int NOT NULL,
	MinAmount int NOT NULL,
	helflaskID int NOT NULL foreign key references Helflask(id),
	storageID int NOT NULL foreign key references Storage(id)
);

alter table alchoholStorage with nocheck add constraint 
alchoholCheck check ([Amount]>=0);

alter table drinkStorage with nocheck add constraint 
drinkCheck check ([Amount]>=0);

alter table helflaskStorage with nocheck add constraint 
helflaskCheck check ([Amount]>=0);

CREATE TABLE MenuCard(
	id int primary key identity(1,1),
	customerID int NOT NULL foreign key references DrinkzyCustomer(id) ON DELETE CASCADE
);

CREATE TABLE MenucardDrinks(
	menuID int NOT NULL foreign key references MenuCard(id) ON DELETE CASCADE,
	drinkid int NOT NULL foreign key references Drink(id)
);

CREATE TABLE MenucardAlchohol(
	menuID int NOT NULL foreign key references MenuCard(id) ON DELETE CASCADE,
	alchoholID int NOT NULL foreign key references Alchohol(id)
);

CREATE TABLE MenucardHelflask(
	menuID int NOT NULL foreign key references MenuCard(id) ON DELETE CASCADE,
	helflaskID int NOT NULL foreign key references Helflask(id)
);

CREATE TABLE Announcements(
	id int primary key identity(1,1),
	Title varchar(50) NOT NULL,
	anText varchar(50) NOT NULL,
	anDate date NOT NULL,
	Img varchar(50),
	customerId int NOT NULL foreign key references DrinkzyCustomer(id)
);

CREATE TABLE Favorites(
	id int primary key identity(1,1),
	userID int NOT NULL foreign key references DrinkzyUser(id)
);

CREATE TABLE FavoritesDrinks(
	favoritesID int NOT NULL foreign key references Favorites(id),
	drinkID int NOT NULL foreign key references Drink(id)
);

CREATE TABLE FavoritesAlchohol(
	favoritesID int NOT NULL foreign key references Favorites(id),
	alchoholID int NOT NULL foreign key references Alchohol(id)
);

CREATE TABLE FavoritesHelflask(
	favoritesID int NOT NULL foreign key references Favorites(id),
	helflaskID int NOT NULL foreign key references Helflask(id)
);

CREATE TABLE Wallet(
	id int primary key identity(1,1),
	Balance decimal(8,2) NOT NULL,
	MaxBalance decimal(8,2),
	MinBalance decimal(8,2),
	LockTime date,
	userID int NOT NULL foreign key references DrinkzyUser(id)
);

CREATE TABLE DrinkzyOrder(
	id int primary key identity(1,1),
	totalPrice decimal(8,2),
	discount decimal(8,2), 
	orderDate datetime,
	orderStatus varchar(50),
	userID int NOT NULL foreign key references DrinkzyUser(id),
	customerID int NOT Null foreign key references DrinkzyCustomer(id)
);

CREATE TABLE OrderLine(
	id int primary key identity(1,1),
	amount int NOT NULL,
	totalPrice decimal(8,2),
	orderID int NOT NULL foreign key references DrinkzyOrder(id) ON DELETE CASCADE,
	drinkID int NOT NULL foreign key references Drink(id)
);

CREATE TABLE OrderLineHelflask(
	id int primary key identity(1,1),
	amount int NOT NULL,
	totalPrice decimal(8,2),
	orderID int NOT NULL foreign key references DrinkzyOrder(id) ON DELETE CASCADE,
	helflaskID int NOT NULL foreign key references Helflask(id)
);

CREATE TABLE OrderLineAlchohol(
	id int primary key identity(1,1),
	amount int NOT NULL,
	totalPrice decimal(8,2),
	orderID int NOT NULL foreign key references DrinkzyOrder(id) ON DELETE CASCADE,
	alchoholID int NOT NULL foreign key references Alchohol(id)
);

INSERT INTO Drink values ('ROM og Cola', 'Den er meget god', 40, 'http://www.bolsjehuset.dk/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/r/o/rom_aroma.jpg');
INSERT INTO Drink values('Vodka og juice', 'appelsin', 35, 'http://cf.ltkcdn.net/cocktails/images/std/202877-547x450-orangecocktail.jpg');
INSERT INTO Drink values('Gin and Tonic', 'meget Gin i', 80, 'http://ydes.dk/wp-content/uploads/2016/01/30599_virgin_gin_tonic.jpg');

INSERT INTO Alchohol values ('Mocai', 4.5, 35, 'https://f.nordiskemedier.dk/2jk2weiuf6pbzx3b.jpg');
INSERT INTO Alchohol values ('Tuborg', 4.6, 20, 'https://www.bevco.dk/media/catalog/product/cache/1/image/1000x/9df78eab33525d08d6e5fb8d27136e95/t/u/tuborg_pilsner_33_cl._4_6_30_flasker_3.png');

INSERT INTO NonAlchohol values ('Cola', 35, 'http://www.addwater.dk/graphics/shop/170_3_f.jpg');
INSERT INTO NonAlchohol values ('Juice', 20, 'https://media.flaschenland.com/ProductImages/800px/250ml_PET_flaske_med_bred_hals_Milk_and_Juice_bla_2.jpg');

INSERT INTO Helflask values ('Romi', 35, 300, 'http://www.lcbo.com/content/dam/lcbo/products/500512.jpg/jcr:content/renditions/cq5dam.web.1280.1280.jpeg');
INSERT INTO Helflask values ('Smirnoff vodka', 37.5, 300, 'https://www.tanners-wines.co.uk/media/catalog/product/cache/image/700x700/e9c3970ab036de70892d86c6d221abfe/w/v/wv002.jpg');

INSERT INTO DrinkzyCustomer values('Hesten', 'http://www.vestiageinc.com/wp-content/uploads/2017/05/Modern-Home-Bar-Design-Ideas-Picture.jpg', 'Jylland', 'hejvej', '20202020', 'email', '','');
INSERT INTO DrinkzyCustomer values('Lokes Ølstue', 'https://ritzcarlton-h.assetsadobe.com/is/image/content/dam/the-ritz-carlton/hotels/asia-pacific/china/hong-kong/assetmigration/RCHKKOW_00052_conversion.png?$XlargeViewport100pct$', 'Suldrup', 'Aarestrupvej 2', '9541', 'mail', '', '');
INSERT INTO DrinkzyCustomer values('Crazy Dazy', 'https://www.nycgo.com/images/venues/597/bodeganegra_tanyablum_06__x_large.jpg', 'Aars', 'Aarsvej 5', '9234', 'mail', '', '');

INSERT INTO Storage values(1);
INSERT INTO Storage values(2);
INSERT INTO Storage values(3);

/*amount, maxamount, minAmount, drinkid, storageID*/
INSERT INTO drinkStorage values(25, 70, 10, 1, 1);
INSERT INTO drinkStorage values(30, 70, 10, 2, 1);
INSERT INTO drinkStorage values(35, 80, 10, 1, 2);
INSERT INTO drinkStorage values(43, 80, 10, 3, 2);
INSERT INTO drinkStorage values(23, 80, 10, 2, 3);

INSERT INTO alchoholStorage values(85, 150, 10, 1, 1);
INSERT INTO alchoholStorage values(75, 150, 10, 2, 1);

INSERT INTO helflaskStorage values(5, 10, 1, 1, 1);
INSERT INTO helflaskStorage values(3, 10, 1, 2, 1); 

INSERT INTO MenuCard values(1);
INSERT INTO MenuCard values(2);
INSERT INTO MenuCard values(3);

/*MenuID, DrinkID*/
INSERT INTO MenucardDrinks values(1,1);
INSERT INTO MenucardDrinks values(1,2);
INSERT INTO MenucardDrinks values(2,1);
INSERT INTO MenucardDrinks values(2,3);
INSERT INTO MenucardDrinks values(3,2);

INSERT INTO MenucardAlchohol values(1,1);
INSERT INTO MenucardAlchohol values(1,2);

INSERT INTO MenucardHelflask values(1,1);
INSERT INTO MenucardHelflask values(1,2);

INSERT INTO Announcements values('Happy hour', 'Dobbelt så møg', '2017-11-17', 'billede', 1);

INSERT INTO Ingredient values ('Cola', 0.0);
INSERT INTO Ingredient values ('Rom', 33.33);
INSERT INTO Ingredient values ('Vodka', 62.00);
INSERT INTO Ingredient values ('Juice', 0.00);

INSERT INTO DrinkIngredient values (1, 1);
INSERT INTO DrinkIngredient values (1, 2);
INSERT INTO DrinkIngredient values (2, 3);
INSERT INTO DrinkIngredient values (2, 4);

