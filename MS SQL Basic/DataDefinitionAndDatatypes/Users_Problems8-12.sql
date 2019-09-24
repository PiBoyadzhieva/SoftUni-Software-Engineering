--Problem 8
CREATE TABLE Users
(Id             BIGINT
 PRIMARY KEY IDENTITY, 
 Username       VARCHAR(30)
 UNIQUE NOT NULL, 
 [Password]     VARCHAR(26) NOT NULL, 
 ProfilePicture VARBINARY(MAX), 
 CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024), 
 LastLoginTime  DATETIME, 
 IsDeleted      BIT
);

INSERT INTO Users
(Username, 
 Password, 
 ProfilePicture, 
 LastLoginTime, 
 IsDeleted
)
VALUES
('Pesho', 
 '123456', 
 NULL, 
 CONVERT(DATETIME, '22-05-2018', 103), 
 0
),
('Gosho', 
 '123456', 
 NULL, 
 CONVERT(DATETIME, '12-07-2018', 103), 
 0
),
('Ivan', 
 '123456', 
 NULL, 
 CONVERT(DATETIME, '01-06-2018', 103), 
 0
),
('Test1', 
 '123456', 
 NULL, 
 CONVERT(DATETIME, '03-12-2018', 103), 
 1
),
('Test2', 
 '123456', 
 NULL, 
 NULL, 
 1
);

--Problem 9
ALTER TABLE Users DROP CONSTRAINT PK__Users__3214EC07C87542F6;
ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUsername PRIMARY KEY(Id, Username);

--Problem 10
ALTER TABLE Users
ADD CONSTRAINT CK_Users_Password CHECK(DATALENGTH([Password]) >= 5);

--Problem 11
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime;

INSERT INTO Users
(Username, 
 [Password], 
 ProfilePicture, 
 IsDeleted
)
VALUES
('Test4', 
 '123456', 
 NULL, 
 1
);

--Problem 12
ALTER TABLE Users DROP CONSTRAINT PK__Users__3214EC07C87542F6;

ALTER TABLE Users
ADD CONSTRAINT CK_UsernameLength CHECK(LEN(Username) >= 3);

SELECT *
FROM Users;