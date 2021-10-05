






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE     PROCEDURE [a57].[sp_GetItems_by_ContainerId] 
    @DealerId [bigint],
	@ContainerId [bigint]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  i.[Id]
	  ,i.[DealerId]
      ,i.[Name]
      ,i.[Description]
      ,i.[Manufacturer]
      ,i.[ManufacturingLine]
      ,i.[Keywords]
      ,i.[Cost]
      ,i.[CurrentPrice]
      ,i.[MinimumPrice]
      ,i.[PricingPlanId]
      ,i.[IsAvailable]
      ,i.[SoldDate]
      ,i.[SoldPrice]
      ,i.[IsShippable]
      ,i.[Quantity]
	  from [a57].Items i
	  inner join [a57].ContainerItems c
	  on i.Id = c.ItemId
	  where i.DealerId = @DealerId
	  and ContainerId = @ContainerId;

	  return
END

