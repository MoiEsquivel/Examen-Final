Create database Vehiculos 

use Vehiculos

------USUARIOS----------
create table Usuarios
(
Id_Usuario int identity,
Usuario nvarchar(50) UNIQUE	,
Clave nvarchar(30),
Nombre nvarchar(50),
Apellido nvarchar(50)
Constraint Pk_Iduser Primary Key (Id_Usuario)
)

create procedure NewUser
@User nvarchar(50),
@Clave nvarchar(30),
@Nombre nvarchar(50),
@Apellido nvarchar(50)
as
	begin
		insert into Usuarios(Usuario,Clave,Nombre,Apellido) values (@User,@Clave,@Nombre,@Apellido)
	end

exec NewUser 'moi@uh.com', '123', 'Moises', 'Esquivel'

create procedure EliminarUser
@User nvarchar(50)
as
	begin
	delete Usuarios where Usuario = @User
	end

create procedure ModificarUser
@User nvarchar(50),
@Clave nvarchar(30),
@Nombre nvarchar(50),
@Apellido nvarchar(50)
as 
	begin
	update Usuarios set Clave = @Clave, Nombre = @Nombre, Apellido = @Apellido where Usuario = @User
	end

---------PLACA---------
create table Placa
(
Id_Placa int identity,
NumeroPlaca nvarchar(6),
Id_Usuario int,
Monto money default 0,
Constraint Pk_IdPlaca primary key (Id_Placa),
Constraint Fk_id foreign key (Id_Usuario) references Usuarios (Id_Usuario)
)

create procedure NewPlaca
@Numplaca nvarchar(6),
@iduser int,
@Monto money
as
	begin
		insert into Placa(NumeroPlaca,Id_Usuario,Monto) values (@Numplaca,@iduser,@Monto)
	end

exec NewPlaca 'WRX520',1,125000

create procedure EliminarPlaca
@Nplaca nvarchar(6)
as
	begin
	delete Placa where NumeroPlaca = @Nplaca
	end
	
create procedure ModificarPlaca
@Numplaca nvarchar(6),
@Nplaca nvarchar(6),
@iduser int,
@Monto money
as 
	begin
	update Placa set NumeroPlaca = @Numplaca, Id_Usuario = @iduser,  Monto = @Monto where NumeroPlaca = @Nplaca 
	end
Create procedure Reporte
@NumPlaca int
as
	begin
		SELECT us.Nombre, us.Apellido,p.NumeroPlaca ,p.Monto, p.Monto * 0.13 AS IVA, p.Monto * 1.13 AS Total
		FROM Usuarios us
		inner Join Placa p on p.Id_Usuario = us.Id_Usuario where p.NumeroPlaca = @NumPlaca
	end
	create procedure Listar
	@user
	as
	begin
select* from Usuarios
select* from Placa