USE [NN.POS.System]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[out_going_payment_suppliers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[supply_id] [int] NOT NULL,
  [branch_id] [int] NOT NULL,
	[ccy_id] [int] NOT NULL,
	[sys_ccy_id] [int] NULL,
	[warehouse_id] [int] NOT NULL,
  [invoice_no] [nvarchar](20) NOT NULL UNIQUE,
  [document_type] [nvarchar](50) NOT NULL,
  [posting_date] [datetime] NOT NULL,
  [date] [datetime] NOT NULL,
  [overdue_days] [decimal](18, 2) NOT NULL,
  [total] [decimal](18,4) NOT NULL,
  [balance_due] [decimal](18,4) NOT NULL,
  [total_payment] [decimal](18,4) NOT NULL,
  [applied_amount] [decimal](18, 4) NOT NULL,
  [status] [nvarchar](20) NOT NULL,
  [discount_value] [decimal](18, 4) NOT NULL,
	[discount_type] [nvarchar](20) NOT NULL,
  [cash] [decimal](18,4) NOT NULL,	
  [exchange_rate] [decimal](18,4) NOT NULL,
  [local_ccy_id] [int] NOT NULL,
	[local_set_rate] [decimal](18, 4) NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_out_going_payment_suppliers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE INDEX invoice_no_out_going_payment_suppliers
ON [dbo].[out_going_payment_suppliers] ([invoice_no]);

GO

