CREATE TABLE People
(Id        INT
 PRIMARY KEY IDENTITY, 
 [Name]    NVARCHAR(200) NOT NULL, 
 Picture   VARBINARY(MAX), 
 Height    DECIMAL(3, 2), 
 [Weight]  DECIMAL(5, 2), 
 Gender    CHAR(1) NOT NULL, 
 Birthdate DATETIME2 NOT NULL, 
 Biography NVARCHAR(MAX)
);

INSERT INTO People
([Name], 
 Picture, 
 Height, 
 [Weight], 
 Gender, 
 Birthdate, 
 Biography
)
VALUES
('Pesho', 
 NULL, 
 1.82, 
 72.50, 
 'm', 
 '1985/01/16', 
 NULL
),
('Gosho', 
 NULL, 
 1.78, 
 80.20, 
 'm', 
 '1996/10/18', 
 'Hello'
),
('Sasho', 
 NULL, 
 1.70, 
 86.30, 
 'm', 
 '1978/02/23', 
 NULL
),
('Aleks', 
 NULL, 
 1.69, 
 68.20, 
 'm', 
 '1986/04/30', 
 'I''m fine'
),
('Pepi', 
 NULL, 
 1.55, 
 45.60, 
 'f', 
 '1999/08/01', 
 NULL
);

SELECT *
FROM People;