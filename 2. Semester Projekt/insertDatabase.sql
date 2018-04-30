use master
use dmaa0916_196566

--create cities--
Insert into cities values(9240, 'Nibe');
Insert into cities values(9000, 'Aalborg');
Insert into cities values(9541, 'Suldrup');
Insert into cities values(9530, 'Støvring');
Insert into cities values(9600, 'Aars');

-- Create Drivers --
Insert Into driver values('Jens', 'Hansen', 10239343, 'vej 32', 9240, 1111, 3, 1);
Insert Into driver values('Per', 'Karlsen', 54656545, 'vej 65', 9000, 2222, 4, 1);

-- Create Orders --
Insert Into torder values('Beton', 50.2, 4.2, 'Sørup', 'Aalborg', '2020-03-03');
Insert Into torder values('Sten', 20, 4.2, 'Sørup', 'Holstebro', '2019-02-05');

-- Create Route --
--Insert Into troute values(1, 1, 25, 5);
--Insert Into troute values(2, 2, 40, 5);