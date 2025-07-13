CREATE PROCEDURE dbo.InsertEmployee
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(200),
    @HireDate DATE,
    @IsActive BIT = 1
AS
BEGIN
    INSERT INTO dbo.Employees (FirstName, LastName, Email, HireDate, IsActive)
    VALUES (@FirstName, @LastName, @Email, @HireDate, @IsActive);
END