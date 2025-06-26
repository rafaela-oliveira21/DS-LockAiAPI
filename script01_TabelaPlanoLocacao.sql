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

IF EXISTS (SELECT * FROM [sys].[identity_columns] 
           WHERE [name] IN (N'Id', N'Nome', N'Descricao', N'DuracaoDias', N'Valor', N'Ativo', 
                            N'DataInclusao', N'IdUsuarioInclusao', N'DataAtualizacao', N'IdUsuarioAtualizacao') 
             AND [object_id] = OBJECT_ID(N'[TB_PLANO_LOCACAO]'))
    SET IDENTITY_INSERT [TB_PLANO_LOCACAO] ON;

INSERT INTO [TB_PLANO_LOCACAO] 
    ([Id], [Nome], [Descricao], [DuracaoDias], [Valor], [Ativo], [DataInclusao], [IdUsuarioInclusao], [DataAtualizacao], [IdUsuarioAtualizacao])
VALUES 
    (1, N'Plano Semanal', N'Aluguel por 7 dias corridos', 7, 120.00, N'Ativo', N'2025-06-20', 100, N'2025-06-21', 100),
    (2, N'Plano Mensal', N'Aluguel por 30 dias corridos', 30, 400.00, N'Ativo', N'2025-06-20', 100, N'2025-06-21', 100);

IF EXISTS (SELECT * FROM [sys].[identity_columns] 
           WHERE [name] IN (N'Id', N'Nome', N'Descricao', N'DuracaoDias', N'Valor', N'Ativo', 
                            N'DataInclusao', N'IdUsuarioInclusao', N'DataAtualizacao', N'IdUsuarioAtualizacao') 
             AND [object_id] = OBJECT_ID(N'[TB_PLANO_LOCACAO]'))
    SET IDENTITY_INSERT [TB_PLANO_LOCACAO] OFF;

COMMIT;
