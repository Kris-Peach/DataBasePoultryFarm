USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[DepartmentWithHen]    Script Date: 15.01.2017 20:59:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Гриднева К
-- Create date: 08.10.2016
-- Description:	показывает каком цехе находится курица, от которой получают больше всего яиц
-- =============================================
CREATE PROCEDURE [dbo].[DepartmentWithHen]
AS
BEGIN
	SELECT TOP 1 Курица.[№Курицы], Курица.НазваниеПороды, Курица.[Кол-воЯиц],Клетка.[№Цеха]
	FROM Курица INNER JOIN Клетка ON Курица.КодКлетки = Клетка.КодКлетки
	GROUP BY Курица.[№Курицы], Курица.НазваниеПороды, Курица.[Кол-воЯиц], Клетка.[№Цеха]
	ORDER BY Курица.[Кол-воЯиц] DESC
END

GO

