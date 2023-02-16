CREATE TABLE [dbo].[tblInfidelidad]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NombresAfectado] NVARCHAR(150) NOT NULL, 
    [ApellidosAfectado] NVARCHAR(150) NOT NULL, 
    [NombresInfiel] NVARCHAR(150) NOT NULL, 
    [ApellidosInfiel] NVARCHAR(150) NOT NULL, 
    [SexoAfectado] NVARCHAR(150) NOT NULL, 
    [SexoInfiel] NVARCHAR(150) NOT NULL, 
    [FechaEvento] DATETIME NOT NULL, 
    [FechaIngreso] DATETIME NOT NULL DEFAULT getdate(), 
    [EstadoPareja] NVARCHAR(150) NOT NULL, 
    [EsLaPrimeraVez] BIT NOT NULL
)
