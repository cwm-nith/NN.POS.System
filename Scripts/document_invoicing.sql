USE [NN.POS.System]
GO

/****** Object:  Table [dbo].[price_lists]    Script Date: 12/12/2023 22:31:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[document_invoicing](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[doc_id] [int] NOT NULL,
	[invoice_count] [int] NOT NULL,
	[doc_invoicing] [nvarchar](150) NOT NULL,
	[prefix] [nvarchar](10) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_document_invoicing] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE INDEX doc_id_doc_invoicing_type_document_invoicing
ON [dbo].[document_invoicing] ([doc_id], [doc_invoicing], [type]);

CREATE INDEX type_document_invoicing
ON [dbo].[document_invoicing] ([type]);

CREATE INDEX doc_invoicing_document_invoicing
ON [dbo].[document_invoicing] ([doc_invoicing]);

CREATE INDEX doc_id_document_invoicing
ON [dbo].[document_invoicing] ([doc_id]);
GO


