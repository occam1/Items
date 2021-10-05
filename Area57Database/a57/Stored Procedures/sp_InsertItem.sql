

-- =============================================
-- Author:		Mark Hall
-- Create date: 2020-10-11
-- Description:	add an address to the address table
-- =============================================

CREATE PROCEDURE [a57].[sp_InsertItem] 
	-- Add the parameters for the stored procedure here
	( @DealerId bigint
           ,@Name varchar (50)
		   ,@Keywords varchar(max)
           ,@Description varchar(max)
           ,@Manufacturer varchar(50)
           ,@ManufacturingLine varchar(50)
           ,@Cost money
           ,@CurrentPrice money 
           ,@MinimumPrice money
           ,@PricingPlanId int
           ,@IsAvailable bit
           ,@SoldDate date
           ,@SoldPrice money
           ,@IsShippable bit
           ,@Quantity int
           ,@CurrentUserId bigint
		   ,@NewItemId bigint OUTPUT
	)
AS
BEGIN
	DECLARE @ReturnCode [int];
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


INSERT INTO [a57].[Items]          
		   ([DealerId]
           ,[Name]
           ,[Description]
           ,[Cost]
           ,[CurrentPrice]
           ,[MinimumPrice]
           ,[Manufacturer]
           ,[ManufacturingLine]
           ,[Keywords]
           ,[PricingPlanId]
           ,[IsAvailable]
           ,[SoldDate]
           ,[SoldPrice]
           ,[IsShippable]
           ,[Quantity]
           ,[CreatedBy])
     VALUES
           (@DealerId 
           ,@Name 
           ,@Description 
           ,@Cost 
           ,@CurrentPrice 
           ,@MinimumPrice 
           ,@Manufacturer 
           ,@ManufacturingLine 
           ,@Keywords 
           ,@PricingPlanId 
           ,@IsAvailable 
           ,@SoldDate
           ,@SoldPrice 
           ,@IsShippable 
           ,@Quantity 
           ,@CurrentUserId);

SET @NewItemId = SCOPE_IDENTITY();
if (@@ROWCOUNT = 1)
	BEGIN
	return 0;
	END
else
	BEGIN
	RETURN(1009)
	END

END

