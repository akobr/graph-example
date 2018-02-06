CREATE TABLE [dbo].[Edges] (
    [IdFrom] INT NOT NULL,
    [IdTo]   INT NOT NULL,
    CONSTRAINT [PK_Edges] PRIMARY KEY CLUSTERED ([IdFrom] ASC, [IdTo] ASC),
    CONSTRAINT [FK_Edge_From_Node] FOREIGN KEY ([IdFrom]) REFERENCES [dbo].[Nodes] ([Id]),
    CONSTRAINT [FK_Edge_To_Node] FOREIGN KEY ([IdTo]) REFERENCES [dbo].[Nodes] ([Id])
);

