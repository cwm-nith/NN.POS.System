USE [NN.POS.System]
GO

/****** Object:  Table [dbo].[price_list_details]    Script Date: 12/12/2023 22:22:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[purchase_order_details](
  [id] [int] IDENTITY(1,1) NOT NULL,
  [purchase_order_id] [int] NOT NULL,
  [item_id] [int] NOT NULL,
  [uom_id] [int] NULL,
  [local_ccy_id] [int] NOT NULL,
  [discount_value] [decimal](18, 3) NOT NULL,
  [discount_rate] [decimal](18, 3) NOT NULL,
  [discount_type] [nvarchar](20) NOT NULL,
  [qty] [decimal](18, 3) NOT NULL,
  [purchase_price] [decimal](18, 3) NOT NULL,
  [total] [decimal](18, 3) NOT NULL,
  [total_sys] [decimal](18, 3) NOT NULL,
  [is_deleted] [bit] NOT NULL,
  [created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_purchase_order_details] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[purchase_order_details]  WITH CHECK ADD  CONSTRAINT [FK_purchase_order_details_purchase_orders] FOREIGN KEY([purchase_order_id])
REFERENCES [dbo].[purchase_orders]([id])
GO

ALTER TABLE [dbo].[purchase_order_details] CHECK CONSTRAINT [FK_purchase_order_details_purchase_orders]
GO



