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
CREATE PROCEDURE GetAcceptedCitApplicationsByCitizen 
	-- Add the parameters for the stored procedure here
	@Citizen int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CitApplication.ProjectID, UnitID, PricePRoom * NoRooms as UnitPrice 
	from CitApplication, Unit, Project 
	where CitizenID = @Citizen and Unit.ProjectID = CitApplication.ProjectID and Unit.ID = UnitID and AStatus = 'A' and Project.ID = CitApplication.ProjectID
END
GO