-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-23
-- Description:	add a entry to the PersonRoleLocation table
-- =============================================

CREATE PROCEDURE [a57].[sp_InsertPersonRoleLocations] 
	-- Add the parameters for the stored procedure here
           ( @PersonId [bigint] 
			,@RoleId [int] = null
			,@LocationId [int]
			,@CreatedBy [int])
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


INSERT INTO [a57].[PersonRoleLocations]
           ([PersonId]
		   ,[RoleId]
		   ,[LocationId]
           ,[CreatedBy]
           ,[CreatedOn])
     VALUES
           (@PersonId
		   ,@RoleId
		   ,@LocationId
		   ,@CreatedBy
           ,current_timestamp)


return (IDENT_CURRENT('a57.PersonRoleLocations'));
END
