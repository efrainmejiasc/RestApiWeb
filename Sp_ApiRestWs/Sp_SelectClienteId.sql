USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_SelectClienteId]    Script Date: 28/08/2018 5:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_SelectClienteId] 
(
 @Id UNIQUEIDENTIFIER
)
AS
BEGIN

SET NOCOUNT ON;

BEGIN TRAN 

SELECT * FROM Cliente  WITH (HOLDLOCK, ROWLOCK) WHERE Id = @Id AND ESTADO = 'ACTIVO' ;

COMMIT TRAN 

END ;
