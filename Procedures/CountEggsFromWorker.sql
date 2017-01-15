USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[CountEggsFromWorker]    Script Date: 15.01.2017 20:56:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Гриднева К.
-- Create date: 08.10.2016
-- Description:	показывает сколько яиц в день приносят куры указанного работника
-- =============================================
CREATE PROCEDURE [dbo].[CountEggsFromWorker]
	-- Add the parameters for the stored procedure here
	@FullName varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT (SUM([Кол-воЯиц])/30 )AS КоличествоЯицВДень
	FROM (Сотрудник INNER JOIN Обслуживает ON Сотрудник.[№Паспорта] = Обслуживает.[№Паспорта]) INNER JOIN Курица ON Обслуживает.КодКлетки = Курица.КодКлетки
	GROUP BY Сотрудник.ФИО
	HAVING (Сотрудник.ФИО = @FullName)
END

GO

