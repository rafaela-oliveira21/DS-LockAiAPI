BEGIN TRANSACTION;

CREATE TABLE [TB_PLANO_LOCACAO] (
    [Id] INT NOT NULL IDENTITY,
    [Nome] NVARCHAR(40) NOT NULL,
    [IdUsuario] INT NOT NULL,
    [IdObjeto] INT NOT NULL,
    [IdPlanoLocacao] INT NOT NULL,
    [DataInicio] DATETIME NOT NULL,
    [DataFim] DATETIME NOT NULL,
    [DataValidade] DATETIME NOT NULL,
    [DataSituacao] DATETIME NOT NULL,
    [Valor] INT NOT NULL,
    [Situacao] NVARCHAR(10) NOT NULL,
    [IdUsuarioSituacao] INT NOT NULL,
    CONSTRAINT [PK_TB_PLANO_LOCACAO] PRIMARY KEY ([Id])

);

INSERT INTO TB_PLANO_LOCACAO 
    (Nome, IdUsuario, IdObjeto, IdPlanoLocacao, DataInicio, DataFim, DataValidade, DataSituacao, Valor, Situacao, IdUsuarioSituacao)
VALUES 
    (N'Plano A', 100, 1, 101, '2025-06-20', '2025-06-27', '2025-07-01', '2025-06-20', 120, N'Ativo', 100),
    (N'Plano B', 101, 2, 102, '2025-06-01', '2025-07-01', '2025-07-10', '2025-06-01', 400, N'Ativo', 101);


SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TB_PLANO_LOCACAO';




