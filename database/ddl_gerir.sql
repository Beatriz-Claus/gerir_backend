--Cria o banco de dados com o nome Gerir
create database Gerir

-- Define o banco Gerir
use Gerir

--Cria a tabela Usuarios
create table Usuarios(
	id uniqueidentifier primary key,
	nome varchar(150) not null,
	email varchar(150) not null,
	senha varchar(150) not null,
	tipo varchar(100) not null
)

--Cria a tabela tarefas
create table Tarefas (
	id uniqueidentifier primary key,
	titulo varchar(150) not null,
	descricao text not null,
	categoria varchar(150) not null,
	dataentrega datetime not null,
	status bit,
	usuario_id uniqueidentifier
	Foreign Key (usuario_id) References Usuarios(id) on delete cascade 
)

