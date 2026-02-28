/****** Object:  Database [ECommerceDB] ******/
CREATE DATABASE [ECommerceDB]
GO
USE [ECommerceDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory] ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItems] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItems](
	[CartItemId] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CartItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[CartId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [smallint] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](64) NOT NULL,
	[Description] [nvarchar](2024) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[OrderDate] [datetime] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[Status] [nvarchar](100) NOT NULL,
	[PostalCode] [nvarchar](20) NOT NULL,
	[Country] [nvarchar](100) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[Note] [nvarchar](500) NULL,
 CONSTRAINT [PK__Order__C3905BCFA5A68296] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[CategoryId] [smallint] NOT NULL,
	[Unit] [nvarchar](50) NULL,
	[Price] [decimal](10, 2) NULL,
	[ImageUrl] [nvarchar](50) NULL,
	[DateOfManufacture] [datetime] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[SupplierId] [nvarchar](16) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierId] [nvarchar](16) NOT NULL,
	[SupplierName] [nvarchar](64) NOT NULL,
	[Email] [nvarchar](64) NOT NULL,
	[Phone] [nvarchar](16) NULL,
	[Address] [nvarchar](64) NULL,
	[Description] [nvarchar](1024) NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250917151625_AddIdentityTables', N'9.0.9')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0999F2E1-83E0-4CFF-A403-406628661D65', N'Admin', N'ADMIN', N'CFC04E5B-E123-4662-932C-F6EC5409511A')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0CAA2656-692B-4289-A32A-EFE258F7D4F4', N'User', N'USER', N'D872A647-7439-419A-9C36-E14D45CB4E1B')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'AA3472D1-7BC5-48A7-AE59-BB846FB80A69', N'Manager', N'MANAGER', N'5D5C2991-4F37-4038-A932-1436C54A79F1')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'953d40e8-1be5-42d9-a598-cc17105a1eb8', N'0999F2E1-83E0-4CFF-A403-406628661D65')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'953d40e8-1be5-42d9-a598-cc17105a1eb8', N'duckienofficial', N'DUCKIENOFFICIAL', N'duckienofficial@gmail.com', N'DUCKIENOFFICIAL@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAELF3shf+81v6vGEPZiHOSwCDQ3k5mimQNVDMKumiY9D4mL7pF60yQoaUSTyVBZIkjA==', N'E35OMAGLSTPN7EJUTM5JU37JYDZXJ4MZ', N'633d7063-0058-4e2e-8a83-341c77a51933', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'cbe59b30-f0bf-490e-8f1a-10a7a06c5234', N'lk108', N'LK108', N'b@b', N'B@B', 0, N'AQAAAAIAAYagAAAAENcH6W/1UN1tPcywX8ai0o730jwDE9AdUIyxoyBu+baMC0WrkLSzsur5yADrVxEj5g==', N'OSSDXVT3JOAOPWLOAFATBB56OLEJTLRK', N'efe3439d-b85e-4ade-a733-2ff223ab4447', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Carts] ON 
GO
INSERT [dbo].[Carts] ([CartId], [UserId]) VALUES (11, N'953d40e8-1be5-42d9-a598-cc17105a1eb8')
GO
SET IDENTITY_INSERT [dbo].[Carts] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (1000, N'Đồng hồ', N'Soft drinks, coffees, teas, beers, and ales')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (1001, N'Laptop', N'Sweet and savory sauces, relishes, spreads, and seasonings')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (1002, N'Máy ảnh', N'Desserts, candies, cake, and sweet breads')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (1003, N'Điện thoại', N'Cheeses')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (1004, N'Nước hoa', N'Breads, crackers, pasta, and cereal')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (1005, N'Trang sức', N'Prepared meats')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (1006, N'Giày', N'Dried fruit and bean curd')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (1007, N'Vali', N'Seaweed and fish')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity]) VALUES (3, 3, 1003, 1)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity]) VALUES (4, 4, 1001, 1)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity]) VALUES (5, 4, 1005, 1)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity]) VALUES (6, 5, 1008, 1)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity]) VALUES (7, 6, 1007, 1)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity]) VALUES (8, 7, 1004, 1)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity]) VALUES (9, 7, 1006, 1)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity]) VALUES (10, 8, 1001, 3)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity]) VALUES (11, 9, 1001, 3)
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [PaymentMethod], [FullName], [Address], [City], [Status], [PostalCode], [Country], [PhoneNumber], [Note]) VALUES (3, N'953d40e8-1be5-42d9-a598-cc17105a1eb8', CAST(N'2025-10-09T22:06:01.923' AS DateTime), CAST(1001.00 AS Decimal(18, 2)), N'VnPay', N'Le Kien', N'Ha Dong', N'Ha Noi', N'Paid', N'123456', N'Vietnam', N'0845057101', NULL)
GO
INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [PaymentMethod], [FullName], [Address], [City], [Status], [PostalCode], [Country], [PhoneNumber], [Note]) VALUES (4, N'953d40e8-1be5-42d9-a598-cc17105a1eb8', CAST(N'2025-10-11T22:27:40.827' AS DateTime), CAST(211.35 AS Decimal(18, 2)), N'COD', N'Le Hoang', N'Ha Dong', N'Ha Noi', N'Cancelled', N'123456', N'Vietnam', N'0845057101', NULL)
GO
INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [PaymentMethod], [FullName], [Address], [City], [Status], [PostalCode], [Country], [PhoneNumber], [Note]) VALUES (5, N'953d40e8-1be5-42d9-a598-cc17105a1eb8', CAST(N'2025-10-11T22:28:00.083' AS DateTime), CAST(40.00 AS Decimal(18, 2)), N'COD', N'Le Hoang', N'Ha Dong', N'Ha Noi', N'Pending', N'123456', N'Vietnam', N'0845057101', NULL)
GO
INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [PaymentMethod], [FullName], [Address], [City], [Status], [PostalCode], [Country], [PhoneNumber], [Note]) VALUES (6, N'953d40e8-1be5-42d9-a598-cc17105a1eb8', CAST(N'2025-10-11T22:28:55.593' AS DateTime), CAST(30.00 AS Decimal(18, 2)), N'VnPay', N'Le Hoang', N'Ha Dong', N'Ha Noi', N'Paid', N'123456', N'Vietnam', N'0845057101', NULL)
GO
INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [PaymentMethod], [FullName], [Address], [City], [Status], [PostalCode], [Country], [PhoneNumber], [Note]) VALUES (7, N'953d40e8-1be5-42d9-a598-cc17105a1eb8', CAST(N'2025-10-12T10:23:03.157' AS DateTime), CAST(47.00 AS Decimal(18, 2)), N'COD', N'Le Hoang', N'Ha Dong', N'Ha Noi', N'Paid', N'123456', N'Vietnam', N'0845057101', NULL)
GO
INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [PaymentMethod], [FullName], [Address], [City], [Status], [PostalCode], [Country], [PhoneNumber], [Note]) VALUES (8, N'953d40e8-1be5-42d9-a598-cc17105a1eb8', CAST(N'2025-10-12T20:39:46.407' AS DateTime), CAST(570.00 AS Decimal(18, 2)), N'VnPay', N'Le Hoang', N'Ha Dong', N'Ha Noi', N'Pending', N'123456', N'Vietnam', N'0845057101', NULL)
GO
INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [PaymentMethod], [FullName], [Address], [City], [Status], [PostalCode], [Country], [PhoneNumber], [Note]) VALUES (9, N'953d40e8-1be5-42d9-a598-cc17105a1eb8', CAST(N'2025-10-12T20:41:27.133' AS DateTime), CAST(570.00 AS Decimal(18, 2)), N'VnPay', N'Le Hoang', N'Ha Dong', N'Ha Noi', N'Pending', N'123456', N'Vietnam', N'0845057101', NULL)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1001, N'Aniseed Syrup 123', 1000, N'10 boxes x 20 bags', CAST(190.00 AS Decimal(10, 2)), N'41MJUdI2jdL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N' value="EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors"', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1002, N'Change', 1000, N'10 boxes x 20 bags', CAST(19.00 AS Decimal(10, 2)), N'41TexqWVkHL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1003, N'Tên mới sửa', 1001, N'12 - 550 ml bottles', CAST(1001.00 AS Decimal(10, 2)), N'31EPGSm2s1L._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1005, N'Chef Anton''s Gumbo Mix', 1001, N'36 boxes', CAST(21.35 AS Decimal(10, 2)), N'41G38jC0ajL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1006, N'Grandma''s Boysenberry Spread', 1001, N'12 - 8 oz jars', CAST(25.00 AS Decimal(10, 2)), N'41iDo0HDhbL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1008, N'Northwoods Cranberry Sauce', 1001, N'12 - 12 oz jars', CAST(40.00 AS Decimal(10, 2)), N'41LMouG6j7L._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1009, N'Mishi Kobe Niku', 1005, N'18 - 500 g pkgs.', CAST(97.00 AS Decimal(10, 2)), N'21meTyhQebL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1010, N'Ikura', 1007, N'12 - 200 ml jars', CAST(31.00 AS Decimal(10, 2)), N'31hCgES5GXL._AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1011, N'Queso Cabrales', 1003, N'1 kg pkg.', CAST(21.00 AS Decimal(10, 2)), N'31jsjfVfH9L._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1013, N'Konbu', 1007, N'2 kg box', CAST(6.00 AS Decimal(10, 2)), N'31ioCUUFnoL.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1014, N'Tofu', 1006, N'40 - 100 g pkgs.', CAST(23.25 AS Decimal(10, 2)), N'81Q1DvOnnoL._SL1500_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1015, N'Genen Shouyu', 1001, N'24 - 250 ml bottles', CAST(15.50 AS Decimal(10, 2)), N'41qlcUEhNmL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1016, N'Pavlova', 1002, N'32 - 500 g boxes', CAST(17.45 AS Decimal(10, 2)), N'41iji4-9UsL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1017, N'Alice Mutton', 1005, N'20 - 1 kg tins', CAST(39.00 AS Decimal(10, 2)), N'31LAnW1JFqL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1018, N'Carnarvon Tigers', 1007, N'16 kg pkg.', CAST(62.50 AS Decimal(10, 2)), N'31yxRemzRLL._SS350_ (1).jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1019, N'Teatime Chocolate Biscuits', 1002, N'10 boxes x 12 pieces', CAST(9.20 AS Decimal(10, 2)), N'41KALboJKuL.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1020, N'Sir Rodney''s Marmalade', 1002, N'30 gift boxes', CAST(81.00 AS Decimal(10, 2)), N'41sl3FN6NpL.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1021, N'Sir Rodney''s Scones', 1002, N'24 pkgs. x 4 pieces', CAST(10.00 AS Decimal(10, 2)), N'41w4TlVPhGL.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1022, N'Gustaf''s KnÃ¤ckebrÃ¶d', 1004, N'24 - 500 g pkgs.', CAST(21.00 AS Decimal(10, 2)), N'31pT+SdvQXL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1023, N'TunnbrÃÂ¶d', 1004, N'12 - 250 g pkgs.', CAST(9.00 AS Decimal(10, 2)), N'31YOss-gC-L._AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1024, N'GuaranÃ¡ FantÃ¡stica', 1000, N'12 - 355 ml cans', CAST(4.50 AS Decimal(10, 2)), N'41V4Ds2PtZL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1025, N'NuNuCa NuÃÂ-Nougat-Creme', 1002, N'20 - 450 g glasses', CAST(14.00 AS Decimal(10, 2)), N'41XX7Pi240L.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1026, N'GumbÃ¤r GummibÃ¤rchen', 1002, N'100 - 250 g bags', CAST(31.23 AS Decimal(10, 2)), N'41-yvkFqVZL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1027, N'Schoggi Schokolade', 1002, N'100 - 100 g pieces', CAST(43.90 AS Decimal(10, 2)), N'41ZE9SmWdzL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1028, N'RÃ¶ssle Sauerkraut', 1006, N'25 - 825 g cans', CAST(45.60 AS Decimal(10, 2)), N'91FM0Hog9FL._SL1500_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1029, N'ThÃ¼ringer Rostbratwurst', 1005, N'50 bags x 30 sausgs.', CAST(123.79 AS Decimal(10, 2)), N'31ncPnMYCxL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1030, N'Nord-Ost Matjeshering', 1007, N'10 - 200 g glasses', CAST(25.89 AS Decimal(10, 2)), N'41lffECD-sL._SY445_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1031, N'Gorgonzola Telino', 1003, N'12 - 100 g pkgs', CAST(12.50 AS Decimal(10, 2)), N'41IPLmZIKhL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1032, N'Mascarpone Fabioli', 1003, N'24 - 200 g pkgs.', CAST(32.00 AS Decimal(10, 2)), N'41qfgTvFBwL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1033, N'Geitost', 1003, N'500 g', CAST(2.50 AS Decimal(10, 2)), N'41qfgTvFBwL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SM', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1034, N'Sasquatch Ale', 1000, N'24 - 12 oz bottles', CAST(14.00 AS Decimal(10, 2)), N'41WvZnGYUkL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1035, N'Steeleye Stout', 1000, N'24 - 12 oz bottles', CAST(18.00 AS Decimal(10, 2)), N'41yh1vBmqsL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1036, N'Inlagd Sill', 1007, N'24 - 250 g  jars', CAST(19.00 AS Decimal(10, 2)), N'41sw9ASUvBL._SX342_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1037, N'Gravad lax', 1007, N'12 - 500 g pkgs.', CAST(26.00 AS Decimal(10, 2)), N'41Z43OmFHjL._SX342_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1038, N'CÃ´te de Blaye', 1000, N'12 - 75 cl bottles', CAST(263.50 AS Decimal(10, 2)), N'41Ymq8fjbOL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1039, N'Chartreuse verte', 1000, N'750 cc per bottle', CAST(18.00 AS Decimal(10, 2)), N'51GBNkHO6vL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1040, N'Boston Crab Meat', 1007, N'24 - 4 oz tins', CAST(18.40 AS Decimal(10, 2)), N'51JhyHtnEgL._SL1001_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1041, N'Jack''s New England Clam Chowder', 1007, N'12 - 12 oz cans', CAST(9.65 AS Decimal(10, 2)), N'71bJrFAys9L._SL1280_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1043, N'Ipoh Coffee', 1000, N'16 - 500 g tins', CAST(46.00 AS Decimal(10, 2)), N'51czOOat0OL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1044, N'Gula Malacca', 1001, N'20 - 2 kg bags', CAST(19.45 AS Decimal(10, 2)), N'41riQRGf-6L._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1045, N'Rogede sild', 1007, N'1k pkg.', CAST(9.50 AS Decimal(10, 2)), N'71cBwWAgvIL._SL1430_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1046, N'Spegesild', 1007, N'4 - 450 g glasses', CAST(12.00 AS Decimal(10, 2)), N'91T2BjUkYmL._SL1500_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1047, N'Zaanse koeken', 1002, N'10 - 4 oz boxes', CAST(9.50 AS Decimal(10, 2)), N'51s6pbRlNyL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1048, N'Chocolade', 1002, N'10 pkgs.', CAST(12.75 AS Decimal(10, 2)), N'91JUBDf1jTL._AA1500_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1049, N'Maxilaku', 1002, N'24 - 50 g pkgs.', CAST(20.00 AS Decimal(10, 2)), N'51w+JqOnmSL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'MO', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1050, N'Valkoinen suklaa', 1002, N'12 - 100 g bars', CAST(16.25 AS Decimal(10, 2)), N'51yomC0EodL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1051, N'Manjimup Dried Apples', 1006, N'50 - 300 g pkgs.', CAST(53.00 AS Decimal(10, 2)), N'416pdroSEkL.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1052, N'Filo Mix', 1004, N'16 - 2 kg boxes', CAST(7.00 AS Decimal(10, 2)), N'41Pg1ahql8L._AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1053, N'Perth Pasties', 1005, N'48 pieces', CAST(32.80 AS Decimal(10, 2)), N'31pAGovVENL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1054, N'TourtiÃ¨re', 1005, N'16 pies', CAST(7.45 AS Decimal(10, 2)), N'31TB6tC6BOL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1055, N'PÃ¢tÃ© chinois', 1005, N'24 boxes x 2 pies', CAST(24.00 AS Decimal(10, 2)), N'41brDHtPY9L._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1056, N'Gnocchi di nonna Alice', 1004, N'24 - 250 g pkgs.', CAST(38.00 AS Decimal(10, 2)), N'51nukXFJLJL.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1057, N'Ravioli Angelo', 1004, N'24 - 250 g pkgs.', CAST(19.50 AS Decimal(10, 2)), N'410PjzqoC8L._AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1058, N'Escargots de Bourgogne', 1007, N'24 pieces', CAST(13.25 AS Decimal(10, 2)), N'91T2BjUkYmL._SL1500_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1059, N'Raclette Courdavault', 1003, N'5 kg pkg.', CAST(55.00 AS Decimal(10, 2)), N'41sdBTtnUDL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1060, N'Camembert Pierrot', 1003, N'15 - 300 g rounds', CAST(34.00 AS Decimal(10, 2)), N'41zxxR71G+L._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1061, N'Sirop d''Ã©rable', 1001, N'24 - 500 ml bottles', CAST(28.50 AS Decimal(10, 2)), N'41RxtSQOd2L._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1062, N'Tarte au sucre', 1002, N'48 pies', CAST(49.30 AS Decimal(10, 2)), N'415cOCbeyML.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1063, N'Vegie-spread', 1001, N'15 - 625 g jars', CAST(43.90 AS Decimal(10, 2)), N'41sd2DTD8EL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1064, N'Wimmers gute SemmelknÃ¶del', 1004, N'20 bags x 4 pieces', CAST(33.25 AS Decimal(10, 2)), N'419WCoqfamL._AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1065, N'Louisiana Fiery Hot Pepper Sauce', 1001, N'32 - 8 oz bottles', CAST(21.05 AS Decimal(10, 2)), N'41wHu2N4tVL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'SS', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1066, N'Louisiana Hot Spiced Okra', 1001, N'24 - 8 oz jars', CAST(17.00 AS Decimal(10, 2)), N'416OcTXFfeL._AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1067, N'Laughing Lumberjack Lager', 1000, N'24 - 12 oz bottles', CAST(14.00 AS Decimal(10, 2)), N'51GBNkHO6vL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1068, N'Scottish Longbreads', 1002, N'10 boxes x 8 pieces', CAST(12.50 AS Decimal(10, 2)), N'Camera1.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1069, N'Gudbrandsdalsost', 1003, N'10 kg pkg.', CAST(36.00 AS Decimal(10, 2)), N'51+4d3VBFvL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1070, N'Outback Lager', 1000, N'24 - 355 ml bottles', CAST(15.00 AS Decimal(10, 2)), N'51Lj5bxbNtL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1071, N'Flotemysost', 1003, N'10 - 500 g pkgs.', CAST(21.50 AS Decimal(10, 2)), N'51l46qQB50L._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1072, N'Mozzarella di Giovanni', 1003, N'24 - 200 g pkgs.', CAST(34.80 AS Decimal(10, 2)), N'5195-l+nflL._AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1073, N'RÃ¶d Kaviar', 1007, N'24 - 150 g jars', CAST(15.00 AS Decimal(10, 2)), N'513UnnRfFML._SL1001_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1074, N'Longlife Tofu', 1006, N'5 kg pkg.', CAST(10.00 AS Decimal(10, 2)), N'816zGZv1ORL._SL1500_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1075, N'RhÃ¶nbrÃ¤u Klosterbier', 1000, N'24 - 0.5 l bottles', CAST(7.75 AS Decimal(10, 2)), N'51uJ-pWfc9L._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1076, N'LakkalikÃ¶Ã¶ri', 1000, N'500 ml', CAST(18.00 AS Decimal(10, 2)), N'51vxcBS1sQL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1077, N'Original Frankfurter grÃ¼ne SoÃe', 1001, N'12 boxes', CAST(13.00 AS Decimal(10, 2)), N'1009.gif', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1081, N'Chai88888888', 1000, N'10 boxes x 20 bags', CAST(19.00 AS Decimal(10, 2)), N'51y46IslQkL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1083, N'Mishi Kobe Niku', 1005, N'18 - 500 g pkgs.', CAST(97.00 AS Decimal(10, 2)), N'41GVLtgNngL._SL500_AA300_.jpg', CAST(N'2009-07-31T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1084, N'Change-New', 1000, N'10 boxes x 20 bags', CAST(19.00 AS Decimal(10, 2)), N'51Z9tfgl4aL._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'NK', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (1085, N'Tên mới thêm', 1001, N'12 - 550 ml bottles', CAST(1001.00 AS Decimal(10, 2)), N'31EPGSm2s1L._SL500_AA300_.jpg', CAST(N'2009-08-01T07:00:00.000' AS DateTime), N'EmEditor uses JavaScript or VBScript for its macro language, so those who are familiar with HTML or Windows scripting will be able to write macros with little difficulty. For those unfamiliar with scripting languages, EmEditor can record keystrokes, which can then be saved in a macro file that can easily be loaded in different situations. With the use of JavaScript or VBScript, you can also troubleshoot your code easily. For example, in JavaScript, you can use the following statement to troubleshoot errors', N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (2001, N'Nike', 1006, N'pair', CAST(100.00 AS Decimal(10, 2)), N'b7Ur4GJZvJGCLTAA.svg', CAST(N'2025-10-23T10:30:00.000' AS DateTime), NULL, N'AP', 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [CategoryId], [Unit], [Price], [ImageUrl], [DateOfManufacture], [Description], [SupplierId], [IsActive]) VALUES (2002, N'quần', 1004, N'cái', CAST(10.00 AS Decimal(10, 2)), NULL, CAST(N'2025-10-09T20:19:00.000' AS DateTime), NULL, N'NK', 1)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
INSERT [dbo].[Suppliers] ([SupplierId], [SupplierName], [Email], [Phone], [Address], [Description]) VALUES (N'AP', N'Apple', N'pike@yahoo.com', N'0987345876', N'765 Hello, Califonia, United States', N'Moble Device')
GO
INSERT [dbo].[Suppliers] ([SupplierId], [SupplierName], [Email], [Phone], [Address], [Description]) VALUES (N'MO', N'Motorola', N'john@gmail.com', N'0918456987', N'22 Rose, Messachuset, United States', N'Communication Company')
GO
INSERT [dbo].[Suppliers] ([SupplierId], [SupplierName], [Email], [Phone], [Address], [Description]) VALUES (N'NK', N'Nokia', N'okawa@gmail.com', N'0913745789', N'123 Revenue, Tokyo, Japan', N'Famous company')
GO
INSERT [dbo].[Suppliers] ([SupplierId], [SupplierName], [Email], [Phone], [Address], [Description]) VALUES (N'SM', N'Seamen', N'brown@gmail.com', N'0987456876', N'23 New World, Texas, United Kindom', N'Digital device company')
GO
INSERT [dbo].[Suppliers] ([SupplierId], [SupplierName], [Email], [Phone], [Address], [Description]) VALUES (N'SS', N'Samsung', N'lee@yahoo.com', N'0913745789', N'456 Romario, Seaul, Korea', N'The best company')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId] ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex] ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId] ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId] ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId] ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex] ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex] ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Cart__1788CC4D9B69D08E] ******/
ALTER TABLE [dbo].[Carts] ADD UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_CategoryId] ******/
CREATE NONCLUSTERED INDEX [IX_Product_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Product_SupplierId] ******/
CREATE NONCLUSTERED INDEX [IX_Product_SupplierId] ON [dbo].[Products]
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Order__OrderDate__662B2B3B]  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('Pending') FOR [Status]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK__CartItem__CartId__4D5F7D71] FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([CartId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK__CartItem__CartId__4D5F7D71]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK__Cart__UserId__4A8310C6] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK__Cart__UserId__4A8310C6]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__Order__69FBBC1F] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK__OrderDeta__Order__69FBBC1F]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK__Product__Categor__3A81B327] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK__Product__Categor__3A81B327]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK__Product__Supplie__3B75D760] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([SupplierId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK__Product__Supplie__3B75D760]
GO