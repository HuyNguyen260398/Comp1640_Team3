USE [master]
GO
/****** Object:  Database [UMCS]    Script Date: 4/22/2019 10:59:15 PM ******/
CREATE DATABASE [UMCS]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'UMCS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\UMCS.mdf' , SIZE = 3328KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
-- LOG ON 
--( NAME = N'UMCS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\UMCS_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UMCS] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UMCS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UMCS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UMCS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UMCS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UMCS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UMCS] SET ARITHABORT OFF 
GO
ALTER DATABASE [UMCS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UMCS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UMCS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UMCS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UMCS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UMCS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UMCS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UMCS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UMCS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UMCS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UMCS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UMCS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UMCS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UMCS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UMCS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UMCS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UMCS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UMCS] SET RECOVERY FULL 
GO
ALTER DATABASE [UMCS] SET  MULTI_USER 
GO
ALTER DATABASE [UMCS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UMCS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UMCS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UMCS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UMCS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UMCS', N'ON'
GO
ALTER DATABASE [UMCS] SET QUERY_STORE = OFF
GO
USE [UMCS]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 4/22/2019 10:59:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Administrator](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Administrator] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClosureDate]    Script Date: 4/22/2019 10:59:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClosureDate](
	[AcademicYear] [int] NOT NULL,
	[ClosureDate] [date] NULL,
	[FinalClosureDate] [date] NULL,
 CONSTRAINT [PK_ClosureDate] PRIMARY KEY CLUSTERED 
(
	[AcademicYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contributions]    Script Date: 4/22/2019 10:59:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contributions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[DateSubmit] [datetime] NULL,
	[LastUpdate] [datetime] NULL,
	[Description] [nvarchar](50) NULL,
	[Type] [nvarchar](10) NULL,
	[FileType] [nvarchar](10) NULL,
	[ArchiveLink] [varchar](100) NULL,
	[Status] [nvarchar](50) NULL,
	[UploadDate] [date] NULL,
	[CommentDate] [date] NULL,
 CONSTRAINT [PK__Contribu__3214EC27E21DF0FB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 4/22/2019 10:59:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FacultyName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 4/22/2019 10:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Faculty](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MarketingManagerID] [int] NULL,
	[FacultiesID] [int] NULL,
	[Role] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[Age] [int] NULL,
	[Image] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK__Faculty__3214EC273A9ECC5D] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MarketingManager]    Script Date: 4/22/2019 10:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MarketingManager](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[Age] [int] NULL,
	[Image] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Students]    Script Date: 4/22/2019 10:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FacultiesID] [int] NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[DateOfBirth] [date] NULL,
	[Image] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Contributions] ON 

INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [Description], [Type], [FileType], [ArchiveLink], [Status], [UploadDate], [CommentDate]) VALUES (1, 1, N'ASPNET_MVC_WEB_API-MyFile', CAST(N'2019-03-22T10:17:30.610' AS DateTime), NULL, NULL, N'Document', N'.doc', N'/Files/AnthonyBruce_SID1_IT_ASPNET_MVC_WEB_API-MyFile.doc', N'Selected', NULL, NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [Description], [Type], [FileType], [ArchiveLink], [Status], [UploadDate], [CommentDate]) VALUES (2, 1, N'cat', CAST(N'2019-03-22T10:18:24.477' AS DateTime), NULL, NULL, N'Image', N'.jpg', N'/Files/AnthonyBruce_SID1_IT_cat.jpg', N'Pending', NULL, NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [Description], [Type], [FileType], [ArchiveLink], [Status], [UploadDate], [CommentDate]) VALUES (3, 1, N'minion', CAST(N'2019-03-23T08:14:46.683' AS DateTime), NULL, NULL, N'Image', N'.jpg', N'/Files/AnthonyBruce_SID1_IT_minion.jpg', N'Pending', NULL, NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [Description], [Type], [FileType], [ArchiveLink], [Status], [UploadDate], [CommentDate]) VALUES (4, 1, N'Literature Review', CAST(N'2019-03-23T08:19:46.263' AS DateTime), NULL, NULL, N'Document', N'.pdf', N'/Files/AnthonyBruce_SID1_IT_Literature Review.pdf', N'Pending', NULL, NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [Description], [Type], [FileType], [ArchiveLink], [Status], [UploadDate], [CommentDate]) VALUES (5, 1, N'do an thi giac may tinh', CAST(N'2019-03-23T08:50:47.420' AS DateTime), NULL, NULL, N'Document', N'.pdf', N'/Files/DarcyEmbruso_SID1_IT_do an thi giac may tinh.pdf', N'Pending', NULL, NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [Description], [Type], [FileType], [ArchiveLink], [Status], [UploadDate], [CommentDate]) VALUES (6, 1, N'78WpGU', CAST(N'2019-03-23T08:52:32.570' AS DateTime), NULL, NULL, N'Image', N'.jpg', N'/Files/DarcyEmbruso_SID1_IT_78WpGU.jpg', N'Pending', NULL, NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [Description], [Type], [FileType], [ArchiveLink], [Status], [UploadDate], [CommentDate]) VALUES (7, 1, N'Assignment_In_Class.', CAST(N'2019-03-23T08:56:01.577' AS DateTime), NULL, NULL, N'Document', N'.docx', N'/Files/DarcyEmbruso_SID1_IT_Assignment_In_Class..docx', N'Pending', NULL, NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [Description], [Type], [FileType], [ArchiveLink], [Status], [UploadDate], [CommentDate]) VALUES (8, 1, N'Nguyen Gia Huy - COMP1661 - LogBook1', CAST(N'2019-04-12T21:34:13.137' AS DateTime), NULL, NULL, N'Document', N'.docx', N'/Files/DarcyEmbruso_SID1_IT_Nguyen Gia Huy - COMP1661 - LogBook1.docx', N'Pending', NULL, NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [Description], [Type], [FileType], [ArchiveLink], [Status], [UploadDate], [CommentDate]) VALUES (9, 1, N'Assignment_In_Class.', CAST(N'2019-04-15T14:42:28.470' AS DateTime), NULL, NULL, N'Document', N'.docx', N'/Files/DarcyEmbruso_SID1_IT_Assignment_In_Class..docx', N'Pending', NULL, NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [Description], [Type], [FileType], [ArchiveLink], [Status], [UploadDate], [CommentDate]) VALUES (10, 1, N'Moblie_Application', CAST(N'2019-04-19T05:12:30.957' AS DateTime), NULL, NULL, N'Document', N'.docx', N'/Files/DarcyEmbruso_SID1_IT_Moblie_Application.docx', N'Pending', NULL, NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [Description], [Type], [FileType], [ArchiveLink], [Status], [UploadDate], [CommentDate]) VALUES (11, 1, N'FileApproach', CAST(N'2019-04-21T12:26:42.290' AS DateTime), NULL, NULL, N'Document', N'.pdf', N'/Files/DarcyEmbruso_SID1_IT_FileApproach.pdf', N'Pending', NULL, NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [Description], [Type], [FileType], [ArchiveLink], [Status], [UploadDate], [CommentDate]) VALUES (12, 1, N'Deliverable sign-off form', CAST(N'2019-04-21T13:45:22.543' AS DateTime), NULL, NULL, N'Document', N'.docx', N'/Files/DarcyEmbruso_SID1_IT_Deliverable sign-off form.docx', N'Pending', NULL, NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [Description], [Type], [FileType], [ArchiveLink], [Status], [UploadDate], [CommentDate]) VALUES (13, 1, N'Deliverable sign-off form', CAST(N'2019-04-21T15:14:27.063' AS DateTime), NULL, NULL, N'Document', N'.docx', N'/Files/DarcyEmbruso_SID1_IT_Deliverable sign-off form.docx', N'Pending', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Contributions] OFF
SET IDENTITY_INSERT [dbo].[Faculties] ON 

INSERT [dbo].[Faculties] ([ID], [FacultyName]) VALUES (1, N'IT')
SET IDENTITY_INSERT [dbo].[Faculties] OFF
SET IDENTITY_INSERT [dbo].[Faculty] ON 

INSERT [dbo].[Faculty] ([ID], [MarketingManagerID], [FacultiesID], [Role], [FirstName], [LastName], [Gender], [Age], [Image], [Phone], [Email], [Address], [Username], [Password]) VALUES (2, 11, 1, N'Faculty', N'Charles', N'Darwin', N'Male', 32, N'/Avatars/cat195747870.jpg', N'0123456789', N'charles@gmail.com', N'USA', N'charles_darwin', N'123')
INSERT [dbo].[Faculty] ([ID], [MarketingManagerID], [FacultiesID], [Role], [FirstName], [LastName], [Gender], [Age], [Image], [Phone], [Email], [Address], [Username], [Password]) VALUES (3, 11, 1, N'Marketing Coordinator', N'Bethany', N'Curly', N'Female', 28, N'/Avatars/cat195747870.jpg', N'0123456789', N'bethanycurly@gmail.com', N'USA', N'bethany_curly', N'123')
SET IDENTITY_INSERT [dbo].[Faculty] OFF
SET IDENTITY_INSERT [dbo].[MarketingManager] ON 

INSERT [dbo].[MarketingManager] ([ID], [FirstName], [LastName], [Gender], [Age], [Image], [Phone], [Email], [Address], [Username], [Password]) VALUES (11, N'Anthony', N'Bruce', N'Male', 30, NULL, N'0123456789', N'anthony@gmail.com', N'USA', N'anthony_bruce', N'123')
SET IDENTITY_INSERT [dbo].[MarketingManager] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([ID], [FacultiesID], [FirstName], [LastName], [Gender], [DateOfBirth], [Image], [Phone], [Email], [Address], [Username], [Password]) VALUES (1, 1, N'Darcy', N'Embruso', N'Female', CAST(N'1991-01-01' AS Date), N'/Avatars/cat195747870.jpg', N'0123456789', N'darcy@gmail.com', N'USA', N'darcy_embruso', N'123')
SET IDENTITY_INSERT [dbo].[Students] OFF
ALTER TABLE [dbo].[Contributions]  WITH CHECK ADD  CONSTRAINT [FK__Contribut__Stude__45F365D3] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([ID])
GO
ALTER TABLE [dbo].[Contributions] CHECK CONSTRAINT [FK__Contribut__Stude__45F365D3]
GO
ALTER TABLE [dbo].[Faculty]  WITH CHECK ADD  CONSTRAINT [FK_Faculty_Faculties] FOREIGN KEY([FacultiesID])
REFERENCES [dbo].[Faculties] ([ID])
GO
ALTER TABLE [dbo].[Faculty] CHECK CONSTRAINT [FK_Faculty_Faculties]
GO
ALTER TABLE [dbo].[Faculty]  WITH CHECK ADD  CONSTRAINT [FK_Faculty_MarketingManager] FOREIGN KEY([MarketingManagerID])
REFERENCES [dbo].[MarketingManager] ([ID])
GO
ALTER TABLE [dbo].[Faculty] CHECK CONSTRAINT [FK_Faculty_MarketingManager]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([FacultiesID])
REFERENCES [dbo].[Faculties] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteMarketingManager]    Script Date: 4/22/2019 10:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DeleteMarketingManager]
	@ID int
as
begin
	set nocount on;
	delete from MarketingManager
	where ID = @ID
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllMarketingManager]    Script Date: 4/22/2019 10:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetAllMarketingManager]
AS
SELECT * FROM MarketingManager

GO
/****** Object:  StoredProcedure [dbo].[sp_GetMarketingManagerById]    Script Date: 4/22/2019 10:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetMarketingManagerById] @ID int
as
select * from MarketingManager where ID = @ID

GO
/****** Object:  StoredProcedure [dbo].[sp_PostMarketingManager]    Script Date: 4/22/2019 10:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_PostMarketingManager]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Gender nvarchar(10),
	@Age int,
	@Image varchar(100),
	@Phone varchar(20),
	@Email nvarchar(50),
	@Address nvarchar(50),
	@Username nvarchar(50),
	@Password varchar(50)
as
begin
	set NOCOUNT on;
		insert into MarketingManager(FirstName, LastName, Gender, Age, [Image], Phone, Email, [Address], Username, [Password])
		values (@FirstName, @LastName, @Gender, @Age, @Image, @Phone, @Email, @Address, @Username, @Password)
	select SCOPE_IDENTITY() as ID
end

GO
/****** Object:  StoredProcedure [dbo].[sp_PutMarketingManager]    Script Date: 4/22/2019 10:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_PutMarketingManager]
	@ID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Gender nvarchar(10),
	@Age int,
	@Image varchar(100),
	@Phone varchar(20),
	@Email nvarchar(50),
	@Address nvarchar(50),
	@Username nvarchar(50),
	@Password varchar(50)
as
begin
	set nocount on;
	update MarketingManager
	set FirstName = @FirstName,
		LastName = @LastName,
		Gender = @Gender,
		Age = @Age,
		[Image] = @Image,
		Phone = @Phone,
		Email = @Email,
		[Address] = @Address,
		Username = @Username,
		[Password] = @Password
	where ID = @ID
end
GO
USE [master]
GO
ALTER DATABASE [UMCS] SET  READ_WRITE 
GO
