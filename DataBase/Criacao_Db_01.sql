CREATE DATABASE InLock_Games;
GO

USE InLock_Games;
GO

--- Tables Create

CREATE TABLE ESTUDIOS (
	EstudioId INT IDENTITY PRIMARY KEY NOT NULL
	, NomeEstudio VARCHAR(250) UNIQUE NOT NULL
);

CREATE TABLE JOGOS (
	JogoId INT IDENTITY PRIMARY KEY NOT NULL
	, NomeJogo VARCHAR(250) UNIQUE NOT NULL
	, Descricao TEXT NOT NULL
	, DataLancamento DATE NOT NULL
	, Valor DECIMAL NOT NULL
	, EstudioId INT FOREIGN KEY REFERENCES ESTUDIOS(EstudioId)
);

CREATE TABLE USUARIOS (
	UsuarioId INT IDENTITY PRIMARY KEY NOT NULL
	, Email VARCHAR(250) UNIQUE NOT NULL
	, Senha VARCHAR(250) NOT NULL
	, TipoUsuario VARCHAR(250) NOT NULL
);
GO

--- Functions Create
--- Function que busca o usuário pelo email ou senha 
CREATE FUNCTION dbo.BuscarUsuario(@email VARCHAR(250), @senha VARCHAR(250))
RETURNS TABLE
AS
RETURN
SELECT U.UsuarioId, U.Email, U.Senha, U.TipoUsuario FROM USUARIOS U WHERE U.Email = @email AND U.Senha = Senha;
GO

--- Function que busca o jogo pelo id 
CREATE FUNCTION dbo.BuscarJogo(@jogoId int)
RETURNS TABLE
AS
RETURN
SELECT * FROM JOGOS J WHERE J.JogoId = @jogoId;
GO

--- Function que busca o estúdio pelo id
CREATE FUNCTION dbo.BuscarEstudio(@estudioId int)
RETURNS TABLE
AS
RETURN
SELECT * FROM ESTUDIOS E WHERE E.EstudioId = @estudioId;
GO