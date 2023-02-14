CREATE PROCEDURE Tickets_AddTicket
	@CustomerId INT,
	@PurchaseId INT,
	@EventProductId INT,
	@SectionId INT
AS
INSERT INTO Tickets
VALUES (@CustomerId, @PurchaseId, @EventProductId, @SectionId);