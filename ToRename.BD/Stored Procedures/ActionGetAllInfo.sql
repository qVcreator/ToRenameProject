CREATE PROCEDURE [dbo].[ActionGetAllInfo]
AS
BEGIN

	SELECT A.[id], A.[From], A.[To], A.[StartTime], A.[EndTime], A.[OptionId], O.[id], O.[Name], A.[IsDeleted]
	FROM dbo.[Action] as A
	LEFT JOIN dbo.[Option] as O on (A.[OptionId] = O.[id])
	WHERE A.[IsDeleted] = 0
END