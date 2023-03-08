---CREATE TABLE EMPLOYEE
CREATE TABLE Employee (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255),
    Age INT
);


---CREATE TABLE Departments
CREATE TABLE Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Designation VARCHAR(255),
);


---CREATE TABLE EmployeesDepartment
Create Table EmployeesDepartment
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    employee_id INT,
	departments_id INT,
    FOREIGN KEY (employee_id) REFERENCES Employee(Id),
	FOREIGN KEY (departments_id) REFERENCES Departments(Id)
);

--INSERT value into EMPLOYEE,Departments, EmployeesDepartment
INSERT INTO Employee (Name, Age) 
VALUES ('John', 35),
('May', 24),
('Peter', 21),
('Anthony', 40),
('April', 32);

INSERT INTO Departments (Designation) 
VALUES ('Team Lead'),
('Senior Developer'),
('Developer');


INSERT INTO EmployeesDepartment (employee_id, departments_id)
VALUES (1,1),
(2,3),
(3,3),
(4,2),
(5,2);

--CREATE STORED PROCEDURE 
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_EmployeeInfo')
DROP PROCEDURE SP_EmployeeInfo
GO



CREATE PROCEDURE SP_EmployeeInfo
        @sort_order VARCHAR(4)
    AS
    BEGIN
        IF @sort_order = 'ASC'
            SELECT E.Name, D.Designation, E.Age 
            FROM EmployeesDepartment ED
            INNER JOIN Employee E ON ED.employee_id = E.Id
            INNER JOIN Departments D ON ED.departments_id = D.Id
            ORDER BY E.age ASC
        ELSE IF @sort_order = 'DESC'
            SELECT E.Name, D.Designation, E.Age 
            FROM EmployeesDepartment ED
            INNER JOIN Employee E ON ED.employee_id = E.Id
            INNER JOIN Departments D ON ED.departments_id = D.Id
            ORDER BY E.age DESC
END