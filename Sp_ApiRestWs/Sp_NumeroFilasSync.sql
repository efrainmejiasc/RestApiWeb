USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_NumeroFilasSync]    Script Date: 28/08/2018 5:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_NumeroFilasSync] 
(
 @FechaCreacionUtc VARCHAR(50)
)
AS
BEGIN

SET NOCOUNT ON;

   BEGIN TRAN

     SELECT COUNT(*) FROM SyncTransaccion WHERE FechaCreacion >= @FechaCreacionUtc ;

   COMMIT TRAN 
END 

