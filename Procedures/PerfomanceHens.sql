USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[PerfomanceHens]    Script Date: 15.01.2017 21:01:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Производительность курицы по номеру курицы>
-- =============================================
CREATE PROCEDURE [dbo].[PerfomanceHens]
	-- Add the parameters for the stored procedure here
	@Num int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Кол-воЯиц]
	FROM dbo.Курица
	WHERE [№Курицы] = @Num
END

GO

