USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[AddHens]    Script Date: 15.01.2017 20:33:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Добавление курицы на фабрику>
-- =============================================
CREATE PROCEDURE [dbo].[AddHens]
	-- Add the parameters for the stored procedure here
	@Code  int, 
	@Breed varchar(50),
	@Weight float,
	@Date date,
	@Count int
AS
IF (SELECT COUNT(КодКлетки) FROM dbo.Клетка WHERE КодКлетки = @Code) >0
BEGIN
	IF (SELECT COUNT(НазваниеПороды) FROM dbo.Порода WHERE НазваниеПороды = @Breed) >0
	BEGIN
	INSERT INTO dbo.Курица (КодКлетки, НазваниеПороды, Вес, ДатаРождения, [Кол-воЯиц])
	VALUES (@Code, @Breed, @Weight, @Date, @Count)
	END
	ELSE PRINT 'На фабрике нет указанной породы'
END
ELSE PRINT 'На фабрике нет указанной клетки'

GO

