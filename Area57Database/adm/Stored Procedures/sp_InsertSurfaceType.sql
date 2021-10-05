


-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-11
-- Description:	add a piece of Furniture to the Furniture table
--    Furniture is a collection of Surfaces and surfaceAreas
--    where items can be displayed/stored.
--    Shelves, cabinets, tables etc.
-- =============================================

CREATE   PROCEDURE [adm].[sp_InsertSurfaceType]	
	@Description [nvarchar] (50)
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

if (@Description = null)
    return(1005);

INSERT INTO [adm].[SurfaceType]
			([Description]
			,[CreatedBy]
			,[CreatedOn])
     VALUES
           (@Description
		   ,current_user   
		   ,CURRENT_TIMESTAMP) ;
		   
select Id from [adm].[SurfaceType]
where Id = (IDENT_CURRENT('adm.SurfaceType'));
if (@@ROWCOUNT = 1)
   return(0);
END
