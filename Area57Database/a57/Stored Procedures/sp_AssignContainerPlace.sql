



-- =============================================
-- Author:		Mark Hall
-- Create date: 2021-10-02
-- Description:assign a container to a furniture/surface/surfacearea
-- =============================================

CREATE PROCEDURE [a57].[sp_AssignContainerPlace] 
	-- Add the parameters for the stored procedure here
	( @DealerId bigint
	      ,@ContainerId bigint
		  ,@FurnitureId bigint
		  ,@SurfaceId bigint
		  ,@SurfaceAreaId bigint
		  ,@CurrentUserId bigint
	)

AS
BEGIN
	DECLARE @ReturnCode [int];
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


INSERT INTO [a57].[ContainerPlaces]          
		   ([DealerId]
           ,[ContainerId]
           ,[FurnitureId]
           ,[SurfaceId]
           ,[SurfaceAreaId]
           ,[CreatedBy])
     VALUES
           (@DealerId 
           ,@ContainerId 
           ,@FurnitureId
           ,@SurfaceId
           ,@SurfaceAreaId
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

