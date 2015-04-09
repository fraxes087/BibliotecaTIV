--TABLA USUARIO
CREATE TABLE [dbo].[Usuarios](
[id_usuario] [int] IDENTITY(1,1) NOT NULL,
[nombre] [varchar](50) NOT NULL,
[apellido] [varchar](50) NOT NULL,
[id_rol][int]NOT NULL,
[mail][varchar](100)NOT NULL,
[fechaNac][date],
[fecha_alta][date]NOT NULL,
CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED
	(
	[id_usuario] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--TABLA ROLES USUARIO
CREATE TABLE [dbo].[RolesUsuarios](
[id_rol][int] IDENTITY(1,1)NOT NULL,
[descripcion][varchar](50)NOT NULL,
CONSTRAINT [PK_RolesUsuarios] PRIMARY KEY CLUSTERED
	(
	[id_rol] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--TABLA LIBROS
CREATE TABLE [dbo].[Libros](
[id_libro] [int] IDENTITY (1,1) NOT NULL,
[titulo] [varchar] (100) NOT NULL,
[id_editorial] [int] NOT NULL,
[id_autor][int] NOT NULL,
[id_genero] [int] NOT NULL,
[edicion] [int],
CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED
	(
	[id_libro] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--TABLA EDITORIALES
CREATE TABLE [dbo].[Editoriales](
[id_editorial] [int] IDENTITY (1,1) NOT NULL,
[nombre] [varchar](100) NOT NULL,
CONSTRAINT [PK_Editoriales] PRIMARY KEY CLUSTERED
	(
	[id_editorial] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--TABLA AUTORES
CREATE TABLE [dbo].[Autores](
[id_autor] [int ]IDENTITY (1,1) NOT NULL,
[apellido] [varchar] (100) NOT NULL, 
[nombre] [varchar] (100) NOT NULL,
CONSTRAINT [PK_Autores] PRIMARY KEY CLUSTERED
	(
	[id_autor] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

-- TABLA ESTADO DE RENTA
CREATE TABLE [dbo].[Estados_Renta](
[id_estado] [int] IDENTITY (1,1) NOT NULL,
[estado] [varchar] (50) NOT NULL,
CONSTRAINT [PK_Estados_Renta] PRIMARY KEY CLUSTERED
	(
	[id_estado] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

-- TABLA RENTAS
CREATE TABLE [dbo].[Rentas](
[id_renta] [int] IDENTITY (1,1) NOT NULL,
[id_estado] [int] NOT NULL,
[id_usuario] [int] NOT NULL,
[fecha_ren] [date] NOT NULL,
[fecha_dev] [date],
CONSTRAINT [PK_Rentas] PRIMARY KEY CLUSTERED
	(
	[id_renta] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--TABLA STOCK
CREATE TABLE [dbo].[Stock](
[id_stock] [int] IDENTITY (1,1) NOT NULL,
[id_libro] [int] NOT NULL,
[cantidad] [int] NOT NULL,
CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED
    (
	[id_stock] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--Usuarios tiene Roles
ALTER TABLE [dbo].[Usuarios] WITH CHECK ADD CONSTRAINT [RolesUsuarios_PK_Usuarios_FK] FOREIGN
KEY([id_rol])
REFERENCES [dbo].[RolesUsuarios] ([id_rol])
GO

ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [RolesUsuarios_PK_Usuarios_FK]
GO
--Rentas tiene Usuarios
ALTER TABLE [dbo].[Rentas] WITH CHECK ADD CONSTRAINT [Usuarios_PK_Rentas_FK] FOREIGN
KEY([id_usuario])
REFERENCES [dbo].[Usuarios] ([id_usuario])
GO

ALTER TABLE [dbo].[Rentas] CHECK CONSTRAINT [Usuarios_PK_Rentas_FK]
GO

--Stock tiene Libro
ALTER TABLE [dbo].[Stock] WITH CHECK ADD CONSTRAINT [Libros_PK_Stock_FK] FOREIGN
KEY([id_libro])
REFERENCES [dbo].[Libros] ([id_libro])
GO

ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [Libros_PK_Stock_FK]
GO

--Libros tiene Editoriales CHEQUEAR
ALTER TABLE [dbo].[Libros] WITH CHECK ADD CONSTRAINT [Editoriales_PK_Libros_FK] FOREIGN
KEY([id_editorial])
REFERENCES [dbo].[Editoriales] ([id_editorial])
GO

ALTER TABLE [dbo].[Libros] WITH CHECK ADD CONSTRAINT [Editoriales_PK_Libros_FK]
GO


--Libros tiene Autores
ALTER TABLE [dbo].[Libros] WITH CHECK ADD CONSTRAINT [Autores_PK_Libros_FK] FOREIGN
KEY([id_autor])
REFERENCES [dbo].[Autores] ([id_autor])
GO

ALTER TABLE [dbo].[Libros] CHECK CONSTRAINT [Autores_PK_Libros_FK]
GO

--Rentas -> Estado_Rentas
