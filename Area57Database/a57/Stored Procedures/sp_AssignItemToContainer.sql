



-- =============================================
-- Author:		Mark Hall
-- Create date: 2021-10-02
-- Description:assign an item to a furniture/surface/surfacearea
-- =============================================

CREATE PROCEDURE [a57].[sp_AssignItemToContainer] 
	-- Add the parameters for the stored procedure here
	( @DealerId bigint
	 ,@ItemId bigint
	 ,@ContainerId bigint
	 ,@CurrentUserId bigint
	)

AS
BEGIN
	DECLARE @ReturnCode [int];
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


INSERT INTO [a57].[ContainerItems]          
		   ([DealerId]
           ,[ItemId]
           ,[ContainerId]
           ,[CreatedBy])
     VALUES
           (@DealerId 
           ,@ItemId 
           ,@ContainerId
           ,@CurrentUserId);

if (@@ROWCOUNT = 1)
	BEGIN
	set @ReturnCode = 0
	END
else
	BEGIN
	SET @ReturnCode = 1009;
	END


return @ReturnCode;
END

