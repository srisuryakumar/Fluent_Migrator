CREATE VIEW dbo.View_ProjectSummary
AS
SELECT 
    COUNT(*) AS TotalProjects,
    SUM(CASE WHEN IsActive = 1 THEN 1 ELSE 0 END) AS ActiveProjects,
    SUM(CASE WHEN IsActive = 0 THEN 1 ELSE 0 END) AS InactiveProjects
FROM 
    dbo.Project;