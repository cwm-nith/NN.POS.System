USE [NN.POS.System]
GO

/****** Object:  Table [dbo].[inventory_audit]    Script Date: 13/12/2023 00:35:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[inventory_audit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[warehouse_id] [int] NOT NULL,
  [branch_id] [int] NOT NULL,
  [user_id] [int] NOT NULL,
  [item_id] [int] NOT NULL,
  [ccy_id] [int] NOT NULL,
  [uom_id] [int] NOT NULL,
  [local_ccy_id] [int] NOT NULL,
	[invoice_no] [nvarchar](20) NOT NULL,
	[trans_type] [nvarchar](50) NOT NULL,
	[process] [nvarchar](20) NOT NULL,
	[qty] [decimal](18, 4) NOT NULL,
	[cost] [decimal](18, 4) NOT NULL,
	[price] [decimal](18, 4) NOT NULL,
	[cumulative_qty] [decimal](18, 4) NOT NULL,
	[cumulative_value] [decimal](18, 4) NOT NULL,
	[trans_value] [decimal](18, 4) NOT NULL,
	[local_set_rate] [decimal](18, 4) NOT NULL,
	[expire_date] [datetime] NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_inventory_audit] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE INDEX warehouse_id_idx_inventory_audit ON [dbo].[inventory_audit] ([warehouse_id]);
CREATE INDEX branch_id_idx_inventory_audit ON [dbo].[inventory_audit] ([branch_id]);
CREATE INDEX user_id_idx_inventory_audit ON [dbo].[inventory_audit] ([user_id]);
CREATE INDEX item_id_idx_inventory_audit ON [dbo].[inventory_audit] ([item_id]);
CREATE INDEX ccy_id_idx_inventory_audit ON [dbo].[inventory_audit] ([ccy_id]);
CREATE INDEX uom_id_idx_inventory_audit ON [dbo].[inventory_audit] ([uom_id]);
CREATE INDEX local_ccy_id_idx_inventory_audit ON [dbo].[inventory_audit] ([local_ccy_id]);
CREATE INDEX invoice_no_idx_inventory_audit ON [dbo].[inventory_audit] ([invoice_no]);
CREATE INDEX trans_type_idx_inventory_audit ON [dbo].[inventory_audit] ([trans_type]);
GO


