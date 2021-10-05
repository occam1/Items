



-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-23
-- Description:	add a person to the person table
-- =============================================

CREATE PROCEDURE [a57].[sp_InsertPerson] 
	-- Add the parameters for the stored procedure here
           ( @FirstName [varchar] (100)
			,@MiddleName [varchar] (100) = null
			,@LastName [varchar] (100)
			,@PasswordLastChanged date
			,@PasswordHash [varchar] (max)
			,@EmailAddress  [varchar] (100)
			,@PhoneNumber  [varchar] (50)
			,@AlternativePhoneNumber  [varchar] (50)
			,@Street1 [varchar] (100) = null
			,@Street2 [varchar] (100) = null
			,@City [varchar] (100) = null
			,@State [varchar] (50) = null
			,@Province [varchar] (100) = null
			,@Country [varchar] (50) = null
			,@PostalCode [varchar] (20) = null
			,@AddressId [int]  = null
			,@CreatedBy [int]
			,@CreatedOn date)
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

if (@AddressId = null)
BEGIN
	If (@State <> null and @Province <> null)
	BEGIN
		If (@Country = 'USA' )
			select @Province = null;
		Else
			select @State = null;
	END

	select @AddressId = id from a57.Addresses where 
		Street1 = @Street1 
		and Street2 = @Street2
		and City = @City 
		and PostalCode = @PostalCode
		and ((State = @State and State <> null) or
			 (Province = @Province and Province <> null));

	If (@@ROWCOUNT = 0)
	BEGIN
		exec @AddressId = a57.sp_InsertAddress @Street1, @Street2, @City, @State, @Province, @Country, @PostalCode;
	END
END

INSERT INTO [a57].[People]
           ([FirstName]
		   ,[MiddleName]
		   ,[LastName]
           ,[EmailAddress]
           ,[AddressId]
           ,[PhoneNumber]
           ,[AlternativePhoneNumber]
           ,[CreatedBy]
           ,[CreatedOn])
     VALUES
           (@FirstName
		   ,@MiddleName
		   ,@LastName
           ,@EmailAddress
		   ,@AddressId
           ,@PhoneNumber
           ,@AlternativePhoneNumber
		   ,@CreatedBy
           ,GETDATE())


return IDENT_CURRENT('a57.People');
END
