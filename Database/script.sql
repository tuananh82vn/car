USE [CarSales_Mini]
GO
/****** Object:  UserDefinedFunction [dbo].[RandomString]    Script Date: 8/08/2019 1:08:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
use [master]
ALTER DATABASE [hendersons] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE hendersons
*/
/*
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'hendersons') BEGIN CREATE DATABASE [hendersons] END
GO
Use hendersons
GO
*/
CREATE FUNCTION [dbo].[RandomString]
(	
	-- Add the parameters for the function here
	 @param1 int
)
RETURNS NVARCHAR(250)

AS BEGIN
    DECLARE @Work NVARCHAR(250)
	=(
	SELECT
    left((
        select  (select REPLACE(new_id,'-','') from getNewID)
        where   textLen.textLen is not null
        FOR XML PATH(''), BINARY BASE64
    ),textLen.textLen) 
	FROM ( values (@param1) ) as textLen(textLen))

	RETURN @Work;
END
GO
/****** Object:  View [dbo].[getNewId]    Script Date: 8/08/2019 1:08:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 



create view [dbo].[getNewId] as select newid() as new_id
 
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 8/08/2019 1:08:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UniqueId] [nchar](6) NOT NULL,
	[Make] [nvarchar](250) NOT NULL,
	[Model] [nvarchar](250) NOT NULL,
	[Color] [nvarchar](250) NOT NULL,
	[Engine] [nvarchar](250) NULL,
	[Doors] [int] NULL,
	[Wheels] [int] NULL,
	[BodyType] [nvarchar](250) NULL,
	[Type] [nvarchar](250) NULL,
	[VehicleType] [nvarchar](250) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [nvarchar](128) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Vehicle] ADD  CONSTRAINT [DF_Vehicle_UniqueId]  DEFAULT ([dbo].[RandomString]((6))) FOR [UniqueId]
GO
ALTER TABLE [dbo].[Vehicle] ADD  CONSTRAINT [DF_Car_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Vehicle] ADD  CONSTRAINT [DF_Car_CreatedBy]  DEFAULT (user_name()) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[Vehicle] ADD  CONSTRAINT [DF_Vehicle_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Vehicle] ADD  CONSTRAINT [DF_Car_UpdatedBy]  DEFAULT (user_name()) FOR [UpdatedBy]
GO
ALTER TABLE [dbo].[Vehicle] ADD  CONSTRAINT [DF_Car_UpdatedOn]  DEFAULT (sysdatetimeoffset()) FOR [UpdatedOn]
GO
