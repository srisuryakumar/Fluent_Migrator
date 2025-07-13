CREATE FUNCTION dbo.Fn_ProjectDurationInDays (
    @StartDate DATE,
    @EndDate DATE
)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(DAY, @StartDate, ISNULL(@EndDate, GETDATE()));
END