USE [NN.POS.System]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[companies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[price_list_id] [int] NOT NULL,
	[sys_ccy_id] [int] NOT NULL,
	[local_ccy_id] [int] NOT NULL,
	[name] [nvarchar](150) NOT NULL,
	[location] [nvarchar](200) NULL,
	[address] [nvarchar](200) NULL,
	[logo] [nvarchar](250) NOT NULL,
	[is_deleted] [bit] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_companies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE INDEX name_companies
ON [dbo].[companies] ([name]);

GO


