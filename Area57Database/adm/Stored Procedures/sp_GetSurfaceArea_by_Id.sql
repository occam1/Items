




-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-23
-- Description:	get the SurfaceArea info from the SurfaceArea table
-- =============================================

CREATE   PROCEDURE [adm].[sp_GetSurfaceArea_by_Id] 
	@Id [bigint]
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [Id]
      ,[PersonId]
      ,[FurnitureId]
      ,[SurfaceId]
      ,[Description]
      ,[Width]
      ,[Depth]
      ,[PositionFromLeft]
      ,[PositionFromFront]
      ,[Type]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[ChangedBy]
      ,[ChangedOn]
  FROM [adm].[SurfaceAreas]
  where Id = @Id;

RETURN ;
END
