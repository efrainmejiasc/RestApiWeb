USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_SyncEstado]    Script Date: 17/08/2018 14:15:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_SyncEstado]
(
  @Version UNIQUEIDENTIFIER,
  @FechaCreacion DATE,
  @FechaCreacionUtc VARCHAR(50),
  @NombreTabla VARCHAR(50),
  @Usuario VARCHAR(50),
  @Dispositivo VARCHAR(50), 
  @Estado VARCHAR(50)
)
AS
BEGIN

 SET TRANSACTION ISOLATION LEVEL SERIALIZABLE

    DECLARE @CODIGO INT ;
    DECLARE @STATE VARCHAR(50);

	  BEGIN TRAN;
         BEGIN TRY

    SELECT @STATE = Estado  FROM SyncTransaccion WHERE NUMERO = (SELECT MAX(NUMERO) FROM SyncTransaccion) 

    If (@STATE = 'INICIADO')
    BEGIN
        SET @CODIGO = - 200;
    END

    ELSE
	   BEGIN
	      INSERT INTO SyncTransaccion 
		                      (Version, FechaCreacion, FechaCreacionUtc, NombreTabla, Usuario, Dispositivo, Estado) 
		   VALUES
		                     (@Version, @FechaCreacion, @FechaCreacionUtc ,@NombreTabla ,@Usuario ,@Dispositivo, @Estado)

          SET @CODIGO = 200;
	   END

    COMMIT TRAN;
         SELECT @CODIGO;

         END TRY
		 BEGIN CATCH
             SELECT ERROR_NUMBER() AS ErrorNumber,
                    ERROR_SEVERITY() AS ErrorSeverity,
                    ERROR_STATE() AS ErrorState,
                    ERROR_PROCEDURE() AS ErrorProcedure,
                    ERROR_LINE() AS ErrorLine,
                    ERROR_MESSAGE() AS ErrorMessage;
             ROLLBACK TRAN;
         END CATCH;
END
