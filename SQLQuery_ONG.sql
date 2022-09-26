CREATE DATABASE ONG

CREATE TABLE Pessoa 
(
   Nome varchar(50) NOT NULL, 
   CPF char(20) NOT NULL, 
   Sexo char(1) NULL,
   Data_Nascimento datetime NULL,
   Telefone char(11) NULL, 
   Cod_Endereco int NOT NULL, 

   CONSTRAINT PK_Pessoa PRIMARY KEY (CPF),
   CONSTRAINT FK_Endereco FOREIGN KEY (Cod_Endereco) REFERENCES Endereco (Cod_Endereco),
   CONSTRAINT CH_Pessoa CHECK (Sexo IN ('F', 'M'))
);

CREATE TABLE Endereco
(
	Logradouro varchar(50) NULL,
	Bairro varchar(20) NULL,
	Numero int NULL, 
	Complemento varchar(50) NULL,
	CEP int NULL,
	Cidade varchar(50) NULL,
	UF char(2) NULL, 
	Cod_Endereco int IDENTITY(1,1),

	CONSTRAINT PK_Endereco PRIMARY KEY (Cod_Endereco), 
); 


CREATE TABLE Animal 
( 
	
	CHIP int NOT NULL,
	Raca varchar(30) NULL,
	Sexo char(1) NULL, 
	Nome varchar(30) NULL,
	CPF char(20) NULL, 
	Cod_Familia int Not NULL, 

	CONSTRAINT PK_Animal PRIMARY KEY (CHIP),
	CONSTRAINT FK_Pessoa_Animal_CPF FOREIGN KEY (CPF) REFERENCES PESSOA (CPF),
	CONSTRAINT FK_Familia FOREIGN KEY (Cod_Familia) REFERENCES Familia (Cod_Familia), 
	CONSTRAINT CH_Animal CHECK (Sexo IN ('F', 'M'))

); 

CREATE TABLE Familia
(
	Cod_Familia int IDENTITY(1,1), 
	Tipo varchar(20) NULL, 
	
	CONSTRAINT PK_Familia PRIMARY KEY(Cod_Familia), 
);


SELECT Familia.Cod_Familia
FROM Familia
WHERE Cod_Familia = 8;

SELECT * FROM Pessoa

--Inserir Pessoa 
INSERT INTO Pessoa (Nome, CPF, Sexo, Data_Nascimento, Telefone, Cod_Endereco)
VALUES ('Fernanda', '', 'F', '19-02-1998', '32538204', 1);

INSERT INTO Endereco(Logradouro,Bairro, Numero, Complemento,CEP, Cidade, UF)
OUTPUT INSERTED.Cod_Endereco
Values ('Av 2', 'Vila', 369, 'Casa', 15900000, 'Taquaritinga', 'SP');

SELECT Pessoa.Nome, Pessoa.CPF, Pessoa.Sexo, Pessoa.Data_Nascimento, Pessoa.Telefone, Endereco.Logradouro,
                Endereco.Bairro, Endereco.Numero, Endereco.Complemento, Endereco.CEP, Endereco.Cidade, Endereco.UF 
				FROM Pessoa, Endereco 
                WHERE Pessoa.Cod_Endereco = Endereco.Cod_Endereco AND Pessoa.CPF = '37143022047'

--Todas as pessoas Cadastradas 
SELECT Pessoa.Nome, Pessoa.CPF, Pessoa.Sexo, Pessoa.Data_Nascimento, Pessoa.Telefone
FROM Pessoa

--Pessoa com endereço 
SELECT Pessoa.Nome, Pessoa.CPF, Pessoa.Sexo, Pessoa.Data_Nascimento, Pessoa.Telefone, Endereco.Logradouro,
Endereco.Bairro, Endereco.Numero, Endereco.Complemento, Endereco.CEP, Endereco.Cidade, Endereco.UF, 
FROM Pessoa, Endereco
Where Pessoa.Cod_Endereco = Endereco.Cod_Endereco AND Pessoa.CPF ='37143022047'

SELECT Pessoa.Nome, Pessoa.CPF, Animal.CHIP, Animal.Raca, Animal.Sexo, Animal.Nome, Animal.Cod_Familia, Familia.Tipo
FROM Pessoa, Animal, Familia
WHERE Pessoa.CPF = Animal.CPF
AND Familia.Cod_Familia = Animal.Cod_Familia
AND Pessoa.CPF = '37143022047'

UPDATE Endereco
SET Logradouro = 'Residencial'
FROM Pessoa
WHERE Pessoa.Cod_Endereco = Endereco.Cod_Endereco
AND Pessoa.CPF = '37143022047';

UPDATE Animal
SET CPF = '37143022047'
WHERE Animal.CHIP= '2'

Update Familia
SET Tipo = 'Cachorro'
WHERE Cod_Familia = '1'

SELECT * FROM FAMILIA 

-- Pessoas com animais
SELECT * FROM Animal

INNER JOIN Animal on Pessoa.CPF = Animal.CPF;

SELECT * FROM PESSOA

--Inserir Endereço 
--Inserir Animal 
INSERT INTO Animal (CHIP, Raca, Sexo, Nome, Cod_Familia)
Values ('4', 'Poodle', 'M', 'Fred', 1)

SELECT * FROM ANIMAL 

--Todas os Animais Cadastrados 
SELECT Animal.CHIP, Animal.Raca, Animal.Sexo, Animal.Nome, Animal.CPF, Familia.Cod_Familia, Familia.Tipo
FROM Animal, Familia
WHERE Animal.CHIP = 1;



--Inserir Familia 
INSERT INTO Familia (Cod_Familia, Tipo, CHIP)
VALUES ('1', 'Gato', '13'),
		('2', 'Cachorro', '12');

--Todas as familias cadastradas
SELECT Familia.Cod_Familia, Familia.Tipo, Familia.CHIP
FROM Familia


--Os animais que determinado CPF tem 
SELECT Pessoa.Nome, Pessoa.CPF, Animal.CHIP, Animal.Raca
FROM Pessoa, Animal
WHERE  Pessoa.CPF = Animal.CPF


SELECT * FROM Endereco
SELECT * FROM Pessoa

DELETE FROM Pessoa
DELETE FROM Endereco