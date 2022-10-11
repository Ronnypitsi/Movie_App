USE [MOVIESDB]
GO

/****** Object:  Table [dbo].[Characters]    Script Date: 09/10/22 12:18:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Characters](
	[MovieID] [int] NOT NULL,
	[ActorID] [int] NOT NULL,
	[CharacterName] [varchar](50) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Characters]  WITH CHECK ADD  CONSTRAINT [FK_Characters_Actors] FOREIGN KEY([ActorID])
REFERENCES [dbo].[Actors] ([ActorID])
GO

ALTER TABLE [dbo].[Characters] CHECK CONSTRAINT [FK_Characters_Actors]
GO

ALTER TABLE [dbo].[Characters]  WITH CHECK ADD  CONSTRAINT [FK_Characters_Movies] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO

ALTER TABLE [dbo].[Characters] CHECK CONSTRAINT [FK_Characters_Movies]
GO


