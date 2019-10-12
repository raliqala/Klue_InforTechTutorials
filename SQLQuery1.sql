CREATE TABLE [dbo].[Programming] (
    [ProgrammingId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX) NULL,
    [IsCheked]      BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Programming] PRIMARY KEY CLUSTERED ([ProgrammingId] ASC)
);