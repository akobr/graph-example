CREATE TABLE [dbo].[Nodes] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [IdExternal] VARCHAR (32)   NOT NULL,
    [Label]      NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Nodes] PRIMARY KEY CLUSTERED ([Id] ASC)
);



