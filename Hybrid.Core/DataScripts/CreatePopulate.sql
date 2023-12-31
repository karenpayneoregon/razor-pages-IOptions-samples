USE [master]
GO
/****** Object:  Database [EF.JsonHybrid]    Script Date: 7/13/2023 11:20:08 AM ******/
CREATE DATABASE [EF.JsonHybrid]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EF.JsonHybrid', FILENAME = N'C:\Users\paynek\EF.JsonHybrid.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EF.JsonHybrid_log', FILENAME = N'C:\Users\paynek\EF.JsonHybrid_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EF.JsonHybrid] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EF.JsonHybrid].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EF.JsonHybrid] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET ARITHABORT OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EF.JsonHybrid] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EF.JsonHybrid] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EF.JsonHybrid] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EF.JsonHybrid] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EF.JsonHybrid] SET  MULTI_USER 
GO
ALTER DATABASE [EF.JsonHybrid] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EF.JsonHybrid] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EF.JsonHybrid] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EF.JsonHybrid] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EF.JsonHybrid] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EF.JsonHybrid] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EF.JsonHybrid] SET QUERY_STORE = OFF
GO
USE [EF.JsonHybrid]
GO
/****** Object:  Table [dbo].[Applications]    Script Date: 7/13/2023 11:20:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[ApplicationId] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationName] [nvarchar](max) NOT NULL,
	[ContactName] [nvarchar](max) NOT NULL,
	[MailSettings] [nvarchar](max) NOT NULL,
	[GeneralSettings] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Applications] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Applications] ON 

INSERT [dbo].[Applications] ([ApplicationId], [ApplicationName], [ContactName], [MailSettings], [GeneralSettings]) VALUES (1, N'ACED', N'Kim Jenkins', N'{"FromAddress":"FromAddressAced","Host":"AcedHost","PickupFolder":"C:\\MailDrop","Port":15,"TimeOut":2000}', N'{"MainDatabaseConnection":"Data Source=.\\sqlexpress;Initial Catalog=WorkingWithDate;Integrated Security=True;Encrypt=False","ServicePath":"http://localhost:11111/api/"}')
INSERT [dbo].[Applications] ([ApplicationId], [ApplicationName], [ContactName], [MailSettings], [GeneralSettings]) VALUES (2, N'SIDES', N'Mike Adams', N'{"FromAddress":"FromAddressSides","Host":"SidesHost","PickupFolder":"C:\\MailDrop","Port":15,"TimeOut":2000}', N'{"MainDatabaseConnection":"Data Source=.\\sqlexpress;Initial Catalog=WorkingWithTime;Integrated Security=True;Encrypt=False","ServicePath":"http://localhost:22222/api/"}')
SET IDENTITY_INSERT [dbo].[Applications] OFF
GO
USE [master]
GO
ALTER DATABASE [EF.JsonHybrid] SET  READ_WRITE 
GO
