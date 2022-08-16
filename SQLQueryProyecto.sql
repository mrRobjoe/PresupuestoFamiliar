Create database UHPRESUPUESTO

use UHPRESUPUESTO

create table Persona(
Id int identity(1,1),
Cedula varchar(20) not null,
Nombre varchar(50) not null,
Apellido1 varchar(50),
Direccion varchar(100),
Telefono varchar(20)
constraint PK_ID primary key(Id),--llave primaria
constraint UQ_Cedula unique (Cedula)
)

drop table Persona
select * from Persona
delete from Persona where Id=12

create table TipoUsuario(
Id int identity(1,1),
Descripcion varchar(50) not null,
constraint PK_IDTipoUser primary key(Id)--llave primaria
)
insert into TipoUsuario values ('Administrador'),('Regular')
select * from TipoUsuario

create table TipoTransaccion(
Id int identity(1,1),
Descripcion varchar(50) not null,
TipoContable varchar(10) not null,
constraint PK_IDTipoTransaccion primary key(Id),--llave primaria
)
insert into TipoTransaccion values ('Ingresos','Debe'),('Salidas','Haber')
select*from TipoTransaccion

create table Usuarioo(
Correo varchar(20),
IdUsuario int,
TipoUser int,
Clave varchar(30),
constraint pk_CorreoUsuario primary key (Correo),
constraint fk_TipoUsuario foreign key (IdUsuario) references Persona (Id),
constraint fk_TipoUsuarioId foreign key (TipoUser) references TipoUsuario (Id)
)

drop table Usuarioo
select * from Usuarioo
delete from Usuarioo where Correo='adrian@gmail.com'

create table Transacciones(
Id int identity(1,1),
idTipoTransaccion int,
Correo varchar(20),
Descrip varchar(50),
Monto money,
Fecha datetime,
constraint pk_IdTransaccion primary key(Id),
constraint fk_idTipoTransaccion foreign key(idTipoTransaccion) references TipoTransaccion(Id),
constraint fk_IdCorreoUser foreign key(Correo) references Usuarioo(Correo)
)

drop table Transacciones
select*from Transacciones
insert into Transacciones values (2, 'zoodri@gmail.com', 'Mensualidad casa', 500000, GETDATE())2


create table Transacciones_Auditoria(
Id int,
idTipoTransaccion int,
Correo varchar(20),
Descrip varchar(50),
Monto money,
Fecha datetime,
usuario varchar(30),
Tipo varchar(10),
fecha2 datetime
)

drop table Transacciones_Auditoria

create trigger Trigger_Auditoria_Transacciones
 on Transacciones
 After Insert, Delete

   as
    begin

	insert into Transacciones_Auditoria (Id, idTipoTransaccion, Correo, Descrip, Monto, Fecha, usuario, Tipo, Fecha2)
	select i.Id, i.idTipoTransaccion, i.Correo, i.Descrip, i.Monto, i.Fecha, 'DBA', 'Ingreso', GETDATE() from Inserted i
	union all
	select d.Id, d.idTipoTransaccion, d.Correo, d.Descrip, d.Monto, d.Fecha, 'DBA', 'Ingreso', GETDATE() from Deleted d	
	
	end


--procesos almacenados para Persona	

create proc sp_BorrarPersona
@id int
  as
   begin 
     delete from Persona where Id=@id
  end

create proc sp_ModificarPersona
@id int,
@cedula varchar(20),
@nombre varchar(50),
@apellido varchar(50),
@direccion varchar(100),
@telefono varchar(20)
  as
   begin
    update Persona set Cedula=@cedula, Nombre=@nombre, Apellido1=@apellido, Direccion=@direccion, Telefono=@telefono
  end

create proc sp_ConsultarPersona
@cedula varchar(20)
 as
  begin
   select * from Persona where Cedula=@cedula
 end


 --procesos almacenados para tipo usuario, Guardado
 create proc sp_AgregarTipoUsuario
 @descripcion varchar(50)=''
  as 
   begin
    insert into TipoUsuario (Descripcion) values (@descripcion)
  end

create proc sp_BorrarTipoUsuario
@id int
 as 
  begin
   delete from TipoUsuario where Id=@id
 end

create proc sp_ModificarTipoUsuario
@id int,
@descrip varchar(50)
 as 
  begin 
   update TipoUsuario Set Descripcion=@descrip
 end

create proc sp_ConsultarTipoUsuario
@id int
 as
  begin 
   select * from TipoUsuario where Id=@id
 end

--procesos almacenados para Tipo transaccion, Guardado

create proc sp_AgregarTipoTransaccion
@descr varchar(50)='',
@tipContable varchar(10)=''
 as 
  begin
   insert into TipoTransaccion (Descripcion,TipoContable) values (@descr,@tipContable)
 end

create proc sp_BorrarTipoTransaccion
@id int
 as
  begin
   delete from TipoTransaccion where Id=@id
 end

create proc sp_ModificarTipoTransaccion
@id int,
@descr varchar(50),
@tipContable varchar(10)
 as 
  begin
   update TipoTransaccion Set Descripcion=@descr, TipoContable=@tipContable
 end

 create proc sp_ConsultarTipoTransaccion
 @id int
  as
   begin 
    select * from TipoTransaccion where Id=@id
 end

 --procesos almacenados para Usuario

create proc sp_BorrarUsuario
@correo varchar(20)
 as
  begin
   delete from Usuarioo where Correo=@correo
 end

create proc sp_ModificarUsuario
@correo varchar(20),
@idUsuario int,
@tipoUsuario int,
@clave varchar(30)
 as
  begin
   update Usuarioo Set Correo=@correo, IdUsuario=@idUsuario, TipoUser=@tipoUsuario, Clave=@clave
 end

create proc sp_ConsultarUsuario
@correo varchar(20)
 as
  begin
   select * from Usuarioo where Correo=@correo
 end

--procesos almacendos para transacciones, Guardado
create proc sp_AgregarTransaccion
@idTipoTransaccion int,
@correo varchar(20),
@descripcion varchar(50),
@monto money
--@fecha datetime
 as
  begin
   insert into Transacciones values (@idTipoTransaccion,@correo,@descripcion,@monto,GETDATE())
 end

 select * from Transacciones

create proc sp_BorrarTransaccion
@id int
 as
  begin
   delete from Transacciones where Id=@id
 end

create proc sp_ModificarTransaccion
@id int,
@idTipoTransaccion int,
@correo varchar(20),
@descripcion varchar(50),
@monto money,
@fecha datetime
 as
  begin 
   update Transacciones Set idTipoTransaccion=@idTipoTransaccion, Correo=@correo, Descrip=@descripcion, Monto=@monto, Fecha=@fecha
 end

create proc sp_ConsultarTransaccion
@id int
 as
  begin
   select * from Transacciones where Id=@id
 end

 --Registro
 create procedure Registro
 @cedula varchar(20),
 @nombre varchar(50),
 @apellido varchar(50) = null,
 @direccion varchar(100),
 @telefono varchar(20),
 @correo varchar (20),
 @tipoUser int,
 @clave varchar(30)
 as
  begin 
   insert into Persona (Cedula, Nombre, Apellido1, Direccion, Telefono) values (@cedula, @nombre, @apellido, @direccion, @telefono)

   insert into Usuarioo (Correo, IdUsuario, TipoUser, Clave)
   select @correo, Id, @tipoUser, @clave from Persona where Cedula=@cedula
   end

--Iniciar sesión
create procedure IniciarSesion
@correo varchar(20),
@clave varchar(30)
as 
 begin
  select Correo, Clave from Usuarioo where Correo=@correo and Clave=@clave
 end


 --Consulta Filtro
 Alter procedure ConsultaTranFilt
 @tipoTran int,
 @user varchar(50),
 @mes int
 as
  begin
   select SUM(Monto) as Total from Transacciones
   where idTipoTransaccion=@tipoTran and Correo=@user and Month(Fecha)=@mes
  end



 --Consulta general ListadoUsuarios
 create proc sp_ConsultPersona
 as
 begin
 select*from Persona
 end

 create proc sp_ConsultUser
 as
 begin
 select*from Usuarioo
 end

 create proc sp_ConsultTransc
 as
 begin
 select*from Transacciones
 end

 create proc sp_ConsultaTranAuditoria
 as
 begin
 select*from Transacciones_Auditoria
 end