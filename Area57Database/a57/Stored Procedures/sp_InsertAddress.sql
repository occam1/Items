
-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-11
-- Description:	add an address to the address table
-- =============================================

CREATE PROCEDURE [a57].[sp_InsertAddress] 
	@Street1 [varchar] (100),
	@Street2 [varchar] (100),
	@City [varchar] (100),
	@State [varchar] (50),
	@Province [varchar] (100) = null,
	@Country [varchar] (50) = "USA",
	@PostalCode [varchar] (20)
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

IF (@Street1 = null)
   return(1004);
if (@City = null)
    return(1005);
if (@State = null AND @Province = null)
	return(1006);
if (@PostalCode = null)
	return(1007);
If (@State = null and @Province <> null and @Country = null)
	return(1008);

INSERT INTO [a57].[Addresses]
           ([Street1]
           ,[Street2]
           ,[City]
           ,[State]
           ,[Province]
           ,[Country]
           ,[PostalCode]
           ,[CreatedBy]
		   ,[CreatedOn])
     VALUES
           (@Street1    
           ,@Street2    
           ,@City       
           ,@State      
           ,@Province   
           ,@Country   
           ,@PostalCode 
           ,current_user   
		   ,CURRENT_TIMESTAMP) ;
		   
select Id from [a57].[Addresses]
where Id = (IDENT_CURRENT('a57.Addresses'));
if (@@ROWCOUNT = 1)
   return(0);
END
