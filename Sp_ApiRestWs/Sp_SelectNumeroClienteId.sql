USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_SelectNumeroClienteId]    Script Date: 28/08/2018 5:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_SelectNumeroClienteId] 
(
 @Id UNIQUEIDENTIFIER
)
AS
BEGIN

SET NOCOUNT ON;

BEGIN TRAN 

SELECT Numero FROM Cliente WITH (HOLDLOCK, ROWLOCK) WHERE Id = @Id ;

COMMIT TRAN 

END; 