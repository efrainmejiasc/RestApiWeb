/*
   lunes, 6 de agosto de 201811:05:22
   Usuario: sa
   Servidor: EMCSERVER
   Base de datos: DB_A3A5F7_FEC
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
	Id uniqueidentifier NOT NULL,
	Nombre varchar(50) NULL,
	Edad int NULL,
	Telefono varchar(50) NULL,
	Saldo float(53) NULL,
	FechaCreacion datetime NULL,
	FechaCreacionUtc datetime NULL,
	FechaModificacion datetime NULL,
	FechaModificacionUtc datetime NULL,
	Proceso int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Cliente ADD CONSTRAINT
	PK_Cliente PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE UNIQUE NONCLUSTERED INDEX IX_Cliente ON dbo.Cliente
	(
	Numero
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.Cliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'CONTROL') as Contr_Per 