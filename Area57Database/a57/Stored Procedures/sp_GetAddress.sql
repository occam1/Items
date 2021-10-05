

-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-23
-- Description:	get the AddressId from the address table
-- =============================================

CREATE PROCEDURE [a57].[sp_GetAddress] 
	@Street1 [varchar] (100),
	@Street2 [varchar] (100),
	@City [varchar] (100),
	@State [varchar] (50),
	@Province [varchar] (100),
	@Country [varchar] (50),
	@PostalCode [varchar] (20)
AS
BEGIN
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

select Id from [a57].[Addresses]
where
     Street1  = @Street1 and   
     Street2  = @Street2  and   
     City     = @City and
     State    = @State and
     Province = @Province and   
     Country  = @Country and   
     PostalCode = @PostalCode;

RETURN ;
END
