USE [ShopsDB]
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCategory]
	@id uniqueidentifier,
	@name nvarchar(max)
AS
	INSERT [dbo].[Categories] ([Id], [Name])  
	VALUES (@id, @name)
GO
/****** Object:  StoredProcedure [dbo].[AddFeedback]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddFeedback]
	@id uniqueidentifier,
	@text nvarchar(max),
	@score int,
	@date datetime,
	@shop_id uniqueidentifier,
	@user_id uniqueidentifier
AS
	INSERT [dbo].[Feedbacks] ([Id], [Text], [Score], [Date], [Shop_Id], [User_Id]) 
	VALUES (@id, @text, @score, @date, @shop_id, @user_id)
GO
/****** Object:  StoredProcedure [dbo].[AddShop]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddShop]
	@id uniqueidentifier,
	@name nvarchar(max),
	@site nvarchar(max),
	@address nvarchar(max),
	@category_id uniqueidentifier
AS
	INSERT [dbo].[Shops] ([Id], [Name], [Site], [Address], [Category_Id]) 
	VALUES (@id, @name, @site, @address, @category_id)
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
	@id uniqueidentifier,
	@first_name nvarchar(max),
	@last_name nvarchar(max),
	@age int,
	@gender int,
	@email nvarchar(max),
	@phone_number nvarchar(max),
	@password nvarchar(max)
AS
	INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Age], [Gender], [Email], [PhoneNumber], [Password])  
	VALUES (@id, @first_name, @last_name, @age, @gender, @email, @phone_number, @password)
GO
/****** Object:  StoredProcedure [dbo].[GetAllCategories]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCategories]

AS
	SELECT * FROM Categories
GO
/****** Object:  StoredProcedure [dbo].[GetAllFeedbacks]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllFeedbacks]
AS
	SELECT * FROM Feedbacks
GO
/****** Object:  StoredProcedure [dbo].[GetAllShops]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllShops]
AS
	SELECT * FROM Shops
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
	SELECT * FROM Users
GO
/****** Object:  StoredProcedure [dbo].[GetFeedbacksByShop]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFeedbacksByShop]
	@shop_id uniqueidentifier
AS
	SELECT * FROM Feedbacks
	WHERE Shop_Id = @shop_id
GO
/****** Object:  StoredProcedure [dbo].[GetFeedbacksByUser]    Script Date: 11.07.2021 1:12:40 ******/
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
/****** Object:  StoredProcedure [dbo].[GetShopsByCategory]    Script Date: 11.07.2021 1:12:40 ******/
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
/****** Object:  StoredProcedure [dbo].[GetShopsByName]    Script Date: 11.07.2021 1:12:40 ******/
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
/****** Object:  StoredProcedure [dbo].[RemoveCategory]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveCategory]
	@id uniqueidentifier
AS
	DELETE FROM Categories
	WHERE Id = @id
RETURN @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[RemoveFeedback]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveFeedback]
	@id uniqueidentifier
AS
	DELETE FROM Feedbacks
	WHERE Id = @id
RETURN @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[RemoveShop]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveShop]
	@id uniqueidentifier
AS
	DELETE FROM Shops
	WHERE Id = @id
RETURN @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveUser]
	@id uniqueidentifier
AS
	DELETE FROM Users
	WHERE Id = @id
RETURN @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategory]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCategory]
	@id uniqueidentifier,
	@name nvarchar(max)
AS
	UPDATE Categories
	SET [Name] = @name
	WHERE Id = @id
RETURN @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[UpdateFeedback]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateFeedback]
	@id uniqueidentifier,
	@text nvarchar(max),
	@score int,
	@date datetime,
	@shop_id uniqueidentifier,
	@user_id uniqueidentifier
AS
	UPDATE Feedbacks
	SET [Text] = @text, 
	[Score] = @score, 
	[Date] = @date, 
	[Shop_Id] = @shop_id, 
	[User_Id] = @user_id
	WHERE Id = @id
RETURN @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[UpdateShop]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateShop]
	@id uniqueidentifier,
	@name nvarchar(max),
	@site nvarchar(max),
	@address nvarchar(max),
	@category_id uniqueidentifier
AS
	UPDATE Shops
	SET [Name] = @name,
	[Site] = @site,
	[Address] = @address,
	[Category_Id] = @category_id 
	WHERE Id = @id
RETURN @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 11.07.2021 1:12:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@id uniqueidentifier,
	@first_name nvarchar(max),
	@last_name nvarchar(max),
	@age int,
	@gender int,
	@email nvarchar(max),
	@phone_number nvarchar(max),
	@password nvarchar(max)
AS
	UPDATE Users
	SET FirstName = @first_name, 
	LastName = @last_name, 
	Age = @age, 
	Gender = @gender, 
	Email = @email, 
	PhoneNumber = @phone_number, 
	[Password] = @password
	WHERE Id = @id
RETURN @@ROWCOUNT
GO
