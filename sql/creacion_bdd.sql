/****** Object:  Database [BrunoFritcshVehiculosOnline]    Script Date: 14-06-2020 1:47:29 ******/
CREATE DATABASE [BrunoFritcshVehiculosOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BrunoFritcshVehiculosOnline', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BrunoFritcshVehiculosOnline.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB ),
( NAME = N'BrunoFri1tcshVehiculosOnline_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BrunoFri1tcshVehiculosOnline_log.ndf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BrunoFritcshVehiculosOnline_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BrunoFritcshVehiculosOnline_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BrunoFritcshVehiculosOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET  MULTI_USER 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET QUERY_STORE = OFF
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banco](
	[id] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[id] [int] NOT NULL,
	[nombre] [nvarchar](70) NOT NULL,
	[id_region] [int] NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comuna]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comuna](
	[id] [int] NOT NULL,
	[nombre] [nvarchar](70) NOT NULL,
	[id_ciudad] [int] NOT NULL,
 CONSTRAINT [PK_Comuna] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cotizacion]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cotizacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_solicitud] [int] NOT NULL,
	[id_tipo_pago] [int] NOT NULL,
	[fec_ingreso_cotizacion] [smalldatetime] NOT NULL,
	[es_pago_diferido] [bit] NOT NULL,
	[cant_meses_diferido] [int] NOT NULL,
	[cant_cuotas] [int] NOT NULL,
	[valor_cuota] [int] NOT NULL,
	[con_factura] [bit] NOT NULL,
	[total_sin_iva] [int] NOT NULL,
	[iva] [int] NOT NULL,
	[total_final] [int] NOT NULL,
 CONSTRAINT [PK_Cotizacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direccion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[calle] [nvarchar](100) NOT NULL,
	[numero] [nvarchar](20) NOT NULL,
	[id_comuna] [int] NOT NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modelo]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[id_marca] [int] NOT NULL,
 CONSTRAINT [PK_Modelo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_direccion] [int] NOT NULL,
	[rut] [int] NOT NULL,
	[dv] [nvarchar](1) NOT NULL,
	[nombres] [nvarchar](70) NOT NULL,
	[apellidos] [nvarchar](70) NOT NULL,
	[fec_nacimiento] [smalldatetime] NULL,
	[email] [nvarchar](100) NOT NULL,
	[telefono] [varchar](20) NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fec_ingreso_solicitud] [smalldatetime] NOT NULL,
	[id_persona] [int] NOT NULL,
	[id_vehiculo] [int] NOT NULL,
 CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCombustible]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCombustible](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_TipoCombustible] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPago](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](70) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoPago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoTarjetaCredito]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoTarjetaCredito](
	[id] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoTarjetaCredito] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoVehiculo]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoVehiculo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[descripcion] [nvarchar](700) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoVehiculo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_persona] [int] NOT NULL,
	[clave] [nvarchar](200) NOT NULL,
	[fecha_registro] [smalldatetime] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_modelo] [int] NOT NULL,
	[id_tipo_vehiculo] [int] NOT NULL,
	[id_tipo_combustible] [int] NOT NULL,
	[id_pais_origen] [int] NOT NULL,
	[anio] [int] NOT NULL,
	[color] [nvarchar](50) NOT NULL,
	[precio] [int] NOT NULL,
	[stock] [int] NOT NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_cotizacion] [int] NOT NULL,
	[fec_venta] [smalldatetime] NOT NULL,
	[total_venta] [int] NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaDetalle]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaDetalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_venta] [int] NOT NULL,
	[id_banco] [int] NOT NULL,
	[id_tipo_tarjeta] [int] NOT NULL,
	[dia_vencimiento] [int] NULL,
	[num_cuenta_corriente] [nvarchar](20) NULL,
	[num_tarjeta_credito] [nvarchar](16) NULL,
	[venc_tarjeta_credito] [nvarchar](5) NULL,
	[cvv_tarjeta_credito] [int] NULL,
 CONSTRAINT [PK_DetalleVenta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (0, N'Sin Banco', 0)
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (1, N'Banco de Chile', 1)
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (2, N'Scotiabank Chile', 1)
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (3, N'Banco de Crédito e Inversiones', 1)
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (4, N'Corpbanca', 1)
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (5, N'Banco Bice', 1)
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (6, N'Banco Santander', 1)
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (7, N'Banco Itaú Chile', 1)
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (8, N'Banco Security', 1)
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (9, N'Banco Falabella', 1)
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (10, N'Banco RIpley', 1)
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (11, N'Banco Consorcio', 1)
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (12, N'Banco Penta', 1)
GO
INSERT [dbo].[Banco] ([id], [nombre], [activo]) VALUES (13, N'Banco Estado', 1)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (1, N'Arica', 1)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (2, N'Parinacota', 1)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (3, N'Iquique', 2)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (4, N'El Tamarugal', 2)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (5, N'Antofagasta', 3)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (6, N'El Loa', 3)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (7, N'Tocopilla', 3)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (8, N'Chañaral', 4)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (9, N'Copiapó', 4)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (10, N'Huasco', 4)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (11, N'Choapa', 5)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (12, N'Elqui', 5)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (13, N'Limarí', 5)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (14, N'Isla de Pascua', 6)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (15, N'Los Andes', 6)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (16, N'Petorca', 6)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (17, N'Quillota', 6)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (18, N'San Antonio', 6)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (19, N'San Felipe de Aconcagua', 6)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (20, N'Valparaiso', 6)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (21, N'Chacabuco', 7)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (22, N'Cordillera', 7)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (23, N'Maipo', 7)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (24, N'Melipilla', 7)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (25, N'Santiago', 7)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (26, N'Talagante', 7)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (27, N'Cachapoal', 8)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (28, N'Cardenal Caro', 8)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (29, N'Colchagua', 8)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (30, N'Cauquenes', 9)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (31, N'Curicó', 9)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (32, N'Linares', 9)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (33, N'Talca', 9)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (34, N'Arauco', 10)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (35, N'Bio Bío', 10)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (36, N'Concepción', 10)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (37, N'Ñuble', 10)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (38, N'Cautín', 11)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (39, N'Malleco', 11)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (40, N'Valdivia', 12)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (41, N'Ranco', 12)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (42, N'Chiloé', 13)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (43, N'Llanquihue', 13)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (44, N'Osorno', 13)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (45, N'Palena', 13)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (46, N'Aisén', 14)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (47, N'Capitán Prat', 14)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (48, N'Coihaique', 14)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (49, N'General Carrera', 14)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (50, N'Antártica Chilena', 15)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (51, N'Magallanes', 15)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (52, N'Tierra del Fuego', 15)
GO
INSERT [dbo].[Ciudad] ([id], [nombre], [id_region]) VALUES (53, N'Última Esperanza', 15)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (1, N'Arica', 1)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (2, N'Camarones', 1)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (3, N'General Lagos', 2)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (4, N'Putre', 2)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (5, N'Alto Hospicio', 3)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (6, N'Iquique', 3)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (7, N'Camiña', 4)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (8, N'Colchane', 4)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (9, N'Huara', 4)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (10, N'Pica', 4)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (11, N'Pozo Almonte', 4)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (12, N'Antofagasta', 5)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (13, N'Mejillones', 5)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (14, N'Sierra Gorda', 5)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (15, N'Taltal', 5)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (16, N'Calama', 6)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (17, N'Ollague', 6)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (18, N'San Pedro de Atacama', 6)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (19, N'María Elena', 7)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (20, N'Tocopilla', 7)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (21, N'Chañaral', 8)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (22, N'Diego de Almagro', 8)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (23, N'Caldera', 9)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (24, N'Copiapó', 9)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (25, N'Tierra Amarilla', 9)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (26, N'Alto del Carmen', 10)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (27, N'Freirina', 10)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (28, N'Huasco', 10)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (29, N'Vallenar', 10)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (30, N'Canela', 11)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (31, N'Illapel', 11)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (32, N'Los Vilos', 11)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (33, N'Salamanca', 11)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (34, N'Andacollo', 12)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (35, N'Coquimbo', 12)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (36, N'La Higuera', 12)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (37, N'La Serena', 12)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (38, N'Paihuaco', 12)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (39, N'Vicuña', 12)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (40, N'Combarbalá', 13)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (41, N'Monte Patria', 13)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (42, N'Ovalle', 13)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (43, N'Punitaqui', 13)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (44, N'Río Hurtado', 13)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (45, N'Isla de Pascua', 14)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (46, N'Calle Larga', 15)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (47, N'Los Andes', 15)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (48, N'Rinconada', 15)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (49, N'San Esteban', 15)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (50, N'La Ligua', 16)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (51, N'Papudo', 16)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (52, N'Petorca', 16)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (53, N'Zapallar', 16)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (54, N'Hijuelas', 17)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (55, N'La Calera', 17)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (56, N'La Cruz', 17)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (57, N'Limache', 17)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (58, N'Nogales', 17)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (59, N'Olmué', 17)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (60, N'Quillota', 17)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (61, N'Algarrobo', 18)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (62, N'Cartagena', 18)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (63, N'El Quisco', 18)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (64, N'El Tabo', 18)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (65, N'San Antonio', 18)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (66, N'Santo Domingo', 18)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (67, N'Catemu', 19)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (68, N'Llaillay', 19)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (69, N'Panquehue', 19)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (70, N'Putaendo', 19)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (71, N'San Felipe', 19)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (72, N'Santa María', 19)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (73, N'Casablanca', 20)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (74, N'Concón', 20)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (75, N'Juan Fernández', 20)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (76, N'Puchuncaví', 20)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (77, N'Quilpué', 20)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (78, N'Quintero', 20)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (79, N'Valparaíso', 20)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (80, N'Villa Alemana', 20)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (81, N'Viña del Mar', 20)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (82, N'Colina', 21)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (83, N'Lampa', 21)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (84, N'Tiltil', 21)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (85, N'Pirque', 22)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (86, N'Puente Alto', 22)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (87, N'San José de Maipo', 22)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (88, N'Buin', 23)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (89, N'Calera de Tango', 23)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (90, N'Paine', 23)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (91, N'San Bernardo', 23)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (92, N'Alhué', 24)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (93, N'Curacaví', 24)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (94, N'María Pinto', 24)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (95, N'Melipilla', 24)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (96, N'San Pedro', 24)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (97, N'Cerrillos', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (98, N'Cerro Navia', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (99, N'Conchalí', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (100, N'El Bosque', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (101, N'Estación Central', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (102, N'Huechuraba', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (103, N'Independencia', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (104, N'La Cisterna', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (105, N'La Granja', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (106, N'La Florida', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (107, N'La Pintana', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (108, N'La Reina', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (109, N'Las Condes', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (110, N'Lo Barnechea', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (111, N'Lo Espejo', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (112, N'Lo Prado', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (113, N'Macul', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (114, N'Maipú', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (115, N'Ñuñoa', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (116, N'Pedro Aguirre Cerda', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (117, N'Peñalolén', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (118, N'Providencia', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (119, N'Pudahuel', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (120, N'Quilicura', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (121, N'Quinta Normal', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (122, N'Recoleta', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (123, N'Renca', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (124, N'San Miguel', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (125, N'San Joaquín', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (126, N'San Ramón', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (127, N'Santiago', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (128, N'Vitacura', 25)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (129, N'El Monte', 26)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (130, N'Isla de Maipo', 26)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (131, N'Padre Hurtado', 26)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (132, N'Peñaflor', 26)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (133, N'Talagante', 26)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (134, N'Codegua', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (135, N'Coínco', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (136, N'Coltauco', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (137, N'Doñihue', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (138, N'Graneros', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (139, N'Las Cabras', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (140, N'Machalí', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (141, N'Malloa', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (142, N'Mostazal', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (143, N'Olivar', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (144, N'Peumo', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (145, N'Pichidegua', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (146, N'Quinta de Tilcoco', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (147, N'Rancagua', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (148, N'Rengo', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (149, N'Requínoa', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (150, N'San Vicente de Tagua Tagua', 27)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (151, N'La Estrella', 28)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (152, N'Litueche', 28)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (153, N'Marchihue', 28)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (154, N'Navidad', 28)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (155, N'Peredones', 28)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (156, N'Pichilemu', 28)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (157, N'Chépica', 29)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (158, N'Chimbarongo', 29)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (159, N'Lolol', 29)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (160, N'Nancagua', 29)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (161, N'Palmilla', 29)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (162, N'Peralillo', 29)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (163, N'Placilla', 29)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (164, N'Pumanque', 29)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (165, N'San Fernando', 29)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (166, N'Santa Cruz', 29)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (167, N'Cauquenes', 30)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (168, N'Chanco', 30)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (169, N'Pelluhue', 30)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (170, N'Curicó', 31)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (171, N'Hualañé', 31)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (172, N'Licantén', 31)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (173, N'Molina', 31)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (174, N'Rauco', 31)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (175, N'Romeral', 31)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (176, N'Sagrada Familia', 31)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (177, N'Teno', 31)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (178, N'Vichuquén', 31)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (179, N'Colbún', 32)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (180, N'Linares', 32)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (181, N'Longaví', 32)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (182, N'Parral', 32)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (183, N'Retiro', 32)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (184, N'San Javier', 32)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (185, N'Villa Alegre', 32)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (186, N'Yerbas Buenas', 32)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (187, N'Constitución', 33)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (188, N'Curepto', 33)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (189, N'Empedrado', 33)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (190, N'Maule', 33)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (191, N'Pelarco', 33)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (192, N'Pencahue', 33)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (193, N'Río Claro', 33)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (194, N'San Clemente', 33)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (195, N'San Rafael', 33)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (196, N'Talca', 33)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (197, N'Arauco', 34)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (198, N'Cañete', 34)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (199, N'Contulmo', 34)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (200, N'Curanilahue', 34)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (201, N'Lebu', 34)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (202, N'Los Álamos', 34)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (203, N'Tirúa', 34)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (204, N'Alto Biobío', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (205, N'Antuco', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (206, N'Cabrero', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (207, N'Laja', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (208, N'Los Ángeles', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (209, N'Mulchén', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (210, N'Nacimiento', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (211, N'Negrete', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (212, N'Quilaco', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (213, N'Quilleco', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (214, N'San Rosendo', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (215, N'Santa Bárbara', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (216, N'Tucapel', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (217, N'Yumbel', 35)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (218, N'Chiguayante', 36)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (219, N'Concepción', 36)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (220, N'Coronel', 36)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (221, N'Florida', 36)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (222, N'Hualpén', 36)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (223, N'Hualqui', 36)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (224, N'Lota', 36)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (225, N'Penco', 36)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (226, N'San Pedro de La Paz', 36)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (227, N'Santa Juana', 36)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (228, N'Talcahuano', 36)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (229, N'Tomé', 36)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (230, N'Bulnes', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (231, N'Chillán', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (232, N'Chillán Viejo', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (233, N'Cobquecura', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (234, N'Coelemu', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (235, N'Coihueco', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (236, N'El Carmen', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (237, N'Ninhue', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (238, N'Ñiquen', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (239, N'Pemuco', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (240, N'Pinto', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (241, N'Portezuelo', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (242, N'Quillón', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (243, N'Quirihue', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (244, N'Ránquil', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (245, N'San Carlos', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (246, N'San Fabián', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (247, N'San Ignacio', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (248, N'San Nicolás', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (249, N'Treguaco', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (250, N'Yungay', 37)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (251, N'Carahue', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (252, N'Cholchol', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (253, N'Cunco', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (254, N'Curarrehue', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (255, N'Freire', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (256, N'Galvarino', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (257, N'Gorbea', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (258, N'Lautaro', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (259, N'Loncoche', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (260, N'Melipeuco', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (261, N'Nueva Imperial', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (262, N'Padre Las Casas', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (263, N'Perquenco', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (264, N'Pitrufquén', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (265, N'Pucón', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (266, N'Saavedra', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (267, N'Temuco', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (268, N'Teodoro Schmidt', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (269, N'Toltén', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (270, N'Vilcún', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (271, N'Villarrica', 38)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (272, N'Angol', 39)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (273, N'Collipulli', 39)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (274, N'Curacautín', 39)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (275, N'Ercilla', 39)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (276, N'Lonquimay', 39)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (277, N'Los Sauces', 39)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (278, N'Lumaco', 39)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (279, N'Purén', 39)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (280, N'Renaico', 39)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (281, N'Traiguén', 39)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (282, N'Victoria', 39)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (283, N'Corral', 40)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (284, N'Lanco', 40)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (285, N'Los Lagos', 40)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (286, N'Máfil', 40)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (287, N'Mariquina', 40)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (288, N'Paillaco', 40)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (289, N'Panguipulli', 40)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (290, N'Valdivia', 40)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (291, N'Futrono', 41)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (292, N'La Unión', 41)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (293, N'Lago Ranco', 41)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (294, N'Río Bueno', 41)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (295, N'Ancud', 42)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (296, N'Castro', 42)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (297, N'Chonchi', 42)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (298, N'Curaco de Vélez', 42)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (299, N'Dalcahue', 42)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (300, N'Puqueldón', 42)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (301, N'Queilén', 42)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (302, N'Quemchi', 42)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (303, N'Quellón', 42)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (304, N'Quinchao', 42)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (305, N'Calbuco', 43)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (306, N'Cochamó', 43)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (307, N'Fresia', 43)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (308, N'Frutillar', 43)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (309, N'Llanquihue', 43)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (310, N'Los Muermos', 43)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (311, N'Maullín', 43)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (312, N'Puerto Montt', 43)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (313, N'Puerto Varas', 43)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (314, N'Osorno', 44)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (315, N'Puero Octay', 44)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (316, N'Purranque', 44)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (317, N'Puyehue', 44)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (318, N'Río Negro', 44)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (319, N'San Juan de la Costa', 44)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (320, N'San Pablo', 44)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (321, N'Chaitén', 45)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (322, N'Futaleufú', 45)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (323, N'Hualaihué', 45)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (324, N'Palena', 45)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (325, N'Aisén', 46)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (326, N'Cisnes', 46)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (327, N'Guaitecas', 46)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (328, N'Cochrane', 47)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (329, N'Ohiggins', 47)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (330, N'Tortel', 47)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (331, N'Coihaique', 48)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (332, N'Lago Verde', 48)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (333, N'Chile Chico', 49)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (334, N'Río Ibáñez', 49)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (335, N'Antártica', 50)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (336, N'Cabo de Hornos', 50)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (337, N'Laguna Blanca', 51)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (338, N'Punta Arenas', 51)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (339, N'Río Verde', 51)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (340, N'San Gregorio', 51)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (341, N'Porvenir', 52)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (342, N'Primavera', 52)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (343, N'Timaukel', 52)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (344, N'Natales', 53)
GO
INSERT [dbo].[Comuna] ([id], [nombre], [id_ciudad]) VALUES (345, N'Torres del Paine', 53)
GO
SET IDENTITY_INSERT [dbo].[Direccion] ON 
GO
INSERT [dbo].[Direccion] ([id], [calle], [numero], [id_comuna]) VALUES (1, N'sdfsdf', N'3434', 13)
GO
SET IDENTITY_INSERT [dbo].[Direccion] OFF
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (1, N'Abarth')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (2, N'Alfa Romeo')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (3, N'Aro')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (4, N'Asia')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (5, N'Asia Motors')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (6, N'Aston Martin')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (7, N'Audi')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (8, N'Austin')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (9, N'Auverland')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (10, N'Bentley')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (11, N'Bertone')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (12, N'Bmw')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (13, N'Cadillac')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (14, N'Chevrolet')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (15, N'Chrysler')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (16, N'Citroen')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (17, N'Corvette')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (18, N'Dacia')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (19, N'Daewoo')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (20, N'Daf')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (21, N'Daihatsu')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (22, N'Daimler')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (23, N'Dodge')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (24, N'Ferrari')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (25, N'Fiat')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (26, N'Ford')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (27, N'Galloper')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (28, N'Gmc')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (29, N'Honda')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (30, N'Hummer')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (31, N'Hyundai')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (32, N'Infiniti')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (33, N'Innocenti')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (34, N'Isuzu')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (35, N'Iveco')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (36, N'Iveco-pegaso')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (37, N'Jaguar')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (38, N'Jeep')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (39, N'Kia')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (40, N'Lada')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (41, N'Lamborghini')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (42, N'Lancia')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (43, N'Land-rover')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (44, N'Ldv')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (45, N'Lexus')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (46, N'Lotus')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (47, N'Mahindra')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (48, N'Maserati')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (49, N'Maybach')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (50, N'Mazda')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (51, N'Mercedes-benz')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (52, N'Mg')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (53, N'Mini')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (54, N'Mitsubishi')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (55, N'Morgan')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (56, N'Nissan')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (57, N'Opel')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (58, N'Peugeot')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (59, N'Pontiac')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (60, N'Porsche')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (61, N'Renault')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (62, N'Rolls-royce')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (63, N'Rover')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (64, N'Saab')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (65, N'Santana')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (66, N'Seat')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (67, N'Skoda')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (68, N'Smart')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (69, N'Ssangyong')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (70, N'Subaru')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (71, N'Suzuki')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (72, N'Talbot')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (73, N'Tata')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (74, N'Toyota')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (75, N'Umm')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (76, N'Vaz')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (77, N'Volkswagen')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (78, N'Volvo')
GO
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (79, N'Wartburg')
GO
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Modelo] ON 
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (1, N'500', 1)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (2, N'Grande Punto', 1)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (3, N'Punto Evo', 1)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (4, N'500c', 1)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (5, N'695', 1)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (6, N'Punto', 1)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (7, N'155', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (8, N'156', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (9, N'159', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (10, N'164', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (11, N'145', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (12, N'147', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (13, N'146', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (14, N'Gtv', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (15, N'Spider', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (16, N'166', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (17, N'Gt', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (18, N'Crosswagon', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (19, N'Brera', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (20, N'90', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (21, N'75', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (22, N'33', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (23, N'Giulietta', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (24, N'Sprint', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (25, N'Mito', 2)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (26, N'Expander', 3)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (27, N'10', 3)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (28, N'24', 3)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (29, N'Dacia', 3)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (30, N'Rocsta', 4)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (31, N'Rocsta', 5)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (32, N'Db7', 6)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (33, N'V8', 6)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (34, N'Db9', 6)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (35, N'Vanquish', 6)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (36, N'V8 Vantage', 6)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (37, N'Vantage', 6)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (38, N'Dbs', 6)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (39, N'Volante', 6)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (40, N'Virage', 6)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (41, N'Vantage V8', 6)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (42, N'Vantage V12', 6)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (43, N'Rapide', 6)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (44, N'Cygnet', 6)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (45, N'80', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (46, N'A4', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (47, N'A6', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (48, N'S6', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (49, N'Coupe', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (50, N'S2', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (51, N'Rs2', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (52, N'A8', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (53, N'Cabriolet', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (54, N'S8', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (55, N'A3', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (56, N'S4', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (57, N'Tt', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (58, N'S3', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (59, N'Allroad Quattro', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (60, N'Rs4', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (61, N'A2', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (62, N'Rs6', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (63, N'Q7', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (64, N'R8', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (65, N'A5', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (66, N'S5', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (67, N'V8', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (68, N'200', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (69, N'100', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (70, N'90', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (71, N'Tts', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (72, N'Q5', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (73, N'A4 Allroad Quattro', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (74, N'Tt Rs', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (75, N'Rs5', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (76, N'A1', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (77, N'A7', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (78, N'Rs3', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (79, N'Q3', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (80, N'A6 Allroad Quattro', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (81, N'S7', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (82, N'Sq5', 7)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (83, N'Mini', 8)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (84, N'Montego', 8)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (85, N'Maestro', 8)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (86, N'Metro', 8)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (87, N'Mini Moke', 8)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (88, N'Diesel', 9)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (89, N'Brooklands', 10)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (90, N'Turbo', 10)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (91, N'Continental', 10)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (92, N'Azure', 10)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (93, N'Arnage', 10)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (94, N'Continental Gt', 10)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (95, N'Continental Flying Spur', 10)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (96, N'Turbo R', 10)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (97, N'Mulsanne', 10)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (98, N'Eight', 10)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (99, N'Continental Gtc', 10)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (100, N'Continental Supersports', 10)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (101, N'Freeclimber Diesel', 11)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (102, N'Serie 3', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (103, N'Serie 5', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (104, N'Compact', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (105, N'Serie 7', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (106, N'Serie 8', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (107, N'Z3', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (108, N'Z4', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (109, N'Z8', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (110, N'X5', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (111, N'Serie 6', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (112, N'X3', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (113, N'Serie 1', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (114, N'Z1', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (115, N'X6', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (116, N'X1', 12)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (117, N'Seville', 13)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (118, N'Sts', 13)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (119, N'El Dorado', 13)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (120, N'Cts', 13)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (121, N'Xlr', 13)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (122, N'Srx', 13)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (123, N'Escalade', 13)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (124, N'Bls', 13)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (125, N'Corvette', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (126, N'Blazer', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (127, N'Astro', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (128, N'Nubira', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (129, N'Evanda', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (130, N'Trans Sport', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (131, N'Camaro', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (132, N'Matiz', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (133, N'Alero', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (134, N'Tahoe', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (135, N'Tacuma', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (136, N'Trailblazer', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (137, N'Kalos', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (138, N'Aveo', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (139, N'Lacetti', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (140, N'Epica', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (141, N'Captiva', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (142, N'Hhr', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (143, N'Cruze', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (144, N'Spark', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (145, N'Orlando', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (146, N'Volt', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (147, N'Malibu', 14)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (148, N'Vision', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (149, N'300m', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (150, N'Grand Voyager', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (151, N'Viper', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (152, N'Neon', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (153, N'Voyager', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (154, N'Stratus', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (155, N'Sebring', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (156, N'Sebring 200c', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (157, N'New Yorker', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (158, N'Pt Cruiser', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (159, N'Crossfire', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (160, N'300c', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (161, N'Le Baron', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (162, N'Saratoga', 15)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (163, N'Xantia', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (164, N'Xm', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (165, N'Ax', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (166, N'Zx', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (167, N'Evasion', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (168, N'C8', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (169, N'Saxo', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (170, N'C2', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (171, N'Xsara', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (172, N'C4', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (173, N'Xsara Picasso', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (174, N'C5', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (175, N'C3', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (176, N'C3 Pluriel', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (177, N'C1', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (178, N'C6', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (179, N'Grand C4 Picasso', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (180, N'C4 Picasso', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (181, N'Ccrosser', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (182, N'C15', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (183, N'Jumper', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (184, N'Jumpy', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (185, N'Berlingo', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (186, N'Bx', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (187, N'C25', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (188, N'Cx', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (189, N'Gsa', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (190, N'Visa', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (191, N'Lna', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (192, N'2cv', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (193, N'Nemo', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (194, N'C4 Sedan', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (195, N'Berlingo First', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (196, N'C3 Picasso', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (197, N'Ds3', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (198, N'Czero', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (199, N'Ds4', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (200, N'Ds5', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (201, N'C4 Aircross', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (202, N'Celysee', 16)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (203, N'Corvette', 17)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (204, N'Contac', 18)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (205, N'Logan', 18)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (206, N'Sandero', 18)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (207, N'Duster', 18)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (208, N'Lodgy', 18)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (209, N'Nexia', 19)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (210, N'Aranos', 19)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (211, N'Lanos', 19)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (212, N'Nubira', 19)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (213, N'Compact', 19)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (214, N'Nubira Compact', 19)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (215, N'Leganza', 19)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (216, N'Evanda', 19)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (217, N'Matiz', 19)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (218, N'Tacuma', 19)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (219, N'Kalos', 19)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (220, N'Lacetti', 19)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (221, N'Applause', 21)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (222, N'Charade', 21)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (223, N'Rocky', 21)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (224, N'Feroza', 21)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (225, N'Terios', 21)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (226, N'Sirion', 21)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (227, N'Serie Xj', 22)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (228, N'Xj', 22)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (229, N'Double Six', 22)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (230, N'Six', 22)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (231, N'Series Iii', 22)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (232, N'Viper', 23)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (233, N'Caliber', 23)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (234, N'Nitro', 23)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (235, N'Avenger', 23)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (236, N'Journey', 23)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (237, N'F355', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (238, N'360', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (239, N'F430', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (240, N'F512 M', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (241, N'550 Maranello', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (242, N'575m Maranello', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (243, N'599', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (244, N'456', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (245, N'456m', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (246, N'612', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (247, N'F50', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (248, N'Enzo', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (249, N'Superamerica', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (250, N'430', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (251, N'348', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (252, N'Testarossa', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (253, N'512', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (254, N'355', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (255, N'F40', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (256, N'412', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (257, N'Mondial', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (258, N'328', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (259, N'California', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (260, N'458', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (261, N'Ff', 24)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (262, N'Croma', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (263, N'Cinquecento', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (264, N'Seicento', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (265, N'Punto', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (266, N'Grande Punto', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (267, N'Panda', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (268, N'Tipo', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (269, N'Coupe', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (270, N'Uno', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (271, N'Ulysse', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (272, N'Tempra', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (273, N'Marea', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (274, N'Barchetta', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (275, N'Bravo', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (276, N'Stilo', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (277, N'Brava', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (278, N'Palio Weekend', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (279, N'600', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (280, N'Multipla', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (281, N'Idea', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (282, N'Sedici', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (283, N'Linea', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (284, N'500', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (285, N'Fiorino', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (286, N'Ducato', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (287, N'Doblo Cargo', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (288, N'Doblo', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (289, N'Strada', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (290, N'Regata', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (291, N'Talento', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (292, N'Argenta', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (293, N'Ritmo', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (294, N'Punto Classic', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (295, N'Qubo', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (296, N'Punto Evo', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (297, N'500c', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (298, N'Freemont', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (299, N'Panda Classic', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (300, N'500l', 25)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (301, N'Maverick', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (302, N'Escort', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (303, N'Focus', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (304, N'Mondeo', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (305, N'Scorpio', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (306, N'Fiesta', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (307, N'Probe', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (308, N'Explorer', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (309, N'Galaxy', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (310, N'Ka', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (311, N'Puma', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (312, N'Cougar', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (313, N'Focus Cmax', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (314, N'Fusion', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (315, N'Streetka', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (316, N'Cmax', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (317, N'Smax', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (318, N'Transit', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (319, N'Courier', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (320, N'Ranger', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (321, N'Sierra', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (322, N'Orion', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (323, N'Pick Up', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (324, N'Capri', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (325, N'Granada', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (326, N'Kuga', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (327, N'Grand Cmax', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (328, N'Bmax', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (329, N'Tourneo Custom', 26)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (330, N'Exceed', 27)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (331, N'Santamo', 27)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (332, N'Super Exceed', 27)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (333, N'Accord', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (334, N'Civic', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (335, N'Crx', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (336, N'Prelude', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (337, N'Nsx', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (338, N'Legend', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (339, N'Crv', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (340, N'Hrv', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (341, N'Logo', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (342, N'S2000', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (343, N'Stream', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (344, N'Jazz', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (345, N'Frv', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (346, N'Concerto', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (347, N'Insight', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (348, N'Crz', 29)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (349, N'H2', 30)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (350, N'H3', 30)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (351, N'H3t', 30)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (352, N'Lantra', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (353, N'Sonata', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (354, N'Elantra', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (355, N'Accent', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (356, N'Scoupe', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (357, N'Coupe', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (358, N'Atos', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (359, N'H1', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (360, N'Atos Prime', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (361, N'Xg', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (362, N'Trajet', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (363, N'Santa Fe', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (364, N'Terracan', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (365, N'Matrix', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (366, N'Getz', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (367, N'Tucson', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (368, N'I30', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (369, N'Pony', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (370, N'Grandeur', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (371, N'I10', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (372, N'I800', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (373, N'Sonata Fl', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (374, N'Ix55', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (375, N'I20', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (376, N'Ix35', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (377, N'Ix20', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (378, N'Genesis', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (379, N'I40', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (380, N'Veloster', 31)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (381, N'G', 32)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (382, N'Ex', 32)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (383, N'Fx', 32)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (384, N'M', 32)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (385, N'Elba', 33)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (386, N'Minitre', 33)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (387, N'Trooper', 34)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (388, N'Pick Up', 34)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (389, N'D Max', 34)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (390, N'Rodeo', 34)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (391, N'Dmax', 34)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (392, N'Trroper', 34)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (393, N'Daily', 35)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (394, N'Massif', 35)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (395, N'Daily', 36)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (396, N'Duty', 36)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (397, N'Serie Xj', 37)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (398, N'Serie Xk', 37)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (399, N'Xj', 37)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (400, N'Stype', 37)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (401, N'Xf', 37)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (402, N'Xtype', 37)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (403, N'Wrangler', 38)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (404, N'Cherokee', 38)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (405, N'Grand Cherokee', 38)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (406, N'Commander', 38)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (407, N'Compass', 38)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (408, N'Wrangler Unlimited', 38)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (409, N'Patriot', 38)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (410, N'Sportage', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (411, N'Sephia', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (412, N'Sephia Ii', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (413, N'Pride', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (414, N'Clarus', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (415, N'Shuma', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (416, N'Carnival', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (417, N'Joice', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (418, N'Magentis', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (419, N'Carens', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (420, N'Rio', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (421, N'Cerato', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (422, N'Sorento', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (423, N'Opirus', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (424, N'Picanto', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (425, N'Ceed', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (426, N'Ceed Sporty Wagon', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (427, N'Proceed', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (428, N'K2500 Frontier', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (429, N'K2500', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (430, N'Soul', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (431, N'Venga', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (432, N'Optima', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (433, N'Ceed Sportswagon', 39)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (434, N'Samara', 40)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (435, N'Niva', 40)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (436, N'Sagona', 40)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (437, N'Stawra 2110', 40)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (438, N'214', 40)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (439, N'Kalina', 40)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (440, N'Serie 2100', 40)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (441, N'Priora', 40)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (442, N'Gallardo', 41)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (443, N'Murcielago', 41)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (444, N'Aventador', 41)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (445, N'Delta', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (446, N'K', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (447, N'Y10', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (448, N'Dedra', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (449, N'Lybra', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (450, N'Z', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (451, N'Y', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (452, N'Ypsilon', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (453, N'Thesis', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (454, N'Phedra', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (455, N'Musa', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (456, N'Thema', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (457, N'Zeta', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (458, N'Kappa', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (459, N'Trevi', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (460, N'Prisma', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (461, N'A112', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (462, N'Ypsilon Elefantino', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (463, N'Voyager', 42)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (464, N'Range Rover', 43)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (465, N'Defender', 43)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (466, N'Discovery', 43)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (467, N'Freelander', 43)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (468, N'Range Rover Sport', 43)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (469, N'Discovery 4', 43)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (470, N'Range Rover Evoque', 43)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (471, N'Maxus', 44)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (472, N'Ls400', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (473, N'Ls430', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (474, N'Gs300', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (475, N'Is200', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (476, N'Rx300', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (477, N'Gs430', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (478, N'Gs460', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (479, N'Sc430', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (480, N'Is300', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (481, N'Is250', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (482, N'Rx400h', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (483, N'Is220d', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (484, N'Rx350', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (485, N'Gs450h', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (486, N'Ls460', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (487, N'Ls600h', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (488, N'Ls', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (489, N'Gs', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (490, N'Is', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (491, N'Sc', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (492, N'Rx', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (493, N'Ct', 45)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (494, N'Elise', 46)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (495, N'Exige', 46)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (496, N'Bolero Pickup', 47)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (497, N'Goa Pickup', 47)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (498, N'Goa', 47)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (499, N'Cj', 47)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (500, N'Pikup', 47)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (501, N'Thar', 47)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (502, N'Ghibli', 48)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (503, N'Shamal', 48)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (504, N'Quattroporte', 48)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (505, N'3200 Gt', 48)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (506, N'Coupe', 48)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (507, N'Spyder', 48)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (508, N'Gransport', 48)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (509, N'Granturismo', 48)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (510, N'430', 48)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (511, N'Biturbo', 48)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (512, N'228', 48)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (513, N'224', 48)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (514, N'Grancabrio', 48)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (515, N'Maybach', 49)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (516, N'Xedos 6', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (517, N'626', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (518, N'121', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (519, N'Xedos 9', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (520, N'323', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (521, N'Mx3', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (522, N'Rx7', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (523, N'Mx5', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (524, N'Mazda3', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (525, N'Mpv', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (526, N'Demio', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (527, N'Premacy', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (528, N'Tribute', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (529, N'Mazda6', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (530, N'Mazda2', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (531, N'Rx8', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (532, N'Mazda5', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (533, N'Cx7', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (534, N'Serie B', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (535, N'B2500', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (536, N'Bt50', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (537, N'Mx6', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (538, N'929', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (539, N'Cx5', 50)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (540, N'Clase C', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (541, N'Clase E', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (542, N'Clase Sl', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (543, N'Clase S', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (544, N'Clase Cl', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (545, N'Clase G', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (546, N'Clase Slk', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (547, N'Clase V', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (548, N'Viano', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (549, N'Clase Clk', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (550, N'Clase A', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (551, N'Clase M', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (552, N'Vaneo', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (553, N'Slklasse', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (554, N'Slr Mclaren', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (555, N'Clase Cls', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (556, N'Clase R', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (557, N'Clase Gl', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (558, N'Clase B', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (559, N'100d', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (560, N'140d', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (561, N'180d', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (562, N'Sprinter', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (563, N'Vito', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (564, N'Transporter', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (565, N'280', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (566, N'220', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (567, N'200', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (568, N'190', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (569, N'600', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (570, N'400', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (571, N'Clase Sl R129', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (572, N'300', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (573, N'500', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (574, N'420', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (575, N'260', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (576, N'230', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (577, N'Clase Clc', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (578, N'Clase Glk', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (579, N'Sls Amg', 51)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (580, N'Mgf', 52)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (581, N'Tf', 52)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (582, N'Zr', 52)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (583, N'Zs', 52)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (584, N'Zt', 52)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (585, N'Ztt', 52)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (586, N'Mini', 52)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (587, N'Countryman', 52)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (588, N'Paceman', 52)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (589, N'Montero', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (590, N'Galant', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (591, N'Colt', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (592, N'Space Wagon', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (593, N'Space Runner', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (594, N'Space Gear', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (595, N'3000 Gt', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (596, N'Carisma', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (597, N'Eclipse', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (598, N'Space Star', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (599, N'Montero Sport', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (600, N'Montero Io', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (601, N'Outlander', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (602, N'Lancer', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (603, N'Grandis', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (604, N'L200', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (605, N'Canter', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (606, N'300 Gt', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (607, N'Asx', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (608, N'Imiev', 54)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (609, N'44', 55)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (610, N'Plus 8', 55)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (611, N'Aero 8', 55)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (612, N'V6', 55)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (613, N'Roadster', 55)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (614, N'4', 55)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (615, N'Plus 4', 55)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (616, N'Terrano Ii', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (617, N'Terrano', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (618, N'Micra', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (619, N'Sunny', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (620, N'Primera', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (621, N'Serena', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (622, N'Patrol', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (623, N'Maxima Qx', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (624, N'200 Sx', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (625, N'300 Zx', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (626, N'Patrol Gr', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (627, N'100 Nx', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (628, N'Almera', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (629, N'Pathfinder', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (630, N'Almera Tino', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (631, N'Xtrail', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (632, N'350z', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (633, N'Murano', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (634, N'Note', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (635, N'Qashqai', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (636, N'Tiida', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (637, N'Vanette', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (638, N'Trade', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (639, N'Vanette Cargo', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (640, N'Pickup', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (641, N'Navara', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (642, N'Cabstar E', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (643, N'Cabstar', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (644, N'Maxima', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (645, N'Camion', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (646, N'Prairie', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (647, N'Bluebird', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (648, N'Np300 Pick Up', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (649, N'Qashqai2', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (650, N'Pixo', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (651, N'Gtr', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (652, N'370z', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (653, N'Cube', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (654, N'Juke', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (655, N'Leaf', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (656, N'Evalia', 56)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (657, N'Astra', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (658, N'Vectra', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (659, N'Calibra', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (660, N'Corsa', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (661, N'Omega', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (662, N'Frontera', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (663, N'Tigra', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (664, N'Monterey', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (665, N'Sintra', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (666, N'Zafira', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (667, N'Agila', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (668, N'Speedster', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (669, N'Signum', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (670, N'Meriva', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (671, N'Antara', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (672, N'Gt', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (673, N'Combo', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (674, N'Movano', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (675, N'Vivaro', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (676, N'Kadett', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (677, N'Monza', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (678, N'Senator', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (679, N'Rekord', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (680, N'Manta', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (681, N'Ascona', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (682, N'Insignia', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (683, N'Zafira Tourer', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (684, N'Ampera', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (685, N'Mokka', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (686, N'Adam', 57)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (687, N'306', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (688, N'605', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (689, N'106', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (690, N'205', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (691, N'405', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (692, N'406', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (693, N'806', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (694, N'807', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (695, N'407', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (696, N'307', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (697, N'206', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (698, N'607', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (699, N'308', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (700, N'307 Sw', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (701, N'206 Sw', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (702, N'407 Sw', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (703, N'1007', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (704, N'107', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (705, N'207', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (706, N'4007', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (707, N'Boxer', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (708, N'Partner', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (709, N'J5', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (710, N'604', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (711, N'505', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (712, N'309', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (713, N'Bipper', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (714, N'Partner Origin', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (715, N'3008', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (716, N'5008', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (717, N'Rcz', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (718, N'508', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (719, N'Ion', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (720, N'208', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (721, N'4008', 58)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (722, N'Trans Sport', 59)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (723, N'Firebird', 59)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (724, N'Trans Am', 59)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (725, N'911', 60)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (726, N'Boxster', 60)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (727, N'Cayenne', 60)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (728, N'Carrera Gt', 60)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (729, N'Cayman', 60)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (730, N'928', 60)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (731, N'968', 60)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (732, N'944', 60)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (733, N'924', 60)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (734, N'Panamera', 60)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (735, N'918', 60)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (736, N'Megane', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (737, N'Safrane', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (738, N'Laguna', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (739, N'Clio', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (740, N'Twingo', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (741, N'Nevada', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (742, N'Espace', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (743, N'Spider', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (744, N'Scenic', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (745, N'Grand Espace', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (746, N'Avantime', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (747, N'Vel Satis', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (748, N'Grand Scenic', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (749, N'Clio Campus', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (750, N'Modus', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (751, N'Express', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (752, N'Trafic', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (753, N'Master', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (754, N'Kangoo', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (755, N'Mascott', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (756, N'Master Propulsion', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (757, N'Maxity', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (758, N'R19', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (759, N'R25', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (760, N'R5', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (761, N'R21', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (762, N'R4', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (763, N'Alpine', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (764, N'Fuego', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (765, N'R18', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (766, N'R11', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (767, N'R9', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (768, N'R6', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (769, N'Grand Modus', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (770, N'Kangoo Combi', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (771, N'Koleos', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (772, N'Fluence', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (773, N'Wind', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (774, N'Latitude', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (775, N'Grand Kangoo Combi', 61)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (776, N'Siver Dawn', 62)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (777, N'Silver Spur', 62)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (778, N'Park Ward', 62)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (779, N'Silver Seraph', 62)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (780, N'Corniche', 62)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (781, N'Phantom', 62)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (782, N'Touring', 62)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (783, N'Silvier', 62)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (784, N'800', 63)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (785, N'600', 63)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (786, N'100', 63)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (787, N'200', 63)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (788, N'Coupe', 63)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (789, N'400', 63)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (790, N'45', 63)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (791, N'Cabriolet', 63)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (792, N'25', 63)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (793, N'Mini', 63)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (794, N'75', 63)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (795, N'Streetwise', 63)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (796, N'Sd', 63)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (797, N'900', 64)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (798, N'93', 64)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (799, N'9000', 64)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (800, N'95', 64)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (801, N'93x', 64)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (802, N'94x', 64)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (803, N'300', 65)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (804, N'350', 65)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (805, N'Anibal', 65)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (806, N'Anibal Pick Up', 65)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (807, N'Ibiza', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (808, N'Cordoba', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (809, N'Toledo', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (810, N'Marbella', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (811, N'Alhambra', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (812, N'Arosa', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (813, N'Leon', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (814, N'Altea', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (815, N'Altea Xl', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (816, N'Altea Freetrack', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (817, N'Terra', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (818, N'Inca', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (819, N'Malaga', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (820, N'Ronda', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (821, N'Exeo', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (822, N'Mii', 66)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (823, N'Felicia', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (824, N'Forman', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (825, N'Octavia', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (826, N'Octavia Tour', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (827, N'Fabia', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (828, N'Superb', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (829, N'Roomster', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (830, N'Scout', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (831, N'Pickup', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (832, N'Favorit', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (833, N'130', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (834, N'S', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (835, N'Yeti', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (836, N'Citigo', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (837, N'Rapid', 67)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (838, N'Smart', 68)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (839, N'Citycoupe', 68)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (840, N'Fortwo', 68)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (841, N'Cabrio', 68)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (842, N'Crossblade', 68)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (843, N'Roadster', 68)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (844, N'Forfour', 68)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (845, N'Korando', 69)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (846, N'Family', 69)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (847, N'K4d', 69)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (848, N'Musso', 69)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (849, N'Korando Kj', 69)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (850, N'Rexton', 69)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (851, N'Rexton Ii', 69)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (852, N'Rodius', 69)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (853, N'Kyron', 69)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (854, N'Actyon', 69)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (855, N'Sports Pick Up', 69)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (856, N'Actyon Sports Pick Up', 69)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (857, N'Kodando', 69)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (858, N'Legacy', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (859, N'Impreza', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (860, N'Svx', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (861, N'Justy', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (862, N'Outback', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (863, N'Forester', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (864, N'G3x Justy', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (865, N'B9 Tribeca', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (866, N'Xt', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (867, N'1800', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (868, N'Tribeca', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (869, N'Wrx Sti', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (870, N'Trezia', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (871, N'Xv', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (872, N'Brz', 70)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (873, N'Maruti', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (874, N'Swift', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (875, N'Vitara', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (876, N'Baleno', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (877, N'Samurai', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (878, N'Alto', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (879, N'Wagon R', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (880, N'Jimny', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (881, N'Grand Vitara', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (882, N'Ignis', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (883, N'Liana', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (884, N'Grand Vitara Xl7', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (885, N'Sx4', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (886, N'Splash', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (887, N'Kizashi', 71)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (888, N'Samba', 72)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (889, N'Tagora', 72)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (890, N'Solara', 72)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (891, N'Horizon', 72)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (892, N'Telcosport', 73)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (893, N'Telco', 73)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (894, N'Sumo', 73)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (895, N'Safari', 73)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (896, N'Indica', 73)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (897, N'Indigo', 73)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (898, N'Grand Safari', 73)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (899, N'Tl Pick Up', 73)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (900, N'Xenon Pick Up', 73)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (901, N'Vista', 73)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (902, N'Xenon', 73)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (903, N'Aria', 73)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (904, N'Carina E', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (905, N'4runner', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (906, N'Camry', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (907, N'Rav4', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (908, N'Celica', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (909, N'Supra', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (910, N'Paseo', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (911, N'Land Cruiser 80', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (912, N'Land Cruiser 100', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (913, N'Land Cruiser', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (914, N'Land Cruiser 90', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (915, N'Corolla', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (916, N'Auris', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (917, N'Avensis', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (918, N'Picnic', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (919, N'Yaris', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (920, N'Yaris Verso', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (921, N'Mr2', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (922, N'Previa', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (923, N'Prius', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (924, N'Avensis Verso', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (925, N'Corolla Verso', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (926, N'Corolla Sedan', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (927, N'Aygo', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (928, N'Hilux', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (929, N'Dyna', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (930, N'Land Cruiser 200', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (931, N'Verso', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (932, N'Iq', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (933, N'Urban Cruiser', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (934, N'Gt86', 74)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (935, N'100', 75)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (936, N'121', 75)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (937, N'214', 76)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (938, N'110 Stawra', 76)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (939, N'111 Stawra', 76)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (940, N'215', 76)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (941, N'112 Stawra', 76)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (942, N'Passat', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (943, N'Golf', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (944, N'Vento', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (945, N'Polo', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (946, N'Corrado', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (947, N'Sharan', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (948, N'Lupo', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (949, N'Bora', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (950, N'Jetta', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (951, N'New Beetle', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (952, N'Phaeton', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (953, N'Touareg', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (954, N'Touran', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (955, N'Multivan', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (956, N'Caddy', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (957, N'Golf Plus', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (958, N'Fox', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (959, N'Eos', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (960, N'Caravelle', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (961, N'Tiguan', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (962, N'Transporter', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (963, N'Lt', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (964, N'Taro', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (965, N'Crafter', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (966, N'California', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (967, N'Santana', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (968, N'Scirocco', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (969, N'Passat Cc', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (970, N'Amarok', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (971, N'Beetle', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (972, N'Up', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (973, N'Cc', 77)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (974, N'440', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (975, N'850', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (976, N'S70', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (977, N'V70', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (978, N'V70 Classic', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (979, N'940', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (980, N'480', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (981, N'460', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (982, N'960', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (983, N'S90', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (984, N'V90', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (985, N'Classic', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (986, N'S40', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (987, N'V40', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (988, N'V50', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (989, N'V70 Xc', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (990, N'Xc70', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (991, N'C70', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (992, N'S80', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (993, N'S60', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (994, N'Xc90', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (995, N'C30', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (996, N'780', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (997, N'760', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (998, N'740', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (999, N'240', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (1000, N'360', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (1001, N'340', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (1002, N'Xc60', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (1003, N'V60', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (1004, N'V40 Cross Country', 78)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (1005, N'353', 79)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (1006, N'Mini', 53)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (1007, N'Countryman', 53)
GO
INSERT [dbo].[Modelo] ([id], [nombre], [id_marca]) VALUES (1008, N'Paceman', 53)
GO
SET IDENTITY_INSERT [dbo].[Modelo] OFF
GO
SET IDENTITY_INSERT [dbo].[Pais] ON 
GO
INSERT [dbo].[Pais] ([id], [nombre], [activo]) VALUES (1, N'Chile', 1)
GO
INSERT [dbo].[Pais] ([id], [nombre], [activo]) VALUES (2, N'Italia', 1)
GO
INSERT [dbo].[Pais] ([id], [nombre], [activo]) VALUES (3, N'Estados Unidos', 1)
GO
INSERT [dbo].[Pais] ([id], [nombre], [activo]) VALUES (4, N'Alemania', 1)
GO
SET IDENTITY_INSERT [dbo].[Pais] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 
GO
INSERT [dbo].[Persona] ([id], [id_direccion], [rut], [dv], [nombres], [apellidos], [fec_nacimiento], [email], [telefono]) VALUES (1, 1, 19025977, N'3', N'david', N'moya', CAST(N'2020-03-18T00:00:00' AS SmallDateTime), N'sfsdfsdfs@sgfsdf.cl', N'234234')
GO
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET IDENTITY_INSERT [dbo].[Region] ON 
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (1, N'Arica y Parinacota')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (2, N'Tarapacá')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (3, N'Antofagasta')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (4, N'Atacama')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (5, N'Coquimbo')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (6, N'Valparaiso')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (7, N'Metropolitana de Santiago')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (8, N'Libertador General Bernardo OHiggins')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (9, N'Maule')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (10, N'Biobío')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (11, N'La Araucanía')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (12, N'Los Ríos')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (13, N'Los Lagos')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (14, N'Aisén del General Carlos Ibáñez del Campo')
GO
INSERT [dbo].[Region] ([id], [nombre]) VALUES (15, N'Magallanes y de la Antártica Chilena')
GO
SET IDENTITY_INSERT [dbo].[Region] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoCombustible] ON 
GO
INSERT [dbo].[TipoCombustible] ([id], [nombre]) VALUES (1, N'Gasolina 93')
GO
INSERT [dbo].[TipoCombustible] ([id], [nombre]) VALUES (2, N'Gasolina 95')
GO
INSERT [dbo].[TipoCombustible] ([id], [nombre]) VALUES (3, N'Gasolina 97')
GO
INSERT [dbo].[TipoCombustible] ([id], [nombre]) VALUES (4, N'Diesel')
GO
INSERT [dbo].[TipoCombustible] ([id], [nombre]) VALUES (5, N'Petroleo')
GO
SET IDENTITY_INSERT [dbo].[TipoCombustible] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoPago] ON 
GO
INSERT [dbo].[TipoPago] ([id], [nombre], [activo]) VALUES (1, N'Pago PAC', 1)
GO
INSERT [dbo].[TipoPago] ([id], [nombre], [activo]) VALUES (2, N'Pago PAT', 1)
GO
SET IDENTITY_INSERT [dbo].[TipoPago] OFF
GO
INSERT [dbo].[TipoTarjetaCredito] ([id], [nombre], [activo]) VALUES (0, N'Sin Tarjeta', 1)
GO
INSERT [dbo].[TipoTarjetaCredito] ([id], [nombre], [activo]) VALUES (1, N'Visa', 1)
GO
INSERT [dbo].[TipoTarjetaCredito] ([id], [nombre], [activo]) VALUES (2, N'MasterCard', 1)
GO
INSERT [dbo].[TipoTarjetaCredito] ([id], [nombre], [activo]) VALUES (3, N'Dinners', 1)
GO
INSERT [dbo].[TipoTarjetaCredito] ([id], [nombre], [activo]) VALUES (4, N'American Express', 1)
GO
SET IDENTITY_INSERT [dbo].[TipoVehiculo] ON 
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (1, N'Microauto', N'Son más reconocidos en Europa donde los llaman Microcar. Son vehículos con capacidad máxima para dos pasajeros. Normalmente circulan con motores bajo los 1.000 cc. En las categorías, se ubican bajo el Segmento A. Ejemplos de ellos: Smart Fortwo, BMW Isetta y Tata Nano.', 1)
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (3, N'Hatchback', N'La traducción del inglés es vehículos compactos. Estos modelos muestran una apariencia cortada, ya que no cuentan con cola y el portalón trasero se abre junto al parabrisas. Es decir, solo poseen dos volúmenes, como el Opel Corsa.', 1)
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (4, N'Sedán', N'La forma más fácil y básica de entender esta clasificación es saber que estos autos se componen de capó, techo y puerta de maletero que se abre sin mover el parabrisas posterior. Popularmente se dice que cuenta con cola, como el Nissan Sentra, por ejemplo.', 1)
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (5, N'SUV', N'Son los modelos que lideran la tendencia en el mercado mundial. Su nombre es la sigla de Sport Utility Vehicle y aproximadamente llevan una década circulando en el mundo. Están orientados a ofrecer confortabilidad en espacio combinado con un modelo que pueda servir para diferentes terrenos. Aunque se privilegia más la comodidad y el estilo.', 1)
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (6, N'TodoTerreno', N'Son vehículos que han sido concebidos para enfrentar todo tipo de caminos, ya sea arena, barro y piedras. Es por ello que están dotados de motores altamente capaces, tracción en las cuatro ruedas, cajas de cambios con avanzada tecnología y antiguamente agregaban una transmisión reductora. Antes no se enfocaban en la comodidad de los pasajeros, pero hoy es muy común encontrar modelos aptos y confortables para la aventura, como el Jeep Wrangler.', 1)
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (8, N'Coupé', N'Esta palabra en francés quiere decir “cortado”. La carrocería de estos modelos es de dos o tres volumenes, pero siempre con dos puertas en sus costados. Si bien puedan entrar cuatro personas en su interior, las plazas traseras son muy angostas e incómodas para que vayan pasajeros adultos allí. Estos modelos son parte del grupo de los deportivos. El Honda Civic Coupé de la foto es un buen ejemplo.', 1)
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (10, N'Cabrio', N'También son llamados convertibles, cabriolet o descapotables. Son autos a los que se les puede sacar o guardar el techo y así el habitáculo queda descubierto. La capota (el techo) antiguamente siempre era de lona, pero hoy también puede ser plástico o metal. La carrocería también está formada con dos puertas laterales.', 1)
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (11, N'Spider', N'Estos son deportivos descapotables aptos para dos personas. Dependiendo de la marca es la elección del nombre entre Spider (italiano) y Roadster (inglés). Son vehículos de tracción trasera y que, por lo general, son muy livianos en peso. De hecho ese es uno de los motivos por los que consiguen una alta potencia.Por segmento', 1)
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (12, N'Segmento A', N'Los vehículos que alojan están especialmente hechos para circular fácilmente por la ciudad. Son más grandes que los Microautos, aunque su longitud no debiese pasar los 3400 mm, y cuentan con bloques más potentes. En Chile es más popular llamarlos Citycar. Uno claro ejemplo de éstos el Suzuki Maruti o el BYD F0.', 1)
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (13, N'Segmento B', N'En algunos continentes son identificados como subcompactos. Estos vehículos pueden contar con tres, cuatro y hasta cinco puertas. En los automóviles de esta categoría es común ver a jóvenes, no obstante, también pueden albergar sin problemas a cuatro pasajeros y en algunos casos cinco. Un prototipo para este grupo es Renault Clio y Peugeot 208, entre otros.', 1)
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (14, N'Segmento C', N'Están construidos con cinco puertas y pueden trasladar hasta cinco pasajeros. Habitualmente son sedanes los que ocupan esta calificación con propulsores de entre 1,4 y 2 litros. Esta fue una de las categorías más requeridas en los 90 y un claro ejemplo de ello es el automóvil más vendido del mundo, el Toyota Corolla.', 1)
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (15, N'Segmento D', N'Acá entran las berlinas o automóviles familiares. Son autos aptos para cinco personas, con motores potentes que pueden llegar hasta los 2,5 litros. Una de sus características principales son el espacio y capacidad que otorgan en su interior y maletero. El Mazda 6 calza con este perfil.', 1)
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (16, N'Segmento E', N'Esta sección se posiciona entre la D y F. Son los autos más grandes que las marcas fabrican en serie. También son modelos de carrocería tipo sedán con espacio para cinco pasajeros. Aunque acá si que se enfocan en entregar la mayor holgura del pasajero en el habitáculo. Sus dimensiones fluctúan entre 4,60 y 5 metros. Los también denominados vehículos familiares, son impulsados con bloques de altas prestaciones, que pueden comenzar en los 2 litros y llegar hasta los 5. Para hacerse una idea, un automóvil que se apega mucho a este segmento es el BMW Serie 5.', 1)
GO
INSERT [dbo].[TipoVehiculo] ([id], [nombre], [descripcion], [activo]) VALUES (17, N'Segmento F', N'Habitualmente son los identificados como vehículos de lujo, con propulsores de alta potencia y que sus medidas de largo superan los 5 metros. Su carrocería siempre toma forma tipo sedán. El Mercedes-Benz Clase S y el Jaguar XJ pertenecen a este grupo.', 1)
GO
SET IDENTITY_INSERT [dbo].[TipoVehiculo] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([id], [id_persona], [clave], [fecha_registro], [activo]) VALUES (1, 1, N'123', CAST(N'2020-03-01T00:00:00' AS SmallDateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehiculo] ON 
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (1, 442, 8, 3, 2, 2020, N'Rojo', 70000000, 10)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (2, 442, 8, 3, 2, 2013, N'VERDE', 100000000, 44)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (3, 442, 8, 3, 2, 2012, N'AZUL', 90000000, 5)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (4, 443, 8, 3, 2, 2020, N'VERDE', 250000000, 12)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (5, 443, 8, 3, 2, 2012, N'AZUL', 70000000, 43)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (6, 443, 8, 3, 2, 2015, N'AMARILLO', 120000000, 334)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (7, 444, 8, 3, 2, 2019, N'AMARILLO', 220000000, 45)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (8, 444, 8, 3, 2, 2018, N'ROJO', 200000000, 5)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (9, 444, 8, 3, 2, 2017, N'PURPURA', 180000000, 45)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (10, 131, 8, 3, 3, 2020, N'ROJO', 60000000, 6)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (11, 131, 8, 3, 3, 2018, N'VERDE', 50000000, 6)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (12, 131, 8, 3, 3, 2017, N'NARANJO', 40000000, 9)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (13, 144, 3, 1, 3, 2020, N'NARANJO', 4000000, 67)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (14, 144, 3, 1, 3, 2013, N'GRAFITO', 3000000, 6)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (15, 144, 3, 1, 3, 2017, N'NEGRO', 3800000, 67)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (16, 64, 8, 4, 2, 2020, N'BLANCO', 100000000, 45)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (17, 64, 8, 4, 2, 2020, N'NEGRO', 100000000, 34)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (18, 64, 8, 4, 2, 2020, N'GRIS', 100000000, 87)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (19, 507, 11, 3, 2, 2020, N'ROJO', 120000000, 90)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (20, 507, 11, 3, 2, 2013, N'NEGRO', 90000000, 65)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (21, 507, 11, 3, 2, 2016, N'AZUL', 100000000, 98)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (22, 3, 5, 3, 2, 2018, N'Blanco', 1200000, 0)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (23, 2, 3, 2, 4, 2020, N'Amarillo', 2000000, 13)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (24, 5, 4, 1, 1, 2020, N'Celeste', 4500000, 23)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (25, 9, 5, 2, 3, 2020, N'Azul', 5400000, 244)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (26, 27, 3, 2, 1, 2019, N'Seleccione...', 7878787, 6)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (27, 2, 10, 1, 1, 2020, N'Amarillo', 2000000, 0)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (28, 30, 3, 2, 3, 2019, N'Amarillo', 4564564, 34)
GO
INSERT [dbo].[Vehiculo] ([id], [id_modelo], [id_tipo_vehiculo], [id_tipo_combustible], [id_pais_origen], [anio], [color], [precio], [stock]) VALUES (29, 30, 3, 1, 2, 2019, N'Amarillo', 1990000, 0)
GO
SET IDENTITY_INSERT [dbo].[Vehiculo] OFF
GO
/****** Object:  Index [UQ_Persona]    Script Date: 14-06-2020 1:47:29 ******/
ALTER TABLE [dbo].[Persona] ADD  CONSTRAINT [UQ_Persona] UNIQUE NONCLUSTERED 
(
	[rut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TipoVehiculo] ADD  CONSTRAINT [DF_TipoVehiculo_descripcion]  DEFAULT ('') FOR [descripcion]
GO
ALTER TABLE [dbo].[Vehiculo] ADD  CONSTRAINT [DF_Vehiculo_stock]  DEFAULT ((0)) FOR [stock]
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Region] FOREIGN KEY([id_region])
REFERENCES [dbo].[Region] ([id])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_Region]
GO
ALTER TABLE [dbo].[Comuna]  WITH CHECK ADD  CONSTRAINT [FK_Comuna_Comuna] FOREIGN KEY([id_ciudad])
REFERENCES [dbo].[Ciudad] ([id])
GO
ALTER TABLE [dbo].[Comuna] CHECK CONSTRAINT [FK_Comuna_Comuna]
GO
ALTER TABLE [dbo].[Cotizacion]  WITH CHECK ADD  CONSTRAINT [FK_Cotizacion_Solicitud] FOREIGN KEY([id_solicitud])
REFERENCES [dbo].[Solicitud] ([id])
GO
ALTER TABLE [dbo].[Cotizacion] CHECK CONSTRAINT [FK_Cotizacion_Solicitud]
GO
ALTER TABLE [dbo].[Cotizacion]  WITH CHECK ADD  CONSTRAINT [FK_Cotizacion_TipoPago] FOREIGN KEY([id_tipo_pago])
REFERENCES [dbo].[TipoPago] ([id])
GO
ALTER TABLE [dbo].[Cotizacion] CHECK CONSTRAINT [FK_Cotizacion_TipoPago]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Comuna] FOREIGN KEY([id_comuna])
REFERENCES [dbo].[Comuna] ([id])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Comuna]
GO
ALTER TABLE [dbo].[Modelo]  WITH CHECK ADD  CONSTRAINT [FK_Modelo_Modelo] FOREIGN KEY([id_marca])
REFERENCES [dbo].[Marca] ([id])
GO
ALTER TABLE [dbo].[Modelo] CHECK CONSTRAINT [FK_Modelo_Modelo]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Direccion] FOREIGN KEY([id_direccion])
REFERENCES [dbo].[Direccion] ([id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Direccion]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Persona] FOREIGN KEY([id_persona])
REFERENCES [dbo].[Persona] ([id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Persona]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Vehiculo] FOREIGN KEY([id_vehiculo])
REFERENCES [dbo].[Vehiculo] ([id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Vehiculo]
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculo_Modelo] FOREIGN KEY([id_modelo])
REFERENCES [dbo].[Modelo] ([id])
GO
ALTER TABLE [dbo].[Vehiculo] CHECK CONSTRAINT [FK_Vehiculo_Modelo]
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculo_Pais] FOREIGN KEY([id_pais_origen])
REFERENCES [dbo].[Pais] ([id])
GO
ALTER TABLE [dbo].[Vehiculo] CHECK CONSTRAINT [FK_Vehiculo_Pais]
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculo_TipoCombustible] FOREIGN KEY([id_tipo_combustible])
REFERENCES [dbo].[TipoCombustible] ([id])
GO
ALTER TABLE [dbo].[Vehiculo] CHECK CONSTRAINT [FK_Vehiculo_TipoCombustible]
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculo_TipoVehiculo] FOREIGN KEY([id_tipo_vehiculo])
REFERENCES [dbo].[TipoVehiculo] ([id])
GO
ALTER TABLE [dbo].[Vehiculo] CHECK CONSTRAINT [FK_Vehiculo_TipoVehiculo]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cotizacion] FOREIGN KEY([id_cotizacion])
REFERENCES [dbo].[Cotizacion] ([id])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cotizacion]
GO
ALTER TABLE [dbo].[VentaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_VentaDetalle_Banco] FOREIGN KEY([id_banco])
REFERENCES [dbo].[Banco] ([id])
GO
ALTER TABLE [dbo].[VentaDetalle] CHECK CONSTRAINT [FK_VentaDetalle_Banco]
GO
ALTER TABLE [dbo].[VentaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_VentaDetalle_TipoTarjetaCredito] FOREIGN KEY([id_tipo_tarjeta])
REFERENCES [dbo].[TipoTarjetaCredito] ([id])
GO
ALTER TABLE [dbo].[VentaDetalle] CHECK CONSTRAINT [FK_VentaDetalle_TipoTarjetaCredito]
GO
ALTER TABLE [dbo].[VentaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_VentaDetalle_Venta] FOREIGN KEY([id_venta])
REFERENCES [dbo].[Venta] ([id])
GO
ALTER TABLE [dbo].[VentaDetalle] CHECK CONSTRAINT [FK_VentaDetalle_Venta]
GO
/****** Object:  StoredProcedure [dbo].[LimpiarTablas]    Script Date: 14-06-2020 1:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LimpiarTablas]
AS
BEGIN
	DELETE FROM VentaDetalle;
	DELETE FROM Venta;
	DELETE FROM Cotizacion;
	DELETE FROM Solicitud;
END
GO
ALTER DATABASE [BrunoFritcshVehiculosOnline] SET  READ_WRITE 
GO
