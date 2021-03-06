USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ExisteVersionSync]    Script Date: 28/08/2018 5:23:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_ExisteVersionSync]
(
  @Version UNIQUEIDENTIFIER
)
AS
BEGIN
   SET  TRANSACTION ISOLATION LEVEL SERIALIZABLE

    BEGIN TRAN [Sync]

	SELECT Numero FROM SyncTransaccion WHERE Version = @Version;

    COMMIT TRAN [Sync]

END
