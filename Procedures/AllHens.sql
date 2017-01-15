USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[AllHens]    Script Date: 15.01.2017 20:54:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Номера всех куриц на фабрике>
-- =============================================
CREATE PROCEDURE [dbo].[AllHens] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [№Курицы]
	FROM dbo.Курица
END

GO

