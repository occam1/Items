




-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-11
-- Description:	add a Picture of an Item to the ItemPictures table
-- Path is the relative path to the default system picture location
-- =============================================

CREATE PROCEDURE [a57].[sp_InsertItemPictures] 
	-- Add the parameters for the stored procedure here
	 (@DealerId [bigint]
	 ,@ItemId [bigint]
	 ,@AltText [nvarchar] (40)
	 ,@Caption1 [nvarchar] (200)
	 ,@Caption2 [nvarchar] (200)
	 ,@Path [nvarchar] (max)
	 ,@CurrentUserID [bigint]
	 ,@NewItemPictureId [bigint] OUTPUT)
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [a57].[ItemPictures]
           ([Id]
		   ,[ItemId]
		   ,[AltText]
		   ,[Caption1]
		   ,[Caption2]
		   ,[Path]
           ,[CreatedBy])
     VALUES
           (@DealerId
		   ,@ItemId
           ,@AltText
		   ,@Caption1
		   ,@Caption2
		   ,@Path
		   ,@CurrentUserId);
SET @NewItemPictureId = SCOPE_IDENTITY();
if @@ROWCOUNT = 1
begin
 return 0
end
else
 begin
 return 1
 end


return (IDENT_CURRENT('a57.ItemPictures'));
END

