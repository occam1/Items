

-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-23
-- Description:	get the Furniture info from the Furniture table
-- =============================================

CREATE     PROCEDURE [a57].[sp_GetBooths_by_DealerId] 
	@DealerId [bigint]
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [Id]
      ,[Name]
      ,[DealerId]
      ,[Type]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[ChangedBy]
      ,[ChangedOn]
  FROM [a57].[Booths]
  where DealerId = @DealerId;

RETURN ;
END
