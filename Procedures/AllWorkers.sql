USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[AllWorkers]    Script Date: 15.01.2017 20:55:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Вывод всех сотрудников фабрики>
-- =============================================
CREATE PROCEDURE [dbo].[AllWorkers] 
	
AS
BEGIN
	SELECT [№Паспорта]
	FROM dbo.Сотрудник
END

GO

