USE [master]
GO
/****** Object:  Database [Ekka_Shopping]    Script Date: 5/15/2024 9:17:14 PM ******/
CREATE DATABASE [Ekka_Shopping]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ekka_Shopping', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Ekka_Shopping.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ekka_Shopping_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Ekka_Shopping_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Ekka_Shopping] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ekka_Shopping].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ekka_Shopping] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Ekka_Shopping] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ekka_Shopping] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ekka_Shopping] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Ekka_Shopping] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ekka_Shopping] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Ekka_Shopping] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Ekka_Shopping] SET  MULTI_USER 
GO
ALTER DATABASE [Ekka_Shopping] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ekka_Shopping] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ekka_Shopping] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ekka_Shopping] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ekka_Shopping] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Ekka_Shopping] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Ekka_Shopping] SET QUERY_STORE = ON
GO
ALTER DATABASE [Ekka_Shopping] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Ekka_Shopping]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/15/2024 9:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/15/2024 9:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Category_Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [nvarchar](max) NOT NULL,
	[Gender_id] [int] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 5/15/2024 9:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[gender_id] [int] IDENTITY(1,1) NOT NULL,
	[gender_name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[gender_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 5/15/2024 9:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[Invoice_Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_Id] [int] NULL,
	[Product_Id] [int] NULL,
	[Quantity] [int] NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[Invoice_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/15/2024 9:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Order_Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_Amount] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Order_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 5/15/2024 9:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[Amount] [int] NOT NULL,
	[PaymentDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/15/2024 9:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Pro_Id] [int] IDENTITY(1,1) NOT NULL,
	[Pro_Name] [nvarchar](max) NOT NULL,
	[Pro_Price] [decimal](10, 2) NOT NULL,
	[Pro_Description] [nvarchar](max) NOT NULL,
	[Pro_Image] [nvarchar](max) NOT NULL,
	[Subcategory_id] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Pro_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/15/2024 9:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subcategories]    Script Date: 5/15/2024 9:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subcategories](
	[subcategory_id] [int] IDENTITY(1,1) NOT NULL,
	[subcategory_name] [nvarchar](max) NOT NULL,
	[category_id] [int] NULL,
 CONSTRAINT [PK_Subcategories] PRIMARY KEY CLUSTERED 
(
	[subcategory_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/15/2024 9:17:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserFullName] [nvarchar](max) NOT NULL,
	[UserEmail] [nvarchar](max) NOT NULL,
	[UserPassword] [nvarchar](max) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240513231548_AddAllTables', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240514143021_Again', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240514182007_Latest', N'6.0.0')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Category_Id], [Category_Name], [Gender_id]) VALUES (1, N'Male Clothes', 1)
INSERT [dbo].[Categories] ([Category_Id], [Category_Name], [Gender_id]) VALUES (2, N'Female Clothes', 2)
INSERT [dbo].[Categories] ([Category_Id], [Category_Name], [Gender_id]) VALUES (3, N'Mens Footwear', 1)
INSERT [dbo].[Categories] ([Category_Id], [Category_Name], [Gender_id]) VALUES (4, N'Women Footwear', 2)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Genders] ON 

INSERT [dbo].[Genders] ([gender_id], [gender_name]) VALUES (1, N'Male')
INSERT [dbo].[Genders] ([gender_id], [gender_name]) VALUES (2, N'Female')
SET IDENTITY_INSERT [dbo].[Genders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (2, N'Blue Shirts', CAST(500.00 AS Decimal(10, 2)), N'Very Good', N'images/DatabaseImages/DressCollection\product_10.jpg', 1)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (3, N'Black TShirt', CAST(500.00 AS Decimal(10, 2)), N'Very Good', N'images/DatabaseImages/DressCollection\product_12.jpg', 1)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (4, N'Rare TShirt', CAST(800.00 AS Decimal(10, 2)), N'Very Good', N'images/DatabaseImages/DressCollection\product_7-1.jpg', 1)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (5, N'Top Coat', CAST(8200.00 AS Decimal(10, 2)), N'Good Condition', N'images/DatabaseImages/DressCollection\product-22-2.jpg', 2)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (6, N'Rare Coat', CAST(8200.00 AS Decimal(10, 2)), N'Good Condition', N'images/DatabaseImages/DressCollection\product-18-1.jpg', 2)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (7, N'Latest', CAST(8200.00 AS Decimal(10, 2)), N'Good Condition', N'images/DatabaseImages/DressCollection\product-21-1.jpg', 2)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (16, N'Latest Shirt', CAST(500.00 AS Decimal(10, 2)), N'assa', N'images/DatabaseImages/DressCollection\product_2.jpg', 1)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (17, N'Full Shirts', CAST(500.00 AS Decimal(10, 2)), N'Good', N'images/DatabaseImages/DressCollection\product_0.jpg', 1)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (18, N'Full', CAST(500.00 AS Decimal(10, 2)), N'Good', N'images/DatabaseImages/DressCollection\product-22-1.jpg', 2)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (19, N'Latest Shoes', CAST(8000.00 AS Decimal(10, 2)), N'sfasf', N'images/DatabaseImages/DressCollection\product-30-1.jpg', 3)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (20, N'Latest Shoes1', CAST(8000.00 AS Decimal(10, 2)), N'sfasf', N'images/DatabaseImages/DressCollection\product-30-1.jpg', 3)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (21, N'Latest Shoes2', CAST(8000.00 AS Decimal(10, 2)), N'sfasf', N'images/DatabaseImages/DressCollection\product-30-1.jpg', 3)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (22, N'Latest Shoes3', CAST(7000.00 AS Decimal(10, 2)), N'sfasf', N'images/DatabaseImages/DressCollection\product-30-1.jpg', 3)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (23, N'Latest Shoes4', CAST(7000.00 AS Decimal(10, 2)), N'sfasf', N'images/DatabaseImages/DressCollection\product-30-1.jpg', 3)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (24, N'Rare Shoes4', CAST(7000.00 AS Decimal(10, 2)), N'sfasf', N'images/DatabaseImages/DressCollection\product-30-1.jpg', 4)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (25, N'Rare Shoes5', CAST(7000.00 AS Decimal(10, 2)), N'sfasf', N'images/DatabaseImages/DressCollection\product-30-1.jpg', 4)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (26, N'Rare Shoes2', CAST(7000.00 AS Decimal(10, 2)), N'sfasf', N'images/DatabaseImages/DressCollection\product-30-1.jpg', 4)
INSERT [dbo].[Products] ([Pro_Id], [Pro_Name], [Pro_Price], [Pro_Description], [Pro_Image], [Subcategory_id]) VALUES (27, N'Rare Shoes1', CAST(7000.00 AS Decimal(10, 2)), N'sfasf', N'images/DatabaseImages/DressCollection\product-30-1.jpg', 4)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (3, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Subcategories] ON 

INSERT [dbo].[Subcategories] ([subcategory_id], [subcategory_name], [category_id]) VALUES (1, N'Mens Shirts', 1)
INSERT [dbo].[Subcategories] ([subcategory_id], [subcategory_name], [category_id]) VALUES (2, N'Female Dress', 2)
INSERT [dbo].[Subcategories] ([subcategory_id], [subcategory_name], [category_id]) VALUES (3, N'Mens Shoes', 3)
INSERT [dbo].[Subcategories] ([subcategory_id], [subcategory_name], [category_id]) VALUES (4, N'Womens Shoes', 4)
SET IDENTITY_INSERT [dbo].[Subcategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserFullName], [UserEmail], [UserPassword], [RoleId]) VALUES (1, N'Saad', N'saad@gmail.com', N'7c1a4a1d4b462cb7b767e6d653440877683f11b5c1b069717c1fe75b5fc605ab', 1)
INSERT [dbo].[Users] ([UserId], [UserFullName], [UserEmail], [UserPassword], [RoleId]) VALUES (1002, N'ahad', N'ahad@gmail.com', N'7c1a4a1d4b462cb7b767e6d653440877683f11b5c1b069717c1fe75b5fc605ab', 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Categories_Gender_id]    Script Date: 5/15/2024 9:17:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Categories_Gender_id] ON [dbo].[Categories]
(
	[Gender_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Invoices_OrderId]    Script Date: 5/15/2024 9:17:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Invoices_OrderId] ON [dbo].[Invoices]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Invoices_ProductId]    Script Date: 5/15/2024 9:17:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Invoices_ProductId] ON [dbo].[Invoices]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_UserId]    Script Date: 5/15/2024 9:17:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_UserId] ON [dbo].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_OrderId]    Script Date: 5/15/2024 9:17:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_OrderId] ON [dbo].[Payments]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_Subcategory_id]    Script Date: 5/15/2024 9:17:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_Subcategory_id] ON [dbo].[Products]
(
	[Subcategory_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subcategories_category_id]    Script Date: 5/15/2024 9:17:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Subcategories_category_id] ON [dbo].[Subcategories]
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 5/15/2024 9:17:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Genders_Gender_id] FOREIGN KEY([Gender_id])
REFERENCES [dbo].[Genders] ([gender_id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Genders_Gender_id]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Order_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Orders_OrderId]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Pro_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users_UserId]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Order_Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Orders_OrderId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Subcategories_Subcategory_id] FOREIGN KEY([Subcategory_id])
REFERENCES [dbo].[Subcategories] ([subcategory_id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Subcategories_Subcategory_id]
GO
ALTER TABLE [dbo].[Subcategories]  WITH CHECK ADD  CONSTRAINT [FK_Subcategories_Categories_category_id] FOREIGN KEY([category_id])
REFERENCES [dbo].[Categories] ([Category_Id])
GO
ALTER TABLE [dbo].[Subcategories] CHECK CONSTRAINT [FK_Subcategories_Categories_category_id]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [Ekka_Shopping] SET  READ_WRITE 
GO
