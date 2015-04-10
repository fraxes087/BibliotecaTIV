--TABLA USUARIO
CREATE TABLE [dbo].[Users](
[id_user] [int] IDENTITY(1,1) NOT NULL,
[first_name] [varchar](50) NOT NULL,
[last_first_name] [varchar](50) NOT NULL,
[id_role][int]NOT NULL,
[id_gender][int]NOT NULL,
[mail][varchar](100)NOT NULL,
[birthDate][date],
[date_sign][date]NOT NULL,
CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED
	(
	[id_user] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--TABLA GENDERS
CREATE TABLE [dbo].[Genders](
[id_gender][int] IDENTITY(1,1)NOT NULL,
[description][varchar](50)NOT NULL,
CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED
	(
	[id_gender] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--TABLA ROLES USUARIO
CREATE TABLE [dbo].[UserRoles](
[id_role][int] IDENTITY(1,1)NOT NULL,
[description][varchar](50)NOT NULL,
CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED
	(
	[id_role] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--TABLA LIBROS
CREATE TABLE [dbo].[Books](
[id_book] [int] IDENTITY (1,1) NOT NULL,
[titulo] [varchar] (100) NOT NULL,
[id_publisher] [int] NOT NULL,
[id_author][int] NOT NULL,
[id_genre] [int] NOT NULL,
[edition] [int],
CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED
	(
	[id_book] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--TABLA GENEROS
CREATE TABLE [dbo].[Genres](
[id_genre] [int] IDENTITY (1,1) NOT NULL,
[description] [varchar](100) NOT NULL,
CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED
	(
	[id_genre] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--TABLA EDITORIALES
CREATE TABLE [dbo].[Publishers](
[id_publisher] [int] IDENTITY (1,1) NOT NULL,
[full_name] [varchar](100) NOT NULL,
CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED
	(
	[id_publisher] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--TABLA AUTORES
CREATE TABLE [dbo].[Authors](
[id_author] [int]IDENTITY (1,1) NOT NULL,
[last_first_name] [varchar] (100) NOT NULL, 
[first_name] [varchar] (100) NOT NULL,
CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED
	(
	[id_author] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

-- TABLA ESTADO DE RENTA
CREATE TABLE [dbo].[Rent_States](
[id_state] [int] IDENTITY (1,1) NOT NULL,
[description] [varchar] (50) NOT NULL,
CONSTRAINT [PK_Rent_States] PRIMARY KEY CLUSTERED
	(
	[id_state] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

-- TABLA RENTAS
CREATE TABLE [dbo].[Rents](
[id_rent] [int] IDENTITY (1,1) NOT NULL,
[id_state] [int] NOT NULL,
[id_user] [int] NOT NULL,
[id_book][int]NOT NULL,
[ren_date] [date] NOT NULL,
[ret_date] [date],
CONSTRAINT [PK_Rents] PRIMARY KEY CLUSTERED
	(
	[id_rent] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--TABLA STOCK
CREATE TABLE [dbo].[Stock](
[id_stock] [int] IDENTITY (1,1) NOT NULL,
[id_book] [int] NOT NULL,
[cant] [int] NOT NULL,
CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED
    (
	[id_stock] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS
= ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--Users tiene Roles
ALTER TABLE [dbo].[Users] WITH CHECK ADD CONSTRAINT [UserRoles_PK_Users_FK] FOREIGN
KEY([id_role])
REFERENCES [dbo].[UserRoles] ([id_role])
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [UserRoles_PK_Users_FK]
GO

--Users tiene Gender
ALTER TABLE [dbo].[Users] WITH CHECK ADD CONSTRAINT [Genders_PK_Users_FK] FOREIGN
KEY([id_gender])
REFERENCES [dbo].[Genders] ([id_gender])
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [Genders_PK_Users_FK]
GO

--Rents tiene Users
ALTER TABLE [dbo].[Rents] WITH CHECK ADD CONSTRAINT [Users_PK_Rents_FK] FOREIGN
KEY([id_user])
REFERENCES [dbo].[Users] ([id_user])
GO

ALTER TABLE [dbo].[Rents] CHECK CONSTRAINT [Users_PK_Rents_FK]
GO

--Stock tiene Libro
ALTER TABLE [dbo].[Stock] WITH CHECK ADD CONSTRAINT [Books_PK_Stock_FK] FOREIGN
KEY([id_book])
REFERENCES [dbo].[Books] ([id_book])
GO

ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [Books_PK_Stock_FK]
GO

--Books tiene Publishers CHEQUEAR
ALTER TABLE [dbo].[Books] WITH CHECK ADD CONSTRAINT [Publishers_PK_Books_FK] FOREIGN
KEY([id_publisher])
REFERENCES [dbo].[Publishers] ([id_publisher])
GO

ALTER TABLE [dbo].[Books] WITH CHECK ADD CONSTRAINT [Publishers_PK_Books_FK]
GO

--Books tiene Genres 
ALTER TABLE [dbo].[Books] WITH CHECK ADD CONSTRAINT [Genres_PK_Books_FK] FOREIGN
KEY([id_genre])
REFERENCES [dbo].[Genres] ([id_genre])
GO

ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [Genres_PK_Books_FK]
GO

--Books tiene Authors
ALTER TABLE [dbo].[Books] WITH CHECK ADD CONSTRAINT [Authors_PK_Books_FK] FOREIGN
KEY([id_author])
REFERENCES [dbo].[Authors] ([id_author])
GO

ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [Authors_PK_Books_FK]
GO

--Rents tiene Rent_States
ALTER TABLE [dbo].[Rents] WITH CHECK ADD CONSTRAINT [Rent_States_PK_Rents_FK] FOREIGN
KEY([id_state])
REFERENCES [dbo].[Rent_States] ([id_state])
GO

ALTER TABLE [dbo].[Rents] CHECK CONSTRAINT [Rent_States_PK_Rents_FK]
GO

--Rents tiene Books
ALTER TABLE [dbo].[Rents] WITH CHECK ADD CONSTRAINT [Books_PK_Rents_FK] FOREIGN
KEY([id_book])
REFERENCES [dbo].[Books] ([id_book])
GO

ALTER TABLE [dbo].[Rents] CHECK CONSTRAINT [Books_PK_Rents_FK]
GO
