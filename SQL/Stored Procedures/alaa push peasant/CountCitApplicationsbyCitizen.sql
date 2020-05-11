USE [Monkey]
GO
/****** Object:  StoredProcedure [dbo].[CountCitApplicationsbyCitizen]    Script Date: 5/11/2020 12:15:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[CountCitApplicationsbyCitizen] 
	-- Add the parameters for the stored procedure here
	@Citizen int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Count(*) from CitApplication Where CitizenID = @citizen and AStatus != 'R'
END
