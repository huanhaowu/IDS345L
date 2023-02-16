SET IDENTITY_INSERT [dbo].[tblCliente] ON
INSERT INTO [dbo].[tblCliente] ([Id], [Nombres], [Apellidos], [FechaNacimiento], [Sexo], [FechaIngreso], [Estado], [Comentario]) VALUES (1, N'Huan', N'Wu', N'1990-01-01 00:00:00', N'Masculino', N'2023-02-04 10:24:06', 1, N'ssss')
INSERT INTO [dbo].[tblCliente] ([Id], [Nombres], [Apellidos], [FechaNacimiento], [Sexo], [FechaIngreso], [Estado], [Comentario]) VALUES (2, N'Huan', N'Wu', N'2003-10-10 00:00:00', N'Masculino', N'2023-02-06 11:26:55', 1, N'Buenas ')
INSERT INTO [dbo].[tblCliente] ([Id], [Nombres], [Apellidos], [FechaNacimiento], [Sexo], [FechaIngreso], [Estado], [Comentario]) VALUES (3, N'Fernando', N'Wu', N'2005-10-03 00:00:00', N'Masculino', N'2023-02-06 11:27:17', 0, N'Buenas')
SET IDENTITY_INSERT [dbo].[tblCliente] OFF
