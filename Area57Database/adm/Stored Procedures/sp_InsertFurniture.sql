




-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-11
-- Description:	add a piece of Furniture to the Furniture table
--    Furniture is a collection of Surfaces and surfaceAreas
--    where items can be displayed/stored.
--    Shelves, cabinets, tables etc.
-- =============================================

CREATE       PROCEDURE [adm].[sp_InsertFurniture]	
	@PersonId [bigint],
	@Description [nvarchar] (50),
	@Type [nvarchar] (50),
	@PositionFromLeft [smallint],
	@PositionFromFront [smallint],
	@PositionFromBottom [smallint],
	@Width [numeric](3, 2),
	@Depth [numeric](3, 2),
	@Height [numeric] (3, 2)
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

IF (@PersonId = null)
   return(10040);
if (@Description = null)
    return(10050);
if (@PositionFromLeft > 10)
	return(10070);
if (@PositionFromFront > 10)
	return(10080);
if (@PositionFromBottom > 10)
	return(10090);

INSERT INTO [adm].[Furniture]
			([PersonId]
			,[Description]
			,[Type]  
			,[PositionFromLeft]
			,[PositionFromFront]  
			,[PositionFromBottom]
			,[Width]
			,[Depth]
			,[Height]
			,[CreatedBy]
			,[CreatedOn])
     VALUES
           (@PersonId
           ,@Description
		   ,@Type
           ,@PositionFromLeft 
		   ,@PositionFromFront
           ,@PositionFromBottom
           ,@Width
           ,@Depth
		   ,@Height 
		   ,current_user   
		   ,CURRENT_TIMESTAMP) ;
		   
select Id from [adm].[Furniture]
where Id = (IDENT_CURRENT('adm.Furniture'));
if (@@ROWCOUNT = 1)
   return(0);
END
