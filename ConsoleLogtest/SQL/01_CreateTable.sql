/****** Object:  Table [dbo].[DemoTable]    Script Date: 8/7/2018 5:14:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DemoTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateOf] [date] NOT NULL,
	[Value] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

INSERT INTO [dbo].[DemoTable]
		([DateOf]
		,[Value])
	VALUES
	('1901-01-01'
	,'Test 1')
GO

INSERT INTO [dbo].[DemoTable]
		([DateOf]
		,[Value])
		VALUES
		('1901-01-02'
		,'Test 2')
GO

INSERT INTO [dbo].[DemoTable]
		([DateOf]
		,[Value])
	VALUES
		('1901-01-03'
		,'Test 3')
GO