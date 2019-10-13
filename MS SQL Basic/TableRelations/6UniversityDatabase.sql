CREATE DATABASE University;

USE University;

CREATE TABLE Majors
(MajorID INT
 PRIMARY KEY IDENTITY, 
 [Name]  NVARCHAR(50) NOT NULL
);

CREATE TABLE Students
(StudentID     INT
 PRIMARY KEY IDENTITY, 
 StudentNumber NVARCHAR(15)
 UNIQUE NOT NULL, 
 StudentName   NVARCHAR(60) NOT NULL, 
 MajorID       INT NOT NULL
                   CONSTRAINT FK_Students_MajorID FOREIGN KEY REFERENCES Majors(MajorID)
);

CREATE TABLE Payments
(PaimentID     INT
 PRIMARY KEY IDENTITY, 
 PaymentDate   SMALLDATETIME NOT NULL, 
 PaymentAmount DECIMAL(15, 2) NOT NULL, 
 StudentID     INT NOT NULL
                   CONSTRAINT FK_Payments_StudentID FOREIGN KEY REFERENCES Students(StudentID)
);

CREATE TABLE Subjects
(SubjectID   INT
 PRIMARY KEY IDENTITY, 
 SubjectName NVARCHAR(50) NOT NULL
);

CREATE TABLE Agenda
(StudentID INT NOT NULL
               FOREIGN KEY REFERENCES Students(StudentID), 
 SubjectID INT NOT NULL
               FOREIGN KEY REFERENCES Subjects(SubjectID), 
 CONSTRAINT FK_CompositeStudentIDSubjectID PRIMARY KEY(StudentID, SubjectID)
);