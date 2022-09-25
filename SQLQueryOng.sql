CREATE DATABASE DbOng

USE dbOng

CREATE TABLE Adotante (

	CPF varchar(11) NOT NULL,
	Nome varchar(50) NOT NULL,
	Sexo char(1) NOT NULL,
	DataNasc Date NOT NULL,
	Telefone varchar(11) NOT NULL,
	Logradouro varchar(50) NOT NULL,
	Numero varchar(10) NOT NULL,
	Complemento varchar(50),
	Bairro varchar(50) NOT NULL,
	Cidade varchar(50) NOT NULL,
	Estado varchar(50) NOT NULL,
	Cep varchar(11)

	CONSTRAINT PK_Adotante PRIMARY KEY (CPF)
);

CREATE TABLE Animal (

	NumChip int IDENTITY,
	Familia varchar(50) NOT NULL,
	Raca varchar(50) NOT NULL,
	Sexo char(1) NOT NULL,
	Nome varchar(50),

	CONSTRAINT PK_Animal PRIMARY KEY (NumChip)
);

CREATE TABLE Adocoes(
	
	DataDoacao datetime,
	FK_Animal_NumChip int,
	FK_Adotante_CPF varchar(11),

	
	CONSTRAINT FK_Animal FOREIGN KEY (FK_Animal_NumChip)  REFERENCES Animal(NumChip),
	CONSTRAINT FK_Adotante FOREIGN KEY (FK_Adotante_CPF)  REFERENCES Adotante(CPF),
	CONSTRAINT PK_Adocoes PRIMARY KEY (FK_Animal_NumChip, FK_Adotante_CPF),
	
);

