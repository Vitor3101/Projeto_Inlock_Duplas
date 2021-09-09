USE Inlock_Games_Tarde
GO

--Lista todos usuarios
SELECT * FROM Usuario

--Lista todos Estudios
SELECT * FROM Estudio

--Lista todos jogos
SELECT * FROM Jogos


--Lista todos jogos e seus estudios
SELECT Nome, Descricao, Valor, DataLancamento, NomeEstudio FROM Jogos
INNER JOIN Estudio
ON Jogos.idEstudio = Estudio.idEstudio


--Lista todos jogos e todos estudios, mesmo que não tenham jogos
SELECT Nome, Descricao, Valor, DataLancamento, NomeEstudio FROM Jogos
LEFT JOIN Estudio
ON Jogos.idEstudio = Estudio.idEstudio


--Lista um usuario atraves de um email e senha
SELECT * FROM USUARIO
WHERE Email ='admin@admin.com' and Senha ='admin'

--Lista um jogo atraves do ID
SELECT * FROM Jogos 
WHERE idJogos = 2

--Lista um estudio atraves do ID
SELECT * FROM Estudio 
WHERE idEstudio = 2
