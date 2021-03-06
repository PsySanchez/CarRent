USE [master]
GO
/****** Object:  Database [CarRent]    Script Date: 17/03/2019 17:33:41 ******/
CREATE DATABASE [CarRent]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRent', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CarRent.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarRent_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CarRent_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CarRent] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRent].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRent] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarRent] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarRent] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarRent] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarRent] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarRent] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarRent] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRent] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRent] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRent] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarRent] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarRent] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRent] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarRent] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRent] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarRent] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRent] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRent] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRent] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRent] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRent] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRent] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRent] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarRent] SET  MULTI_USER 
GO
ALTER DATABASE [CarRent] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRent] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRent] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRent] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarRent] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarRent] SET QUERY_STORE = OFF
GO
USE [CarRent]
GO
/****** Object:  Table [dbo].[ModelsCar]    Script Date: 17/03/2019 17:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelsCar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ManufacturerId] [int] NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[PricePerDay] [money] NOT NULL,
	[Photo] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ModelsCar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManufacturersCar]    Script Date: 17/03/2019 17:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManufacturersCar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ManufacturerName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ManufacturersCar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyFleet]    Script Date: 17/03/2019 17:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyFleet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelId] [int] NOT NULL,
	[CarNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CompanyFleet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Cars]    Script Date: 17/03/2019 17:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Cars]
AS
SELECT        dbo.CompanyFleet.Id, dbo.CompanyFleet.CarNumber, dbo.ModelsCar.Model, dbo.ModelsCar.PricePerDay, dbo.ModelsCar.Photo, dbo.ManufacturersCar.ManufacturerName
FROM            dbo.CompanyFleet INNER JOIN
                         dbo.ModelsCar ON dbo.CompanyFleet.ModelId = dbo.ModelsCar.Id INNER JOIN
                         dbo.ManufacturersCar ON dbo.ModelsCar.ManufacturerId = dbo.ManufacturersCar.Id
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 17/03/2019 17:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CarId] [int] NOT NULL,
	[FromDate] [date] NOT NULL,
	[ToDate] [date] NOT NULL,
	[TotalCost] [money] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17/03/2019 17:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Telephone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UserOrders]    Script Date: 17/03/2019 17:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UserOrders]
AS
SELECT        dbo.Users.LastName, dbo.Users.FirstName, dbo.Orders.FromDate, dbo.Orders.ToDate, dbo.Orders.TotalCost, dbo.ModelsCar.Photo, dbo.ModelsCar.Model, dbo.ManufacturersCar.ManufacturerName, dbo.Orders.UserId
FROM            dbo.ModelsCar INNER JOIN
                         dbo.CompanyFleet ON dbo.ModelsCar.Id = dbo.CompanyFleet.ModelId INNER JOIN
                         dbo.ManufacturersCar ON dbo.ModelsCar.ManufacturerId = dbo.ManufacturersCar.Id INNER JOIN
                         dbo.Orders ON dbo.CompanyFleet.Id = dbo.Orders.CarId INNER JOIN
                         dbo.Users ON dbo.Orders.UserId = dbo.Users.Id
GO
/****** Object:  Table [dbo].[ContactUsMessage]    Script Date: 17/03/2019 17:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUsMessage](
	[ContactUsID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](100) NOT NULL,
	[Subject] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ContactUsMessage] PRIMARY KEY CLUSTERED 
(
	[ContactUsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CompanyFleet] ON 

INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (3, 1, N'401-23-462')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (4, 2, N'125-56-684')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (5, 3, N'652-45-63')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (7, 4, N'326-41-63')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (8, 5, N'369-54-632')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (10, 6, N'784-45-621')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (11, 7, N'142-65-789')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (12, 8, N'325-41-326')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (16, 10, N'142-63-732')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (17, 11, N'731-94-164')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (19, 12, N'942-36-462')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (25, 10, N'152-65-325')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (26, 4, N'95-634-52')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (27, 7, N'965-45-325')
INSERT [dbo].[CompanyFleet] ([Id], [ModelId], [CarNumber]) VALUES (28, 8, N'125-64-987')
SET IDENTITY_INSERT [dbo].[CompanyFleet] OFF
SET IDENTITY_INSERT [dbo].[ContactUsMessage] ON 

INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1002, N'Voronin', N'Alex', N'misha@gmail.com', N'503015629', N'test', N'service')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1003, N'alex', N'voronin', N'alex@twistech.co.il', N'0546242245', N'Test email', N'service')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1004, N'alex', N'voronin', N'alex@twistech.com', N'0539225322', N'test email', N'suggestions')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1005, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test', N'service')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1006, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test', N'service')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1007, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test', N'service')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1008, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test', N'service')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1009, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test', N'service')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1010, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test', N'service')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1011, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test', N'suggestions')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1012, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test', N'suggestions')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1013, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test', N'suggestions')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1014, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test', N'suggestions')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1015, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test', N'suggestions')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1016, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test', N'suggestions')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1017, N'Alex', N'Voronin', N'alex@twistech.co.il', N'0503015629', N'Test', N'suggestions')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1018, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test', N'suggestions')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1019, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'test', N'service')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1020, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'test', N'suggestions')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1021, N'Alex', N'Voronin', N'alex@twistech.co.il', N'503015629', N'Test 2019', N'service')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1022, N'Test', N'Test', N'alex@twistech.com', N'0546242245', N'test 17.17 17/03/2019', N'suggestions')
INSERT [dbo].[ContactUsMessage] ([ContactUsID], [FirstName], [LastName], [Email], [Phone], [Message], [Subject]) VALUES (1023, N'Test', N'Test', N'alex@twistech.com', N'0546242245', N'test 17.17 17/03/2019', N'suggestions')
SET IDENTITY_INSERT [dbo].[ContactUsMessage] OFF
SET IDENTITY_INSERT [dbo].[ManufacturersCar] ON 

INSERT [dbo].[ManufacturersCar] ([Id], [ManufacturerName]) VALUES (1, N'Honda')
INSERT [dbo].[ManufacturersCar] ([Id], [ManufacturerName]) VALUES (2, N'Hyundai')
INSERT [dbo].[ManufacturersCar] ([Id], [ManufacturerName]) VALUES (3, N'Chevrolet')
INSERT [dbo].[ManufacturersCar] ([Id], [ManufacturerName]) VALUES (4, N'Volkswagen')
INSERT [dbo].[ManufacturersCar] ([Id], [ManufacturerName]) VALUES (5, N'Mazda')
SET IDENTITY_INSERT [dbo].[ManufacturersCar] OFF
SET IDENTITY_INSERT [dbo].[ModelsCar] ON 

INSERT [dbo].[ModelsCar] ([Id], [ManufacturerId], [Model], [PricePerDay], [Photo]) VALUES (1, 1, N'Civic', 30.0000, N'hondaCivic.png')
INSERT [dbo].[ModelsCar] ([Id], [ManufacturerId], [Model], [PricePerDay], [Photo]) VALUES (2, 1, N'Accord', 40.0000, N'hondaAccord.png')
INSERT [dbo].[ModelsCar] ([Id], [ManufacturerId], [Model], [PricePerDay], [Photo]) VALUES (3, 2, N'i25', 25.0000, N'hyundaiI25.png')
INSERT [dbo].[ModelsCar] ([Id], [ManufacturerId], [Model], [PricePerDay], [Photo]) VALUES (4, 2, N'IONIQ', 35.0000, N'hyundaiIoniq.png')
INSERT [dbo].[ModelsCar] ([Id], [ManufacturerId], [Model], [PricePerDay], [Photo]) VALUES (5, 2, N'i30', 30.0000, N'hyundaiI30.png')
INSERT [dbo].[ModelsCar] ([Id], [ManufacturerId], [Model], [PricePerDay], [Photo]) VALUES (6, 2, N'i20', 25.0000, N'hyundaiI20.png')
INSERT [dbo].[ModelsCar] ([Id], [ManufacturerId], [Model], [PricePerDay], [Photo]) VALUES (7, 2, N'i10', 20.0000, N'hyundaiI10.png')
INSERT [dbo].[ModelsCar] ([Id], [ManufacturerId], [Model], [PricePerDay], [Photo]) VALUES (8, 3, N'Spark', 20.0000, N'chevroletSpark.png')
INSERT [dbo].[ModelsCar] ([Id], [ManufacturerId], [Model], [PricePerDay], [Photo]) VALUES (10, 3, N'Trax', 40.0000, N'chevroletTrax.png')
INSERT [dbo].[ModelsCar] ([Id], [ManufacturerId], [Model], [PricePerDay], [Photo]) VALUES (11, 4, N'Passat', 35.0000, N'volkswagenPassat.png')
INSERT [dbo].[ModelsCar] ([Id], [ManufacturerId], [Model], [PricePerDay], [Photo]) VALUES (12, 5, N'3', 30.0000, N'mazda3.png')
SET IDENTITY_INSERT [dbo].[ModelsCar] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [UserId], [CarId], [FromDate], [ToDate], [TotalCost]) VALUES (1043, 3, 7, CAST(N'2019-03-31' AS Date), CAST(N'2019-04-01' AS Date), 35.0000)
INSERT [dbo].[Orders] ([Id], [UserId], [CarId], [FromDate], [ToDate], [TotalCost]) VALUES (1044, 3, 19, CAST(N'2019-03-31' AS Date), CAST(N'2019-04-02' AS Date), 60.0000)
INSERT [dbo].[Orders] ([Id], [UserId], [CarId], [FromDate], [ToDate], [TotalCost]) VALUES (1045, 3, 3, CAST(N'2019-03-28' AS Date), CAST(N'2019-03-29' AS Date), 0.0000)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [UserName], [Password], [Telephone], [Email], [DateOfBirth], [Role]) VALUES (3, N'Alex', N'Voronin', N'admin', N'admin', N'12345', N'alex.varonin@gmail.com                            ', CAST(N'1900-01-01' AS Date), N'admin')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [UserName], [Password], [Telephone], [Email], [DateOfBirth], [Role]) VALUES (9, N'barny', N'voronin', N'barny', N'123456', N'+97250301562', N'barny@gmail.com', CAST(N'2001-03-09' AS Date), N'user')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[CompanyFleet]  WITH CHECK ADD  CONSTRAINT [FK_CompanyFleet_ModelsCar] FOREIGN KEY([ModelId])
REFERENCES [dbo].[ModelsCar] ([Id])
GO
ALTER TABLE [dbo].[CompanyFleet] CHECK CONSTRAINT [FK_CompanyFleet_ModelsCar]
GO
ALTER TABLE [dbo].[ModelsCar]  WITH CHECK ADD  CONSTRAINT [FK_ModelsCar_ManufacturersCar] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[ManufacturersCar] ([Id])
GO
ALTER TABLE [dbo].[ModelsCar] CHECK CONSTRAINT [FK_ModelsCar_ManufacturersCar]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_CompanyFleet] FOREIGN KEY([CarId])
REFERENCES [dbo].[CompanyFleet] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_CompanyFleet]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
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
         Begin Table = "CompanyFleet"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ModelsCar"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 417
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "ManufacturersCar"
            Begin Extent = 
               Top = 6
               Left = 455
               Bottom = 102
               Right = 648
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Cars'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Cars'
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
         Begin Table = "CompanyFleet"
            Begin Extent = 
               Top = 39
               Left = 467
               Bottom = 152
               Right = 637
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ModelsCar"
            Begin Extent = 
               Top = 28
               Left = 710
               Bottom = 189
               Right = 881
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ManufacturersCar"
            Begin Extent = 
               Top = 12
               Left = 942
               Bottom = 118
               Right = 1135
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Users"
            Begin Extent = 
               Top = 7
               Left = 18
               Bottom = 242
               Right = 188
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Orders"
            Begin Extent = 
               Top = 23
               Left = 241
               Bottom = 199
               Right = 411
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
      Begin ColumnWidths = 12
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UserOrders'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1770
         Output = 945
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UserOrders'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UserOrders'
GO
USE [master]
GO
ALTER DATABASE [CarRent] SET  READ_WRITE 
GO
