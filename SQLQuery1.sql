use master
go

if db_id('dbapitrabajador') is not null
begin
	drop database dbapitrabajador
end
go

create database dbapitrabajador
go

use dbapitrabajador
go

create table cargo(
idcargo int primary key identity,
nombre nvarchar(100) not null,
descripcion nvarchar(500),
fecharegistro datetime2 default current_timestamp,
fechamodificacion datetime2 default current_timestamp
)
go

create table trabajador(
idtrabajador int primary key identity,
idcargo int references cargo(idcargo),
nombre nvarchar(100) not null,
edad int not null,
salario decimal(10, 2) not null,
fecharegistro datetime2 default current_timestamp,
fechamodificacion datetime2 default current_timestamp
)
go

create table pagotrabajador(
idpagotrabajador int primary key identity,
idtrabajador int references trabajador(idtrabajador),
fechapago datetime2 not null default current_timestamp,
totalpago decimal(10, 2) not null,
fecharegistro datetime2 default current_timestamp,
fechamodificacion datetime2 default current_timestamp
)
go
