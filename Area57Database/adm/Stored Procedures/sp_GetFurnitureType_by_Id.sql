﻿




-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-23
-- Description:	get the Furniture info from the Furniture table
-- =============================================

CREATE   PROCEDURE [adm].[sp_GetFurnitureType_by_Id] 
	@Id [bigint]
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [Id]
      ,[Description]
      ,[NumberOfSurfaces]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[ChangedBy]
      ,[ChangedOn]
  FROM [adm].[FurnitureType]
  where Id = @Id;

RETURN ;
END
