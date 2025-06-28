


create PROCEDURE spEmployee
    @DepartmentID INT
AS
BEGIN
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

EXEC spEmployee @DepartmentID = 2;
GO
select*from employees
GO 
select*from Departments
GO