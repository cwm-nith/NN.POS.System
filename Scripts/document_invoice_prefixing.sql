USE [NN.POS.System]
GO

/****** Object:  Table [dbo].[price_lists]    Script Date: 12/12/2023 22:31:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[document_invoice_prefixing](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[prefix] [nvarchar](10) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_document_invoice_prefixing] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE INDEX type_document_invoice_prefixing
ON [dbo].[document_invoice_prefixing] ([type]);

CREATE INDEX prefix_document_invoicing
ON [dbo].[document_invoice_prefixing] ([prefix]);
GO


