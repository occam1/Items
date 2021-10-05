



-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-11
-- Description:	add a SurfaceArea, a segment 
--    of a Surface that is part of 
--    a piece of Furniture 
--    
-- =============================================

CREATE     PROCEDURE [adm].[sp_InsertSurfaceArea]	
	@PersonId [bigint],
	@FurnitureId [bigint],
	@SurfaceId [bigint], 
	@Description [nvarchar] (50),
	@Width [numeric](3, 2),
	@Depth [numeric](3, 2),
	@PositionFromLeft [smallint],
	@PositionFromFront [smallint],
	@Type [nvarchar] (50)
AS
BEGIN	
   -- interfering with SELECT statements.
	SET NOCOUNT ON;

IF (@PersonId = null)
   return(10040);
   IF (@FurnitureId = null)
   return(10041);
   IF (@SurfaceId = null)
   return(10042);
if (@Description = null)
    return(10050);
if (@PositionFromLeft > 10)
	return(10070);
if (@PositionFromFront > 10)
	return(10080);

INSERT INTO [adm].[SurfaceArea]
			([PersonId]
			,[FurnitureId]
			,[SurfaceId]
			,[Description]
			,[Type]
			,[Width]
			,[Depth]
			,[PositionFromLeft] 
			,[PositionFromFront] 
 			,[CreatedBy]
			,[CreatedOn])
     VALUES
           (@PersonId
		   ,@FurnitureId
		   ,@SurfaceId
           ,@Description
		   ,@Type 
		   ,@Width
		   ,@Depth
           ,@PositionFromLeft 
		   ,@PositionFromFront 
		   ,current_user   
		   ,CURRENT_TIMESTAMP) ;
		   
select Id from [adm].[SurfaceArea]
where Id = (IDENT_CURRENT('adm.SurfaceArea'));
if (@@ROWCOUNT = 1)
   return(0);
END
