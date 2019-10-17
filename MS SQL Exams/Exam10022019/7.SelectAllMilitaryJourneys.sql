SELECT Id, 
       format(JourneyStart, 'dd/MM/yyyy') AS [JourneyStart], 
       format(JourneyEnd, 'dd/MM/yyyy') AS [JourneyEnd]
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart;