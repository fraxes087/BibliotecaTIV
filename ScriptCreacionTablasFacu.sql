USE [BiblioOnline]
GO
/****** Object:  User [biblioonline]    Script Date: 04/15/2015 21:32:15 ******/
CREATE USER [biblioonline] FOR LOGIN [biblioonline] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 04/15/2015 21:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRoles](
	[id_role] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[id_role] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 04/15/2015 21:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Authors](
	[id_author] [int] IDENTITY(1,1) NOT NULL,
	[last_first_name] [varchar](100) NOT NULL,
	[first_name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[id_author] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rent_States]    Script Date: 04/15/2015 21:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rent_States](
	[id_state] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rent_States] PRIMARY KEY CLUSTERED 
(
	[id_state] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 04/15/2015 21:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Publishers](
	[id_publisher] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED 
(
	[id_publisher] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 04/15/2015 21:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genres](
	[id_genre] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[id_genre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 04/15/2015 21:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genders](
	[id_gender] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[id_gender] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Books]    Script Date: 04/15/2015 21:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Books](
	[id_book] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](100) NOT NULL,
	[id_publisher] [int] NOT NULL,
	[id_author] [int] NOT NULL,
	[id_genre] [int] NOT NULL,
	[edition] [int] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[id_book] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/15/2015 21:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](8) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[id_role] [int] NOT NULL,
	[id_gender] [int] NOT NULL,
	[mail] [varchar](100) NOT NULL,
	[birthDate] [date] NULL,
	[date_sign] [date] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 04/15/2015 21:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[id_stock] [int] IDENTITY(1,1) NOT NULL,
	[id_book] [int] NOT NULL,
	[cant] [int] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[id_stock] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rents]    Script Date: 04/15/2015 21:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rents](
	[id_rent] [int] IDENTITY(1,1) NOT NULL,
	[id_state] [int] NOT NULL,
	[id_user] [int] NOT NULL,
	[id_book] [int] NOT NULL,
	[ren_date] [date] NOT NULL,
	[ret_date] [date] NULL,
 CONSTRAINT [PK_Rents] PRIMARY KEY CLUSTERED 
(
	[id_rent] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [Authors_PK_Books_FK]    Script Date: 04/15/2015 21:32:15 ******/
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [Authors_PK_Books_FK] FOREIGN KEY([id_author])
REFERENCES [dbo].[Authors] ([id_author])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [Authors_PK_Books_FK]
GO
/****** Object:  ForeignKey [Genres_PK_Books_FK]    Script Date: 04/15/2015 21:32:15 ******/
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [Genres_PK_Books_FK] FOREIGN KEY([id_genre])
REFERENCES [dbo].[Genres] ([id_genre])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [Genres_PK_Books_FK]
GO
/****** Object:  ForeignKey [Publishers_PK_Books_FK]    Script Date: 04/15/2015 21:32:15 ******/
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [Publishers_PK_Books_FK] FOREIGN KEY([id_publisher])
REFERENCES [dbo].[Publishers] ([id_publisher])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [Publishers_PK_Books_FK]
GO
/****** Object:  ForeignKey [Books_PK_Rents_FK]    Script Date: 04/15/2015 21:32:15 ******/
ALTER TABLE [dbo].[Rents]  WITH CHECK ADD  CONSTRAINT [Books_PK_Rents_FK] FOREIGN KEY([id_book])
REFERENCES [dbo].[Books] ([id_book])
GO
ALTER TABLE [dbo].[Rents] CHECK CONSTRAINT [Books_PK_Rents_FK]
GO
/****** Object:  ForeignKey [Rent_States_PK_Rents_FK]    Script Date: 04/15/2015 21:32:15 ******/
ALTER TABLE [dbo].[Rents]  WITH CHECK ADD  CONSTRAINT [Rent_States_PK_Rents_FK] FOREIGN KEY([id_state])
REFERENCES [dbo].[Rent_States] ([id_state])
GO
ALTER TABLE [dbo].[Rents] CHECK CONSTRAINT [Rent_States_PK_Rents_FK]
GO
/****** Object:  ForeignKey [Users_PK_Rents_FK]    Script Date: 04/15/2015 21:32:15 ******/
ALTER TABLE [dbo].[Rents]  WITH CHECK ADD  CONSTRAINT [Users_PK_Rents_FK] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([id_user])
GO
ALTER TABLE [dbo].[Rents] CHECK CONSTRAINT [Users_PK_Rents_FK]
GO
/****** Object:  ForeignKey [Books_PK_Stock_FK]    Script Date: 04/15/2015 21:32:15 ******/
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [Books_PK_Stock_FK] FOREIGN KEY([id_book])
REFERENCES [dbo].[Books] ([id_book])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [Books_PK_Stock_FK]
GO
/****** Object:  ForeignKey [Genders_PK_Users_FK]    Script Date: 04/15/2015 21:32:15 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [Genders_PK_Users_FK] FOREIGN KEY([id_gender])
REFERENCES [dbo].[Genders] ([id_gender])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [Genders_PK_Users_FK]
GO
/****** Object:  ForeignKey [UserRoles_PK_Users_FK]    Script Date: 04/15/2015 21:32:15 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [UserRoles_PK_Users_FK] FOREIGN KEY([id_role])
REFERENCES [dbo].[UserRoles] ([id_role])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [UserRoles_PK_Users_FK]
GO
