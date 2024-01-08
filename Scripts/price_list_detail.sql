USE [NN.POS.System]
GO

/****** Object:  Table [dbo].[price_list_details]    Script Date: 09/01/2024 00:22:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[price_list_details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[price_list_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[uom_id] [int] NULL,
	[ccy_id] [int] NOT NULL,
	[discount_value] [decimal](18, 4) NOT NULL,
	[discount_type] [nvarchar](20) NOT NULL,
	[promotion_id] [int] NOT NULL,
	[cost] [decimal](18, 4) NOT NULL,
	[price] [decimal](18, 4) NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_price_list_details] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[price_list_details]  WITH NOCHECK ADD  CONSTRAINT [FK_price_list_details_price_lists] FOREIGN KEY([price_list_id])
REFERENCES [dbo].[price_lists] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[price_list_details] CHECK CONSTRAINT [FK_price_list_details_price_lists]
GO


