USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[AllBreed]    Script Date: 15.01.2017 20:54:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Вывод названия всех пород >
-- =============================================
CREATE PROCEDURE [dbo].[AllBreed]
	
AS
BEGIN
	SELECT НазваниеПороды
	FROM dbo.Порода
END

GO

