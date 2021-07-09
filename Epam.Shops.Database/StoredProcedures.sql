USE [ShopsDB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllShops]    Script Date: 10.07.2021 0:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllShops]
AS
	SELECT * FROM Shops
GO
/****** Object:  StoredProcedure [dbo].[GetFeedbacksByUser]    Script Date: 10.07.2021 0:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFeedbacksByUser]
	@id uniqueidentifier
AS
	SELECT * FROM Feedbacks
	WHERE User_Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetShopsByCategory]    Script Date: 10.07.2021 0:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetShopsByCategory]
	@categoryId uniqueidentifier
AS
	SELECT * FROM Shops
	WHERE Category_Id = Id
GO
/****** Object:  StoredProcedure [dbo].[GetShopsByName]    Script Date: 10.07.2021 0:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetShopsByName]
	@name nvarchar(max)
AS
	SELECT * FROM Shops 
	WHERE @name = Name
GO
