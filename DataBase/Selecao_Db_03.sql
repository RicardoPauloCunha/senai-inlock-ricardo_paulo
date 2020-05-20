USE InLock_Games;
GO

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

-- Lista os jogos do estudio com id 3
SELECT JogoId, NomeJogo, Descricao, DataLancamento, Valor, EstudioId FROM JOGOS WHERE EstudioId = 3;

--- Function Execute

--- Busca um Usuário por email e senha;
SELECT * FROM BuscarUsuario('cliente@cliente.com', 'cliente');

--- Busca um Jogo pelo id
SELECT * FROM BuscarJogo(1);

--- Busca um Estúdio pelo id
SELECT * FROM BuscarEstudio(2);
