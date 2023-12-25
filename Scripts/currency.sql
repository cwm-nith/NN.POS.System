USE [NN.POS.System]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[currencies](
	[id] [int] NOT NULL,
	[name] [nvarchar](150) NOT NULL,
	[symbol] [nvarchar](10) NOT NULL,
	[is_deleted] [bit] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_currencies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE INDEX name_currencies
ON [dbo].[currencies] ([name]);


CREATE INDEX symbol_currencies
ON [dbo].[currencies] ([name]);

GO


