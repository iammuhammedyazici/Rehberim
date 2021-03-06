USE [DboRehber]
GO
/****** Object:  Table [dbo].[TBL_ILCELER]    Script Date: 22.04.2019 20:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_ILCELER](
	[ID] [int] NOT NULL,
	[ILCE] [varchar](25) NULL,
	[SEHIR] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ilceler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_ILLER]    Script Date: 22.04.2019 20:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_ILLER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SEHIR] [varchar](20) NULL,
 CONSTRAINT [PK_iller] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_REHBER]    Script Date: 22.04.2019 20:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_REHBER](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[AD] [varchar](30) NULL,
	[SOYAD] [varchar](30) NULL,
	[IL] [varchar](20) NULL,
	[ILCE] [varchar](25) NULL,
	[MAHALLE] [varchar](25) NULL,
	[NO] [varchar](10) NULL,
	[TEL] [varchar](15) NULL,
	[MAIL] [varchar](50) NULL,
	[RESIM] [varchar](100) NULL
) ON [PRIMARY]
GO
