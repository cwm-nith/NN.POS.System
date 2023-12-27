USE [NN.POS.System]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[warehouses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[branch_id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[code] [nvarchar](20) NOT NULL,
	[location] [nvarchar](200) NOT NULL,
	[address] [nvarchar](200) NOT NULL,
	[stock_in] [decimal](18, 4) NOT NULL,
	[is_deleted] [bit] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_warehouses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE INDEX name_warehouses
ON [dbo].[warehouses] ([name]);


CREATE INDEX code_warehouses
ON [dbo].[warehouses] ([code]);

GO


