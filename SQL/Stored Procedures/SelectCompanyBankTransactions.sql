USE [Monkey]
GO
/****** Object:  StoredProcedure [dbo].[SelectCompanyBankTransactions]    Script Date: 5/9/2020 2:53:07 PM ******/
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
Create PROCEDURE [dbo].[SelectCompanyBankTransactions] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50), 
	@CID int
AS
IF(@Name = 'All')
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TID, EmployeeID, Name, Amount From ComTransaction, Company Where CID = @CID and CompanyID = @CID
END
ELSE
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TID, EmployeeID, Name, Amount From ComTransaction, Company Where BankName = @Name and CID = @CID and CompanyID = @CID
END
