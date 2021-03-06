/*
   viernes, 24 de agosto de 20184:27:38
   Usuario: sa
   Servidor: EMCSERVER
   Base de datos: DB_A3F354_RESTSYNC
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.ClienteTrack
	(
	Numero int NOT NULL IDENTITY (1, 1),
	Id uniqueidentifier NULL,
	Nombre varchar(50) NULL,
	Edad varchar(50) NULL,
	Telefono varchar(50) NULL,
	Saldo float(53) NULL,
	FechaCreacion datetime NULL,
	FechaCreacionUtc varchar(50) NULL,
	FechaModificacion datetime NULL,
	FechaModificacionUtc varchar(50) NULL,
	Proceso int NULL,
	Transaccion varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ClienteTrack ADD CONSTRAINT
	PK_ClienteTrack PRIMARY KEY CLUSTERED 
	(
	Numero
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ClienteTrack SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ClienteTrack', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ClienteTrack', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ClienteTrack', 'Object', 'CONTROL') as Contr_Per 