CREATE FUNCTION dbo.Fn_IsProjectActive (
    @EndDate DATE
)
RETURNS BIT
AS
BEGIN
    RETURN CASE 
        WHEN @EndDate IS NULL OR @EndDate >= GETDATE() THEN 1
        ELSE 0
    END;
END