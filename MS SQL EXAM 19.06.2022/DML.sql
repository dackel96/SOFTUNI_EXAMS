--1
/*
Extract information about all the Volunteers
– name, phone number, address, id of the animal, they are responsible to
and id of the department they are involved into. Order the result by name of the volunteer (ascending),
then by the id of the animal (ascending) and then by the id of the department (ascending).
*/
SELECT [Name]
	,PhoneNumber
	,[Address]
	,AnimalId
	,DepartmentId
	FROM Volunteers
ORDER BY [Name] ASC,AnimalId ASC,DepartmentId ASC
--2
/*
Select all animals and their type. Extract name, animal type and birth date (in format 'dd.MM.yyyy').
Order the result by animal‘s name (ascending).
*/
SELECT a.[Name]
	,aa.AnimalType
	,FORMAT(a.BirthDate,'dd.MM.yyyy') AS BirthDate
	FROM Animals AS a
	JOIN AnimalTypes AS aa ON aa.Id = a.AnimalTypeId
ORDER BY a.[Name] ASC
--3
/*
Extract the animals for each owner. Find the top 5 owners, who have the biggest count of animals.
Select the owner’s name and the count of the animals he owns.
Order the result by the count of animals owned (descending) and then by the owner’s name.
*/
SELECT TOP(5) o.[Name]
	,COUNT(a.Id) AS CountOfAnimals
	FROM Animals AS a
	JOIN Owners AS o ON a.OwnerId = o.Id
GROUP BY o.[Name]
ORDER BY CountOfAnimals DESC,o.[Name]
--4
/*
Extract information about the owners of mammals,
the name of their animal and in which cage these animals are.
Select owner’s name and animal’s name (in format 'owner-animal'),
owner‘s phone number and the id of the cage. Order the result by the name of the owner 
(ascending) and then by the name of the animal (descending).
*/
SELECT CONCAT(o.[Name],'-',a.[Name]) AS OwnersAnimals
	,o.PhoneNumber
	,c.Id
	FROM Owners AS o
	JOIN Animals AS a ON a.OwnerId = o.Id
	JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
	JOIN Cages AS c ON c.Id = ac.CageId
WHERE a.AnimalTypeId = 1
ORDER BY o.[Name] ASC,a.[Name] DESC
--5
/*
Extract information about the volunteers,
involved in 'Education program assistant' department,
who live in Sofia. Select their name, phone number and their address in Sofia (skip city’s name).
Order the result by the name of the volunteers (ascending).
*/
SELECT v.[Name]
	,v.PhoneNumber
	,LTRIM(SUBSTRING (LTRIM(v.[Address]),CHARINDEX('Sofia',v.[Address]) + 6, LEN(v.[Address]))) AS [Address]
	FROM Volunteers AS v
	JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
	WHERE v.DepartmentId = 2 AND v.[Address] LIKE '%Sofia%'
ORDER BY v.[Name] ASC
--6
/*
Extract all animals, who does not have an owner and are younger than 5 years (5 years from '01/01/2022'),
except for the Birds. Select their name, year of birth and animal type. Order the result by animal’s name.
*/
SELECT a.[Name]
	,DATEPART(YEAR,BirthDate) AS BirthYear
	,aa.AnimalType
	FROM Animals AS a
	JOIN AnimalTypes AS aa ON a.AnimalTypeId = aa.Id
WHERE aa.AnimalType <> 'Birds' AND OwnerId IS NULL AND DATEDIFF(YEAR,BirthDate,'01/01/2022') < 5
ORDER BY a.[Name]