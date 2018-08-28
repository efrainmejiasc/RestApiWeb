USE [DB_A3F354_RESTSYNC]
GO
/****** Object:  StoredProcedure [dbo].[Sp_SyncInOutExito]    Script Date: 28/08/2018 5:36:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 ALTER PROCEDURE [dbo].[Sp_SyncInOutExito] 
(
  @Version VARCHAR(50),
  @Estado VARCHAR(50)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT Numero  FROM SyncTransaccion WHERE Version = @Version AND Estado = UPPER(@Estado) ;

END 
