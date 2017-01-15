USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[AllCell]    Script Date: 15.01.2017 20:54:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Вывод всех клеок фабрики>
-- =============================================
CREATE PROCEDURE [dbo].[AllCell] 
	
AS
BEGIN
	
	SELECT КодКлетки
	FROM dbo.Клетка
END

GO

