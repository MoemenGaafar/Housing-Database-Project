USE [Monkey]
GO
/****** Object:  StoredProcedure [dbo].[Insert_Company]    Script Date: 5/12/2020 11:23:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Insert_Company]
	-- Add the parameters for the stored procedure here
	@Password varchar(50),  
	@Name varchar(50) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

    -- Insert statements for procedure here
	INSERT INTO Company( Password, Name, NoCompleteProj, NoCurrentProj)
	Values(@Password, @Name, 0, 0)
END
