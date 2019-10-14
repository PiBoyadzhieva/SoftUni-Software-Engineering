DELETE FROM RepositoriesContributors
WHERE RepositoryId = 3;

DELETE FROM Issues
WHERE RepositoryId = 3;

--Second Way

DELETE FROM RepositoriesContributors
WHERE RepositoryId IN
(
    SELECT r.Id
    FROM Repositories AS r
    WHERE r.[Name] = 'Softuni-Teamwork'
);

DELETE FROM Issues
WHERE RepositoryId IN
(
    SELECT r.Id
    FROM Repositories AS r
    WHERE r.[Name] = 'Softuni-Teamwork'
);