SELECT i.Id, 
       concat(u.Username, ' : ', i.Title) AS [IssueAssignee]
FROM Issues AS i
     INNER JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, 
         IssueAssignee;