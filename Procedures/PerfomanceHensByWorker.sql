USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[PerfomanceHensByWorker]    Script Date: 15.01.2017 21:01:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Гриднева К.
-- Create date: 08.10.2016
-- Description:	показывает среднее количество яиц, которое получает в месяц каждый работник от обслуживаемых им кур.
-- =============================================
CREATE PROCEDURE [dbo].[PerfomanceHensByWorker]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Сотрудник.ФИО, AVG(Курица.[Кол-воЯиц]) AS СреднееКоличествоЯиц
	FROM (Сотрудник INNER JOIN Обслуживает ON Сотрудник.[№Паспорта] = Обслуживает.[№Паспорта]) INNER JOIN Курица ON Обслуживает.КодКлетки = Курица.КодКлетки
	GROUP BY Сотрудник.ФИО
END

GO

