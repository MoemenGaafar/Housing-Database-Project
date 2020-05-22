USE [Monkey]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUnit]    Script Date: 5/15/2020 7:06:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[DeleteUnit] 
	-- Add the parameters for the stored procedure here
	@ID int, 
	@ProjectID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	Delete from Unit where ID = @ID and ProjectID = @ProjectID
END
