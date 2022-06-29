CREATE PROCEDURE dbo.ActionDeleteById
@Id int,
@From varchar,
@To varchar,
@StartTime datetime = null,
@EndTime datetime = null,
@OptionId int
AS
BEGIN
UPDATE dbo.[Action]
SET [From]=@From,
[To]=@To,
StartTime=@StartTime,
EndTime=@EndTime,
OptionId=@OptionId,
IsDeleted=1
WHERE Id = @Id
END