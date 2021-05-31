USE [master]
GO
CREATE DATABASE [Inventory]
GO
ALTER DATABASE [Inventory] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Inventory].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Inventory] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Inventory] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Inventory] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Inventory] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Inventory] SET ARITHABORT OFF 
GO
ALTER DATABASE [Inventory] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Inventory] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Inventory] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Inventory] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Inventory] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Inventory] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Inventory] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Inventory] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Inventory] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Inventory] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Inventory] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Inventory] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Inventory] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Inventory] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Inventory] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Inventory] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Inventory] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Inventory] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Inventory] SET  MULTI_USER 
GO
ALTER DATABASE [Inventory] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Inventory] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Inventory] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Inventory] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Inventory] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Inventory] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Inventory', N'ON'
GO
ALTER DATABASE [Inventory] SET QUERY_STORE = OFF
GO
USE [Inventory]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 5/2/2021 12:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nama] [nvarchar](max) NOT NULL,
	[Jumlah] [int] NOT NULL,
	[Harga] [float] NOT NULL,
 CONSTRAINT [PK_Inventory_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/2/2021 12:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer] [nvarchar](max) NOT NULL,
	[InventoryId] [int] NULL,
	[TotalAmount] [int] NOT NULL,
	[TotalPrice] [float] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 5/2/2021 12:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[InventoryId] [int] NOT NULL,
	[TotalAmount] [int] NOT NULL,
 CONSTRAINT [Purchase_Pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 5/2/2021 12:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nama] [nvarchar](max) NOT NULL,
	[Alamat] [nvarchar](max) NULL,
	[Kontak] [nvarchar](max) NULL,
 CONSTRAINT [Supplier_Pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/2/2021 12:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nama] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [User_Pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Inventory] ON 
GO
INSERT [dbo].[Inventory] ([Id], [Nama], [Jumlah], [Harga]) VALUES (1, N'OBH', 0, 6000)
GO
INSERT [dbo].[Inventory] ([Id], [Nama], [Jumlah], [Harga]) VALUES (2, N'Polonium', 0, 6000)
GO
INSERT [dbo].[Inventory] ([Id], [Nama], [Jumlah], [Harga]) VALUES (4, N'Milkuat', 0, 5000)
GO
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([Id], [Customer], [InventoryId], [TotalAmount], [TotalPrice]) VALUES (1, N'Prabowo S', 1, 100, NULL)
GO
INSERT [dbo].[Orders] ([Id], [Customer], [InventoryId], [TotalAmount], [TotalPrice]) VALUES (2, N'Puskesmas Baloi', 2, 100, NULL)
GO
INSERT [dbo].[Orders] ([Id], [Customer], [InventoryId], [TotalAmount], [TotalPrice]) VALUES (7, N'Frangky', 4, 12, NULL)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Purchase] ON 
GO
INSERT [dbo].[Purchase] ([Id], [SupplierId], [InventoryId], [TotalAmount]) VALUES (6, 5, 2, 50)
GO
INSERT [dbo].[Purchase] ([Id], [SupplierId], [InventoryId], [TotalAmount]) VALUES (7, 7, 4, 100)
GO
INSERT [dbo].[Purchase] ([Id], [SupplierId], [InventoryId], [TotalAmount]) VALUES (8, 5, 1, 9000)
GO
INSERT [dbo].[Purchase] ([Id], [SupplierId], [InventoryId], [TotalAmount]) VALUES (9, 5, 4, 9000)
GO
INSERT [dbo].[Purchase] ([Id], [SupplierId], [InventoryId], [TotalAmount]) VALUES (10, 6, 2, 400)
GO
SET IDENTITY_INSERT [dbo].[Purchase] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 
GO
INSERT [dbo].[Supplier] ([Id], [Nama], [Alamat], [Kontak]) VALUES (5, N'PT Indo Sukses Jaya', N'Jl Karangetang', N'088449')
GO
INSERT [dbo].[Supplier] ([Id], [Nama], [Alamat], [Kontak]) VALUES (6, N'PT IndiaFood', N'Jl Mumbai', N'08849123')
GO
INSERT [dbo].[Supplier] ([Id], [Nama], [Alamat], [Kontak]) VALUES (7, N'PT Dolphin Foods', N'Jl Bung Karno No 66', N'848641515')
GO
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Nama], [Password]) VALUES (1, N'admin', N'123456')
GO
INSERT [dbo].[Users] ([Id], [Nama], [Password]) VALUES (5, N'user', N'123654')
GO
INSERT [dbo].[Users] ([Id], [Nama], [Password]) VALUES (6, N'user 1', N'111111')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([InventoryId])
REFERENCES [dbo].[Inventory] ([Id])
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[GetInventory]    Script Date: 5/2/2021 12:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInventory]
AS
SELECT   Inventory.Id AS 'Id',
         Inventory.Nama AS 'Nama',
         SUM(ISNULL(Purchase.TotalAmount, 0)) - SUM(ISNULL(Orders.TotalAmount, 0)) AS 'Jumlah',
         Inventory.Harga AS 'Harga'
FROM     Inventory
         LEFT OUTER JOIN
         Orders
         ON Orders.InventoryId = Inventory.Id
         LEFT OUTER JOIN
         Purchase
         ON Purchase.InventoryId = Inventory.Id
GROUP BY Inventory.Id, Inventory.Nama, Inventory.Harga;

GO
/****** Object:  StoredProcedure [dbo].[GetOrders]    Script Date: 5/2/2021 12:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrders]
AS
SELECT Orders.Id AS 'Id',
       Orders.Customer,
       Orders.InventoryId,
       Orders.TotalAmount,
       Orders.TotalAmount * Inventory.Harga AS 'TotalPrice',
       Inventory.Nama AS 'NamaInventory'
FROM   Orders
       LEFT OUTER JOIN
       Inventory
       ON Inventory.Id = Orders.InventoryId;

GO
/****** Object:  StoredProcedure [dbo].[GetPurchase]    Script Date: 5/2/2021 12:02:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPurchase]
AS
SELECT   Purchase.Id AS 'Id',
         Supplier.Nama  AS 'Nama Supplier',
		 Inventory.Nama  AS 'Nama Barang',
         Purchase.TotalAmount AS 'Jumlah',
         Purchase.TotalAmount * Inventory.Harga AS'Harga'
FROM     Supplier
         INNER JOIN
         Purchase
         ON Purchase.SupplierId = Supplier.Id
         INNER JOIN
         Inventory
         ON Purchase.InventoryId = Inventory.Id
GROUP BY Purchase.Id, Supplier.Nama, Inventory.Nama, Purchase.TotalAmount, Inventory.Harga;


GO
USE [master]
GO
ALTER DATABASE [Inventory] SET  READ_WRITE 
GO
