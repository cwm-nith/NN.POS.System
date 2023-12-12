USE [NN.POS.System]
GO

/****** Object:  Table [dbo].[user_roles]    Script Date: 12/12/2023 21:56:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user_roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_user_roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[user_roles]  WITH CHECK ADD  CONSTRAINT [FK_user_roles_roles] FOREIGN KEY([role_id])
REFERENCES [dbo].[roles] ([id])
GO

ALTER TABLE [dbo].[user_roles] CHECK CONSTRAINT [FK_user_roles_roles]
GO

ALTER TABLE [dbo].[user_roles]  WITH CHECK ADD  CONSTRAINT [FK_user_roles_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO

ALTER TABLE [dbo].[user_roles] CHECK CONSTRAINT [FK_user_roles_users]
GO


