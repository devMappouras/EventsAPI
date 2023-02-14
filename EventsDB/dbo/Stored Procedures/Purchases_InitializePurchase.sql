CREATE PROCEDURE Purchases_InitializePurchase
	@CustomerId INT,
	@PurchaseStatusId INT
AS

INSERT INTO Purchases
VALUES (@CustomerId, @PurchaseStatusId);