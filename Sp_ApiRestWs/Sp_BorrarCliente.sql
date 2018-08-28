USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_BorrarCliente]    Script Date: 28/08/2018 5:21:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_BorrarCliente]
(
  @Id UNIQUEIDENTIFIER 
)
AS
BEGIN

SET NOCOUNT ON;

 DELETE Cliente WHERE Id = @Id ;

END
