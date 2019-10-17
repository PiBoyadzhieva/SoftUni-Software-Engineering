select s.[Name], avg(Grade) as AverageGrade from Subjects as s
inner join StudentsSubjects as ss on ss.SubjectId = s.Id
group by s.[Name], ss.SubjectId
order by ss.SubjectId 