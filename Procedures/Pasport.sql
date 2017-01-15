USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[Pasport]    Script Date: 15.01.2017 21:00:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Номер паспорта по фамилии сотрудника>
-- =============================================
CREATE PROCEDURE [dbo].[Pasport]
	-- Add the parameters for the stored procedure here
	@FullName varchar(50)
	
AS
BEGIN
	
	SELECT [№Паспорта]
	FROM dbo.Сотрудник
	WHERE ФИО = @FullName
END

GO

