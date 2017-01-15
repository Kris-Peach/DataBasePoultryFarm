USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[CountHensOfBreedInDepartment]    Script Date: 15.01.2017 20:57:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Гриднева К
-- Create date: 08.10.2016
-- Description:	показывает сколько кур каждой породы в каждом цехе
-- =============================================
CREATE PROCEDURE [dbo].[CountHensOfBreedInDepartment]
AS
BEGIN
	SELECT Клетка.[№Цеха], Курица.НазваниеПороды, COUNT(Курица.[№Курицы]) AS [Количество Кур]
	FROM Курица INNER JOIN Клетка ON Курица.КодКлетки = Клетка.КодКлетки
	GROUP BY Клетка.[№Цеха], Курица.НазваниеПороды
END

GO

