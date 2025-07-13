CREATE VIEW dbo.View_ActiveProjects
AS
SELECT 
    ProjectId,
    ProjectName,
    StartDate,
    EndDate
FROM 
    dbo.Project
WHERE 
    IsActive = 1;