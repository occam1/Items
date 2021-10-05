



-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-11
-- Description:	add a piece of Furniture to the Furniture table
--    Furniture is a collection of Surfaces and surfaceAreas
--    where items can be displayed/stored.
--    Shelves, cabinets, tables etc.
-- =============================================

CREATE     PROCEDURE [adm].[sp_InsertFurnitureType]	
	@Description [nvarchar] (50),
	@NumberOfSurfaces [int]
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
if (@Description = null)
    return(10050);

INSERT INTO [adm].[FurnitureType]
			([Description]
			,[NumberOfSurfaces]  
			,[CreatedBy]
			,[CreatedOn])
     VALUES
           (@Description
		   ,@NumberOfSurfaces
           ,current_user   
		   ,CURRENT_TIMESTAMP) ;
		   
select Id from [adm].[FurnitureType]
where Id = (IDENT_CURRENT('adm.FurnitureType'));
if (@@ROWCOUNT = 1)
   return(0);
END
