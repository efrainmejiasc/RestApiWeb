USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertarClienteAll]    Script Date: 28/08/2018 5:26:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_InsertarClienteAll] 
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

BEGIN TRAN [CLIENTE]


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

   SAVE TRAN [CLIENTETRACK]
   ROLLBACK TRAN [CLIENTETRACK]

       INSERT INTO Cliente (
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
   Estado ) 
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
   UPPER(@Estado));

   SAVE TRAN [CLIENTE]
   ROLLBACK TRAN [CLIENTE]

   COMMIT TRAN [CLIENTE]

END ;