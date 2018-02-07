/*
Post-Deployment Script Template
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.
 Use SQLCMD syntax to include a file in the post-deployment script.
 Example:      :r .\myfile.sql
 Use SQLCMD syntax to reference a variable in the post-deployment script.
 Example:      :setvar TableName MyTable
               SELECT * FROM [$(TableName)]
--------------------------------------------------------------------------------------
*/

DECLARE @createTestData bit;

-- SPECIFY IF THE SIMPLE TEST DATA WILL BE ADDED TO PUBLISHED DATABASE
SET @createTestData = 1;

IF (@createTestData = 1)
BEGIN
  :r .\Script.Test.Data.sql
END;

