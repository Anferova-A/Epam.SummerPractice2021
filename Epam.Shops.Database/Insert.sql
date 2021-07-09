USE [ShopsDB]
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'1412c5e3-a6da-4435-b66f-9902cfb390a3', N'Товары для животных')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'ec377592-1e13-4f1b-8466-9aefa3fefe8b', N'Товары для дома')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'bce1203f-a2e9-4f40-9ecc-ab4d8da24cc8', N'Продукты')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'a9de3088-184f-4f6e-a21e-bd0b748b82c9', N'Спорт')
GO
INSERT [dbo].[Shops] ([Id], [Name], [Site], [Address], [Category_Id]) VALUES (N'eda32319-ae4c-4141-ba0b-1380c09e9b59', N'Золотая рыбка', N'www.goldfish.ru', N'Волгоград', N'1412c5e3-a6da-4435-b66f-9902cfb390a3')
GO
INSERT [dbo].[Shops] ([Id], [Name], [Site], [Address], [Category_Id]) VALUES (N'332ea46c-79a8-4d83-98ab-16b79bb25bf8', N'Поворот', NULL, N'Саратов', N'bce1203f-a2e9-4f40-9ecc-ab4d8da24cc8')
GO
INSERT [dbo].[Shops] ([Id], [Name], [Site], [Address], [Category_Id]) VALUES (N'd417285b-1346-49c1-9393-2cbe29b1b5ca', N'Зоомир', NULL, N'Саратов', N'1412c5e3-a6da-4435-b66f-9902cfb390a3')
GO
INSERT [dbo].[Shops] ([Id], [Name], [Site], [Address], [Category_Id]) VALUES (N'1072d0da-baeb-4c44-901d-d2bcda39019c', N'Уют', NULL, N'Саратов', N'ec377592-1e13-4f1b-8466-9aefa3fefe8b')
GO
INSERT [dbo].[Shops] ([Id], [Name], [Site], [Address], [Category_Id]) VALUES (N'4cd56c64-4a72-499d-aa58-e7180c96a09e', N'Бегемотик', NULL, N'Саратов', N'1412c5e3-a6da-4435-b66f-9902cfb390a3')
GO
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Age], [Gender], [Email], [PhoneNumber], [Password]) VALUES (N'b3166a53-593c-4c12-afa9-1598fbde5f77', N'Павел', N'Овчинников', 19, 1, N'pavelovch@list.ru', NULL, N'16-EA-DE-CE-CB-5C-8B-FB-DA-35-4A-AC-5A-85-61-96-AF-80-21-22-C7-7B-81-0D-6A-DF-80-1C-5F-44-90-3C')
GO
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Age], [Gender], [Email], [PhoneNumber], [Password]) VALUES (N'deac1581-c7a7-40d9-81b9-4fd5cf525ea2', N'Наталия', N'Растопшина', 0, 0, N'rastopchyanin@list.ru', N'+79195237656', N'87-54-AA-CE-6C-10-FF-35-E7-93-B4-F3-DF-A4-0B-5A-E2-D5-91-47-27-8F-E5-3E-D0-BC-ED-7D-2D-78-62-55')
GO
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Age], [Gender], [Email], [PhoneNumber], [Password]) VALUES (N'8cf441ca-9f07-4f6a-ae63-88a10f7328fa', N'Олег', N'Клюков', 39, 1, N'klyukovoleg@list.ru', N'+79195236574', N'B3-00-F9-0B-84-87-AC-D7-55-58-AE-24-D3-6F-4F-42-46-7D-BC-A7-2A-04-F4-7C-EC-93-BA-05-73-F8-C7-E1')
GO
INSERT [dbo].[Feedbacks] ([Id], [Text], [Score], [Date], [Shop_Id], [User_Id]) VALUES (N'a7fda26d-4b33-4ff6-9f1a-1a4e0ba9ef78', N'Ваша рыбка какая-то не золотая! МАЛО ТОВАРОВ В НАЛИЧИИ!', 3, CAST(N'2021-07-09T20:30:02.737' AS DateTime), N'eda32319-ae4c-4141-ba0b-1380c09e9b59', N'8cf441ca-9f07-4f6a-ae63-88a10f7328fa')
GO
INSERT [dbo].[Feedbacks] ([Id], [Text], [Score], [Date], [Shop_Id], [User_Id]) VALUES (N'81d1c0b8-dbd1-41f4-9c25-4cb2d51d94f8', N'Нет мяса для шашлыка, был расстроен этим фактом.', 4, CAST(N'2021-07-09T20:30:02.740' AS DateTime), N'332ea46c-79a8-4d83-98ab-16b79bb25bf8', N'b3166a53-593c-4c12-afa9-1598fbde5f77')
GO
INSERT [dbo].[Feedbacks] ([Id], [Text], [Score], [Date], [Shop_Id], [User_Id]) VALUES (N'4269b784-6b1f-4ce0-880a-6c174a1f515a', N'Очень нравятся ваши низкокаллорийные тортики!', 5, CAST(N'2021-07-09T20:30:02.737' AS DateTime), N'332ea46c-79a8-4d83-98ab-16b79bb25bf8', N'deac1581-c7a7-40d9-81b9-4fd5cf525ea2')
GO
INSERT [dbo].[Feedbacks] ([Id], [Text], [Score], [Date], [Shop_Id], [User_Id]) VALUES (N'b7c40263-4a2f-45a4-a492-7904cdbecc95', N'Спасибо, магазин - супер!', 5, CAST(N'2021-07-09T20:30:02.737' AS DateTime), N'd417285b-1346-49c1-9393-2cbe29b1b5ca', N'deac1581-c7a7-40d9-81b9-4fd5cf525ea2')
GO
INSERT [dbo].[Feedbacks] ([Id], [Text], [Score], [Date], [Shop_Id], [User_Id]) VALUES (N'428e9271-096e-41ad-b291-9f973e3c1fef', N'В целом всё хорошо, но всегда можно лучше :)', 4, CAST(N'2021-07-09T20:30:02.730' AS DateTime), N'd417285b-1346-49c1-9393-2cbe29b1b5ca', N'8cf441ca-9f07-4f6a-ae63-88a10f7328fa')
GO
INSERT [dbo].[Feedbacks] ([Id], [Text], [Score], [Date], [Shop_Id], [User_Id]) VALUES (N'acaad7ec-87d8-46e9-ab8e-e555968c86e0', N'Не нашел в вашем магазине шамуров! ((((', 4, CAST(N'2021-07-09T20:30:02.737' AS DateTime), N'1072d0da-baeb-4c44-901d-d2bcda39019c', N'b3166a53-593c-4c12-afa9-1598fbde5f77')
GO
INSERT [dbo].[Feedbacks] ([Id], [Text], [Score], [Date], [Shop_Id], [User_Id]) VALUES (N'2aa6e296-fdda-45bb-b539-fce07239c06b', N'Не нашла у вас нужного товара для своей кошки', 4, CAST(N'2021-07-09T20:30:02.737' AS DateTime), N'4cd56c64-4a72-499d-aa58-e7180c96a09e', N'deac1581-c7a7-40d9-81b9-4fd5cf525ea2')
GO
