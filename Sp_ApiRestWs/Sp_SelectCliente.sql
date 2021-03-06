USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_SelectCliente]    Script Date: 28/08/2018 5:29:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_SelectCliente] 


AS
BEGIN

SET NOCOUNT ON;

BEGIN TRAN

SELECT *  FROM Cliente WITH (HOLDLOCK, ROWLOCK) WHERE Estado = 'ACTIVO' ORDER BY Numero ASC;

COMMIT TRAN 
END 
