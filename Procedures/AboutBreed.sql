USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[AboutBreed]    Script Date: 15.01.2017 20:32:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Гриднева К.
-- Create date: 08.10.2016
-- Description:	выдает справку о породе и информацию о курах этой породы, имеющихся на фабрике
-- =============================================
CREATE PROCEDURE [dbo].[AboutBreed]
	@NameBreed varchar(50)
AS
BEGIN
	SELECT Порода.НазваниеПороды, Порода.Производительность, AVG(Порода.СреднийВес) AS [Средний вес кур],
	Порода.[№Диеты], COUNT(Курица.[№Курицы]) AS [Кол-во кур], AVG(Курица.Вес)AS [Средний вес],
	AVG(Курица.[Кол-воЯиц]) AS [Среднее кол-во яиц] 
	FROM Порода INNER JOIN Курица ON (Порода.НазваниеПороды = Курица.НазваниеПороды)
	GROUP BY Порода.НазваниеПороды, Порода.Производительность, Порода.[№Диеты]
	HAVING Порода.НазваниеПороды = @NameBreed
END

GO

