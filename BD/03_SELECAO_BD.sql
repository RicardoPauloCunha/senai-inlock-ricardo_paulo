USE InLock_Games_Manha;

--- Lista todos os Usuários
SELECT UsuarioId, Email, Senha, TipoUsuario FROM USUARIOS;

--- Lista todos os Estúdios
SELECT EstudioId, NomeEstudio FROM ESTUDIOS;

--- Lista todos os Jogos
SELECT JogoId, NomeJogo, Descricao, CONVERT(VARCHAR, DataLancamento, 106) AS DataLancamento, Valor, EstudioId FROM Jogos;

--- Lista todos os Jogos e seu Estúdios
SELECT J.JogoId, J.NomeJogo, J.Descricao, CONVERT(VARCHAR, J.DataLancamento, 106) AS DataLancamento, J.Valor, J.EstudioId, E.EstudioId, E.NomeEstudio 
FROM JOGOS J 
INNER JOIN ESTUDIOS E 
ON 
J.EstudioId = E.EstudioId;

--- Lista Estúdios e seus Jogos mesmo sem nenhuma referencia
SELECT E.EstudioId, E.NomeEstudio, J.JogoId, J.NomeJogo
FROM ESTUDIOS E 
FULL OUTER JOIN JOGOS J 
ON E.EstudioId = J.EstudioId;

SELECT JogoId, NomeJogo, Descricao, DataLancamento, Valor, EstudioId FROM JOGOS WHERE EstudioId = 3;


--- Functions Create

--- Function que busca o usuário pelo email ou senha 
CREATE FUNCTION dbo.BuscarUsuario(@email VARCHAR(250), @senha VARCHAR(250))
RETURNS TABLE
AS
RETURN
	SELECT U.UsuarioId, U.Email, U.Senha, U.TipoUsuario FROM USUARIOS U WHERE U.Email = @email AND U.Senha = Senha; 

--- Function que busca o jogo pelo id 
CREATE FUNCTION dbo.BuscarJogo(@jogoId int)
RETURNS TABLE
AS
RETURN
	SELECT * FROM JOGOS J WHERE J.JogoId = @jogoId;

--- Function que busca o estúdio pelo id
CREATE FUNCTION dbo.BuscarEstudio(@estudioId int)
RETURNS TABLE
AS
RETURN
	SELECT * FROM ESTUDIOS E WHERE E.EstudioId = @estudioId;


--- Function Execute

--- Busca um Usuário por email e senha;
SELECT * FROM BuscarUsuario('cliente@cliente.com', 'cliente');

--- Busca um Jogo pelo id
SELECT * FROM BuscarJogo(1);

--- Busca um Estúdio pelo id
SELECT * FROM BuscarEstudio(2);
