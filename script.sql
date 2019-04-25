/****** Object:  Database [UMCS]    Script Date: 25-Apr-19 6:56:40 PM ******/
CREATE DATABASE [UMCS]
GO
ALTER DATABASE [UMCS] SET COMPATIBILITY_LEVEL = 120
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
USE [UMCS]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 25-Apr-19 6:56:40 PM ******/
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
/****** Object:  Table [dbo].[ClosureDate]    Script Date: 25-Apr-19 6:56:40 PM ******/
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
/****** Object:  Table [dbo].[Contributions]    Script Date: 25-Apr-19 6:56:40 PM ******/
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
	[DateSubmit] [date] NULL,
	[LastUpdate] [date] NULL,
	[CommentDate] [date] NULL,
	[Description] [nvarchar](50) NULL,
	[Type] [nvarchar](10) NULL,
	[FileType] [nvarchar](10) NULL,
	[ArchiveLink] [varchar](100) NULL,
	[Status] [nvarchar](50) NULL,
	[FID] [int] NULL,
 CONSTRAINT [PK__Contribu__3214EC27E21DF0FB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 25-Apr-19 6:56:40 PM ******/
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
/****** Object:  Table [dbo].[Faculty]    Script Date: 25-Apr-19 6:56:40 PM ******/
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
	[EmailPW] [varchar](50) NULL,
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
/****** Object:  Table [dbo].[MarketingManager]    Script Date: 25-Apr-19 6:56:40 PM ******/
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
/****** Object:  Table [dbo].[Students]    Script Date: 25-Apr-19 6:56:40 PM ******/
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
INSERT [dbo].[Administrator] ([Username], [Password]) VALUES (N'a', N'1')
INSERT [dbo].[ClosureDate] ([AcademicYear], [ClosureDate], [FinalClosureDate]) VALUES (2019, CAST(N'2019-05-02' AS Date), CAST(N'2019-05-23' AS Date))
SET IDENTITY_INSERT [dbo].[Contributions] ON 

INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [CommentDate], [Description], [Type], [FileType], [ArchiveLink], [Status], [FID]) VALUES (10, 2, N'_SID2_IT_Capture', CAST(N'2019-04-25' AS Date), CAST(N'2019-04-25' AS Date), NULL, NULL, N'Image', N'.jpg', N'C:\Users\win\Desktop\Comp1640_Team3\Code\UMCS\Files\_SID2_IT_Capture.jpg', N'Pending', NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [CommentDate], [Description], [Type], [FileType], [ArchiveLink], [Status], [FID]) VALUES (11, 2, N'_SID2_IT_check', CAST(N'2019-04-25' AS Date), CAST(N'2019-04-25' AS Date), NULL, NULL, N'Image', N'.jpg', N'C:\Users\win\Desktop\Comp1640_Team3\Code\UMCS\Files\_SID2_IT_check.jpg', N'Pending', NULL)
INSERT [dbo].[Contributions] ([ID], [StudentID], [Title], [DateSubmit], [LastUpdate], [CommentDate], [Description], [Type], [FileType], [ArchiveLink], [Status], [FID]) VALUES (12, 2, N'_SID2_IT_cw', CAST(N'2019-04-25' AS Date), CAST(N'2019-04-25' AS Date), NULL, NULL, N'Document', N'.pdf', N'C:\Users\win\Desktop\Comp1640_Team3\Code\UMCS\Files\_SID2_IT_cw.pdf', N'Pending', NULL)
SET IDENTITY_INSERT [dbo].[Contributions] OFF
SET IDENTITY_INSERT [dbo].[Faculties] ON 

INSERT [dbo].[Faculties] ([ID], [FacultyName]) VALUES (1, N'IT')
INSERT [dbo].[Faculties] ([ID], [FacultyName]) VALUES (2, N'Design')
SET IDENTITY_INSERT [dbo].[Faculties] OFF
SET IDENTITY_INSERT [dbo].[Faculty] ON 

INSERT [dbo].[Faculty] ([ID], [MarketingManagerID], [FacultiesID], [Role], [FirstName], [LastName], [Gender], [Age], [Image], [Phone], [Email], [EmailPW], [Address], [Username], [Password]) VALUES (2, 11, 1, N'Faculty', N'Charles', N'Darwin', N'Male', 32, N'/Avatars/cat195747870.jpg', N'0123456789', N'charles@gmail.com', NULL, N'USA', N'charles_darwin', N'123')
INSERT [dbo].[Faculty] ([ID], [MarketingManagerID], [FacultiesID], [Role], [FirstName], [LastName], [Gender], [Age], [Image], [Phone], [Email], [EmailPW], [Address], [Username], [Password]) VALUES (3, 11, 1, N'Marketing Coordinator', N'Bethany', N'Curly', N'Female', 28, N'/Avatars/cat195747870.jpg', N'0123456789', N'bethanycurly@gmail.com', N'Comp1640', N'USA', N'bethany_curly', N'123')
INSERT [dbo].[Faculty] ([ID], [MarketingManagerID], [FacultiesID], [Role], [FirstName], [LastName], [Gender], [Age], [Image], [Phone], [Email], [EmailPW], [Address], [Username], [Password]) VALUES (4, 11, 2, N'Faculty', NULL, NULL, NULL, NULL, N'/Avatars/cat195747870.jpg', NULL, NULL, NULL, NULL, N'f1', N'123')
INSERT [dbo].[Faculty] ([ID], [MarketingManagerID], [FacultiesID], [Role], [FirstName], [LastName], [Gender], [Age], [Image], [Phone], [Email], [EmailPW], [Address], [Username], [Password]) VALUES (5, 11, 2, N'Marketing Coordinator', NULL, NULL, NULL, NULL, N'/Avatars/cat195747870.jpg', NULL, NULL, NULL, NULL, N'mc1', N'123')
SET IDENTITY_INSERT [dbo].[Faculty] OFF
SET IDENTITY_INSERT [dbo].[MarketingManager] ON 

INSERT [dbo].[MarketingManager] ([ID], [FirstName], [LastName], [Gender], [Age], [Image], [Phone], [Email], [Address], [Username], [Password]) VALUES (11, N'Anthony', N'Bruce', N'Male', 30, N'/Avatars/cat195747870.jpg', N'0123456789', N'anthony@gmail.com', N'USA', N'anthony_bruce', N'123')
SET IDENTITY_INSERT [dbo].[MarketingManager] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([ID], [FacultiesID], [FirstName], [LastName], [Gender], [DateOfBirth], [Image], [Phone], [Email], [Address], [Username], [Password]) VALUES (1, 1, N'Darcy', N'Embruso', N'Female', CAST(N'1991-01-01' AS Date), N'/Avatars/cat195747870.jpg', N'0123456789', N'darcyembruso@gmail.com', N'USA', N'darcy_embruso', N'123')
INSERT [dbo].[Students] ([ID], [FacultiesID], [FirstName], [LastName], [Gender], [DateOfBirth], [Image], [Phone], [Email], [Address], [Username], [Password]) VALUES (2, 1, NULL, NULL, NULL, NULL, N'/Avatars/cat195747870.jpg', NULL, NULL, NULL, N's1', N'123')
INSERT [dbo].[Students] ([ID], [FacultiesID], [FirstName], [LastName], [Gender], [DateOfBirth], [Image], [Phone], [Email], [Address], [Username], [Password]) VALUES (3, 2, NULL, NULL, NULL, NULL, N'/Avatars/cat195747870.jpg', NULL, NULL, NULL, N's2', N'123')
INSERT [dbo].[Students] ([ID], [FacultiesID], [FirstName], [LastName], [Gender], [DateOfBirth], [Image], [Phone], [Email], [Address], [Username], [Password]) VALUES (4, 2, NULL, NULL, NULL, NULL, N'/Avatars/cat195747870.jpg', NULL, NULL, NULL, N's3', N'123')
SET IDENTITY_INSERT [dbo].[Students] OFF
ALTER TABLE [dbo].[Contributions]  WITH CHECK ADD  CONSTRAINT [FK__Contribut__Stude__45F365D3] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([ID])
GO
ALTER TABLE [dbo].[Contributions] CHECK CONSTRAINT [FK__Contribut__Stude__45F365D3]
GO
ALTER TABLE [dbo].[Contributions]  WITH CHECK ADD  CONSTRAINT [FK_Contributions_Faculties] FOREIGN KEY([FID])
REFERENCES [dbo].[Faculties] ([ID])
GO
ALTER TABLE [dbo].[Contributions] CHECK CONSTRAINT [FK_Contributions_Faculties]
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteMarketingManager]    Script Date: 25-Apr-19 6:56:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetAllMarketingManager]    Script Date: 25-Apr-19 6:56:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetAllMarketingManager]
AS
SELECT * FROM MarketingManager


GO
/****** Object:  StoredProcedure [dbo].[sp_GetMarketingManagerById]    Script Date: 25-Apr-19 6:56:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetMarketingManagerById] @ID int
as
select * from MarketingManager where ID = @ID


GO
/****** Object:  StoredProcedure [dbo].[sp_PostMarketingManager]    Script Date: 25-Apr-19 6:56:40 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_PutMarketingManager]    Script Date: 25-Apr-19 6:56:40 PM ******/
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
