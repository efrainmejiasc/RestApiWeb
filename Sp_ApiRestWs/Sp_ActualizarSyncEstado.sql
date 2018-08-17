USE [DB_A3F354_RESTSYNC]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_ActualizarSyncEstado]
(
 @Version UNIQUEIDENTIFIER ,
 @Estado VARCHAR(50)
)
AS
BEGIN

SET NOCOUNT ON;

 UPDATE SyncTransaccion 
                SET  Estado = UPPER(@Estado)
                                    WHERE Version = @Version ;


END;