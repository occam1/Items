






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE     PROCEDURE [a57].[sp_GetItemPictures_by_Id] 
      @Id [bigint]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id] 
	,[ItemId] 
	,[altText] 
	,[Caption1]
	,[Caption2]
	,[Location]
	,[CreatedBy] 
	,[CreatedOn] 
	,[ChangedBy] 
	,[ChangedOn]
	  from [a57].ItemPictures
	  where Id = @Id ;
END
