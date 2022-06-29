CREATE PROCEDURE [dbo].[ActionAdd]
	@From varchar(255),
	@To varchar(255),
	@StartDate datetime = null,
	@EndDate datetime = null,
	@OptionId int,
	@isDeleted bit = 0,
	@LastId int = null
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
SET @LastId = SCOPE_IDENTITY();
EXEC ActionGetAllInfoById @Id=@LastId
END
