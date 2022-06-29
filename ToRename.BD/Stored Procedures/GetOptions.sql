CREATE PROCEDURE [dbo].[GetOptions]
AS
BEGIN

	SELECT id, [Name] FROM dbo.[Option]
END