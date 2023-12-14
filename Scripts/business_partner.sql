USE [NN.POS.System]
GO

/****** Object:  Table [dbo].[business_partners]    Script Date: 12/12/2023 22:04:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[business_partners](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](150) NOT NULL,
	[last_name] [nvarchar](150) NOT NULL,
	[phone_number] [nvarchar](250) NOT NULL,
	[email] [nvarchar](150) NULL,
	[address] [nvarchar](150) NULL,
	[contact_type] [nvarchar](20) NOT NULL,
	[business_type] [nvarchar](20) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
 CONSTRAINT [PK_business_partners] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE INDEX bt_ct_business_partners
ON [dbo].[business_partners] ([business_type], [contact_type]);

CREATE INDEX fname_lname_business_partners
ON [dbo].[business_partners] ([first_name], [last_name]);

GO


