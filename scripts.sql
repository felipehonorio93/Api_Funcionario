﻿-- tabela para cadastro de funcionários (SQL)
CREATE TABLE FUNCIONARIO(
	IDFUNCIONARIO		UNIQUEIDENTIFIER	NOT NULL,
	NOME				NVARCHAR(150)		NOT NULL,
	CPF					NVARCHAR(15)		NOT NULL,
	MATRICULA			NVARCHAR(10)		NOT NULL,
	DATAADMISSAO		DATE				NOT NULL,
	PRIMARY KEY(IDFUNCIONARIO))
GO

-- tabela para cadastro de log de funcionários (SQL)
CREATE TABLE FUNCIONARIO_LOG(
	IDFUNCIONARIO_LOG	UNIQUEIDENTIFIER	NOT NULL,
	DATAHORA			DATETIME			NOT NULL,
	OPERACAO			NVARCHAR(20)		NOT NULL,
	DETALHES			NVARCHAR(MAX)		NOT NULL,
	PRIMARY KEY(IDFUNCIONARIO_LOG))
GO

-- procedure (rotina) para realizar o cadastro de funcionários
CREATE PROCEDURE SP_INSERIR_FUNCIONARIO
	@NOME			NVARCHAR(150),
	@CPF			NVARCHAR(15),
	@MATRICULA		NVARCHAR(10),
	@DATAADMISSAO	DATETIME
AS
DECLARE
	@IDFUNCIONARIO UNIQUEIDENTIFIER
BEGIN
	BEGIN TRANSACTION

	SET @IDFUNCIONARIO = NEWID()

	INSERT INTO FUNCIONARIO(IDFUNCIONARIO, NOME, CPF, MATRICULA, DATAADMISSAO)
	VALUES(@IDFUNCIONARIO, @NOME, @CPF, @MATRICULA, @DATAADMISSAO)

	INSERT INTO FUNCIONARIO_LOG(IDFUNCIONARIO_LOG, DATAHORA, OPERACAO, DETALHES)
	VALUES(NEWID(), GETDATE(), 'CADASTRO', CONCAT(@IDFUNCIONARIO, ', ', @NOME, ', ', @CPF, ', ', @MATRICULA, ', ', @DATAADMISSAO))

	COMMIT
END
GO

-- procedure (rotina) para realizar a atualização de funcionários
CREATE PROCEDURE SP_ALTERAR_FUNCIONARIO
	@IDFUNCIONARIO	UNIQUEIDENTIFIER,
	@NOME			NVARCHAR(150),
	@CPF			NVARCHAR(15),
	@MATRICULA		NVARCHAR(10),
	@DATAADMISSAO	DATETIME
AS
BEGIN
	BEGIN TRANSACTION

	UPDATE FUNCIONARIO SET
		NOME = @NOME,
		CPF = @CPF,
		MATRICULA = @MATRICULA,
		DATAADMISSAO = @DATAADMISSAO
	WHERE
		IDFUNCIONARIO = @IDFUNCIONARIO

	INSERT INTO FUNCIONARIO_LOG(IDFUNCIONARIO_LOG, DATAHORA, OPERACAO, DETALHES)
	VALUES(NEWID(), GETDATE(), 'EDIÇÃO', CONCAT(@IDFUNCIONARIO, ', ', @NOME, ', ', @CPF, ', ', @MATRICULA, ', ', @DATAADMISSAO))

	COMMIT
END
GO

-- procedure (rotina) para realizar a exclusão de funcionários
CREATE PROCEDURE SP_EXCLUIR_FUNCIONARIO
	@IDFUNCIONARIO	UNIQUEIDENTIFIER
AS
DECLARE
	@NOME			NVARCHAR(150),
	@CPF			NVARCHAR(15),
	@MATRICULA		NVARCHAR(10),
	@DATAADMISSAO	DATETIME
BEGIN

	SELECT
		@NOME = NOME,
		@CPF = CPF,
		@MATRICULA = MATRICULA,
		@DATAADMISSAO = DATAADMISSAO
	FROM FUNCIONARIO 	
	WHERE IDFUNCIONARIO = @IDFUNCIONARIO

	BEGIN TRANSACTION

	DELETE FROM FUNCIONARIO
	WHERE IDFUNCIONARIO = @IDFUNCIONARIO

	INSERT INTO FUNCIONARIO_LOG(IDFUNCIONARIO_LOG, DATAHORA, OPERACAO, DETALHES)
	VALUES(NEWID(), GETDATE(), 'EXCLUSÃO', CONCAT(@IDFUNCIONARIO, ', ', @NOME, ', ', @CPF, ', ', @MATRICULA, ', ', @DATAADMISSAO))

	COMMIT
END
GO

-- procedure (rotina) para realizar a consulta de funcionários
CREATE PROCEDURE SP_CONSULTAR_FUNCIONARIOS
AS
BEGIN
	SELECT * FROM FUNCIONARIO 	
	ORDER BY NOME ASC
END
GO

-- procedure (rotina) para realizar a consulta de 1 funcionário pelo ID
CREATE PROCEDURE SP_OBTER_FUNCIONARIO
	@IDFUNCIONARIO	UNIQUEIDENTIFIER
AS
BEGIN
	SELECT * FROM FUNCIONARIO 	
	WHERE IDFUNCIONARIO = @IDFUNCIONARIO
END
GO
