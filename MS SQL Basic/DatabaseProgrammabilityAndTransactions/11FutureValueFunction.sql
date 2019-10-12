GO
CREATE FUNCTION ufn_CalculateFutureValue
(@sum           DECIMAL(15, 2), 
 @interestRate  FLOAT, 
 @numberOfYears INT
)
RETURNS DECIMAL(15, 4)
AS
     BEGIN
         --  FV=I?(?(1+R)?^T)
         --  	I – Initial sum
         --  	R – Yearly interest rate
         --  	T – Number of years
         DECLARE @value DECIMAL(15, 4);
         SET @value = @sum * (POWER(1 + @interestRate, @numberOfYears));
         RETURN @value;
     END;
GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.10, 5);