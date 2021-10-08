




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE     PROCEDURE [a57].[sp_GetItems_by_DealerId] 
    @DealerId [bigint]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  [Id]
	  ,[DealerId]
      ,[Name]
      ,[Description]
      ,[Manufacturer]
      ,[ManufacturingLine]
      ,[Keywords]
      ,[Cost]
      ,[CurrentPrice]
      ,[MinimumPrice]
      ,[PricingPlanId]
      ,[IsAvailable]
      ,[SoldDate]
      ,[SoldPrice]
      ,[IsShippable]
      ,[Quantity]
	  from [a57].Items
	  where DealerId = @DealerId;
END
