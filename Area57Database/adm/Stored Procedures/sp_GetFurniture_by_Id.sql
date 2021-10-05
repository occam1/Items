




-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-23
-- Description:	get the Furniture info from the Furniture table
-- =============================================

CREATE   PROCEDURE [adm].[sp_GetFurniture_by_Id] 
	@Id [bigint]
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [Id]
      ,[PersonId]
      ,[Description]
      ,[Type]
      ,[PositionFromLeft]
      ,[PositionFromFront]
      ,[PositionFromBottom]
      ,[Width]
      ,[Depth]
      ,[Height]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[ChangedBy]
      ,[ChangedOn]
  FROM [adm].[Furniture]
  where Id = @Id;

RETURN ;
END
