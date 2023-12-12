USE [NN.POS.System]
GO

/****** Object:  Table [dbo].[price_lists]    Script Date: 12/12/2023 22:31:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[price_lists](
	[id] [int] NOT NULL,
	[name] [nvarchar](150) NOT NULL,
	[ccy_id] [int] NOT NULL,
	[is_deleted] [bit] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_price_lists] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE INDEX name_price_lists
ON [dbo].[price_lists] ([name]);

GO


