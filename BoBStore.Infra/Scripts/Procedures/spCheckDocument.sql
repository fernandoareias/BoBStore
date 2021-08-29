
-- Cria uma Store Procedure para verificar se o Documento existe
CREATE PROCEDURE spCheckDocument
    @Document CHAR(11)
AS
SELECT CASE WHEN EXISTS (
        SELECT [Id]
    FROM [Customer]
    WHERe [Document] = @Document
    )
    THEN CAST(1 AS BIT)
    ELSE CAST(0 AS BIT) END