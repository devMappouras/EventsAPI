CREATE PROCEDURE Purchase_CompletePurchase
	@PurchaseId INT,
	@PurchaseStatusId INT
AS

UPDATE Purchases 
SET PurchaseStatusId = @PurchaseStatusId
WHERE PurchaseId = @PurchaseId;