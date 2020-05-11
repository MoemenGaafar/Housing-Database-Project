-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SelectProjectByEmployee
	@EID int,
	@Etype char(1)
AS
IF (@Etype = 'H')
BEGIN
	SET NOCOUNT ON;
	SELECT PID As "ID" FROM HousingEmployee WHERE EID = @EID
END
ELSE IF(@Etype = 'P')
BEGIN
	SET NOCOUNT ON;
	SELECT ID FROM Project WHERE PEmployeeID = @EID
END
ELSE
BEGIN
	SET NOCOUNT ON;
	SELECT ID FROM Project WHERE MEmployeeID = @EID
END
GO
