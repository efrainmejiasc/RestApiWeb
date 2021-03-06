USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarClienteAll]    Script Date: 28/08/2018 5:16:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_ActualizarClienteAll]
(
 @Id UNIQUEIDENTIFIER ,
 @Nombre VARCHAR(50),
 @Edad INT, 
 @Telefono VARCHAR(50),
 @Mail Varchar(50), 
 @Saldo FLOAT, 
 @FechaCreacion DATETIME,
 @FechaCreacionUtc Varchar(50), 
 @FechaModificacion DATETIME, 
 @FechaModificacionUtc Varchar(50),
 @Proceso VARCHAR(50),
 @Usuario VARCHAR(50),
 @Estado VARCHAR(50),
 @Transaccion VARCHAR(50)
)
AS
BEGIN

SET NOCOUNT ON;

SET  TRANSACTION ISOLATION LEVEL SERIALIZABLE

BEGIN TRAN [CLIENTETRACK]

INSERT INTO ClienteTrack (
   Id,
   Nombre ,
   Edad , 
   Telefono , 
   Mail,
   Saldo , 
   FechaCreacion ,
   FechaCreacionUtc , 
   FechaModificacion , 
   FechaModificacionUtc ,
   Proceso ,
   Usuario,
   Estado,
   Transaccion ) 
 VALUES (
   @Id,
   @Nombre ,
   @Edad , 
   @Telefono ,
   @Mail, 
   @Saldo , 
   @FechaCreacion ,
   @FechaCreacionUtc , 
   @FechaModificacion , 
   @FechaModificacionUtc ,
   @Proceso ,
   @Usuario,
   UPPER(@Estado),
   UPPER(@Transaccion))

   
   SAVE TRAN [CLIENTEINSERT]
   ROLLBACK TRAN [CLIENTEINSERT]


 UPDATE Cliente WITH (HOLDLOCK, ROWLOCK) 
                SET  
                  Nombre = @Nombre,
                  Edad = @Edad, 
                  Telefono =  @Telefono,
                  Mail = @Mail, 
                  Saldo = @Saldo, 
                  FechaModificacion = @FechaModificacion, 
                  FechaModificacionUtc = @FechaModificacionUtc,
                  Usuario = @Usuario,
                  Estado = UPPER(@Estado)
                                   WHERE Id = @Id ;

  SAVE TRAN [CLIENTEUPDATE]
  ROLLBACK TRAN [CLIENTEUPDATE]
  COMMIT TRAN   [CLIENTETRACK] 

END;
