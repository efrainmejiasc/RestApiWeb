USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ExisteSyncIniciada]    Script Date: 28/08/2018 5:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_ExisteSyncIniciada]

AS
BEGIN

 SET TRANSACTION ISOLATION LEVEL SERIALIZABLE

    DECLARE @CODIGO INT ;
    DECLARE @STATE VARCHAR(50);
	DECLARE @TIEMPO INT;
	DECLARE @NUMERO INT;


	  BEGIN TRAN;
         BEGIN TRY

		      SET @NUMERO =(SELECT MAX(NUMERO) FROM SyncTransaccion);

              SELECT @STATE = Estado ,  @TIEMPO = DATEDIFF(MINUTE,FECHACREACION,GETDATE()) FROM SyncTransaccion WITH (HOLDLOCK, ROWLOCK)  WHERE NUMERO = @NUMERO
			  IF (@TIEMPO >= 10 AND @STATE ='INICIADO')
	            BEGIN
			    	PRINT @NUMERO
		            DELETE FROM SYNCTRANSACCION WHERE NUMERO = @NUMERO;
					SET @STATE ='TERMINADO'
                END


    If (@STATE = 'INICIADO')
    BEGIN
        SET @CODIGO = - 200;
    END

    ELSE
	   BEGIN
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
