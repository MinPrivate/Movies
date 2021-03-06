USE [master]
GO
/****** Object:  Database [WATCHMOVIE]    Script Date: 07/22/2012 14:18:57 ******/
CREATE DATABASE [WATCHMOVIE] ON  PRIMARY 
( NAME = N'WATCHMOVIE', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\WATCHMOVIE.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WATCHMOVIE_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\WATCHMOVIE_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WATCHMOVIE] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WATCHMOVIE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WATCHMOVIE] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [WATCHMOVIE] SET ANSI_NULLS OFF
GO
ALTER DATABASE [WATCHMOVIE] SET ANSI_PADDING OFF
GO
ALTER DATABASE [WATCHMOVIE] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [WATCHMOVIE] SET ARITHABORT OFF
GO
ALTER DATABASE [WATCHMOVIE] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [WATCHMOVIE] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [WATCHMOVIE] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [WATCHMOVIE] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [WATCHMOVIE] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [WATCHMOVIE] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [WATCHMOVIE] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [WATCHMOVIE] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [WATCHMOVIE] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [WATCHMOVIE] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [WATCHMOVIE] SET  DISABLE_BROKER
GO
ALTER DATABASE [WATCHMOVIE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [WATCHMOVIE] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [WATCHMOVIE] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [WATCHMOVIE] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [WATCHMOVIE] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [WATCHMOVIE] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [WATCHMOVIE] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [WATCHMOVIE] SET  READ_WRITE
GO
ALTER DATABASE [WATCHMOVIE] SET RECOVERY FULL
GO
ALTER DATABASE [WATCHMOVIE] SET  MULTI_USER
GO
ALTER DATABASE [WATCHMOVIE] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [WATCHMOVIE] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'WATCHMOVIE', N'ON'
GO
USE [WATCHMOVIE]
GO
/****** Object:  Table [dbo].[RUSER]    Script Date: 07/22/2012 14:18:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RUSER](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[email] [varchar](50) NOT NULL,
	[address] [varchar](250) NULL,
	[like_kind] [varchar](250) NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CINEMA]    Script Date: 07/22/2012 14:18:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CINEMA](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](150) NULL,
	[address] [varchar](250) NULL,
	[phone] [varchar](150) NULL,
	[start_work_time] [varchar](150) NULL,
	[end_work_time] [varchar](150) NULL,
	[introduction] [varchar](max) NULL,
	[website] [varchar](150) NULL,
	[rank] [tinyint] NULL,
	[rank_number] [int] NULL,
	[path] [varchar](400) NULL,
 CONSTRAINT [PK_CINEMA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CINEMA_ADDRESS] ON [dbo].[CINEMA] 
(
	[address] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_CINEMA_NAME] ON [dbo].[CINEMA] 
(
	[name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MOVIE]    Script Date: 07/22/2012 14:18:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MOVIE](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[director] [varchar](230) NULL,
	[actor] [varchar](400) NULL,
	[kind] [varchar](150) NULL,
	[region] [varchar](30) NULL,
	[last_time] [smallint] NULL,
	[first_showtime] [date] NULL,
	[introduction] [varchar](max) NULL,
	[rank] [tinyint] NULL,
	[rank_number] [smallint] NULL,
	[click_number] [smallint] NULL,
	[path] [varchar](400) NULL,
 CONSTRAINT [PK_MOVIE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_MOVIE_ACTOR] ON [dbo].[MOVIE] 
(
	[actor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MOVIE_DIRECTOR] ON [dbo].[MOVIE] 
(
	[director] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MOVIE_NAME] ON [dbo].[MOVIE] 
(
	[name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MOVIE_SHOWTIME] ON [dbo].[MOVIE] 
(
	[first_showtime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[funcGetUserNameById]    Script Date: 07/22/2012 14:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vincent Lee>
-- Create date: <2012/7/14>
-- Description:	<根据用户ID获得用户名>
-- =============================================
CREATE FUNCTION [dbo].[funcGetUserNameById]
(
	@Id int
)
RETURNS varchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Name varchar(50)

	-- Add the T-SQL statements to compute the return value here
	 
	 SELECT @Name=
	 (SELECT name
	  FROM RUSER
	  WHERE id=@Id
	  )
	 

	-- Return the result of the function
	RETURN @Name

END
GO
/****** Object:  UserDefinedFunction [dbo].[funcGetRankByMovieName]    Script Date: 07/22/2012 14:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vincent Lee>
-- Create date: <2012/7/14>
-- Description:	<根据电影名字得到电影评分>
-- =============================================
CREATE FUNCTION [dbo].[funcGetRankByMovieName]
(
	@MovieName varchar(50)
)
RETURNS tinyint
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Rank tinyint

	-- Add the T-SQL statements to compute the return value here
	SELECT @Rank = 
	(SELECT rank 
	 FROM MOVIE
	 WHERE name=@MovieName
	 )

	-- Return the result of the function
	RETURN @Rank

END
GO
/****** Object:  UserDefinedFunction [dbo].[funcGetKindByMovieName]    Script Date: 07/22/2012 14:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vincent Lee>
-- Create date: <2012/7/14>
-- Description:	<根据电影名字得到电影类型>
-- =============================================
CREATE FUNCTION [dbo].[funcGetKindByMovieName]
(
	@MovieName varchar(50)
)
RETURNS tinyint
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Kind varchar(50)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Kind = 
	(SELECT kind 
	 FROM MOVIE
	 WHERE name=@MovieName
	 )

	-- Return the result of the function
	RETURN @Kind

END
GO
/****** Object:  Table [dbo].[CINAME_COMMENT]    Script Date: 07/22/2012 14:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CINAME_COMMENT](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[cinema_id] [int] NULL,
	[time] [datetime2](0) NULL,
	[body] [varchar](400) NULL,
	[support] [smallint] NULL,
	[oppose] [smallint] NULL,
 CONSTRAINT [PK_CINAME_COMMENT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MOVIE_SCHEDULE]    Script Date: 07/22/2012 14:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MOVIE_SCHEDULE](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[movie_id] [int] NULL,
	[cinema_id] [int] NULL,
	[showtime] [datetime] NULL,
	[price] [int] NULL,
	[kind] [varchar](40) NULL,
	[book_website] [varchar](400) NULL,
 CONSTRAINT [PK_MOVIE_SCHEDULE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MOVIE_PICTURE]    Script Date: 07/22/2012 14:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MOVIE_PICTURE](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](250) NULL,
	[movie_id] [int] NULL,
	[type] [varchar](20) NULL,
	[path] [varchar](400) NULL,
 CONSTRAINT [PK_MOVIE_PICTURE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MOVIE_COMMENT]    Script Date: 07/22/2012 14:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MOVIE_COMMENT](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[movie_id] [int] NULL,
	[time] [datetime2](0) NULL,
	[body] [varchar](400) NULL,
	[support] [smallint] NULL,
	[oppose] [smallint] NULL,
 CONSTRAINT [PK_MOVIE_COMMENT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[funcCheckUSerByIDPassword]    Script Date: 07/22/2012 14:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vincent Lee>
-- Create date: <2012/7/14>
-- Description:	<根据用户ID及密码判断是否为注册用户>
-- =============================================
CREATE FUNCTION [dbo].[funcCheckUSerByIDPassword]
(
	@Id int,
	@Password varchar(50)
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	DECLARE @IsUSer bit

	-- Add the T-SQL statements to compute the return value here
	 
	 if exists (select * from RUSER where id=@Id AND password=@Password)
		SELECT @IsUSer =(select 1)
	 else 
		SELECT @IsUSer=(select 0)
	 

	-- Return the result of the function
	RETURN @IsUser

END
GO
/****** Object:  UserDefinedFunction [dbo].[funcCheckUSerByEmailPassword]    Script Date: 07/22/2012 14:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vincent Lee>
-- Create date: <2012/7/14>
-- Description:	<根据用户邮箱及密码判断是否为注册用户>
-- =============================================
CREATE FUNCTION [dbo].[funcCheckUSerByEmailPassword]
(
	@Email varchar(50),
	@Password varchar(50)
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	DECLARE @IsUSer bit

	-- Add the T-SQL statements to compute the return value here
	 
	 if exists (select * from RUSER where email=@Email AND password=@Password)
		SELECT @IsUSer =(select 1)
	 else 
		SELECT @IsUSer=(select 0)
	 

	-- Return the result of the function
	RETURN @IsUser

END
GO
/****** Object:  UserDefinedFunction [dbo].[funcCheckEmailByEmail]    Script Date: 07/22/2012 14:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vincent Lee>
-- Create date: <2012/7/14>
-- Description:	<检查Email是否已经存在>
-- =============================================
CREATE FUNCTION [dbo].[funcCheckEmailByEmail]
(
	@Email varchar(50)
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	DECLARE @IsExist bit

	-- Add the T-SQL statements to compute the return value here
	 
	if exists (select * from RUSER where email=@Email)
		SELECT @IsExist =(select 1)
	 else 
		SELECT @IsExist=(select 0)

	-- Return the result of the function
	RETURN @IsExist

END
GO
/****** Object:  Table [dbo].[FILM_CRITIC]    Script Date: 07/22/2012 14:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FILM_CRITIC](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[movie_id] [int] NULL,
	[title] [varchar](50) NULL,
	[body] [varchar](max) NULL,
	[time] [datetime2](0) NULL,
	[support] [smallint] NULL,
	[oppose] [smallint] NULL,
 CONSTRAINT [PK_FILM_CRITIC] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[procMovieRankByName]    Script Date: 07/22/2012 14:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vincent Lee>
-- Create date: <2012/7/13>
-- Description:	<对电影进行评分>
-- =============================================
CREATE PROCEDURE [dbo].[procMovieRankByName]
	-- Add the parameters for the stored procedure here 
	@MovieName varchar(50),
	@Rank int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update MOVIE
	Set rank=(rank*rank_number+@Rank)/(rank_number+1)
	WHERE name=@MovieName
END
GO
/****** Object:  Table [dbo].[COLLECTION]    Script Date: 07/22/2012 14:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COLLECTION](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[movie_id] [int] NULL,
 CONSTRAINT [PK_COLLECTION] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CINEMA_PICTURE]    Script Date: 07/22/2012 14:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CINEMA_PICTURE](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](250) NULL,
	[cinema_id] [int] NULL,
	[type] [varchar](20) NULL,
	[path] [varchar](400) NULL,
 CONSTRAINT [PK_CINEMA_PICTURE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[VSCHEDULE]    Script Date: 07/22/2012 14:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VSCHEDULE]
AS
SELECT dbo.MOVIE.name AS movie, dbo.CINEMA.name AS cinema, dbo.CINEMA.address, 
      dbo.MOVIE_SCHEDULE.showtime, dbo.MOVIE_SCHEDULE.price
FROM dbo.CINEMA INNER JOIN
      dbo.MOVIE_SCHEDULE ON 
      dbo.CINEMA.id = dbo.MOVIE_SCHEDULE.cinema_id INNER JOIN
      dbo.MOVIE ON dbo.MOVIE.id = dbo.MOVIE_SCHEDULE.movie_id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "MOVIE_SCHEDULE"
            Begin Extent = 
               Top = 7
               Left = 504
               Bottom = 117
               Right = 639
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "MOVIE"
            Begin Extent = 
               Top = 108
               Left = 277
               Bottom = 218
               Right = 442
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CINEMA"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 116
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VSCHEDULE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VSCHEDULE'
GO
/****** Object:  StoredProcedure [dbo].[procMovieCommentIncreaseSupport]    Script Date: 07/22/2012 14:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vincent Lee>
-- Create date: <2012/7/13>
-- Description:	<对电影评论支持数加1>
-- =============================================
CREATE PROCEDURE [dbo].[procMovieCommentIncreaseSupport]
	-- Add the parameters for the stored procedure here 
	@MovieName varchar(50),
	@Time datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update MOVIE_COMMENT
	Set support=support+1
	WHERE time=@Time AND movie_id=(SELECT id
										FROM MOVIE
										WHERE name=@MovieName)
END
GO
/****** Object:  StoredProcedure [dbo].[procMovieCommentIncreaseOppose]    Script Date: 07/22/2012 14:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vincent Lee>
-- Create date: <2012/7/13>
-- Description:	<对电影评论反对数加1>
-- =============================================
CREATE PROCEDURE [dbo].[procMovieCommentIncreaseOppose]
	-- Add the parameters for the stored procedure here 
	@MovieName varchar(50),
	@Time datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update MOVIE_COMMENT
	Set oppose=oppose+1
	WHERE time=@Time AND movie_id=(SELECT id
										FROM MOVIE
										WHERE name=@MovieName)
END
GO
/****** Object:  StoredProcedure [dbo].[procCinemaCommentIncreaseSupport]    Script Date: 07/22/2012 14:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vincent Lee>
-- Create date: <2012/7/13>
-- Description:	<对电影院评论支持数加1>
-- =============================================
CREATE PROCEDURE [dbo].[procCinemaCommentIncreaseSupport]
	-- Add the parameters for the stored procedure here 
	@CinemaName varchar(50),
	@Time datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update CINAME_COMMENT
	Set support=support+1
	WHERE time=@Time AND cinema_id=(SELECT id
										FROM CINEMA
										WHERE name=@CinemaName)
END
GO
/****** Object:  StoredProcedure [dbo].[procCinemaCommentIncreaseOppose]    Script Date: 07/22/2012 14:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vincent Lee>
-- Create date: <2012/7/13>
-- Description:	<对电影院评论反对数加1>
-- =============================================
CREATE PROCEDURE [dbo].[procCinemaCommentIncreaseOppose]
	-- Add the parameters for the stored procedure here 
	@CinemaName varchar(50),
	@Time datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update CINAME_COMMENT
	Set oppose=oppose+1
	WHERE time=@Time AND cinema_id=(SELECT id
										FROM CINEMA
										WHERE name=@CinemaName)
END
GO
/****** Object:  Table [dbo].[CRITIC_COMMENT]    Script Date: 07/22/2012 14:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CRITIC_COMMENT](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[critic_id] [int] NULL,
	[time] [datetime2](0) NULL,
	[body] [varchar](400) NULL,
	[support] [smallint] NULL,
	[oppose] [smallint] NULL,
 CONSTRAINT [PK_CRITIC_COMMENT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[funcGetCinemaNumByMovieName]    Script Date: 07/22/2012 14:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vincent Lee>
-- Create date: <2012/7/14>
-- Description:	<根据电影名字得到播放该电影的电影院总数>
-- =============================================
CREATE FUNCTION [dbo].[funcGetCinemaNumByMovieName]
(
	@MovieName varchar(50)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @CinemaNum int

	-- Add the T-SQL statements to compute the return value here
	--SELECT <@ResultVar, sysname, @Result> = <@Param1, sysname, @p1>
	SELECT @CinemaNum = 
	(SELECT COUNT(DISTINCT cinema_id)
						FROM MOVIE_SCHEDULE
	WHERE movie_id=(SELECT id
					FROM MOVIE
					WHERE name=@MovieName)
	)
	-- Return the result of the function
	RETURN @CinemaNum

END
GO
/****** Object:  Default [DF_CINEMA_rank]    Script Date: 07/22/2012 14:18:57 ******/
ALTER TABLE [dbo].[CINEMA] ADD  CONSTRAINT [DF_CINEMA_rank]  DEFAULT ((0)) FOR [rank]
GO
/****** Object:  Default [DF_CINEMA_rank_number]    Script Date: 07/22/2012 14:18:57 ******/
ALTER TABLE [dbo].[CINEMA] ADD  CONSTRAINT [DF_CINEMA_rank_number]  DEFAULT ((0)) FOR [rank_number]
GO
/****** Object:  Default [DF_MOVIE_rank]    Script Date: 07/22/2012 14:18:57 ******/
ALTER TABLE [dbo].[MOVIE] ADD  CONSTRAINT [DF_MOVIE_rank]  DEFAULT ((0)) FOR [rank]
GO
/****** Object:  Default [DF_MOVIE_rank_number]    Script Date: 07/22/2012 14:18:57 ******/
ALTER TABLE [dbo].[MOVIE] ADD  CONSTRAINT [DF_MOVIE_rank_number]  DEFAULT ((0)) FOR [rank_number]
GO
/****** Object:  Default [DF_MOVIE_click_number]    Script Date: 07/22/2012 14:18:57 ******/
ALTER TABLE [dbo].[MOVIE] ADD  CONSTRAINT [DF_MOVIE_click_number]  DEFAULT ((0)) FOR [click_number]
GO
/****** Object:  Default [DF_CINAME_COMMENT_support]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[CINAME_COMMENT] ADD  CONSTRAINT [DF_CINAME_COMMENT_support]  DEFAULT ((0)) FOR [support]
GO
/****** Object:  Default [DF_CINAME_COMMENT_oppose]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[CINAME_COMMENT] ADD  CONSTRAINT [DF_CINAME_COMMENT_oppose]  DEFAULT ((0)) FOR [oppose]
GO
/****** Object:  Default [DF_MOVIE_COMMENT_support]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[MOVIE_COMMENT] ADD  CONSTRAINT [DF_MOVIE_COMMENT_support]  DEFAULT ((0)) FOR [support]
GO
/****** Object:  Default [DF_MOVIE_COMMENT_oppose]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[MOVIE_COMMENT] ADD  CONSTRAINT [DF_MOVIE_COMMENT_oppose]  DEFAULT ((0)) FOR [oppose]
GO
/****** Object:  Default [DF_FILM_CRITIC_support]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[FILM_CRITIC] ADD  CONSTRAINT [DF_FILM_CRITIC_support]  DEFAULT ((0)) FOR [support]
GO
/****** Object:  Default [DF_FILM_CRITIC_oppose]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[FILM_CRITIC] ADD  CONSTRAINT [DF_FILM_CRITIC_oppose]  DEFAULT ((0)) FOR [oppose]
GO
/****** Object:  Default [DF_CRITIC_COMMENT_support]    Script Date: 07/22/2012 14:18:59 ******/
ALTER TABLE [dbo].[CRITIC_COMMENT] ADD  CONSTRAINT [DF_CRITIC_COMMENT_support]  DEFAULT ((0)) FOR [support]
GO
/****** Object:  Default [DF_CRITIC_COMMENT_oppose]    Script Date: 07/22/2012 14:18:59 ******/
ALTER TABLE [dbo].[CRITIC_COMMENT] ADD  CONSTRAINT [DF_CRITIC_COMMENT_oppose]  DEFAULT ((0)) FOR [oppose]
GO
/****** Object:  ForeignKey [FK_CINAME_COMMENT_CINEMA]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[CINAME_COMMENT]  WITH CHECK ADD  CONSTRAINT [FK_CINAME_COMMENT_CINEMA] FOREIGN KEY([cinema_id])
REFERENCES [dbo].[CINEMA] ([id])
GO
ALTER TABLE [dbo].[CINAME_COMMENT] CHECK CONSTRAINT [FK_CINAME_COMMENT_CINEMA]
GO
/****** Object:  ForeignKey [FK_CINAME_COMMENT_USER]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[CINAME_COMMENT]  WITH CHECK ADD  CONSTRAINT [FK_CINAME_COMMENT_USER] FOREIGN KEY([user_id])
REFERENCES [dbo].[RUSER] ([id])
GO
ALTER TABLE [dbo].[CINAME_COMMENT] CHECK CONSTRAINT [FK_CINAME_COMMENT_USER]
GO
/****** Object:  ForeignKey [FK_MOVIE_SCHEDULE_CINEMA]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[MOVIE_SCHEDULE]  WITH CHECK ADD  CONSTRAINT [FK_MOVIE_SCHEDULE_CINEMA] FOREIGN KEY([cinema_id])
REFERENCES [dbo].[CINEMA] ([id])
GO
ALTER TABLE [dbo].[MOVIE_SCHEDULE] CHECK CONSTRAINT [FK_MOVIE_SCHEDULE_CINEMA]
GO
/****** Object:  ForeignKey [FK_MOVIE_SCHEDULE_MOVIE]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[MOVIE_SCHEDULE]  WITH CHECK ADD  CONSTRAINT [FK_MOVIE_SCHEDULE_MOVIE] FOREIGN KEY([movie_id])
REFERENCES [dbo].[MOVIE] ([id])
GO
ALTER TABLE [dbo].[MOVIE_SCHEDULE] CHECK CONSTRAINT [FK_MOVIE_SCHEDULE_MOVIE]
GO
/****** Object:  ForeignKey [FK_MOVIE_PICTURE_MOVIE]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[MOVIE_PICTURE]  WITH CHECK ADD  CONSTRAINT [FK_MOVIE_PICTURE_MOVIE] FOREIGN KEY([movie_id])
REFERENCES [dbo].[MOVIE] ([id])
GO
ALTER TABLE [dbo].[MOVIE_PICTURE] CHECK CONSTRAINT [FK_MOVIE_PICTURE_MOVIE]
GO
/****** Object:  ForeignKey [FK_MOVIE_COMMENT_MOVIE]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[MOVIE_COMMENT]  WITH CHECK ADD  CONSTRAINT [FK_MOVIE_COMMENT_MOVIE] FOREIGN KEY([movie_id])
REFERENCES [dbo].[MOVIE] ([id])
GO
ALTER TABLE [dbo].[MOVIE_COMMENT] CHECK CONSTRAINT [FK_MOVIE_COMMENT_MOVIE]
GO
/****** Object:  ForeignKey [FK_MOVIE_COMMENT_USER]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[MOVIE_COMMENT]  WITH CHECK ADD  CONSTRAINT [FK_MOVIE_COMMENT_USER] FOREIGN KEY([user_id])
REFERENCES [dbo].[RUSER] ([id])
GO
ALTER TABLE [dbo].[MOVIE_COMMENT] CHECK CONSTRAINT [FK_MOVIE_COMMENT_USER]
GO
/****** Object:  ForeignKey [FK_FILM_CRITIC_FILM_CRITIC]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[FILM_CRITIC]  WITH CHECK ADD  CONSTRAINT [FK_FILM_CRITIC_FILM_CRITIC] FOREIGN KEY([user_id])
REFERENCES [dbo].[RUSER] ([id])
GO
ALTER TABLE [dbo].[FILM_CRITIC] CHECK CONSTRAINT [FK_FILM_CRITIC_FILM_CRITIC]
GO
/****** Object:  ForeignKey [FK_FILM_CRITIC_MOVIE]    Script Date: 07/22/2012 14:18:58 ******/
ALTER TABLE [dbo].[FILM_CRITIC]  WITH CHECK ADD  CONSTRAINT [FK_FILM_CRITIC_MOVIE] FOREIGN KEY([movie_id])
REFERENCES [dbo].[MOVIE] ([id])
GO
ALTER TABLE [dbo].[FILM_CRITIC] CHECK CONSTRAINT [FK_FILM_CRITIC_MOVIE]
GO
/****** Object:  ForeignKey [FK_COLLECTION_COLLECTION]    Script Date: 07/22/2012 14:18:59 ******/
ALTER TABLE [dbo].[COLLECTION]  WITH CHECK ADD  CONSTRAINT [FK_COLLECTION_COLLECTION] FOREIGN KEY([user_id])
REFERENCES [dbo].[RUSER] ([id])
GO
ALTER TABLE [dbo].[COLLECTION] CHECK CONSTRAINT [FK_COLLECTION_COLLECTION]
GO
/****** Object:  ForeignKey [FK_COLLECTION_MOVIE]    Script Date: 07/22/2012 14:18:59 ******/
ALTER TABLE [dbo].[COLLECTION]  WITH CHECK ADD  CONSTRAINT [FK_COLLECTION_MOVIE] FOREIGN KEY([movie_id])
REFERENCES [dbo].[MOVIE] ([id])
GO
ALTER TABLE [dbo].[COLLECTION] CHECK CONSTRAINT [FK_COLLECTION_MOVIE]
GO
/****** Object:  ForeignKey [FK_CINEMA_PICTURE_CINEMA]    Script Date: 07/22/2012 14:18:59 ******/
ALTER TABLE [dbo].[CINEMA_PICTURE]  WITH CHECK ADD  CONSTRAINT [FK_CINEMA_PICTURE_CINEMA] FOREIGN KEY([cinema_id])
REFERENCES [dbo].[CINEMA] ([id])
GO
ALTER TABLE [dbo].[CINEMA_PICTURE] CHECK CONSTRAINT [FK_CINEMA_PICTURE_CINEMA]
GO
/****** Object:  ForeignKey [FK_CRITIC_COMMENT_FILM_CRITIC]    Script Date: 07/22/2012 14:18:59 ******/
ALTER TABLE [dbo].[CRITIC_COMMENT]  WITH CHECK ADD  CONSTRAINT [FK_CRITIC_COMMENT_FILM_CRITIC] FOREIGN KEY([critic_id])
REFERENCES [dbo].[FILM_CRITIC] ([id])
GO
ALTER TABLE [dbo].[CRITIC_COMMENT] CHECK CONSTRAINT [FK_CRITIC_COMMENT_FILM_CRITIC]
GO
/****** Object:  ForeignKey [FK_CRITIC_COMMENT_USER]    Script Date: 07/22/2012 14:18:59 ******/
ALTER TABLE [dbo].[CRITIC_COMMENT]  WITH CHECK ADD  CONSTRAINT [FK_CRITIC_COMMENT_USER] FOREIGN KEY([user_id])
REFERENCES [dbo].[RUSER] ([id])
GO
ALTER TABLE [dbo].[CRITIC_COMMENT] CHECK CONSTRAINT [FK_CRITIC_COMMENT_USER]
GO
