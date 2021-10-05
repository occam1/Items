



-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-23
-- Description:	get the Surface info from the Surface table
-- =============================================

CREATE   PROCEDURE [adm].[sp_GetSurface_by_PersonId] 
	@PersonId [bigint]
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [Id]
      ,[PersonId]
      ,[FurnitureId]
      ,[Description]
      ,[Width]
      ,[Depth]
      ,[PositionFromBottom]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[ChangedBy]
      ,[ChangedOn]
  FROM [adm].[Surfaces]
  where PersonId = @PersonId;

RETURN ;
END
