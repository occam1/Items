
-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-11
-- Description:	add an address to the address table
-- =============================================

CREATE PROCEDURE [a57].[sp_InsertLocation] 
	-- Add the parameters for the stored procedure here
	(@Name [varchar] (100),
	@EmailAddress [varchar] (300),
	@PhoneNumber [varchar] (50),
	@AlternativePhoneNumber [varchar] (50),
	@Street1 [varchar] (100) = null,
	@Street2 [varchar] (100) = null,
	@City [varchar] (100) = null,
	@State [varchar] (50) = null,
	@Province [varchar] (100) = null,
	@Country [varchar] (50)= null,
	@AddressId [int]  = null,
	@PostalCode [varchar] (20) = null,
	@TypeId [int])
AS
BEGIN
	DECLARE @ReturnCode [int];
	DECLARE @AddressIdTable table(addressId [int]);
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
If (@AddressId = null)
BEGIN
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
 insert into @AddressIdTable exec @ReturnCode = sp_InsertAddress @Street1, @Street2, @City, @State, @Province, @Country, @PostalCode;
	if @ReturnCode <> 0
	   return(@ReturnCode);
	else
	  select top 1 @Addressid = addressId from @AddressIdTable;
END

INSERT INTO [a57].[Locations]
           ([Name]
           ,[EmailAddress]
           ,[PhoneNumber]
           ,[AlternativePhoneNumber]
           ,[AddressId]
           ,[TypeId]
           ,[CreatedBy]
           ,[CreatedOn])
     VALUES
           (@Name
           ,@EmailAddress
           ,@PhoneNumber
           ,@AlternativePhoneNumber
           ,@AddressId
           ,@TypeId
           ,CURRENT_USER
           ,current_timestamp)
return (IDENT_CURRENT('a57.Locations'));
END

