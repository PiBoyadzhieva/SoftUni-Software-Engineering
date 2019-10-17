SELECT TOP (10) FirstName, 
                LastName, 
                CAST(AVG(Grade) AS DECIMAL(3, 2)) AS [Grade]
FROM Students AS s
     INNER JOIN StudentsExams AS se ON se.StudentId = s.Id
     INNER JOIN Exams AS e ON se.ExamId = e.Id
GROUP BY FirstName, 
         LastName
ORDER BY Grade DESC, FirstName, LastName;
