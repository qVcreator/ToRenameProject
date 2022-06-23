CREATE PROCEDURE [dbo].[ActionAllInfo]
AS
BEGIN

	SELECT A.[id], A.[From], A.[To], A.[StartTime], A.[EndTime], A.[OptionId], O.[id], O.[Name], A.[IsDeleted]
	FROM dbo.[Action] as A
	LEFT JOIN dbo.[Option] as O on (A.[OptionId] = O.[id])
END