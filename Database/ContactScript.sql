USE [master]
GO
/****** Object:  Database [Contacts]    Script Date: 1/17/2018 9:54:13 AM ******/
CREATE DATABASE [Contacts]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Contacts', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Contacts.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Contacts_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Contacts_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Contacts] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Contacts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Contacts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Contacts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Contacts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Contacts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Contacts] SET ARITHABORT OFF 
GO
ALTER DATABASE [Contacts] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Contacts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Contacts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Contacts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Contacts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Contacts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Contacts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Contacts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Contacts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Contacts] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Contacts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Contacts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Contacts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Contacts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Contacts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Contacts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Contacts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Contacts] SET RECOVERY FULL 
GO
ALTER DATABASE [Contacts] SET  MULTI_USER 
GO
ALTER DATABASE [Contacts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Contacts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Contacts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Contacts] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Contacts] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Contacts', N'ON'
GO
ALTER DATABASE [Contacts] SET QUERY_STORE = OFF
GO
USE [Contacts]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Contacts]
GO
/****** Object:  Table [dbo].[contact_list]    Script Date: 1/17/2018 9:54:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contact_list](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[surname] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[createon] [datetime] NULL,
	[modifiedon] [datetime] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[contact_list] ON 

INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (1024, N'marko', N'markic', N'123456', N'druidhr@gmail.com', CAST(N'2018-01-14T19:39:58.223' AS DateTime), CAST(N'2018-01-14T19:39:58.223' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (1025, N'mara', N'maric', N'12332612545', N'druidhr@gmail.com', CAST(N'2018-01-14T19:48:34.670' AS DateTime), CAST(N'2018-01-14T19:48:34.670' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (3, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:52.960' AS DateTime), CAST(N'2018-01-14T02:02:19.927' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (4, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:53.553' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (5, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:53.820' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (6, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:54.117' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (7, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:54.257' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (8, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:54.493' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (9, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:54.663' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (10, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:54.900' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (11, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:55.133' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (12, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:55.350' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (13, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:55.587' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (14, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:55.757' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (15, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:56.007' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (16, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:56.227' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (17, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:56.383' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (18, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:56.600' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (19, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:56.710' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (20, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:56.900' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (21, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:57.100' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (22, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2017-12-20T12:51:57.243' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (23, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2018-01-14T00:26:01.837' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (24, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2018-01-14T00:29:55.107' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (25, N'Gen', N'Gen', N'+385959004497', N'druidhr@gmail.com', CAST(N'2018-01-14T00:31:06.113' AS DateTime), CAST(N'2018-01-14T01:15:07.810' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (1026, N'ivo', N'ivic', N'1436523766', N'mar@gmail.com', CAST(N'2018-01-15T23:18:29.513' AS DateTime), CAST(N'2018-01-15T23:18:29.513' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (1027, N'ivo', N'ivicici', N'123456', N'mar@gmail.com', CAST(N'2018-01-15T23:20:09.950' AS DateTime), CAST(N'2018-01-15T23:20:09.950' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (1028, N'ivo', N'ivicici', N'123456', N'mar@gmail.com', CAST(N'2018-01-15T23:21:06.917' AS DateTime), CAST(N'2018-01-15T23:21:06.917' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (1029, N'ivo', N'ivicici', N'1436523766', N'mar@gmail.com', CAST(N'2018-01-15T23:30:40.440' AS DateTime), CAST(N'2018-01-15T23:30:40.440' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (1030, N'ivo', N'markic', N'12332612545', N'mar@gmail.com', CAST(N'2018-01-15T23:31:31.167' AS DateTime), CAST(N'2018-01-15T23:31:31.167' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (1031, N'ivo', N'ivicici', N'123456', N'mar@gmail.com', CAST(N'2018-01-15T23:31:59.773' AS DateTime), CAST(N'2018-01-15T23:31:59.773' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (1032, N'ivo', N'ivicici', N'1436523766', N'mar@gmail.com', CAST(N'2018-01-15T23:35:49.407' AS DateTime), CAST(N'2018-01-15T23:35:49.407' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (1033, N'ivo', N'maric', N'1436523766', N'mar@gmail.com', CAST(N'2018-01-15T23:47:52.463' AS DateTime), CAST(N'2018-01-15T23:47:52.463' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (1034, N'ivo', N'maric', N'12332612545', N'mar@gmail.com', CAST(N'2018-01-15T23:48:35.047' AS DateTime), CAST(N'2018-01-15T23:48:35.047' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (1035, N'ivo', N'markic', N'123456', N'mar@gmail.com', CAST(N'2018-01-15T23:53:33.357' AS DateTime), CAST(N'2018-01-15T23:53:54.670' AS DateTime))
INSERT [dbo].[contact_list] ([id], [name], [surname], [phone], [email], [createon], [modifiedon]) VALUES (1036, N'ivo', N'maric', N'123456', N'druidhr@gjjjj.mmmm', CAST(N'2018-01-15T23:54:25.983' AS DateTime), CAST(N'2018-01-15T23:54:43.933' AS DateTime))
SET IDENTITY_INSERT [dbo].[contact_list] OFF
/****** Object:  StoredProcedure [dbo].[CreateNewContact]    Script Date: 1/17/2018 9:54:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateNewContact] @Name varchar(50), @Surname varchar(50), @phone varchar(50), @email varchar(50), @contactID int OUT
AS
BEGIN
INSERT INTO contact_list("name", "surname", "phone", "email", "createon", "modifiedon") VALUES(@Name, @Surname, @phone, @email, GETDATE(), GETDATE())
SET @contactID = IDENT_CURRENT('contact_list');
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteContact]    Script Date: 1/17/2018 9:54:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteContact] @contactID int
AS
DELETE contact_list
WHERE id = @contactID
GO
/****** Object:  StoredProcedure [dbo].[GetContactByID]    Script Date: 1/17/2018 9:54:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetContactByID] @contactID int
AS
SELECT *FROM contact_list WHERE id = @contactID
GO
/****** Object:  StoredProcedure [dbo].[ListOfContactsWithPagination]    Script Date: 1/17/2018 9:54:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListOfContactsWithPagination] @PageNumber int, @OrderBy varchar(50), @Order varchar(5), @searchBy varchar(50), @searchByValue varchar(50)
AS
BEGIN

DECLARE @startListPageNumber int
SET @startListPageNumber = (@PageNumber * 10) - 9

DECLARE @endListPageNumber int
SET @endListPageNumber = @PageNumber * 10

EXEC('
	SELECT  *
	FROM 
	(
		SELECT ROW_NUMBER() OVER ( ORDER BY ' +@OrderBy+ '  ' +@Order+ ' ) AS RowNum, * 
		FROM contact_list
		WHERE ' +@searchBy+ ' like ''%' +@searchByValue+ '%''
	) AS RowConstrainedResult
		WHERE RowNum >= ' +@startListPageNumber+ '
		AND RowNum <= ' +@endListPageNumber+ '
	')

END;
GO
/****** Object:  StoredProcedure [dbo].[NumberOfContacts]    Script Date: 1/17/2018 9:54:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NumberOfContacts] @searchBy varchar(50), @searchByValue varchar(50), @NumberOfContacts int OUT
AS

DECLARE @SQLString NVARCHAR(500);
DECLARE @ParmDefinition NVARCHAR(500);

SET @SQLString = N'SELECT @NumberOfContacts = COUNT(id)
					FROM contact_list
					WHERE ' +@searchBy+ ' like ''%' +@searchByValue+ '%''';

SET @ParmDefinition = N'@NumberOfContacts int OUT';
BEGIN
EXECUTE sp_executesql 
		@SQLString, 
		@ParmDefinition, 
		@NumberOfContacts=@NumberOfContacts OUTPUT
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateContact]    Script Date: 1/17/2018 9:54:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateContact] @Name varchar(50), @Surname varchar(50), @phone varchar(50), @email varchar(50), @contactID int
AS
UPDATE contact_list
SET name = @Name, surname = @Surname, phone = @phone, email = @email, modifiedon = GETDATE()
WHERE id = @contactID
GO
USE [master]
GO
ALTER DATABASE [Contacts] SET  READ_WRITE 
GO
