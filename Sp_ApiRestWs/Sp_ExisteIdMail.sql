USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ExisteIdMail]    Script Date: 28/08/2018 5:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_ExisteIdMail]
(
 @Id                   UNIQUEIDENTIFIER,
 @Mail                 VARCHAR(50) 
)
  AS

  BEGIN TRAN [SELECCIONIDMAIL]
	                                    BEGIN
                                        DECLARE @CODIGO INT;

                                                 IF(EXISTS( SELECT * FROM Cliente  WHERE Id  = @Id ))
                                                         BEGIN 
                                                         SET @CODIGO = -1; 
												         END;
                                                 ELSE  IF(EXISTS( SELECT * FROM Cliente  WHERE Mail = @MAIL ))
                                                       BEGIN
                                                       SET @CODIGO = -2;
				                                      END
												  ELSE
						                               BEGIN
                                                       SET @CODIGO = 0;
				                                       END
                                                   select @CODIGO;
COMMIT TRAN [SELECCIONIDMAIL]

 END;

					
