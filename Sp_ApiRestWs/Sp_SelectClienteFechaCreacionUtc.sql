USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_SelectClienteFechaCreacionUtc]    Script Date: 28/08/2018 5:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_SelectClienteFechaCreacionUtc] 
(
 @Id UNIQUEIDENTIFIER
)
AS
BEGIN

SET NOCOUNT ON;

BEGIN TRAN

SELECT  FechaCreacionUtc  FROM Cliente WITH (HOLDLOCK, ROWLOCK) WHERE Id = @Id ;

COMMIT TRAN

END; 
