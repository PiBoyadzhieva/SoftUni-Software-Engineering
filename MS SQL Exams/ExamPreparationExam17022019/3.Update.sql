UPDATE StudentsSubjects
  SET 
      grade = 6.00
WHERE SubjectId IN(1, 2)
AND grade >= 5.50;
