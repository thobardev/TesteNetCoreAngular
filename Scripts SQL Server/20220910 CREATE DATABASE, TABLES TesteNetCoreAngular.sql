CREATE DATABASE TesteNetCoreAngular 
COLLATE Latin1_General_100_CI_AI
go
use TesteNetCoreAngular
go
create table Escolaridade
(
   	Id int not null primary key identity(1,1),
   	Descricao nvarchar(100) not null,
);
go
create table Usuarios
(
   	Id int not null primary key identity(1,1),
   	
   	Nome nvarchar(100) not null,
   	Sobrenome varchar(200) not null,
	Email varchar(200) not null,
   	DataNascimento datetime not null,
   	EscolaridadeId int not null FOREIGN KEY REFERENCES Escolaridade(Id)
);
