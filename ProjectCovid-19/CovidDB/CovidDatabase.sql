USE [Covid-19DB]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 2/21/2021 7:22:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 2/21/2021 7:22:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[MobileNumber] [nvarchar](15) NOT NULL,
	[Password] [nvarchar](15) NOT NULL,
	[ConfirmPassword] [nvarchar](15) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([Id], [Username], [Password]) VALUES (1, N'thansi@gmail.com', N'Thansi@123')
SET IDENTITY_INSERT [dbo].[Login] OFF
GO
SET IDENTITY_INSERT [dbo].[Registration] ON 

INSERT [dbo].[Registration] ([Id], [Name], [Email], [MobileNumber], [Password], [ConfirmPassword]) VALUES (1, N'Thansi', N'thansi@gmail.com', N'8754210214', N'Thansi@123', N'Thansi@123')
SET IDENTITY_INSERT [dbo].[Registration] OFF
GO
/****** Object:  StoredProcedure [dbo].[LoginUser]    Script Date: 2/21/2021 7:22:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LoginUser]
@Username		NVARCHAR(50)
, @Password		NVARCHAR(15)
AS
BEGIN
SELECT *
	--[Username]
	--, [Password]
FROM [dbo].[Login]
WHERE [Username]=@Username
AND [Password]=@Password
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrationSave]    Script Date: 2/21/2021 7:22:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RegistrationSave]
@Name					NVARCHAR(50)
, @Email				NVARCHAR(50)
, @MobileNumber			NVARCHAR(15)
, @Password				NVARCHAR(15)
, @ConfirmPassword		NVARCHAR(15)
AS
BEGIN
INSERT INTO [dbo].[Registration]
(
[Name]
, [Email]
, [MobileNumber]
, [Password]
, [ConfirmPassword]
)
VALUES
(
@Name
, @Email
, @MobileNumber
, @Password
, @ConfirmPassword
)
INSERT INTO [dbo].[Login]
(
[Username]
, [Password]
)
VALUES
(
@Email
, @Password
)
--SELECT [Email],[Password] FROM [dbo].[Registration]
END
GO
