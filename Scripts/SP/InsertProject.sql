CREATE PROCEDURE dbo.InsertProject
    @ProjectName NVARCHAR(100),
    @StartDate DATE,
    @EndDate DATE = NULL,
    @IsActive BIT = 1
AS
BEGIN
    INSERT INTO dbo.Project (ProjectName, StartDate, EndDate, IsActive)
    VALUES (@ProjectName, @StartDate, @EndDate, @IsActive);
END