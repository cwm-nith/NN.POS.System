USE [NN.POS.System]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[warehouse_summaries](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[warehouse_id] [int] NOT NULL,
	[uom_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[ccy_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[in_stock] [decimal](18, 3) NOT NULL,
  [committed_stock] [decimal](18, 3) NOT NULL,
  [ordered_stock] [decimal](18, 3) NOT NULL,
  [available_stock] [decimal](18, 3) NOT NULL,
  [factor] [decimal](18, 3) NOT NULL,
  [cost] [decimal](18, 3) NOT NULL,
  [expire_date] [datetime] NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_warehouse_summaries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO


