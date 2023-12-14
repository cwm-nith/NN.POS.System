USE [NN.POS.System]
GO

/****** Object:  Table [dbo].[item_master_data]    Script Date: 13/12/2023 00:35:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[item_master_data](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](100) NOT NULL UNIQUE,
	[barcode] [nvarchar](100) NOT NULL UNIQUE,
	[name] [nvarchar](250) NOT NULL,
	[other_name] [nvarchar](250) NULL,
	[stock_in] [decimal](18, 2) NOT NULL,
	[stock_commit] [decimal](18, 2) NOT NULL,
	[stock_on_hand] [decimal](18, 2) NOT NULL,
	[base_uom_id] [int] NOT NULL,
	[price_list_id] [int] NOT NULL,
	[uom_group_id] [int] NOT NULL,
	[purchase_uom_id] [int] NULL,
	[sale_uom_id] [int] NULL,
	[inventory_uom_id] [int] NULL,
	[warehouse_id] [int] NOT NULL,
	[type] [nvarchar](20) NOT NULL,
	[process] [nvarchar](20) NOT NULL,
	[is_sale] [bit] NOT NULL,
	[is_inventory] [bit] NOT NULL,
	[is_purchase] [bit] NOT NULL,
	[image] [nvarchar](250) NOT NULL,
	[description] [nvarchar](1250) NULL,
	[is_deleted] [bit] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_item_master_data] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE INDEX name_idx_item_master_data ON [dbo].[item_master_data] ([name]);
CREATE INDEX barcode_idx_item_master_data ON [dbo].[item_master_data] ([barcode]);
CREATE INDEX code_idx_item_master_data ON [dbo].[item_master_data] ([code]);
CREATE INDEX other_name_idx_item_master_data ON [dbo].[item_master_data] ([other_name]);
GO


