CREATE PROC usp_CancelFlights
AS
    BEGIN
        UPDATE Flights
          SET 
              ArrivalTime = NULL, 
              DepartureTime = NULL
        WHERE DATEDIFF(SECOND, DepartureTime, ArrivalTime) > 0;
    END;

EXEC usp_CancelFlights
