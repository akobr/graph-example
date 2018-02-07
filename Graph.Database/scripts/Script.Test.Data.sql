-- NOTES --
INSERT INTO dbo.[Notes] (Id, Label)
VALUES (1, 'Test node 1');

INSERT INTO dbo.[Notes] (Id, Label)
VALUES (2, 'Test node 2');

INSERT INTO dbo.[Notes] (Id, Label)
VALUES (3, 'Test node 3');


-- EDGES --
INSERT INTO dbo.Edges (IdFrom, IdTo)
VALUES (1, 2);

INSERT INTO dbo.Edges (IdFrom, IdTo)
VALUES (2, 1);

INSERT INTO dbo.Edges (IdFrom, IdTo)
VALUES (2, 3);

INSERT INTO dbo.Edges (IdFrom, IdTo)
VALUES (3, 2);
