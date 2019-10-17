SELECT concat(s.FirstName, ' ', s.LastName) AS [Full Name]
FROM Students AS s
     LEFT OUTER JOIN StudentsExams AS se ON se.StudentId = s.Id
     LEFT OUTER JOIN Exams AS e ON se.ExamId = e.Id
WHERE e.Id IS NULL
ORDER BY [Full Name];