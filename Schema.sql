CREATE DATABASE Kanban
GO

USE [Kanban]
GO

/****** Object:  Table [dbo].[ConfigData]    Script Date: 3/17/2019 3:20:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


			--/////////////////////
			-- create EmployeeSkill table
			--/////////////////////
CREATE TABLE [dbo].[EmployeeSkill](
	[Type] [nvarchar](100) NOT NULL,
	[Speed] [float] NOT NULL,
	[DefectRate] int NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


			--/////////////////////
			-- create Employee table
			--/////////////////////
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Active] bit NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
 CONSTRAINT [FK_Type] FOREIGN KEY([Type]) REFERENCES [dbo].[EmployeeSkill] ([Type])
)


			--/////////////////////
		    -- create Station table
			--/////////////////////
CREATE TABLE [dbo].[Station](
	[StationID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[TotalLamp] [int] NOT NULL,
	[LampCount] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Station] PRIMARY KEY CLUSTERED ([StationID] ASC),
 cONSTRAINT [FK_EmplyeeID] FOREIGN KEY([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])
)
GO


			--/////////////////////
			-- create Parts table
			--/////////////////////
CREATE TABLE [dbo].[Parts](
	[PartID] [int] NOT NULL,
	[Name][nvarchar](20) NULL,
	[Capacity] [int] NOT NULL,
 CONSTRAINT [PK_Parts] PRIMARY KEY CLUSTERED ([PartID])
)

GO

			--/////////////////////
			-- create Bin table
			--/////////////////////
CREATE TABLE [dbo].[Bin](
	[BinID] [int] IDENTITY(1,1) NOT NULL,
	[PartID] [int] NOT NULL,
	[Quantities][int] NULL,
 CONSTRAINT [PK_Bin] PRIMARY KEY CLUSTERED ([BinID]),
 CONSTRAINT [FK_PartID] FOREIGN KEY([PartID]) REFERENCES [dbo].[Parts] ([PartID])
) 

GO


			--/////////////////////
			-- create StaionBin table
			--/////////////////////
CREATE TABLE [dbo].[StationBin](
	[StationID][int] NOT NULL,
	[BinID] [int] NOT NULL,
 CONSTRAINT [PK_StationBin] PRIMARY KEY CLUSTERED ([StationID],[BinID] ASC),
 CONSTRAINT [FK_StaionID] FOREIGN KEY ([StationID]) REFERENCES [dbo].[Station] ([StationID]),
 CONSTRAINT [FK_BinID] FOREIGN KEY ([BinID]) REFERENCES [dbo].[Bin] ([BinID])

) 


			--/////////////////////
			-- create Cart table
			--/////////////////////
CREATE TABLE [dbo].[Cart](
	[StationID] [int] NOT NULL,
	[BinID] [int] NOT NULL,
	[PartID] [int] NOT NULL,
	[Quantities] [int] NOT NULL

 CONSTRAINT [FK_Cart_PartID] FOREIGN KEY([PartID])REFERENCES [dbo].[Parts] ([PartID]),
 CONSTRAINT [FK_Cart_BinID] FOREIGN KEY([BinID]) REFERENCES [dbo].[Bin] ([BinID])
)
GO




			--/////////////////////
			-- create TestTray table
			--/////////////////////
CREATE TABLE [dbo].[TestTray](
	[TestTrayID] [int] IDENTITY(1,1) NOT NULL,
	[TestUnitNumber] [int] NULL

 CONSTRAINT [PK_TestTray] PRIMARY KEY CLUSTERED ([TestTrayID]  ASC)
)
GO

			--/////////////////////
			-- create Trays table
			--/////////////////////
CREATE TABLE [dbo].[Trays](
	[TestTrayID] [int] NULL,
	[UnitNumber] [int] NULL,
	[TrayID] [nchar](10) NOT NULL,
	[TestStatus] [bit] NULL
 CONSTRAINT [PK_TrayID] PRIMARY KEY CLUSTERED ([TrayID]  ASC),
 CONSTRAINT [FK_TestTrayID] FOREIGN KEY([TestTrayID]) REFERENCES [dbo].[TestTray] ([TestTrayID])
)
GO



			--/////////////////////
			-- create StationTestTray table
			--/////////////////////
CREATE TABLE [dbo].[StationTestTray](
	[TestTrayID] [int] NOT NULL,
	[StationID] [int] NOT NULL
 CONSTRAINT [PK_StationTestTray] PRIMARY KEY CLUSTERED ([TestTrayID],[StationID]),
 CONSTRAINT [FK_TestTray] FOREIGN KEY([TestTrayID]) REFERENCES [dbo].[TestTray] ([TestTrayID]),
CONSTRAINT [FK_Station] FOREIGN KEY([StationID]) REFERENCES [dbo].[Station] ([StationID])
) 
GO


			--/////////////////////
			-- create Configuration table
			--/////////////////////
CREATE TABLE [dbo].[Configuration](
	[ConfigID] [nvarchar](200) NOT NULL,
	[ConfigValue] [nvarchar](200) NULL,
	CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED ([ConfigID])
) 
GO

INSERT INTO Configuration
(ConfigID,ConfigValue)
VALUES
('RunInterval','300'),
('Stations','5'),
('OrderAmount','1000'),
('Scale','1');
GO


INSERT INTO EmployeeSkill
(Type, Speed , DefectRate)
VALUES
('Rookie', 90, 117),
('Normal', 60, 200),
('Super', 51, 666);

GO

INSERT INTO Parts
(PartID,Name,Capacity)
VALUES
(1,'Harness',55),
(2,'Reflector',35),
(3,'Housing',24),
(4,'Lens',40),
(5,'Bulb',60),
(6,'Bezel',75);
Go


create view CommonTray as select StationBin.StationID, Bin.BinID,Bin.PartID,Bin.Quantities 
from StationBin inner join Bin on StationBin.BinID=Bin.BinID 
where Quantities<6;
GO



create view AssemblyLine as select ConfigValue from Configuration
