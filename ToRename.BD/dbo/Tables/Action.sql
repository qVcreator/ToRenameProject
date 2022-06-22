CREATE TABLE [dbo].[Action] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [From]      VARCHAR (255) NULL,
    [To]        VARCHAR (255) NULL,
    [StartTime] DATETIME      NULL,
    [EndTime]   DATETIME      NULL,
    [OptionId]  INT           NOT NULL,
    [IsDeleted] BIT           NOT NULL
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([OptionId]) REFERENCES [dbo].[Option] ([id]),
);

