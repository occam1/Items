


-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-11
-- Description:	add a Booth to the Booths table
-- =============================================

CREATE PROCEDURE [a57].[sp_InsertBooths] 
	-- Add the parameters for the stored procedure here
	 (@Id [bigint]
	 ,@Name [varchar] (50)
	 ,@DealerId [bigint]
	 ,@Type [int]
	 ,@CreatedBy [int])
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [a57].[Booths]
           ([Id]
		   ,[Name]
		   ,[DealerId]
		   ,[Type]
           ,[CreatedBy]
           ,[CreatedOn])
     VALUES
           (@Id
		   ,@Name
           ,@DealerId
		   ,@Type
		   ,@CreatedBy
           ,current_timestamp);

return (IDENT_CURRENT('a57.Booths'));
END

