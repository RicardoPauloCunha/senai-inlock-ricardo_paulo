USE InLock_Games_Manha;

INSERT INTO USUARIOS(Email, Senha, TipoUsuario)
VALUES
('admin@admin.com', 'admin', 'ADMINISTRADIR'),
('cliente@cliente.com', 'cliente', 'CLIENTE');

INSERT INTO ESTUDIOS
VALUES
('Blizzard'),
('Rockstar Studios'),
('Square Enix');

INSERT INTO JOGOS(NomeJogo, Descricao, DataLancamento, Valor, EstudioId)
VALUES
('Diablo3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.', '2012-05-15', 99.00, 1),
('Red Dead Redemption II', 'Jogo eletr�nico de a��o-aventura western.', '2018-10-26', 120.00, 2);



