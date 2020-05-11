USE [Monkey]
GO
/****** Object:  StoredProcedure [dbo].[SelectCitizenBankTransactions]    Script Date: 5/9/2020 2:49:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
use Monkey
go
Create PROCEDURE [dbo].[SelectCitizenBankTransactions] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50), 
	@CID int
AS
IF (@Name = 'All')
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT TID, EmployeeID, CitizenID, ProjectID, UnitID, Amount From CitTransaction Where CitizenID = @CID
END
ELSE
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT TID, EmployeeID, CitizenID, ProjectID, UnitID, Amount From CitTransaction Where BankName = @Name and CitizenID = @CID
END
