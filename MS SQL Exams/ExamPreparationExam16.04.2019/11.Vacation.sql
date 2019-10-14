CREATE FUNCTION udf_CalculateTickets
(@origin      VARCHAR(50), 
 @destination VARCHAR(50), 
 @peopleCount INT
)
RETURNS VARCHAR(30)
AS
     BEGIN

         IF(@peopleCount <= 0)
             BEGIN
                 RETURN 'Invalid people count!';
         END;

         DECLARE @flightId INT=
         (
             SELECT TOP (1) Id
             FROM Flights
             WHERE Destination = @destination
                   AND Origin = @origin
         );

         IF(@flightId IS NULL)
             BEGIN
                 RETURN 'Invalid flight!';
         END;

         DECLARE @pricePerPerson DECIMAL(15, 2)=
         (
             SELECT TOP (1) Price
             FROM Tickets
             WHERE FlightId = @flightId
         );

         DECLARE @totalPrice DECIMAL(15, 2)= @pricePerPerson * @peopleCount;

         RETURN concat('Total price', ' ', @totalPrice);
     END;
