USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[AddBreed]    Script Date: 15.01.2017 20:32:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Добавление породы в базу>
-- =============================================
CREATE PROCEDURE  [dbo].[AddBreed]
	-- Add the parameters for the stored procedure here
	@NameBreed varchar(50), 
	@Power int,
	@Weight float,
	@Diete int
AS
IF (SELECT COUNT (НазваниеПороды) FROM dbo.Порода WHERE НазваниеПороды = @NameBreed) = 0
BEGIN
	INSERT INTO dbo.Порода (НазваниеПороды, Производительность, СреднийВес, [№Диеты])
	VALUES (@NameBreed, @Power, @Weight, @Diete)
END
ELSE PRINT 'На фабрике есть такая порода'

GO

