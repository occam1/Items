




-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-23
-- Description:	get the Person Role Location info 
--  from the PersonRoleLocation table
-- =============================================

CREATE     PROCEDURE [a57].[sp_GetPersonRoleLocations_by_Id] 
	@PersonId [bigint]
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [Id]
      ,[PersonId]
      ,[RoleId]
      ,[LocationId]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[ChangedBy]
      ,[ChangedOn]
  FROM [a57].[PersonRoleLocations]
  where Id = @PersonId;

RETURN ;
END
