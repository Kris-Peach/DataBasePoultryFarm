USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[AllPosition]    Script Date: 15.01.2017 20:54:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Вывод всех должностей>
-- =============================================
CREATE PROCEDURE [dbo].[AllPosition]
	
AS
BEGIN
	SELECT [Название должности]
	FROM dbo.Должность
END

GO

