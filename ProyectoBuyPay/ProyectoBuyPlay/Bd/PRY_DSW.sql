create database proyectoDSW
go
use proyectoDSW
go
-------------------------
create table tb_estados(
idestado int IDENTITY(1,1) PRIMARY KEY,
descripcion varchar(15) NOT NULL
)
go
insert into tb_estados values ( 'activo'), ('inactivo')
go
select*from tb_estados
-------------------------
create table tb_tipos(
idtipo	int IDENTITY(1,1) PRIMARY KEY,
descripcion varchar(25) NOT NULL
)
go
insert into tb_tipos values ('Android')
insert into tb_tipos values ('Battle.net')
insert into tb_tipos values ('Epic')
insert into tb_tipos values ('Free2Play')
insert into tb_tipos values ('NCSoft')
insert into tb_tipos values ('GOG COM')
insert into tb_tipos values ('Nintendo')
insert into tb_tipos values ('Origin')
insert into tb_tipos values ('PlayStation 3')
insert into tb_tipos values ('PlayStation 4')
insert into tb_tipos values ('PlayStation 5')
insert into tb_tipos values ('PlayStation Vita')
insert into tb_tipos values ('Steam')
insert into tb_tipos values ('Uplay')
insert into tb_tipos values ('XBOX 360')
insert into tb_tipos values ('XBOX ONE')
go
select * from tb_tipos
-------------------------
create table tb_juegos(
codigo int IDENTITY(1,1) PRIMARY KEY,
nombre varchar(50) NOT NULL,
precio decimal(8,2) NOT NULL,
feclan date not null,
descripcion text not null,
requisitos text not null,
estado int DEFAULT 1,
tipo int not null,
foreign key (estado) references tb_estados(idestado),
foreign key (tipo) references tb_tipos(idtipo)
)
go
-------------------------
CREATE TABLE tb_usuarios(
codigo  int IDENTITY(1,1) PRIMARY KEY,
nombre varchar(20) NOT NULL,
apellido varchar(30) NOT NULL,
usuario  varchar(50) NOT NULL,
clave    varchar(10) NOT NULL,
facceso date null,
estado  int DEFAULT 1,
juegos int null, 
foreign key (estado) references tb_estados(idestado),
foreign key (juegos) references tb_juegos(codigo)
)
go
-------------------------
create table tb_compras(
codigo int IDENTITY(1,1) PRIMARY KEY,
usuario int null,
juegos int null,
foreign key (juegos) references tb_juegos(codigo),
foreign key (usuario) references tb_usuarios(codigo)
)
go


create or alter proc sp_addUsuario
@nombre varchar(20),
@apellido  varchar(30),
@usuario varchar(50),
@clave varchar(10)
as
insert tb_usuarios values(@nombre,@apellido,@usuario,@clave,SYSDATETIME(),1,null)
go

exec sp_addUsuario @nombre='Betsy', @apellido='Pillco',@usuario='betsy@gmail.com', @clave='123456'
go

create or alter procedure usp_validaAcceso 
@usuario varchar(50),
@clave varchar(10)
as
begin
select * from tb_usuarios where usuario = @usuario and clave = @clave 
end
go

create or alter procedure usp_recuperarcontra
@clave varchar(10)
as
begin
update tb_usuarios set clave = @clave
end
go

create or alter proc sp_buscarUsuario
@usuario varchar(50)
as
begin
select clave from tb_usuarios where usuario = @usuario
end
go

