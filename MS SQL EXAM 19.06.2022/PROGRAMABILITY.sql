--1
/*
Create a user-defined function named udf_GetVolunteersCountFromADepartment (@VolunteersDepartment)
that receives a department and returns the count of volunteers, who are involved in this department.
*/
GO
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(50))
RETURNS INT
AS
BEGIN
RETURN(SELECT COUNT(v.Id)
	FROM VolunteersDepartments AS vd
	JOIN Volunteers AS v ON v.DepartmentId = vd.Id
	WHERE vd.DepartmentName = @VolunteersDepartment)
END
GO

--2
/*
Create a stored procedure, named usp_AnimalsWithOwnersOrNot(@AnimalName). 
Extract the name of the owner of the given animal.  If there is no owner, put 'For adoption'.
*/
GO
CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(50))
AS
BEGIN
SELECT @AnimalName AS [Name]
	,ISNULL(o.[Name],'For adoption') AS OwnersName
	FROM Owners AS o
	RIGHT JOIN Animals AS a ON a.OwnerId = o.Id
WHERE a.[Name] = @AnimalName
END
GO