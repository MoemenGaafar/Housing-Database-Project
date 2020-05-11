USE [Monkey]
GO
/****** Object:  StoredProcedure [dbo].[ClaimCitApplication]    Script Date: 5/10/2020 5:54:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[ClaimCitApplication] 
	-- Add the parameters for the stored procedure here
	@Citizen int, 
	@Project int, 
	@Unit int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update CitApplication
	Set AStatus = 'D'
	Where CitizenID = @Citizen and ProjectID = @Project and UnitID = @Unit 
	
	Update Unit
	Set UStatus = 1, PaymentEndDate = DATEADD(year, 5, GETDATE()) 
	Where ProjectID = @Project and ID = @Unit

	Update CitApplication 
	Set AStatus = 'R'
	Where CitizenID != @Citizen and ProjectID = @Project and UnitID = @Unit

END
