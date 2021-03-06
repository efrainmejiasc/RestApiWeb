USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_SelectFilasSync]    Script Date: 28/08/2018 5:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_SelectFilasSync] 
(
 @Version UNIQUEIDENTIFIER
)
AS
BEGIN

SET NOCOUNT ON;

   BEGIN TRAN

     SELECT * FROM Cliente WHERE  Id IN (SELECT DISTINCT Id FROM ClienteTrack
                       WHERE FechaModificacionUtc >= (SELECT FechaCreacionUtc FROM SyncTransaccion WHERE Version = @Version)) ORDER BY CLIENTE.NUMERO ASC 

   COMMIT TRAN 
END 
