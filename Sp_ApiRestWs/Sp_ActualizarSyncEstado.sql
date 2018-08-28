USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarSyncEstado]    Script Date: 28/08/2018 5:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_ActualizarSyncEstado]
(
 @Version UNIQUEIDENTIFIER ,
 @Estado VARCHAR(50)
)
AS
BEGIN

SET NOCOUNT ON;

 UPDATE SyncTransaccion 
                SET Estado = UPPER(@Estado)
                                            WHERE Version = @Version ;


END;