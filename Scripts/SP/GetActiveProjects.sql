CREATE PROCEDURE dbo.GetActiveProjects
AS
BEGIN
    SELECT * FROM dbo.Project WHERE IsActive = 1;
END