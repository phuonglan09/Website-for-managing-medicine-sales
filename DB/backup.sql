USE [master]
GO
/****** Object:  Database [DoctorskinCore]    Script Date: 11/30/2023 3:22:39 PM ******/
CREATE DATABASE [DoctorskinCore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DoctorskinCore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\DoctorskinCore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DoctorskinCore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\DoctorskinCore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DoctorskinCore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DoctorskinCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DoctorskinCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DoctorskinCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DoctorskinCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DoctorskinCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DoctorskinCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [DoctorskinCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DoctorskinCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DoctorskinCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DoctorskinCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DoctorskinCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DoctorskinCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DoctorskinCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DoctorskinCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DoctorskinCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DoctorskinCore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DoctorskinCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DoctorskinCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DoctorskinCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DoctorskinCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DoctorskinCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DoctorskinCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DoctorskinCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DoctorskinCore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DoctorskinCore] SET  MULTI_USER 
GO
ALTER DATABASE [DoctorskinCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DoctorskinCore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DoctorskinCore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DoctorskinCore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DoctorskinCore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DoctorskinCore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DoctorskinCore] SET QUERY_STORE = OFF
GO
USE [DoctorskinCore]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](500) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[RoleGroupId] [int] NULL,
	[Username] [nvarchar](500) NULL,
	[Password] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banners]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Homepage] [bit] NULL,
	[Servicepage] [bit] NULL,
	[Blogpage] [bit] NULL,
	[Productpage] [bit] NULL,
 CONSTRAINT [PK_Banners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogDetails]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Shortcontent] [nvarchar](max) NULL,
	[Cardimg] [nvarchar](max) NULL,
	[Hideblog] [bit] NULL,
	[BlogTypeId] [int] NOT NULL,
	[DateUp] [datetime] NULL,
	[Contentblog] [nvarchar](max) NULL,
 CONSTRAINT [PK_BlogDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogTypes]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Namebt] [nvarchar](max) NOT NULL,
	[Hide] [bit] NOT NULL,
 CONSTRAINT [PK_BlogTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Require] [nvarchar](max) NULL,
	[Timebooking] [datetime] NULL,
	[Completed] [bit] NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Namebrand] [nvarchar](max) NULL,
	[Hidebrand] [bit] NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[iduser] [int] NULL,
	[idp] [int] NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Namec] [nvarchar](max) NULL,
	[Hide] [bit] NULL,
	[DateUp] [datetime] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Namedoc] [nvarchar](max) NULL,
	[Infordoc] [nvarchar](max) NULL,
	[AvaDoc] [nvarchar](max) NULL,
	[HideDoc] [bit] NULL,
	[DateUpDoc] [datetime] NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[Id] [int] NULL,
	[ModuleName] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderCode] [nvarchar](50) NULL,
	[UserId] [int] NULL,
	[OrderDate] [datetime] NULL,
	[TotalAmount] [decimal](18, 0) NULL,
	[Status] [int] NULL,
	[Userfb] [bit] NULL,
	[PhoneAddress] [nvarchar](500) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[UnitPrice] [decimal](18, 0) NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Namep] [nvarchar](max) NULL,
	[CateId] [int] NULL,
	[Newprice] [decimal](18, 0) NOT NULL,
	[Oldprice] [decimal](18, 0) NOT NULL,
	[Descr] [nvarchar](max) NOT NULL,
	[Hide] [bit] NOT NULL,
	[Statep] [nvarchar](max) NOT NULL,
	[Img] [nvarchar](max) NULL,
	[DateUp] [datetime] NULL,
	[Idbrand] [int] NULL,
	[Avilability] [nvarchar](max) NULL,
	[Rated] [nvarchar](max) NULL,
	[Listimg] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleGroupId] [int] NULL,
	[ModuleId] [int] NULL,
	[Add] [bit] NULL,
	[Edit] [bit] NULL,
	[Delete] [bit] NULL,
	[View] [bit] NULL,
	[Confirm] [bit] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleGroup]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_Role_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameDt] [nvarchar](max) NULL,
	[DescDt] [nvarchar](max) NULL,
	[HideDt] [bit] NULL,
	[ImgDt] [nvarchar](max) NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicesDetails]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicesDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameSd] [nvarchar](max) NULL,
	[ImgSd] [nvarchar](max) NULL,
	[HideSd] [bit] NULL,
	[PriceSd] [decimal](18, 0) NULL,
	[IdDt] [int] NULL,
	[DescDe] [nvarchar](max) NULL,
	[Amount] [int] NULL,
 CONSTRAINT [PK_ServicesDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Birth] [datetime] NULL,
	[Gender] [nvarchar](10) NULL,
	[Phone] [nvarchar](10) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Hide] [bit] NULL,
	[Ava] [nvarchar](max) NULL,
	[dateregist] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([Id], [FullName], [Phone], [Address], [RoleGroupId], [Username], [Password], [IsActive]) VALUES (1, N'Duy', N'0842002639', N'12 7A Xã Bình Hưng Huyện Bình Cánh ', 1, N'duy', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 1)
INSERT [dbo].[Admin] ([Id], [FullName], [Phone], [Address], [RoleGroupId], [Username], [Password], [IsActive]) VALUES (2, N'admin', N'0997752127', N'30 Đặng Thùy Trâm', 1, N'admin', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 1)
INSERT [dbo].[Admin] ([Id], [FullName], [Phone], [Address], [RoleGroupId], [Username], [Password], [IsActive]) VALUES (3, N'Lan', N'12345', N'asda', 2, N'lan', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 1)
INSERT [dbo].[Admin] ([Id], [FullName], [Phone], [Address], [RoleGroupId], [Username], [Password], [IsActive]) VALUES (4, N'duy', N'1234', N'12313', 1, N'linh', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 1)
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Banners] ON 

INSERT [dbo].[Banners] ([Id], [Image], [Homepage], [Servicepage], [Blogpage], [Productpage]) VALUES (3, N'231130\20231130_BANNER-BS-KHAM-1-scaled[2].png', 1, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Banners] OFF
GO
SET IDENTITY_INSERT [dbo].[BlogDetails] ON 

INSERT [dbo].[BlogDetails] ([Id], [Title], [Shortcontent], [Cardimg], [Hideblog], [BlogTypeId], [DateUp], [Contentblog]) VALUES (1, N'5 bệnh dễ để lại sẹo trên da có thể phòng ngừa nhờ vaccine', N'Thủy đậu, zona, HPV, sởi, rubella dễ gây sẹo ảnh hưởng thẩm mỹ, có thể phòng ngừa nhờ vaccine. ', N'231130\20231130_tre-tiem-vaccine-tai-vnvc-phon-1643-6252-1700819533[1].jpg', 0, 3, CAST(N'2023-03-11T09:16:00.000' AS DateTime), N'<h1>5 bệnh dễ để lại sẹo tr&ecirc;n da c&oacute; thể ph&ograve;ng ngừa nhờ vaccine</h1>

<p>Thủy đậu, zona, HPV, sởi, rubella dễ g&acirc;y sẹo ảnh hưởng thẩm mỹ, c&oacute; thể ph&ograve;ng ngừa nhờ vaccine.</p>

<article>
<p>B&aacute;c sĩ Bạch Thị Ch&iacute;nh, Gi&aacute;m đốc Y khoa Hệ thống ti&ecirc;m chủng VNVC cho biết khi nhắc đến chăm s&oacute;c da, người d&acirc;n thường nghĩ tới mỹ phẩm hoặc c&aacute;c sản phẩm d&agrave;nh cho bệnh da liễu. Tuy nhi&ecirc;n, thủy đậu, zona, sởi... cũng c&oacute; thể g&acirc;y tổn thương da, để lại sẹo. B&ecirc;n cạnh đ&oacute;, trời lạnh, nhiệt độ giảm, độ ẩm kh&ocirc;ng kh&iacute; thấp khiến nước bốc hơi khỏi da nhanh hơn, l&agrave;m trầm trọng th&ecirc;m t&igrave;nh trạng tổn thương v&agrave; tăng nguy cơ biến chứng, ảnh hưởng thẩm mỹ. Ti&ecirc;m vaccine l&agrave; biện ph&aacute;p đơn giản, hiệu quả, dễ thực hiện để ph&ograve;ng bệnh v&agrave; biến chứng.</p>

<p><strong>Thủy đậu</strong></p>

<p>Một số người cho rằng thủy đậu chỉ l&agrave; bệnh l&agrave;nh t&iacute;nh, hậu quả chỉ dừng lại ở c&aacute;c nốt mụn nước nổi v&agrave;i ng&agrave;y tr&ecirc;n da. Tuy nhi&ecirc;n, bệnh c&oacute; thể biến chứng nhiễm tr&ugrave;ng da, nhiễm tr&ugrave;ng huyết, vi&ecirc;m thanh quản... nếu kh&ocirc;ng được chăm s&oacute;c, điều trị đ&uacute;ng.</p>

<p>Trường hợp kh&ocirc;ng c&oacute; biến chứng, bệnh thường khỏi sau 7-10 ng&agrave;y. C&aacute;c vết mụn nước sẽ kh&ocirc; dần, bong vảy, xuất hiện vết th&acirc;m nơi nổi mụn nước, tự khỏi sau 3-6 th&aacute;ng t&ugrave;y v&agrave;o cơ địa mỗi người. Nếu dưới 15 tuổi, qu&aacute; tr&igrave;nh t&aacute;i tạo da rất tốt n&ecirc;n hiếm khi để lại sẹo. C&ograve;n người tr&ecirc;n 15 tuổi c&oacute; qu&aacute; tr&igrave;nh t&aacute;i tạo da chậm hơn.</p>

<p>Do đ&oacute;, vaccine gi&uacute;p ngừa thủy đậu đồng thời giảm c&aacute;c biến chứng, giảm tổn thương da, hiệu quả 88-98%. Nghi&ecirc;n cứu năm 2104 của Heywood v&agrave; cộng sự (Australia) cho thấy, chủng ngừa gi&uacute;p tiết kiệm hơn một nửa chi ph&iacute; điều trị, chăm s&oacute;c y tế (339,54 đ&ocirc; la so với 775,64 đ&ocirc; la) đồng thời tăng số năm chất lượng sống so với kh&ocirc;ng ti&ecirc;m chủng.</p>
</article>
')
INSERT [dbo].[BlogDetails] ([Id], [Title], [Shortcontent], [Cardimg], [Hideblog], [BlogTypeId], [DateUp], [Contentblog]) VALUES (2, N'Mẹo giảm nếp nhăn vùng cổ', N'Thường xuyên thoa kem chống nắng, hạn chế cúi đầu khi ngồi, giảm căng thẳng và chăm sóc vùng da cổ hạn chế nếp nhăn hình thành. ', N'231130\20231130_portrait-beautiful-young-asian-5852-2785-1700706644[1].jpg', 0, 2, CAST(N'2023-11-25T16:19:37.827' AS DateTime), N'<p>Thường xuy&ecirc;n thoa kem chống nắng, hạn chế c&uacute;i đầu khi ngồi, giảm căng thẳng v&agrave; chăm s&oacute;c v&ugrave;ng da cổ hạn chế nếp nhăn h&igrave;nh th&agrave;nh.</p>

<article>
<p>Ngo&agrave;i tuổi t&aacute;c, nếp nhăn ở cổ c&ograve;n phụ thuộc v&agrave;o nhiều yếu tố như di truyền, t&aacute;c hại của &aacute;nh nắng mặt trời, căng thẳng hoặc kh&ocirc;ng chăm s&oacute;c đ&uacute;ng c&aacute;ch. Dưới đ&acirc;y l&agrave; c&aacute;ch giảm nếp nhăn v&agrave; ngăn ch&uacute;ng xuất hiện lại nhiều hơn.</p>

<p><strong>Thoa kem chống nắng</strong></p>

<p>Tiếp x&uacute;c với &aacute;nh nắng mặt trời l&agrave; t&aacute;c nh&acirc;n thường gặp g&acirc;y l&atilde;o h&oacute;a da. Thoa kem chống nắng ở cổ c&oacute; thể bảo vệ l&agrave;n da mỏng manh khỏi c&aacute;c tia UV c&oacute; hại. Ngo&agrave;i ra, đội mũ v&agrave; mang khăn qu&agrave;ng cổ giảm t&aacute;c hại của &aacute;nh nắng mặt trời.</p>

<p><strong>Ngồi đ&uacute;ng tư thế</strong></p>

<p>Th&oacute;i quen c&uacute;i đầu khi d&ugrave;ng điện thoại hoặc m&aacute;y t&iacute;nh dễ dẫn đến đau mỏi vai g&aacute;y, lưng v&agrave; g&oacute;p phần tạo c&aacute;c nếp gấp ở cổ theo thời gian. Để ngăn ngừa, mỗi người n&ecirc;n đặt điện thoại ngang tầm mắt. Khi ngồi l&agrave;m việc, giữ đầu v&agrave; lưng th&agrave;nh một đường thẳng, tr&aacute;nh c&uacute;i đầu.</p>

<p><strong>Tẩy tế b&agrave;o chết</strong></p>

<p>V&ugrave;ng da quanh cổ v&agrave; ngực rất nhạy cảm. V&ugrave;ng da n&agrave;y kh&ocirc;ng được tẩy tế b&agrave;o chết c&oacute; thể t&iacute;ch tụ tế b&agrave;o chết, l&agrave;m tắc nghẽn lỗ ch&acirc;n l&ocirc;ng. N&ecirc;n tẩy tế b&agrave;o chết cho da cổ &iacute;t nhất một lần mỗi tuần, hạn chế sử dụng c&aacute;c th&agrave;nh phần mạnh v&igrave; dễ g&acirc;y mẩn đỏ.</p>

<p>Thoa kem dưỡng ẩm d&agrave;nh cho v&ugrave;ng da cổ gi&uacute;p cấp ẩm, ngăn ngừa c&aacute;c nếp nhăn h&igrave;nh th&agrave;nh trong tương lai.</p>
</article>
')
INSERT [dbo].[BlogDetails] ([Id], [Title], [Shortcontent], [Cardimg], [Hideblog], [BlogTypeId], [DateUp], [Contentblog]) VALUES (3, N'Có nên tự peel da trị mụn trứng cá?', N'Em 16 tuổi, mọc nhiều mụn trứng cá ở hai má, trán và cằm. Peel da làm sạch mụn, da đẹp nhanh lại rẻ, em có nên mua thuốc thực hiện ở nhà không? (Minh An, Long An) ', N'231130\20231130_cosmetologist-cleaning-face-wo-3107-2313-1700621637[1].jpg', 0, 3, CAST(N'2023-11-30T11:28:31.170' AS DateTime), N'<p>Em 16 tuổi, mọc nhiều mụn trứng c&aacute; ở hai m&aacute;, tr&aacute;n v&agrave; cằm. Peel da l&agrave;m sạch mụn, da đẹp nhanh lại rẻ, em c&oacute; n&ecirc;n mua thuốc thực hiện ở nh&agrave; kh&ocirc;ng? (Minh An, Long An)</p>

<article>
<p><strong>Trả lời:</strong></p>

<p>Nổi mụn trứng c&aacute; ở tuổi dậy th&igrave; rất thường gặp, do thay đổi nội tiết tố trong cơ thể hoặc chăm s&oacute;c da chưa ph&ugrave; hợp. Th&oacute;i quen thức khuya, lo &acirc;u, căng thẳng, chế độ ăn nhiều chất ngọt, b&eacute;o... l&agrave;m mụn nặng hơn.</p>

<p>Mụn trứng c&aacute; c&oacute; rất nhiều phương ph&aacute;p điều trị. Peel da (t&aacute;i tạo da bằng h&oacute;a chất) kh&ocirc;ng phải l&agrave; phương ph&aacute;p điều trị duy nhất hay hiệu quả nhất. Với những trường hợp nhẹ, sử dụng thuốc thoa v&agrave; điều chỉnh c&aacute;c bước l&agrave;m sạch, chăm s&oacute;c da cơ bản gi&uacute;p kiểm so&aacute;t tốt mụn trứng c&aacute;.</p>

<p>Peel da l&agrave; phương ph&aacute;p sử dụng c&aacute;c chất h&oacute;a học với nồng độ kh&aacute;c nhau để l&agrave;m đứt g&atilde;y li&ecirc;n kết giữa c&aacute;c tế b&agrave;o sừng n&ocirc;ng, s&acirc;u. Kết hợp c&aacute;c th&agrave;nh phần c&oacute; hoạt t&iacute;nh kh&aacute;ng vi&ecirc;m, trắng s&aacute;ng, chống oxy h&oacute;a... n&ecirc;n peel c&oacute; t&aacute;c dụng loại bỏ tế b&agrave;o chết, giảm sừng h&oacute;a nang l&ocirc;ng, giảm tiết b&atilde; nhờn, th&uacute;c đẩy qu&aacute; tr&igrave;nh thay da v&agrave; t&aacute;i tạo da mới, trắng s&aacute;ng hơn. Từ đ&oacute; hỗ trợ điều trị c&aacute;c vấn đề thẩm mỹ da như mụn trứng c&aacute;, sắc tố (th&acirc;m, n&aacute;m, t&agrave;n nhang), trị sẹo, trẻ h&oacute;a, thu nhỏ lỗ ch&acirc;n l&ocirc;ng.</p>

<p>Tuy nhi&ecirc;n, kh&ocirc;ng phải loại da n&agrave;o cũng c&oacute; thể peel được m&agrave; phải t&ugrave;y v&agrave;o t&igrave;nh trạng, t&iacute;nh chất của da ở từng thời điểm. Nếu da dị ứng, nhiễm tr&ugrave;ng, nhiễm nấm hoặc mụn trứng c&aacute; nặng, qu&aacute; nhạy cảm... th&igrave; kh&ocirc;ng n&ecirc;n thực hiện phương ph&aacute;p n&agrave;y ngay.</p>

<p>Sản phẩm peel da c&oacute; nhiều loại, chứa c&aacute;c hoạt chất kh&aacute;c nhau, phục vụ mục đ&iacute;ch t&aacute;i tạo da ở c&aacute;c mức độ kh&aacute;c nhau, như peel n&ocirc;ng, trung b&igrave;nh v&agrave; s&acirc;u. Hơn nữa, kh&ocirc;ng phải sản phẩm n&agrave;o tr&ecirc;n thị trường hiện nay cũng c&oacute; nguồn gốc xuất xứ r&otilde; r&agrave;ng v&agrave; được chứng minh về chất lượng sản phẩm, th&agrave;nh phần, đảm bảo nồng độ c&aacute;c chất trong ngưỡng an to&agrave;n.</p>
</article>
')
SET IDENTITY_INSERT [dbo].[BlogDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[BlogTypes] ON 

INSERT [dbo].[BlogTypes] ([Id], [Namebt], [Hide]) VALUES (1, N'Blog trị mụn', 0)
INSERT [dbo].[BlogTypes] ([Id], [Namebt], [Hide]) VALUES (2, N'Blog trị sẹo', 0)
INSERT [dbo].[BlogTypes] ([Id], [Namebt], [Hide]) VALUES (3, N'Blog tin tức', 0)
SET IDENTITY_INSERT [dbo].[BlogTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [Namebrand], [Hidebrand]) VALUES (1, N'Nội địa', 0)
INSERT [dbo].[Brands] ([Id], [Namebrand], [Hidebrand]) VALUES (2, N'Obagi', 0)
INSERT [dbo].[Brands] ([Id], [Namebrand], [Hidebrand]) VALUES (3, N'Balance', 0)
INSERT [dbo].[Brands] ([Id], [Namebrand], [Hidebrand]) VALUES (4, N'Klairs', 0)
INSERT [dbo].[Brands] ([Id], [Namebrand], [Hidebrand]) VALUES (5, N'L''Oréa', 0)
INSERT [dbo].[Brands] ([Id], [Namebrand], [Hidebrand]) VALUES (6, N'3M', 0)
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Carts] ON 

INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (1, 5, 10, 1)
INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (2, 5, 9, 1)
INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (3, 5, 10, 1)
INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (4, 5, 9, 1)
INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (5, 5, 10, 1)
INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (6, 5, 9, 1)
INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (7, 6, 10, 1)
INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (8, 6, 9, 2)
INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (9, 7, 31, 2)
INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (10, 7, 32, 2)
INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (11, 7, 30, 2)
INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (12, 8, 23, 1)
INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (13, 8, 20, 1)
INSERT [dbo].[Carts] ([Id], [iduser], [idp], [quantity]) VALUES (14, 8, 14, 1)
SET IDENTITY_INSERT [dbo].[Carts] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Namec], [Hide], [DateUp]) VALUES (1, N'Kem dưỡng ẩm', 1, CAST(N'2023-02-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Categories] ([Id], [Namec], [Hide], [DateUp]) VALUES (2, N'Thiết bị y tế', 0, CAST(N'2023-11-25T13:43:28.563' AS DateTime))
INSERT [dbo].[Categories] ([Id], [Namec], [Hide], [DateUp]) VALUES (3, N'Chăm sóc sắc đẹp', 0, CAST(N'2023-11-30T11:59:11.167' AS DateTime))
INSERT [dbo].[Categories] ([Id], [Namec], [Hide], [DateUp]) VALUES (4, N'Thực phẩm chức năng', 0, CAST(N'2023-11-30T12:19:17.297' AS DateTime))
INSERT [dbo].[Categories] ([Id], [Namec], [Hide], [DateUp]) VALUES (5, N'Dược phẩm', 0, CAST(N'2023-11-30T13:01:58.553' AS DateTime))
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctors] ON 

INSERT [dbo].[Doctors] ([Id], [Namedoc], [Infordoc], [AvaDoc], [HideDoc], [DateUpDoc]) VALUES (1, N'Bs. Từ Mậu Xương', N'Kinh nghiệm nhiều năm trong ngành điều trị da liễu, B.s Từ Mậu Xương được nhiều người biết đến như một người thầy thuốc giỏi, tận tâm, kinh nghiệm lâm sàng phong phú, thiết kế phác đồ điều trị hiệu quả.', N'231130\20231130_CAN-THO-BS-XUONG.png', 1, CAST(N'2023-11-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Doctors] ([Id], [Namedoc], [Infordoc], [AvaDoc], [HideDoc], [DateUpDoc]) VALUES (2, N'Bs. Trần Hồng Anh', N'Là một trong những B.s trẻ có chuyên môn cao, cách tiếp cận và tư vấn nhẹ nhàng, thân thiện B.s Hồng Anh đã giúp cho hàng ngàn bệnh nhân tại O2 SKIN vượt qua rào cản mặc cảm', N'231130\20231130_QUAN-10-BS-HONG-ANH[1].png', 0, CAST(N'2023-11-30T10:41:17.653' AS DateTime))
INSERT [dbo].[Doctors] ([Id], [Namedoc], [Infordoc], [AvaDoc], [HideDoc], [DateUpDoc]) VALUES (3, N'Bs. Nguyễn Quỳnh Thi', N'Là một trong những vị bác sĩ giỏi chuyên môn, giàu kinh nghiệm trong lĩnh vực da liễu, 7 năm trực tiếp khám và điều trị mụn cho hàng ngàn Khách hàng tại O2 SKIN', N'231130\20231130_BINH-THANH-BS-THI[1].png', 0, CAST(N'2023-11-30T10:41:48.953' AS DateTime))
INSERT [dbo].[Doctors] ([Id], [Namedoc], [Infordoc], [AvaDoc], [HideDoc], [DateUpDoc]) VALUES (4, N'Bs. Lý Nguyễn Hoàng', N'Kinh nghiệm hơn 30 năm trong điều trị da liễu, Bác sĩ Lý Nguyễn Hoàng là một trong những Bác sĩ chuyên môn cao và am hiểu sâu về da liễu và điều trị mụn', N'231130\20231130_THU-DUC-BS-HOANG[1].png', 0, CAST(N'2023-11-30T10:42:32.683' AS DateTime))
INSERT [dbo].[Doctors] ([Id], [Namedoc], [Infordoc], [AvaDoc], [HideDoc], [DateUpDoc]) VALUES (5, N'Bs. Phan Ngọc Linh Duy', N'Kinh nghiệm 6 năm điều trị và giảng dạy về Bộ môn Da liễu, là Bác sĩ cố vấn chuyên môn, phục vụ giảng dạy cho Phòng khám, là đồng chủ biên cuốn sách “Hiểu mụn để hết mụn”', N'231130\20231130_QUAN-10-BS-THUY[1].png', 0, CAST(N'2023-11-30T11:00:41.703' AS DateTime))
INSERT [dbo].[Doctors] ([Id], [Namedoc], [Infordoc], [AvaDoc], [HideDoc], [DateUpDoc]) VALUES (6, N'Bs. Nguyễn Thị Phương Lan', N'Với kinh nghiệm 7 năm trong nghề, Bs Lan ghi điểm trong lòng khách hàng nhờ cách tư vấn tận tâm, đầy thuyết phục.', N'231130\20231130_BINH-THANH-BS-THAO[1].png', 0, CAST(N'2023-11-30T11:07:35.113' AS DateTime))
INSERT [dbo].[Doctors] ([Id], [Namedoc], [Infordoc], [AvaDoc], [HideDoc], [DateUpDoc]) VALUES (7, N'Bs. Đoàn Nguyễn Minh Phương', N'Là Bác sĩ gạo cội với 21 năm kinh nghiệm điều trị da liễu, Bs Phương có khả năng lên phác đồ rất hiệu quả', N'231130\20231130_QUAN-10-BS-NGOC[1].png', 0, CAST(N'2023-11-30T11:08:53.670' AS DateTime))
SET IDENTITY_INSERT [dbo].[Doctors] OFF
GO
INSERT [dbo].[Module] ([Id], [ModuleName]) VALUES (1, N'Quản lý nhân viên')
INSERT [dbo].[Module] ([Id], [ModuleName]) VALUES (2, N'Quản lý dịch vụ')
INSERT [dbo].[Module] ([Id], [ModuleName]) VALUES (3, N'Quản lý sản phẩm')
INSERT [dbo].[Module] ([Id], [ModuleName]) VALUES (4, N'Quản lý loại sản phẩm')
INSERT [dbo].[Module] ([Id], [ModuleName]) VALUES (5, N'Quản lý nhãn hiệu')
INSERT [dbo].[Module] ([Id], [ModuleName]) VALUES (6, N'Tin tức')
INSERT [dbo].[Module] ([Id], [ModuleName]) VALUES (7, N'Quản lý khách hàng')
INSERT [dbo].[Module] ([Id], [ModuleName]) VALUES (8, N'Quản lý đơn hàng')
INSERT [dbo].[Module] ([Id], [ModuleName]) VALUES (9, N'Quản lý lịch đặt')
INSERT [dbo].[Module] ([Id], [ModuleName]) VALUES (10, N'Quản lý bác sĩ')
INSERT [dbo].[Module] ([Id], [ModuleName]) VALUES (11, N'Quản lý banner')
INSERT [dbo].[Module] ([Id], [ModuleName]) VALUES (12, N'Quản lý nhóm quyền')
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [OrderCode], [UserId], [OrderDate], [TotalAmount], [Status], [Userfb], [PhoneAddress], [Address]) VALUES (8, N'231130024218922', 7, CAST(N'2023-11-30T14:42:18.927' AS DateTime), CAST(658800 AS Decimal(18, 0)), 2, 0, N'1238481231', N'12 jdjfjjfoadf')
INSERT [dbo].[Order] ([Id], [OrderCode], [UserId], [OrderDate], [TotalAmount], [Status], [Userfb], [PhoneAddress], [Address]) VALUES (9, N'231130024413515', 8, CAST(N'2023-11-30T14:44:13.517' AS DateTime), CAST(953000 AS Decimal(18, 0)), 1, 0, N'123456789', N'21e ikjdksjgsd')
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (7, 8, 31, CAST(40900 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (8, 8, 32, CAST(22500 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (9, 8, 30, CAST(266000 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (10, 9, 23, CAST(145000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (11, 9, 20, CAST(276000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (12, 9, 14, CAST(532000 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (9, N'Nhiệt kế điện tử Pharmacity', 2, CAST(88000 AS Decimal(18, 0)), CAST(150000 AS Decimal(18, 0)), N'<p>Nhiệt kế điện tử Pharmacity d&ugrave;ng để đo th&acirc;n nhiệt v&ugrave;ng miệng, n&aacute;ch, hậu m&ocirc;n bằng c&ocirc;ng nghệ cảm ứng cho kết quả nhanh, ch&iacute;nh x&aacute;c nhất v&agrave; dễ d&agrave;ng sử dụng.</p>
', 0, N'No', N'231130\20231130_P08456_1_l-thumbnail-510x510.png', CAST(N'2023-03-13T00:00:00.000' AS DateTime), 4, N'Còn hàng', N'4', N'/Content/upload/img/kem-duong-am-klairs-lam-diu-phuc-hoi-da-ban-dem-1.jpg,/Content/upload/img/kem-duong-am-lam-diu-da-ban-dem-klairs-30ml-2.jpg,/Content/upload/img/kem-duong-am-lam-diu-da-ban-dem-klairs-02.jpg')
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (10, N'Nhiệt kế điện tử hồng ngoại đo trán Microlife', 2, CAST(1100000 AS Decimal(18, 0)), CAST(1150000 AS Decimal(18, 0)), N'<p>Nhiệt kế điện tử hồng ngoại đo tr&aacute;n Microlife NC200</p>
', 0, N'No', N'231130\20231130_P16044_1_l-thumbnail-510x510[1].png', CAST(N'2023-11-25T12:42:22.443' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (13, N'Nhiệt kế hồng ngoại Kachi JXB-315', 2, CAST(790000 AS Decimal(18, 0)), CAST(800000 AS Decimal(18, 0)), N'<p>Nhiệt kế hồng ngoại Kachi JXB-315 với thiết kế đặc biệt để gi&uacute;p đo nhiệt độ cơ thể con người với khoảng c&aacute;ch 0 ~ 3cm n&ecirc;n c&oacute; thể ứng dụng trong rất nhiều lĩnh vực của đời sống. Sản phẩm rấthữu &iacute;ch khi đo nhiệt độ tại những vị tr&iacute; nguy hiểm: chứa chất độc hại, điều kiện khắc nghiệt, thiết bị điện&hellip;</p>
', 0, N'No', N'231130\20231130_P21654_11-thumbnail-510x510-70[1].jpg', CAST(N'2023-11-30T00:35:34.413' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (14, N'Nhiệt kế điện tử đo tai Omron TH-839S', 2, CAST(532000 AS Decimal(18, 0)), CAST(732000 AS Decimal(18, 0)), N'<p>Sản phẩm được thiết kế đặc biệt để sử dụng tại v&ugrave;ng tai, gi&uacute;p trẻ bớt lo sợ hơn so với c&aacute;c dụng cụ đo nhiệt th&ocirc;ng thường. Hơn nữa, với Omron TH-839S, gia đ&igrave;nh bạn sẽ kh&ocirc;ng c&ograve;n phải lo lắng với nguy cơ độc hại của thủy ng&acirc;n như khi sử dụng những loại nhiệt kế truyền thống kh&aacute;</p>
', 0, N'No', N'231130\20231130_P08830_1_l-thumbnail-510x510.png', CAST(N'2023-11-30T11:53:50.710' AS DateTime), 1, N'Hết hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (15, N'Nhiệt kế điện tử Microlife MT500', 2, CAST(90000 AS Decimal(18, 0)), CAST(125000 AS Decimal(18, 0)), N'<p>Nhiệt kế điện tử Microlife MT500 l&agrave; d&ograve;ng sản phẩm nhiệt kế điện tử cung cấp giải ph&aacute;p thay thế cho nhiệt kế thủy ng&acirc;n do t&iacute;nh an to&agrave;n trong sử dụng, c&oacute; độ ch&iacute;nh x&aacute;c cao, đo nhanh cho kết quả chỉ sau 30 gi&acirc;y.</p>
', 0, N'No', N'231130\20231130_P08457_1_l-thumbnail-510x510.png', CAST(N'2023-11-30T11:57:53.827' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (16, N'Sữa rửa mặt Acne-Aid Liquid Cleanser (Chai 100ml)', 3, CAST(150000 AS Decimal(18, 0)), CAST(175000 AS Decimal(18, 0)), N'<p>Sữa rửa mặt Acne-Aid Liquid Cleanser l&agrave;m sạch da dịu nhẹ, gi&uacute;p loại bỏ dầu cho da. Th&iacute;ch hợp sử dụng h&agrave;ng ng&agrave;y, đặc biệt cho da dầu v&agrave; mụn.</p>
', 0, N'No', N'231130\20231130_P22986_1-thumbnail-510x510-70.jpg', CAST(N'2023-11-30T12:00:29.660' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (19, N'Kem hỗ trợ giảm mụn Bioderma Sebium Kerato (Hộp 30ml)', 3, CAST(500000 AS Decimal(18, 0)), CAST(445000 AS Decimal(18, 0)), N'<p>Kem dưỡng da l&agrave;m giảm mụn v&agrave; mụn đầu đen, l&agrave;m đều m&agrave;u da, giảm vết th&acirc;m mụn sau 2 ng&agrave;y, gi&uacute;p giảm b&atilde; nhờn v&agrave; giảm k&iacute;ch ứng tr&ecirc;n da với khả năng dung nạp cao</p>
', 0, N'No', N'231130\20231130_P25746_1-thumbnail-510x510-70.jpg', CAST(N'2023-11-30T12:04:04.410' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (20, N'Sữa rửa mặt dịu nhẹ cho mọi loại da Cetaphil Gentle Skin Cleanser (250ml)', 3, CAST(276000 AS Decimal(18, 0)), CAST(300000 AS Decimal(18, 0)), N'<p>Sữa rửa mặt dịu nhẹ cho da nhạy cảm Cetaphil Gentle Skin Cleanser với c&aacute;c th&agrave;nh phần dịu l&agrave;nh gi&uacute;p l&agrave;m sạch da một c&aacute;ch dịu nhẹ c&ugrave;ng với c&ocirc;ng thức khoa học mới từ sự kết hợp 3 th&agrave;nh phần l&agrave;nh t&iacute;nh Niacinamide (Vitamin B3), Panthenol (Pro-vitamin B5) v&agrave; Glycerin đ&atilde; tạo ra cơ chế đặc biệt gi&uacute;p th&uacute;c đẩy qu&aacute; tr&igrave;nh sản sinh Ceramides tự nhi&ecirc;n của da v&agrave; tổng hợp Fillaggrin c&oacute; c&ocirc;ng dụng bảo vệ h&agrave;ng r&agrave;o tự nhi&ecirc;n của da gi&uacute;p cải thiện khả năng phục hồi của l&agrave;n da nhạy cảm. Đồng thời, sản phẩm c&ograve;n gi&uacute;p đẩy l&ugrave;i 5 dấu hiệu nhạy cảm của l&agrave;n da: kh&ocirc;, căng, k&iacute;ch ứng, kh&ocirc;ng mịn m&agrave;ng v&agrave; nhất t&igrave;nh trạng suy yếu h&agrave;ng r&agrave;o bảo vệ tự nhi&ecirc;n của da.</p>
', 0, N'No', N'231130\20231130_P22162_4-thumbnail-510x510-70.jpg', CAST(N'2023-11-30T12:05:30.537' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (21, N'Kem giảm bóng nhờn, ngừa mụn chứa bùn hoạt tính Dermacos (Hộp 50ml)', 3, CAST(330000 AS Decimal(18, 0)), CAST(400000 AS Decimal(18, 0)), N'<p>Kem giảm b&oacute;ng nhờn, ngừa mụn chứa b&ugrave;n hoạt t&iacute;nh Dermacos chứa Than B&ugrave;n (Peat Extract) &amp; nguồn Axit Salicylic tự nhi&ecirc;n từ Vỏ c&acirc;y Liễu (Salix Alba Bark) l&agrave;m giảm b&oacute;ng nhờn da, giảm mụn, ngừa mụn &amp; l&agrave;m dịu nhẹ k&iacute;ch ứng, mẩn đỏ da. Chiết xuất L&ocirc; Hội (Aloe Barbadensis), Zinc PCA &amp; Vitamin E (Tocopheryl Acetate) dưỡng ẩm, l&agrave;m mờ vết th&acirc;m &amp; giảm nguy cơ để lại sẹo do mụn trứng c&aacute;. Titanium Dioxide gi&uacute;p chống nắng, bảo vệ da trước tia cực t&iacute;m &amp; c&aacute;c t&aacute;c nh&acirc;n c&oacute; hại b&ecirc;n ngo&agrave;i. Gi&uacute;p da trở l&ecirc;n mịn m&agrave;ng &amp; kh&ocirc; tho&aacute;ng cả ng&agrave;y.</p>
', 0, N'No', N'231130\20231130_P25816_1N-thumbnail-510x510-70.jpg', CAST(N'2023-11-30T12:07:59.970' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (22, N'Gel xử lý thâm mụn, sẹo mụn Hiruscar Post Acne (5g)', 3, CAST(175000 AS Decimal(18, 0)), CAST(155000 AS Decimal(18, 0)), N'<p>Với c&ocirc;ng thức ba trong một độc quyền của Pionin, MPS, Allium Cepa v&agrave; Vitamin B3, Hiruscar Post Acne gi&uacute;p l&agrave;m s&aacute;ng vết th&acirc;m mụn, cải thiện sẹo mụn nhanh sau hai tuần sử dụng, đồng thời ngăn ngừa t&aacute;i ph&aacute;t mụn tại c&ugrave;ng vị tr&iacute;.</p>
', 0, N'No', N'231130\20231130_P01858_1_l-thumbnail-510x510.png', CAST(N'2023-11-30T12:16:57.583' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (23, N'Men vi sinh hỗ trợ tiêu hóa 6 ENZYMES IP (Hộp 20 ống x 10ml)', 4, CAST(145000 AS Decimal(18, 0)), CAST(155000 AS Decimal(18, 0)), N'<p>Bổ sung enzym ti&ecirc;u h&oacute;a gi&uacute;p tăng cường ti&ecirc;u ho&aacute; thức ăn, hỗ trợ giảm t&igrave;nh trạng đầy bụng, kh&oacute; ti&ecirc;u, biếng ăn, t&aacute;o b&oacute;n</p>
', 0, N'No', N'231130\20231130_P25921_2-thumbnail-510x510-70.jpg', CAST(N'2023-11-30T12:20:37.510' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (24, N'Xịt mũi họng Khiết Thanh Á Âu (30ml)', 4, CAST(100000 AS Decimal(18, 0)), CAST(115000 AS Decimal(18, 0)), N'<p>Xịt mũi họng Khiết Thanh &Aacute; &Acirc;u sử dụng l&agrave;m sạch, loại bỏ bụi bẩn, loại bỏ t&aacute;c nh&acirc;n g&acirc;y bệnh dị ứng; gi&uacute;p kh&aacute;ng khuẩn, kh&aacute;ng virus, kh&aacute;ng vi&ecirc;m; l&agrave;m dịu ngứa họng, r&aacute;t họng, đau v&agrave; sưng vi&ecirc;m họng.</p>
', 0, N'No', N'231130\20231130_P22919_1-thumbnail-510x510-70.jpg', CAST(N'2023-11-30T12:31:53.047' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (25, N'Thực phẩm hỗ trợ giảm ho An Huy Promax New Siro (Chai 100ml)', 4, CAST(70000 AS Decimal(18, 0)), CAST(65000 AS Decimal(18, 0)), N'<p>Thực phẩm hỗ trợ giảm ho An Huy Promax New Siro hỗ trợ hạn chế ho nhiều, gi&uacute;p giảm đau r&aacute;t họng, khản tiếng do ho k&eacute;o d&agrave;i, giảm c&aacute;c biểu hiện hắt hơn, sổ mũi, chảy nước mũi do cảm lạnh.</p>
', 0, N'No', N'231130\20231130_P25475_3-thumbnail-510x510-70.jpg', CAST(N'2023-11-30T12:34:10.523' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (26, N'Thực phẩm bổ sung Canxi và Vitamin D An Huy Anfa Calcium D (Hộp 30 viên)', 4, CAST(185600 AS Decimal(18, 0)), CAST(200000 AS Decimal(18, 0)), N'<p>Thực phẩm bổ sung Canxi v&agrave; Vitamin D An Huy Anfa Calcium D bổ sung canxi v&agrave; vitamin D3 cho cơ thể, gi&uacute;p xương v&agrave; răng chắc khỏe. Hỗ trợ ph&aacute;t triển chiều cao, gi&uacute;p giảm nguy cơ c&ograve;i xương ở trẻ em, kh&ocirc;ng xương ở người lớn.</p>
', 0, N'No', N'231130\20231130_P25532_1-thumbnail-510x510-70.jpg', CAST(N'2023-11-30T12:52:33.767' AS DateTime), 3, N'Hết hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (27, N'TPCN hỗ trợ tăng cường thính lực Kim Thính (3 vỉ x 10 viên/hộp)', 4, CAST(210000 AS Decimal(18, 0)), CAST(300000 AS Decimal(18, 0)), N'<p>Thực phẩm chức năng hỗ trợ tăng cường th&iacute;nh lực Kim Th&iacute;nh hỗ trợ tăng cường lưu th&ocirc;ng kh&iacute; huyết, gi&uacute;p tăng cường sức khỏe th&iacute;nh gi&aacute;c. Hỗ trợ giảm c&aacute;c triệu chứng nghe k&eacute;m, suy giảm th&iacute;nh lực.</p>
', 0, N'No', N'231130\20231130_P24942_1-thumbnail-510x510-70.jpg', CAST(N'2023-11-30T12:53:32.523' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (28, N'Acetylcystein 200 Imexpharm (10 vỉ x 10 viên)', 5, CAST(147000 AS Decimal(18, 0)), CAST(155000 AS Decimal(18, 0)), N'<p>Hoạt chất: Acetylcysteine</p>

<p>C&ocirc;ng dụng: Điều trị c&aacute;c bệnh l&yacute; đường h&ocirc; hấp c&oacute; đờm nhầy qu&aacute;nh như&nbsp;vi&ecirc;m phế quản cấp&nbsp;v&agrave; mạn.</p>

<p>Đối tượng sử dụng: Người lớn/ trẻ em tr&ecirc;n 2 tuổi</p>

<p>H&igrave;nh thức: Vi&ecirc;n nang cứng</p>

<p>Thương hiệu: Imexpharm</p>

<p>Nơi sản xuất: Việt Nam</p>

<p>*Thuốc chỉ d&ugrave;ng theo đơn của b&aacute;c sĩ</p>
', 0, N'No', N'231130\20231130_P17315_1_l-thumbnail-510x510.png', CAST(N'2023-11-30T13:05:08.070' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (29, N'Altamin (Hộp 10 vỉ x 10 viên)', 5, CAST(109000 AS Decimal(18, 0)), CAST(200000 AS Decimal(18, 0)), N'<p>Hoạt chất: Cao kh&ocirc; Actiso 100mg, Cao kh&ocirc; Rau đắng đất 75mg, Cao kh&ocirc; hạt b&igrave;m b&igrave;m biếc 5,245mg</p>

<p>C&ocirc;ng dụng: Điều trị thiểu năng gan, vi&ecirc;m gan g&acirc;y mệt mỏi, kh&oacute; ti&ecirc;u, v&agrave;ng da, mụn nhọt lở ngứa, b&iacute; đại tiểu tiện, t&aacute;o b&oacute;n...</p>

<p>Đối tượng sử dụng: Người lớn v&agrave; trẻ em tr&ecirc;n 8 tuổi</p>

<p>H&igrave;nh thức: Vi&ecirc;n nang mềm</p>

<p>Thương hiệu: Bidiphar</p>

<p>Nơi sản xuất: C&ocirc;ng ty cổ phần Dược - Trang thiết bị y tế B&igrave;nh Định (Việt Nam)</p>
', 0, N'No', N'231130\20231130_P14649_1_l-thumbnail-510x510.png', CAST(N'2023-11-30T13:06:30.953' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (30, N'Allvitamine (Hộp 6 vỉ x 10 viên)', 5, CAST(266000 AS Decimal(18, 0)), CAST(300000 AS Decimal(18, 0)), N'<p>Hoạt chất: Vitamin A, B1, B2, B5, B6, PP, E</p>

<p>C&ocirc;ng dụng: Bổ sung vitamin cần thiết cho cơ thể</p>

<p>Đối tượng sử dụng: Người lớn v&agrave; trẻ em</p>

<p>H&igrave;nh thức: Vi&ecirc;n n&eacute;n bao đường</p>

<p>Thương hiệu: USA - NIC pharma</p>

<p>Nơi sản xuất:&nbsp;USA - NIC Pharma Company (Việt Nam)</p>
', 0, N'No', N'231130\20231130_P19886_1_l-thumbnail-510x510.png', CAST(N'2023-11-30T13:08:41.503' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (31, N'Dầu Khuynh Diệp OPC (Hộp 1 chai 15ml)', 5, CAST(40900 AS Decimal(18, 0)), CAST(70000 AS Decimal(18, 0)), N'<p>Hoạt chất: Eucalyptol 12,44g.</p>

<p>C&ocirc;ng dụng: Ph&ograve;ng, điều trị cảm c&uacute;m, sổ mũi, nghẹt mũi, ho tức ngực, đau bụng, nhức mỏi...</p>

<p>Đối tượng sử dụng: Người lớn/ trẻ em</p>

<p>H&igrave;nh thức: Dầu xoa</p>

<p>Thương hiệu: OPC</p>

<p>Nơi sản xuất:Việt Nam</p>
', 0, N'No', N'231130\20231130_P00418_1_l-thumbnail-510x510 (1).png', CAST(N'2023-11-30T13:11:34.517' AS DateTime), 1, N'Còn hàng', NULL, NULL)
INSERT [dbo].[Products] ([Id], [Namep], [CateId], [Newprice], [Oldprice], [Descr], [Hide], [Statep], [Img], [DateUp], [Idbrand], [Avilability], [Rated], [Listimg]) VALUES (32, N'Dầu gió xanh Thiên Thảo (Chai 12ml)', 5, CAST(22500 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), N'<p>Hoạt chất: Menthol 2,52g; Methyl salicylate 2,16g; Eucalyptol 0,72 ml,....</p>

<p>C&ocirc;ng dụng: Cảm, ho, sổ mũi,....</p>

<p>Đối tượng sử dụng: Người lớn</p>

<p>H&igrave;nh thức: Thuốc b&ocirc;i ngo&agrave;i da</p>

<p>Thương hiệu: Đ&ocirc;ng Nam Dược Trường Sơn (Việt Nam)</p>

<p>Nơi sản xuất: C&ocirc;ng ty cổ phần Đ&ocirc;ng Nam Dược Trường Sơn (Việt Nam)</p>

<p>*Thuốc chỉ d&ugrave;ng theo đơn của b&aacute;c sĩ.</p>
', 0, N'No', N'231130\20231130_P00066_1_l-thumbnail-510x510.png', CAST(N'2023-11-30T13:13:32.397' AS DateTime), 1, N'Còn hàng', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (1, 2, 1, 1, 1, 1, 0, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (2, 2, 2, 1, 1, 1, 0, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (3, 2, 3, 1, 1, 1, 0, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (4, 2, 4, 1, 1, 1, 0, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (5, 2, 5, 1, 1, 1, 0, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (6, 2, 6, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (7, 2, 7, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (8, 2, 8, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (9, 2, 9, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (10, 2, 10, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (11, 2, 11, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (12, 2, 12, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (13, 1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (14, 1, 2, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (15, 1, 3, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (16, 1, 4, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (17, 1, 5, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (18, 1, 6, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (19, 1, 7, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (20, 1, 8, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (21, 1, 9, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (22, 1, 10, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (23, 1, 11, 1, 1, 1, 1, 1)
INSERT [dbo].[Role] ([Id], [RoleGroupId], [ModuleId], [Add], [Edit], [Delete], [View], [Confirm]) VALUES (24, 1, 12, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleGroup] ON 

INSERT [dbo].[RoleGroup] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[RoleGroup] ([Id], [Name]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[RoleGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [NameDt], [DescDt], [HideDt], [ImgDt]) VALUES (1, N'Điều trị mụn', N'Các dịch vụ điều trị mụn tại O2 SKIN tập trung điều trị chuyên sâu, lần lượt giải quyết từng vấn đề của làn da mụn như giảm viêm, giảm nhờn, giảm sừng hóa nang lông, hỗ trợ đẩy nhanh quá trình gom khô cồi mụn và lấy nhân mụn ra khỏi da, mang lại cảm giác nhẹ nhàng, sạch thoáng lỗ chân lông.', 0, N'231130\20231130_Dich-vu-dieu-tri-mun[1].png')
INSERT [dbo].[Services] ([Id], [NameDt], [DescDt], [HideDt], [ImgDt]) VALUES (2, N'Điều trị phục hồi da', N'Da nhạy cảm, da đang bị dị ứng, kích ứng hoặc tai biến corticoid sẽ được điều trị bằng các phương pháp điện di chuyên sâu, đắp mặt nạ phục hồi, cấp ẩm tức thì, làm dịu da và giảm các triệu chứng kích ứng, đỏ da, rát da, giúp phục hồi da về trạng thái cân bằng, khỏe mạnh.', 0, N'231130\20231130_9-dien-di-giam-kich-ung[1].png')
INSERT [dbo].[Services] ([Id], [NameDt], [DescDt], [HideDt], [ImgDt]) VALUES (3, N'Điều trị thâm', N'Những vết thâm do mụn để lại sẽ tồn tại rất lâu trên da nếu không có phương pháp thúc đẩy điều trị. Dịch vụ điều trị thâm, hồng ban sau mụn tại O2 SKIN dành cho mọi tuýp da và tình trạng da sẽ giúp bạn nhanh chóng xóa mờ các vết thâm, hồng ban sau mụn, sớm lấy lại làn da trắng sáng, đều màu và mịn màng.', 0, N'231130\20231130_dien-di-1512[1].png')
INSERT [dbo].[Services] ([Id], [NameDt], [DescDt], [HideDt], [ImgDt]) VALUES (4, N'Điều trị sẹo rỗ', N'Những tổn thương sau mụn cần được hỗ trợ phục hồi càng sớm càng tốt bằng các phương pháp kỹ thuật cao, giúp điều trị chuyên sâu cho từng vấn đề như sẹo rỗ, thâm mụn, hồng ban, lỗ chân lông to, da dày sừng...Giúp làn da sớm trở lại trạng thái khỏe mạnh, mịn màng và sạch mụn.', 0, N'231130\20231130_13-peel-da-dtri-tham[1].png')
INSERT [dbo].[Services] ([Id], [NameDt], [DescDt], [HideDt], [ImgDt]) VALUES (5, N'Điều trị mụn trứng cá', N'Điều trị mụn trứng cá  jnjdasnjdnajdasdasd', 1, N'231128\20231128_11.jpg')
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Birth], [Gender], [Phone], [Email], [Password], [Hide], [Ava], [dateregist]) VALUES (7, N'Phan Duy', CAST(N'1992-02-10T00:00:00.000' AS DateTime), N'Male', N'1238481231', N'duypnl219@gmail.com', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 0, NULL, CAST(N'2023-11-30T14:40:16.307' AS DateTime))
INSERT [dbo].[Users] ([Id], [Name], [Birth], [Gender], [Phone], [Email], [Password], [Hide], [Ava], [dateregist]) VALUES (8, N'Phương Lan ', CAST(N'2003-12-09T00:00:00.000' AS DateTime), N'Female', N'123456789', N'phuonglannguyen963@gmail.com', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 0, NULL, CAST(N'2023-11-30T14:43:06.767' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  StoredProcedure [dbo].[Sp_BookingListAllPaging]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_BookingListAllPaging]
	@search nvarchar(500),
	@offset int,
	@limit int
AS
BEGIN
	SELECT *
	,COUNT(1) OVER() as TotalRow
	FROM Bookings 
	Where (@search is null
	OR [Name] like N'%'+@search+'%'
	OR [Phone] like N'%'+@search+'%'
	OR [Email] like N'%'+@search+'%')
	Order by Id DESC
	offset @offset rows
	fetch next @limit rows only;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetAdminListAll]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetAdminListAll]
	@search nvarchar(500),
	@offset int,
	@limit int
AS
BEGIN
	SELECT a.*
	, rg.Name As RoleGroupName
	, COUNT(1) OVER() as TotalRow
	FROM [Admin] a
	LEFT JOIN RoleGroup rg ON rg.Id = a.RoleGroupId
	Where (@search is null 
	OR a.FullName like N'%'+@search+'%'
	OR a.Username like N'%'+@search+'%')
	Order By a.Id DESC
	offset @offset rows
	fetch next @limit rows only;

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetBlogListAllPaging]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetBlogListAllPaging] 
	@search nvarchar(500),
	@offset int,
	@limit int
AS
BEGIN
	SELECT bd.*, bt.Namebt, COUNT(1) OVER() AS TotalRow
	FROM BlogDetails bd
	Left join BlogTypes bt On bt.Id = bd.BlogTypeId
	Where (@search is null 
	OR bd.Title like N'%'+@search+'%'
	OR bt.Namebt like N'%'+@search+'%')
	order by bd.Id DESC
	offset @offset rows
	fetch next @limit rows only;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetBrandListAllPaging]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetBrandListAllPaging]
	@search nvarchar(500),
	@offset int,
	@limit int
AS
BEGIN
	SELECT *,
	COUNT(1) OVER() as TotalRow
	FROM Brands
	where (@search is null 
	OR Namebrand like N'%'+@search+'%')
	order by Id desc
	offset @offset rows
	fetch next @limit rows only;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetCategoryListAllPaging]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetCategoryListAllPaging]
	@search nvarchar(500),
	@offset int,
	@limit int
AS
BEGIN
	Select *
	, COUNT(1) OVER() as TotalRow
	From Categories 
	Where (@search is null
	OR namec like N'%'+@search+'%')
	Order by Id DESC
	offset @offset rows
	fetch next @limit rows only;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetDoctorListAllPaging]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetDoctorListAllPaging]
	@search nvarchar(500),
	@offset int,
	@limit int
AS
BEGIN
	SELECT *,
	COUNT(1) OVER() as TotalRow
	FROM Doctors
	Where (@search is null 
	OR Namedoc like N'%'+@search+'%')
	Order by Id DESC
	offset @offset rows
	fetch next @limit rows only;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetListProductSort]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetListProductSort] 
	@sort int,
	@offset int, 
	@limit int
AS
BEGIN
	SELECT *
	, COUNT(1) OVER() as TotalRow
	FROM Products
	Where Hide = 0
	ORDER BY 
	Case when @sort = 0 then Id end DESC,
	case when @sort = 1 then Newprice end ASC,
	case when @sort = 2 then Newprice end DESC,
	case when @sort = 3 then Namep end ASC,
	case when @sort = 4 then Namep end DESC
	offset @offset rows
	fetch next @limit rows only
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetOrderDetailByOrderId]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetOrderDetailByOrderId]
	@OrderId int,
	@offset int,
	@limit int
AS
BEGIN
	SELECT od.*
	, p.Namep as ProductName
	, p.Img as ProductImage
	, COUNT(1) OVER() as TotalRow
	FROM OrderDetail od
	INNER JOIN Products p ON p.Id = od.ProductId
	Where od.OrderId = @OrderId
	Order by od.Id ASC
	offset @offset rows 
	fetch next @limit rows only;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetOrderListAllPaging]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetOrderListAllPaging]
	@search nvarchar(500),
	@status int,
	@offset int,
	@limit int
AS
BEGIN
	SELECT o.*
	, u.[Name] as FullName
	, COUNT(1) OVER() as TotalRow
	FROM [Order] o
	LEFT JOIN [Users] u ON u.Id = o.UserId
	Where (@search is null 
	OR o.OrderCode like N'%'+@search+'%'
	OR u.[Name] like N'%'+@search+'%')
	AND (@status = 0 OR o.[Status] = @status)
	Order By o.Id DESC
	offset @offset rows
	fetch next @limit rows only;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetProduct_ById]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetProduct_ById]
	@Id int
AS
BEGIN
	Select p.*, c.Namec
	From Products p
	LEFT JOIN Categories c ON c.Id = p.CateId
	Where p.Id = @Id AND p.Hide = 0
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetProductByCateId]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetProductByCateId]
	@CateId int,
	@offset int,
	@limit int
AS
BEGIN
	SELECT p.*
	, c.Namec
	, COUNT(1) OVER() as TotalRow
	FROM Products p
	INNER JOIN Categories c ON c.Id = p.CateId
	where c.Id = @CateId AND p.Hide = 0
	Order by Id DESC
	offset @offset rows 
	fetch next @limit rows only;

END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetProductListAllPaging]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetProductListAllPaging]
	@search nvarchar(500),
	@offset int,
	@limit int
AS
BEGIN
	SELECT p.*, b.Namebrand, c.Namec, COUNT(1) OVER() as TotalRow
	FROM Products p
	Left Join Brands b ON b.Id = p.Idbrand
	Left Join Categories c ON c.Id = p.CateId
	where (@search is null 
	OR p.Namep like N'%'+@search+'%'
	OR b.Namebrand like N'%'+@search+'%'
	OR c.Namec like N'%'+@search+'%')
	Order by p.Id DESC
	offset @offset rows
	fetch next @limit rows only;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetProductSelling]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetProductSelling]
AS
BEGIN
	Select Top 8 * 
	from Products 
	where Id in (
		select TOP 8 ProductId 
		from OrderDetail 
		Group by ProductId
		Order by SUM(Quantity) DESC
	)
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetRole_ListAll]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetRole_ListAll] 
	@roleGroupId int
AS
BEGIN
	SELECT distinct * FROM (
		SELECT distinct T.Id, T.RoleGroupId, T.[View], T.Edit, T.[Add], T.[Delete],
			T.Confirm, M.ModuleName, M.Id AS ModuleId
			FROM
			(SELECT RM.Id, RM.ModuleID, RM.RoleGroupId, RM.[View], RM.[Add], RM.Edit,
			RM.[Delete], RM.Confirm
			FROM dbo.RoleGroup R
			INNER JOIN dbo.[Role] RM ON RM.RoleGroupId=R.Id
		)T
		RIGHT JOIN dbo.Module M ON T.ModuleID = M.ID 
		where T.RoleGroupId = @roleGroupId 
	union all
		SELECT distinct T.Id, ISNULL(T.RoleGroupId, @roleGroupId), T.[View], T.Edit, T.[Add], T.[Delete],T.Confirm, M.ModuleName, M.Id AS ModuleId
		FROM
			(SELECT RM.Id, RM.ModuleID, RM.RoleGroupId, RM.[View], RM.[Add], RM.Edit,
			RM.[Delete], RM.Confirm
			FROM dbo.RoleGroup R
			RIGHT JOIN [Role] RM ON R.ID=RM.RoleGroupId where R.Id = @roleGroupId
			) T
		RIGHT JOIN dbo.Module M ON T.ModuleId = M.Id
	)as A 
	Order By ModuleId
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetRoleGroupListAllPaging]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetRoleGroupListAllPaging]
	@search nvarchar(500),
	@offset int,
	@limit int
AS
BEGIN
	SELECT *
	, COUNT(1) OVER() as TotalRow
	FROM RoleGroup
	where (@search is null 
	OR [Name] like N'%'+@search+'%')
	order by Id Desc
	offset @offset rows
	fetch next @limit rows only;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetServiceDetail_ListAllPaiging]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetServiceDetail_ListAllPaiging]
	@serviceId int,
	@search nvarchar(500),
	@offset int,
	@limit int
AS
BEGIN
	SELECT *
	,COUNT(1) OVER() as TotalRow
	FROM ServicesDetails 
	where (IdDt = @serviceId) 
	AND (@search is null 
	OR NameSd like N'%'+@search+'%')
	Order By Id DESC
	offset @offset rows
	fetch next @limit rows only;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetServiceListAllPaging]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetServiceListAllPaging]
	@search nvarchar(500),
	@offset int,
	@limit int
AS
BEGIN
	Select *,
	COUNT(1) OVER() As TotalRow
	From [Services]
	Where (@search is null 
	OR NameDt like N'%'+@search+'%')
	Order By Id DESC
	offset @offset rows
	fetch next @limit rows only;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetUser_ListAllPaging]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetUser_ListAllPaging]
	@search nvarchar(500),
	@offset int,
	@limit int
AS
BEGIN
	SELECT *
	, COUNT(1) OVER() AS TotalRow
	FROM Users 
	Where (@search is null
	OR [Name] like N'%'+@search+'%'
	OR Email like N'%'+@search+'%'
	OR Phone like N'%'+@search+'%')
	Order By Id DESC
	offset @offset rows
	fetch next @limit rows only;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertOrder]    Script Date: 11/30/2023 3:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_InsertOrder]
	@OrderCode nvarchar(50),
	@UserId int,
	@TotalAmount decimal(18,0),
	@Status int,
	@PhoneNumber nvarchar(50),
	@Address nvarchar(MAX),
	@NewId int OUTPUT
AS
BEGIN
	INSERT INTO [Order](OrderCode, UserId, OrderDate, TotalAmount, Status, Userfb, PhoneAddress, Address )
	VALUES(@OrderCode, @UserId, GETDATE(), @TotalAmount, @Status, 0, @PhoneNumber, @Address)
	SET @NewId = SCOPE_IDENTITY()
END
GO
USE [master]
GO
ALTER DATABASE [DoctorskinCore] SET  READ_WRITE 
GO
