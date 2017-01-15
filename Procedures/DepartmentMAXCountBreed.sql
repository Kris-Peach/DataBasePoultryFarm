USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[DepartmentMAXCountBreed]    Script Date: 15.01.2017 20:59:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Гриднева К.
-- Create date: 08.10.2016
-- Description:	показывает каком цехе наибольшее количество кур определенной породы
-- =============================================
CREATE PROCEDURE [dbo].[DepartmentMAXCountBreed]
	@NameBreed varchar(50)

AS
IF (SELECT COUNT(НазваниеПороды) FROM Курица WHERE НазваниеПороды = @NameBreed) > 0
BEGIN
	SELECT TOP 1 Клетка.[№Цеха] FROM Клетка INNER JOIN  Курица ON Клетка.КодКлетки=Курица.КодКлетки
	GROUP BY Клетка.[№Цеха], Курица.НазваниеПороды
	HAVING (Курица.НазваниеПороды = @NameBreed)
	ORDER BY COUNT(Курица.КодКлетки) DESC 
END
ELSE PRINT 'На фабрике нет курицы указанной породы'

GO

