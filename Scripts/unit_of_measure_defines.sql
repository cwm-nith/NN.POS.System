USE [NN.POS.System]
GO

/****** Object:  Table [dbo].[unit_of_measure_defines]    Script Date: 12/12/2023 22:45:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[unit_of_measure_defines](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[base_uom_id] [int] NOT NULL,
	[alt_uom_id] [int] NOT NULL,
	[group_uom_id] [int] NOT NULL,
	[alt_qty] [decimal](18, 4) NOT NULL,
	[base_qty] [decimal](18, 4) NOT NULL,
	[factor] [decimal](18, 4) NOT NULL,
	[is_deleted] [bit] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_unit_of_measure_defines] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


