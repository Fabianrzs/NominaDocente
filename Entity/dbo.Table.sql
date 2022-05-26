CREATE TABLE [dbo].[DOCENTES]
(
	[Identificacion] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [Nombres] VARCHAR(50) NULL, 
    [TipoDocente] VARCHAR(50) NULL, 
    [AreaDesempenio] VARCHAR(50) NULL, 
    [Categoria] VARCHAR(50) NULL, 
    [Salario] NUMERIC NULL, 
    [Nomina] NUMERIC NULL, 
    [AreaInvestigacion] VARCHAR(50) NULL
)
