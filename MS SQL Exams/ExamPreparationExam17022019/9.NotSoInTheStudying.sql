SELECT concat(st.FirstName, ' ', isnull(st.MiddleName + ' ', ''), st.LastName) AS [Full Name]
FROM Students AS st
     LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = st.Id
     LEFT JOIN Subjects AS sub ON ss.SubjectId = sub.Id
WHERE SubjectId IS NULL
ORDER BY [Full Name];