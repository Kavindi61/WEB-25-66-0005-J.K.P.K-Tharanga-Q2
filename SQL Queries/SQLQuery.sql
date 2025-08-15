CREATE TABLE Courses (
    CourseID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    LecturerName VARCHAR(100) NOT NULL
);
CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    city VARCHAR(40) NOT NULL,
    CourseID INT NOT NULL,
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE
);
INSERT INTO Courses (CourseID, Name, LecturerName) VALUES
(1, 'Web development', 'M.M.Herath'),
(2, 'Graphic Design', 'J.S.V. Piyasena'),
(3, 'Mobile App Development', 'K.K.S. Dias'),
(4, 'Java', 'U.H.S.Perera');

INSERT INTO Students (StudentID, Name, city, CourseID) VALUES
(1, 'Kasun Gamage', 'Kandy', 2),
(2, 'Daniel Sam', 'Jaffna', 3),
(3, 'Hansi Silva', 'Matara', 1),
(4, 'Ranidu Herath', 'Matara', 3),
(5, 'Praneeth Wijesinghe', 'Kandy', 4),
(6, 'Nuwani Herath', 'Rathnapura', 1);