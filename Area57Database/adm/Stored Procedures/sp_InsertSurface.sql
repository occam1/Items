




-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-11
-- Description:	add a Surface,  
--    a Surface is a shelf or tabletop
--    , any place that can be used for display 
--    in a piece of Furniture.  It could even be 
--    slatboard or pegboard on a wall.
-- =============================================

CREATE       PROCEDURE [adm].[sp_InsertSurface]	
	@PersonId [bigint],
	@FurnitureId [bigint],
	@Description [nvarchar] (50),
	@Width [numeric](3, 2),
	@Depth [numeric](3, 2),
	@PositionFromBottom [smallint]
AS
BEGIN	
   -- interfering with SELECT statements.
	SET NOCOUNT ON;

IF (@PersonId = null)
   return(10040);
   IF (@FurnitureId = null)
   return(10041);
if (@Description = null)
    return(10050);
if (@PositionFromBottom > 10)
	return(10090);

INSERT INTO [adm].[Surface]
			([PersonId]
			,[FurnitureId]
			,[Description]
			,[Width]
			,[Depth]
			,[PositionFromBottom]
 			,[CreatedBy]
			,[CreatedOn])
     VALUES
           (@PersonId
		   ,@FurnitureId
           ,@Description
		   ,@Width
		   ,@Depth
		   ,@PositionFromBottom 
		   ,current_user   
		   ,CURRENT_TIMESTAMP) ;
		   
select Id from [adm].[Surface]
where Id = (IDENT_CURRENT('adm.Surface'));
if (@@ROWCOUNT = 1)
   return(0);
END
