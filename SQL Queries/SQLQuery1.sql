SELECT TOP (1000) [StudentID]
      ,[Name]
      ,[city]
      ,[CourseID]
  FROM [Courses].[dbo].[Students]

  SELECT* FROM Students;
SELECT StudentID,Name,city
FROM Students
WHERE city='Kandy';

UPDATE Students
SET city='Galle'
WHERE StudentID=4;

SELECT 
    s.StudentID,
    s.Name AS StudentName,
    s.City,
    c.CourseID,
    c.Name AS CourseName,
    c.LecturerName
FROM Students s
INNER JOIN Courses c
    ON s.CourseID = c.CourseID;
