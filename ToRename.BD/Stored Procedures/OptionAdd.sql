CREATE PROCEDURE [dbo].[OptionAdd]
	@From varchar(255),
	@To varchar(255),
	@StartDate datetime,
	@EndDate datetime,
	@OptionId int,
	@isDeleted bit = 0
AS
BEGIN
INSERT INTO dbo.[Action](
	[From],
	[To],
	[StartTime],
	[EndTime],
	[OptionId],
	[isDeleted]
)
VALUES(
	@From,
	@To,
	@StartDate,
	@EndDate,
	@OptionId,
	@isDeleted
)
END
