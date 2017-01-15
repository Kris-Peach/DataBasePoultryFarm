USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[CountHensForWorker]    Script Date: 15.01.2017 20:56:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Гриднева К.
-- Create date: 08.10.2016
-- Description:	показывает какое количество кур обслуживает каждый работник
-- =============================================
CREATE PROCEDURE [dbo].[CountHensForWorker]
AS
BEGIN
	SELECT Сотрудник.НазваниеДолжности, Сотрудник.ФИО, COUNT(Курица.[№Курицы]) AS [Количество Кур]
	FROM (Сотрудник INNER JOIN Обслуживает ON Сотрудник.[№Паспорта] = Обслуживает.[№Паспорта]) INNER JOIN Курица ON Обслуживает.КодКлетки = Курица.КодКлетки
	GROUP BY Сотрудник.НазваниеДолжности, Сотрудник.ФИО
	HAVING (Сотрудник.НазваниеДолжности = 'Рабочий по уходу за птицей')
END

GO

