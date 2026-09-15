/*

Departments
    │
    ├── 1 : M Employees
    ├── 1 : M Instructors
    └── 1 : M Courses

Courses
    ├── 1 : M Instructors
    └── 1 : M CrsResults

Trainees
    └── 1 : M CrsResults

So your seed script should insert in this order:

Departments → Employees → Courses → Instructors → Trainees → CrsResults

*/

-- =========================================================
-- Departments
-- =========================================================

INSERT INTO Departments (Name, ManagerName)
VALUES
('CS', 'Ahmed'),
('IT', 'Ali'),
('HR', 'Hassan'),
('Finance', 'Mahmoud');


-- =========================================================
-- Employees
-- =========================================================

INSERT INTO Employees
    (Name, Salary, Address, ImageUrl, JopTitle, DepartmentId)
VALUES

-- CS
('John', 1000, '123 Main St', '2.png', 'BackEnd Developer',
    (SELECT Id FROM Departments WHERE Name = 'CS')),

('Ahmed', 1500, '456 Second St', '1.png', 'FrontEnd Developer',
    (SELECT Id FROM Departments WHERE Name = 'CS')),

('Sara', 1200, '789 Third St', '3.png', 'BackEnd Developer',
    (SELECT Id FROM Departments WHERE Name = 'CS')),

-- IT
('Omar', 1300, '101 Fourth St', '4.png', 'Backend Developer',
    (SELECT Id FROM Departments WHERE Name = 'IT')),

('Mona', 1600, '202 Fifth St', '5.png', 'Frontend Developer',
    (SELECT Id FROM Departments WHERE Name = 'IT')),

('Youssef', 1400, '303 Sixth St', '6.png', 'DevOps Engineer',
    (SELECT Id FROM Departments WHERE Name = 'IT')),

-- HR
('Khaled', 1100, '404 Seventh St', '7.png', 'HR Specialist',
    (SELECT Id FROM Departments WHERE Name = 'HR')),

('Nour', 1250, '505 Eighth St', '8.png', 'Recruiter',
    (SELECT Id FROM Departments WHERE Name = 'HR')),

('Mai', 1350, '606 Ninth St', '9.png', 'HR Manager',
    (SELECT Id FROM Departments WHERE Name = 'HR')),

-- Finance
('Mostafa', 1800, '707 Tenth St', '10.png', 'Accountant',
    (SELECT Id FROM Departments WHERE Name = 'Finance')),

('Dina', 2000, '808 Eleventh St', '11.png', 'Financial Analyst',
    (SELECT Id FROM Departments WHERE Name = 'Finance')),

('Karim', 2200, '909 Twelfth St', '12.png', 'Finance Manager',
    (SELECT Id FROM Departments WHERE Name = 'Finance'));


-- =========================================================
-- Courses
-- =========================================================

INSERT INTO Courses
    (Name, Degree, MinDegree, DepartmentId)
VALUES

('C# Fundamentals', 100, 50,
    (SELECT Id FROM Departments WHERE Name = 'CS')),

('Database', 100, 50,
    (SELECT Id FROM Departments WHERE Name = 'CS')),

('Web Development', 100, 50,
    (SELECT Id FROM Departments WHERE Name = 'CS')),

('Networking', 100, 50,
    (SELECT Id FROM Departments WHERE Name = 'IT')),

('System Administration', 100, 50,
    (SELECT Id FROM Departments WHERE Name = 'IT')),

('Human Resources Management', 100, 50,
    (SELECT Id FROM Departments WHERE Name = 'HR')),

('Financial Accounting', 100, 50,
    (SELECT Id FROM Departments WHERE Name = 'Finance'));


-- =========================================================
-- Instructors
-- =========================================================

INSERT INTO Instructors
    (Name, ImageUrl, Salary, Address, DepartmentId, CourseId)
VALUES

-- CS
('Dr. Ahmed', 'instructor1.png', 5000, '10 CS Street',
    (SELECT Id FROM Departments WHERE Name = 'CS'),
    (SELECT Id FROM Courses WHERE Name = 'C# Fundamentals')),

('Dr. Mohamed', 'instructor2.png', 5500, '20 CS Street',
    (SELECT Id FROM Departments WHERE Name = 'CS'),
    (SELECT Id FROM Courses WHERE Name = 'Database')),

('Dr. Sara', 'instructor3.png', 5200, '30 CS Street',
    (SELECT Id FROM Departments WHERE Name = 'CS'),
    (SELECT Id FROM Courses WHERE Name = 'Web Development')),

-- IT
('Dr. Ali', 'instructor4.png', 4800, '40 IT Street',
    (SELECT Id FROM Departments WHERE Name = 'IT'),
    (SELECT Id FROM Courses WHERE Name = 'Networking')),

('Dr. Omar', 'instructor5.png', 5100, '50 IT Street',
    (SELECT Id FROM Departments WHERE Name = 'IT'),
    (SELECT Id FROM Courses WHERE Name = 'System Administration')),

-- HR
('Dr. Hassan', 'instructor6.png', 4700, '60 HR Street',
    (SELECT Id FROM Departments WHERE Name = 'HR'),
    (SELECT Id FROM Courses WHERE Name = 'Human Resources Management')),

-- Finance
('Dr. Mahmoud', 'instructor7.png', 6000, '70 Finance Street',
    (SELECT Id FROM Departments WHERE Name = 'Finance'),
    (SELECT Id FROM Courses WHERE Name = 'Financial Accounting'));


-- =========================================================
-- Trainees
-- =========================================================

INSERT INTO Trainees
    (Name, ImageUrl, Address, Grade)
VALUES

('Adam', 'trainee1.png', '1 Trainee Street', 85),
('Omar', 'trainee2.png', '2 Trainee Street', 92),
('Mariam', 'trainee3.png', '3 Trainee Street', 78),
('Youssef', 'trainee4.png', '4 Trainee Street', 88),
('Nour', 'trainee5.png', '5 Trainee Street', 95),
('Salma', 'trainee6.png', '6 Trainee Street', 72),
('Khaled', 'trainee7.png', '7 Trainee Street', 81),
('Mona', 'trainee8.png', '8 Trainee Street', 90);


-- =========================================================
-- Course Results
-- =========================================================

INSERT INTO CrsResults
    (Degree, CourseId, TraineeId)
VALUES

-- Adam
(85,
    (SELECT Id FROM Courses WHERE Name = 'C# Fundamentals'),
    (SELECT Id FROM Trainees WHERE Name = 'Adam')),

(78,
    (SELECT Id FROM Courses WHERE Name = 'Database'),
    (SELECT Id FROM Trainees WHERE Name = 'Adam')),

(90,
    (SELECT Id FROM Courses WHERE Name = 'Web Development'),
    (SELECT Id FROM Trainees WHERE Name = 'Adam')),


-- Omar
(95,
    (SELECT Id FROM Courses WHERE Name = 'C# Fundamentals'),
    (SELECT Id FROM Trainees WHERE Name = 'Omar')),

(88,
    (SELECT Id FROM Courses WHERE Name = 'Database'),
    (SELECT Id FROM Trainees WHERE Name = 'Omar')),

(92,
    (SELECT Id FROM Courses WHERE Name = 'Web Development'),
    (SELECT Id FROM Trainees WHERE Name = 'Omar')),


-- Mariam
(72,
    (SELECT Id FROM Courses WHERE Name = 'C# Fundamentals'),
    (SELECT Id FROM Trainees WHERE Name = 'Mariam')),

(80,
    (SELECT Id FROM Courses WHERE Name = 'Database'),
    (SELECT Id FROM Trainees WHERE Name = 'Mariam')),


-- Youssef
(88,
    (SELECT Id FROM Courses WHERE Name = 'Networking'),
    (SELECT Id FROM Trainees WHERE Name = 'Youssef')),

(91,
    (SELECT Id FROM Courses WHERE Name = 'System Administration'),
    (SELECT Id FROM Trainees WHERE Name = 'Youssef')),


-- Nour
(95,
    (SELECT Id FROM Courses WHERE Name = 'Human Resources Management'),
    (SELECT Id FROM Trainees WHERE Name = 'Nour')),


-- Salma
(76,
    (SELECT Id FROM Courses WHERE Name = 'Human Resources Management'),
    (SELECT Id FROM Trainees WHERE Name = 'Salma')),


-- Khaled
(84,
    (SELECT Id FROM Courses WHERE Name = 'Financial Accounting'),
    (SELECT Id FROM Trainees WHERE Name = 'Khaled')),


-- Mona
(93,
    (SELECT Id FROM Courses WHERE Name = 'Financial Accounting'),
    (SELECT Id FROM Trainees WHERE Name = 'Mona'));