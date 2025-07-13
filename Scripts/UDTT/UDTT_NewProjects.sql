CREATE TYPE dbo.UDTT_NewProjects AS TABLE (
    ProjectName NVARCHAR(100),
    StartDate DATE,
    EndDate DATE NULL,
    IsActive BIT
);