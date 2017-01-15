USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[DeleteBreed]    Script Date: 15.01.2017 20:57:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Удаление породы изтаблицы Порода, выбор удаляемой породы по запросу AllBreed>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBreed] 
	@NameBreed varchar(50) 
	
AS
IF(SELECT COUNT(НазваниеПороды) FROM dbo.Курица WHERE НазваниеПороды = @NameBreed ) < 0
BEGIN
	DELETE dbo.Порода
	WHERE НазваниеПороды = @NameBreed 
END
ELSE PRINT 'Курицы выбранной породы присутствуют на фабрике, удаление невозможно'

GO

