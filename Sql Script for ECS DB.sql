/******** DMA Schema Migration Deployment Script      Script Date: 4/26/2018 1:31:47 PM ********/

/****** Object:  Table [dbo].[Account]    Script Date: 4/26/2018 1:31:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Email] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Points] [int] NOT NULL,
	[AccountStatus] [bit] NOT NULL,
	[SuspensionTime] [datetime] NOT NULL,
	[FirstTimeUser] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Account] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[Account_Insert]    Script Date: 4/26/2018 1:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Account_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[Account_Insert]
    @UserName [nvarchar](20),
    @Email [nvarchar](max),
    @Password [nvarchar](50),
    @Points [int],
    @AccountStatus [bit],
    @SuspensionTime [datetime],
    @FirstTimeUser [bit]
AS
BEGIN
    INSERT [dbo].[Account]([UserName], [Email], [Password], [Points], [AccountStatus], [SuspensionTime], [FirstTimeUser])
    VALUES (@UserName, @Email, @Password, @Points, @AccountStatus, @SuspensionTime, @FirstTimeUser)
END
GO
/****** Object:  StoredProcedure [dbo].[Account_Update]    Script Date: 4/26/2018 1:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Account_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[Account_Update]
    @UserName [nvarchar](20),
    @Email [nvarchar](max),
    @Password [nvarchar](50),
    @Points [int],
    @AccountStatus [bit],
    @SuspensionTime [datetime],
    @FirstTimeUser [bit]
AS
BEGIN
    UPDATE [dbo].[Account]
    SET [Email] = @Email, [Password] = @Password, [Points] = @Points, [AccountStatus] = @AccountStatus, [SuspensionTime] = @SuspensionTime, [FirstTimeUser] = @FirstTimeUser
    WHERE ([UserName] = @UserName)
END
GO
/****** Object:  StoredProcedure [dbo].[Account_Delete]    Script Date: 4/26/2018 1:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Account_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[Account_Delete]
    @UserName [nvarchar](20)
AS
BEGIN
    DELETE [dbo].[Account]
    WHERE ([UserName] = @UserName)
END
GO
/****** Object:  Table [dbo].[InterestTag]    Script Date: 4/26/2018 1:31:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InterestTag]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[InterestTag](
	[TagName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.InterestTag] PRIMARY KEY CLUSTERED 
(
	[TagName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[InterestTag_Insert]    Script Date: 4/26/2018 1:31:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InterestTag_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InterestTag_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[InterestTag_Insert]
    @TagName [nvarchar](128)
AS
BEGIN
    INSERT [dbo].[InterestTag]([TagName])
    VALUES (@TagName)
END
GO
/****** Object:  StoredProcedure [dbo].[InterestTag_Update]    Script Date: 4/26/2018 1:31:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InterestTag_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InterestTag_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[InterestTag_Update]
    @TagName [nvarchar](128)
AS
BEGIN
    RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[InterestTag_Delete]    Script Date: 4/26/2018 1:31:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InterestTag_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InterestTag_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[InterestTag_Delete]
    @TagName [nvarchar](128)
AS
BEGIN
    DELETE [dbo].[InterestTag]
    WHERE ([TagName] = @TagName)
END
GO
/****** Object:  Table [dbo].[Article]    Script Date: 4/26/2018 1:31:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Article]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Article](
	[ArticleLink] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ArticleTitle] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ArticleDescription] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TagName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_dbo.Article] PRIMARY KEY CLUSTERED 
(
	[ArticleLink] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Article]') AND name = N'IX_TagName')
CREATE NONCLUSTERED INDEX [IX_TagName] ON [dbo].[Article]
(
	[TagName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Article_Insert]    Script Date: 4/26/2018 1:31:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Article_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Article_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[Article_Insert]
    @ArticleLink [nvarchar](128),
    @ArticleTitle [nvarchar](max),
    @ArticleDescription [nvarchar](max),
    @TagName [nvarchar](128)
AS
BEGIN
    INSERT [dbo].[Article]([ArticleLink], [ArticleTitle], [ArticleDescription], [TagName])
    VALUES (@ArticleLink, @ArticleTitle, @ArticleDescription, @TagName)
END
GO
/****** Object:  StoredProcedure [dbo].[Article_Update]    Script Date: 4/26/2018 1:31:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Article_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Article_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[Article_Update]
    @ArticleLink [nvarchar](128),
    @ArticleTitle [nvarchar](max),
    @ArticleDescription [nvarchar](max),
    @TagName [nvarchar](128)
AS
BEGIN
    UPDATE [dbo].[Article]
    SET [ArticleTitle] = @ArticleTitle, [ArticleDescription] = @ArticleDescription, [TagName] = @TagName
    WHERE ([ArticleLink] = @ArticleLink)
END
GO
/****** Object:  StoredProcedure [dbo].[Article_Delete]    Script Date: 4/26/2018 1:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Article_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Article_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[Article_Delete]
    @ArticleLink [nvarchar](128)
AS
BEGIN
    DELETE [dbo].[Article]
    WHERE ([ArticleLink] = @ArticleLink)
END
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 4/26/2018 1:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permission]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Permission](
	[PermissionName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.Permission] PRIMARY KEY CLUSTERED 
(
	[PermissionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 4/26/2018 1:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AccountType](
	[Username] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PermissionName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.AccountType] PRIMARY KEY CLUSTERED 
(
	[Username] ASC,
	[PermissionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AccountType]') AND name = N'IX_PermissionName')
CREATE NONCLUSTERED INDEX [IX_PermissionName] ON [dbo].[AccountType]
(
	[PermissionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AccountType]') AND name = N'IX_Username')
CREATE NONCLUSTERED INDEX [IX_Username] ON [dbo].[AccountType]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AccountType_Insert]    Script Date: 4/26/2018 1:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountType_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AccountType_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[AccountType_Insert]
    @Username [nvarchar](20),
    @PermissionName [nvarchar](128)
AS
BEGIN
    INSERT [dbo].[AccountType]([Username], [PermissionName])
    VALUES (@Username, @PermissionName)
END
GO
/****** Object:  StoredProcedure [dbo].[AccountType_Update]    Script Date: 4/26/2018 1:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountType_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AccountType_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[AccountType_Update]
    @Username [nvarchar](20),
    @PermissionName [nvarchar](128)
AS
BEGIN
    RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[AccountType_Delete]    Script Date: 4/26/2018 1:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountType_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AccountType_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[AccountType_Delete]
    @Username [nvarchar](20),
    @PermissionName [nvarchar](128)
AS
BEGIN
    DELETE [dbo].[AccountType]
    WHERE (([Username] = @Username) AND ([PermissionName] = @PermissionName))
END
GO
/****** Object:  StoredProcedure [dbo].[Permission_Insert]    Script Date: 4/26/2018 1:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permission_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Permission_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[Permission_Insert]
    @PermissionName [nvarchar](128)
AS
BEGIN
    INSERT [dbo].[Permission]([PermissionName])
    VALUES (@PermissionName)
END
GO
/****** Object:  StoredProcedure [dbo].[Permission_Update]    Script Date: 4/26/2018 1:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permission_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Permission_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[Permission_Update]
    @PermissionName [nvarchar](128)
AS
BEGIN
    RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[Permission_Delete]    Script Date: 4/26/2018 1:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permission_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Permission_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[Permission_Delete]
    @PermissionName [nvarchar](128)
AS
BEGIN
    DELETE [dbo].[Permission]
    WHERE ([PermissionName] = @PermissionName)
END
GO
/****** Object:  Table [dbo].[SecurityQuestion]    Script Date: 4/26/2018 1:31:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SecurityQuestion](
	[SecurityQuestionID] [int] IDENTITY(1,1) NOT NULL,
	[SecQuestion] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.SecurityQuestion] PRIMARY KEY CLUSTERED 
(
	[SecurityQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[SecurityQuestion_Insert]    Script Date: 4/26/2018 1:31:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestion_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SecurityQuestion_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[SecurityQuestion_Insert]
    @SecQuestion [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[SecurityQuestion]([SecQuestion])
    VALUES (@SecQuestion)
    
    DECLARE @SecurityQuestionID int
    SELECT @SecurityQuestionID = [SecurityQuestionID]
    FROM [dbo].[SecurityQuestion]
    WHERE @@ROWCOUNT > 0 AND [SecurityQuestionID] = scope_identity()
    
    SELECT t0.[SecurityQuestionID]
    FROM [dbo].[SecurityQuestion] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[SecurityQuestionID] = @SecurityQuestionID
END
GO
/****** Object:  StoredProcedure [dbo].[SecurityQuestion_Update]    Script Date: 4/26/2018 1:31:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestion_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SecurityQuestion_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[SecurityQuestion_Update]
    @SecurityQuestionID [int],
    @SecQuestion [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[SecurityQuestion]
    SET [SecQuestion] = @SecQuestion
    WHERE ([SecurityQuestionID] = @SecurityQuestionID)
END
GO
/****** Object:  StoredProcedure [dbo].[SecurityQuestion_Delete]    Script Date: 4/26/2018 1:31:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestion_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SecurityQuestion_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[SecurityQuestion_Delete]
    @SecurityQuestionID [int]
AS
BEGIN
    DELETE [dbo].[SecurityQuestion]
    WHERE ([SecurityQuestionID] = @SecurityQuestionID)
END
GO
/****** Object:  Table [dbo].[SecurityQuestionAccount]    Script Date: 4/26/2018 1:31:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestionAccount]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SecurityQuestionAccount](
	[SecurityQuestionID] [int] NOT NULL,
	[Username] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Answer] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.SecurityQuestionAccount] PRIMARY KEY CLUSTERED 
(
	[SecurityQuestionID] ASC,
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestionAccount]') AND name = N'IX_SecurityQuestionID')
CREATE NONCLUSTERED INDEX [IX_SecurityQuestionID] ON [dbo].[SecurityQuestionAccount]
(
	[SecurityQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestionAccount]') AND name = N'IX_Username')
CREATE NONCLUSTERED INDEX [IX_Username] ON [dbo].[SecurityQuestionAccount]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SecurityQuestionAccount_Insert]    Script Date: 4/26/2018 1:31:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestionAccount_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SecurityQuestionAccount_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[SecurityQuestionAccount_Insert]
    @Username [nvarchar](20),
    @SecurityQuestionID [int],
    @Answer [nvarchar](100)
AS
BEGIN
    INSERT [dbo].[SecurityQuestionAccount]([SecurityQuestionID], [Username], [Answer])
    VALUES (@SecurityQuestionID, @Username, @Answer)
END
GO
/****** Object:  StoredProcedure [dbo].[SecurityQuestionAccount_Update]    Script Date: 4/26/2018 1:31:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestionAccount_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SecurityQuestionAccount_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[SecurityQuestionAccount_Update]
    @Username [nvarchar](20),
    @SecurityQuestionID [int],
    @Answer [nvarchar](100)
AS
BEGIN
    UPDATE [dbo].[SecurityQuestionAccount]
    SET [Answer] = @Answer
    WHERE (([SecurityQuestionID] = @SecurityQuestionID) AND ([Username] = @Username))
END
GO
/****** Object:  StoredProcedure [dbo].[SecurityQuestionAccount_Delete]    Script Date: 4/26/2018 1:31:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestionAccount_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SecurityQuestionAccount_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[SecurityQuestionAccount_Delete]
    @Username [nvarchar](20),
    @SecurityQuestionID [int]
AS
BEGIN
    DELETE [dbo].[SecurityQuestionAccount]
    WHERE (([SecurityQuestionID] = @SecurityQuestionID) AND ([Username] = @Username))
END
GO
/****** Object:  Table [dbo].[BadAccessToken]    Script Date: 4/26/2018 1:31:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BadAccessToken]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BadAccessToken](
	[BadTokenId] [int] IDENTITY(1,1) NOT NULL,
	[BadTokenValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.BadAccessToken] PRIMARY KEY CLUSTERED 
(
	[BadTokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[BadAccessToken_Insert]    Script Date: 4/26/2018 1:31:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BadAccessToken_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[BadAccessToken_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[BadAccessToken_Insert]
    @BadTokenValue [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[BadAccessToken]([BadTokenValue])
    VALUES (@BadTokenValue)
    
    DECLARE @BadTokenId int
    SELECT @BadTokenId = [BadTokenId]
    FROM [dbo].[BadAccessToken]
    WHERE @@ROWCOUNT > 0 AND [BadTokenId] = scope_identity()
    
    SELECT t0.[BadTokenId]
    FROM [dbo].[BadAccessToken] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[BadTokenId] = @BadTokenId
END
GO
/****** Object:  StoredProcedure [dbo].[BadAccessToken_Update]    Script Date: 4/26/2018 1:31:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BadAccessToken_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[BadAccessToken_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[BadAccessToken_Update]
    @BadTokenId [int],
    @BadTokenValue [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[BadAccessToken]
    SET [BadTokenValue] = @BadTokenValue
    WHERE ([BadTokenId] = @BadTokenId)
END
GO
/****** Object:  StoredProcedure [dbo].[BadAccessToken_Delete]    Script Date: 4/26/2018 1:31:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BadAccessToken_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[BadAccessToken_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[BadAccessToken_Delete]
    @BadTokenId [int]
AS
BEGIN
    DELETE [dbo].[BadAccessToken]
    WHERE ([BadTokenId] = @BadTokenId)
END
GO
/****** Object:  Table [dbo].[ExpiredAccessToken]    Script Date: 4/26/2018 1:31:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpiredAccessToken]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExpiredAccessToken](
	[ExpiredTokenId] [int] IDENTITY(1,1) NOT NULL,
	[ExpiredTokenValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CanReuse] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ExpiredAccessToken] PRIMARY KEY CLUSTERED 
(
	[ExpiredTokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[ExpiredAccessToken_Insert]    Script Date: 4/26/2018 1:31:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpiredAccessToken_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpiredAccessToken_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[ExpiredAccessToken_Insert]
    @ExpiredTokenValue [nvarchar](max),
    @CanReuse [bit]
AS
BEGIN
    INSERT [dbo].[ExpiredAccessToken]([ExpiredTokenValue], [CanReuse])
    VALUES (@ExpiredTokenValue, @CanReuse)
    
    DECLARE @ExpiredTokenId int
    SELECT @ExpiredTokenId = [ExpiredTokenId]
    FROM [dbo].[ExpiredAccessToken]
    WHERE @@ROWCOUNT > 0 AND [ExpiredTokenId] = scope_identity()
    
    SELECT t0.[ExpiredTokenId]
    FROM [dbo].[ExpiredAccessToken] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[ExpiredTokenId] = @ExpiredTokenId
END
GO
/****** Object:  StoredProcedure [dbo].[ExpiredAccessToken_Update]    Script Date: 4/26/2018 1:31:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpiredAccessToken_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpiredAccessToken_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[ExpiredAccessToken_Update]
    @ExpiredTokenId [int],
    @ExpiredTokenValue [nvarchar](max),
    @CanReuse [bit]
AS
BEGIN
    UPDATE [dbo].[ExpiredAccessToken]
    SET [ExpiredTokenValue] = @ExpiredTokenValue, [CanReuse] = @CanReuse
    WHERE ([ExpiredTokenId] = @ExpiredTokenId)
END
GO
/****** Object:  StoredProcedure [dbo].[ExpiredAccessToken_Delete]    Script Date: 4/26/2018 1:31:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpiredAccessToken_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpiredAccessToken_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[ExpiredAccessToken_Delete]
    @ExpiredTokenId [int]
AS
BEGIN
    DELETE [dbo].[ExpiredAccessToken]
    WHERE ([ExpiredTokenId] = @ExpiredTokenId)
END
GO
/****** Object:  Table [dbo].[JAccessToken]    Script Date: 4/26/2018 1:31:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JAccessToken]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[JAccessToken](
	[UserName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TokenId] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DateTimeIssued] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.JAccessToken] PRIMARY KEY CLUSTERED 
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[JAccessToken]') AND name = N'IX_UserName')
CREATE NONCLUSTERED INDEX [IX_UserName] ON [dbo].[JAccessToken]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[JAccessToken_Insert]    Script Date: 4/26/2018 1:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JAccessToken_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[JAccessToken_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[JAccessToken_Insert]
    @Value [nvarchar](max),
    @UserName [nvarchar](20),
    @DateTimeIssued [datetime]
AS
BEGIN
    INSERT [dbo].[JAccessToken]([UserName], [Value], [DateTimeIssued])
    VALUES (@UserName, @Value, @DateTimeIssued)
    
    DECLARE @TokenId int
    SELECT @TokenId = [TokenId]
    FROM [dbo].[JAccessToken]
    WHERE @@ROWCOUNT > 0 AND [TokenId] = scope_identity()
    
    SELECT t0.[TokenId]
    FROM [dbo].[JAccessToken] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[TokenId] = @TokenId
END
GO
/****** Object:  StoredProcedure [dbo].[JAccessToken_Update]    Script Date: 4/26/2018 1:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JAccessToken_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[JAccessToken_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[JAccessToken_Update]
    @TokenId [int],
    @Value [nvarchar](max),
    @UserName [nvarchar](20),
    @DateTimeIssued [datetime]
AS
BEGIN
    UPDATE [dbo].[JAccessToken]
    SET [UserName] = @UserName, [Value] = @Value, [DateTimeIssued] = @DateTimeIssued
    WHERE ([TokenId] = @TokenId)
END
GO
/****** Object:  StoredProcedure [dbo].[JAccessToken_Delete]    Script Date: 4/26/2018 1:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JAccessToken_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[JAccessToken_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[JAccessToken_Delete]
    @TokenId [int]
AS
BEGIN
    DELETE [dbo].[JAccessToken]
    WHERE ([TokenId] = @TokenId)
END
GO
/****** Object:  Table [dbo].[PartialAccount]    Script Date: 4/26/2018 1:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PartialAccount]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PartialAccount](
	[UserName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AccountType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.PartialAccount] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[PartialAccount_Insert]    Script Date: 4/26/2018 1:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PartialAccount_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PartialAccount_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[PartialAccount_Insert]
    @UserName [nvarchar](20),
    @Password [nvarchar](50),
    @AccountType [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[PartialAccount]([UserName], [Password], [AccountType])
    VALUES (@UserName, @Password, @AccountType)
END
GO
/****** Object:  StoredProcedure [dbo].[PartialAccount_Update]    Script Date: 4/26/2018 1:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PartialAccount_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PartialAccount_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[PartialAccount_Update]
    @UserName [nvarchar](20),
    @Password [nvarchar](50),
    @AccountType [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[PartialAccount]
    SET [Password] = @Password, [AccountType] = @AccountType
    WHERE ([UserName] = @UserName)
END
GO
/****** Object:  StoredProcedure [dbo].[PartialAccount_Delete]    Script Date: 4/26/2018 1:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PartialAccount_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PartialAccount_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[PartialAccount_Delete]
    @UserName [nvarchar](20)
AS
BEGIN
    DELETE [dbo].[PartialAccount]
    WHERE ([UserName] = @UserName)
END
GO
/****** Object:  Table [dbo].[PartialAccountSalt]    Script Date: 4/26/2018 1:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PartialAccountSalt]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PartialAccountSalt](
	[SaltId] [int] IDENTITY(1,1) NOT NULL,
	[PasswordSalt] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.PartialAccountSalt] PRIMARY KEY CLUSTERED 
(
	[SaltId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PartialAccountSalt]') AND name = N'IX_UserName')
CREATE NONCLUSTERED INDEX [IX_UserName] ON [dbo].[PartialAccountSalt]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[PartialAccountSalt_Insert]    Script Date: 4/26/2018 1:31:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PartialAccountSalt_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PartialAccountSalt_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[PartialAccountSalt_Insert]
    @PasswordSalt [nvarchar](max),
    @UserName [nvarchar](20)
AS
BEGIN
    INSERT [dbo].[PartialAccountSalt]([PasswordSalt], [UserName])
    VALUES (@PasswordSalt, @UserName)
    
    DECLARE @SaltId int
    SELECT @SaltId = [SaltId]
    FROM [dbo].[PartialAccountSalt]
    WHERE @@ROWCOUNT > 0 AND [SaltId] = scope_identity()
    
    SELECT t0.[SaltId]
    FROM [dbo].[PartialAccountSalt] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[SaltId] = @SaltId
END
GO
/****** Object:  StoredProcedure [dbo].[PartialAccountSalt_Update]    Script Date: 4/26/2018 1:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PartialAccountSalt_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PartialAccountSalt_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[PartialAccountSalt_Update]
    @SaltId [int],
    @PasswordSalt [nvarchar](max),
    @UserName [nvarchar](20)
AS
BEGIN
    UPDATE [dbo].[PartialAccountSalt]
    SET [PasswordSalt] = @PasswordSalt, [UserName] = @UserName
    WHERE ([SaltId] = @SaltId)
END
GO
/****** Object:  StoredProcedure [dbo].[PartialAccountSalt_Delete]    Script Date: 4/26/2018 1:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PartialAccountSalt_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PartialAccountSalt_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[PartialAccountSalt_Delete]
    @SaltId [int]
AS
BEGIN
    DELETE [dbo].[PartialAccountSalt]
    WHERE ([SaltId] = @SaltId)
END
GO
/****** Object:  Table [dbo].[Salt]    Script Date: 4/26/2018 1:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Salt]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Salt](
	[SaltId] [int] IDENTITY(1,1) NOT NULL,
	[PasswordSalt] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.Salt] PRIMARY KEY CLUSTERED 
(
	[SaltId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Salt]') AND name = N'IX_UserName')
CREATE NONCLUSTERED INDEX [IX_UserName] ON [dbo].[Salt]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Salt_Insert]    Script Date: 4/26/2018 1:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Salt_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Salt_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[Salt_Insert]
    @PasswordSalt [nvarchar](max),
    @UserName [nvarchar](20)
AS
BEGIN
    INSERT [dbo].[Salt]([PasswordSalt], [UserName])
    VALUES (@PasswordSalt, @UserName)
    
    DECLARE @SaltId int
    SELECT @SaltId = [SaltId]
    FROM [dbo].[Salt]
    WHERE @@ROWCOUNT > 0 AND [SaltId] = scope_identity()
    
    SELECT t0.[SaltId]
    FROM [dbo].[Salt] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[SaltId] = @SaltId
END
GO
/****** Object:  StoredProcedure [dbo].[Salt_Update]    Script Date: 4/26/2018 1:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Salt_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Salt_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[Salt_Update]
    @SaltId [int],
    @PasswordSalt [nvarchar](max),
    @UserName [nvarchar](20)
AS
BEGIN
    UPDATE [dbo].[Salt]
    SET [PasswordSalt] = @PasswordSalt, [UserName] = @UserName
    WHERE ([SaltId] = @SaltId)
END
GO
/****** Object:  StoredProcedure [dbo].[Salt_Delete]    Script Date: 4/26/2018 1:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Salt_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Salt_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[Salt_Delete]
    @SaltId [int]
AS
BEGIN
    DELETE [dbo].[Salt]
    WHERE ([SaltId] = @SaltId)
END
GO
/****** Object:  Table [dbo].[SweepStake]    Script Date: 4/26/2018 1:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SweepStake]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SweepStake](
	[SweepStakesID] [int] IDENTITY(1,1) NOT NULL,
	[OpenDateTime] [datetime] NOT NULL,
	[ClosedDateTime] [datetime] NOT NULL,
	[Prize] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Price] [int] NOT NULL,
	[UsernameWinner] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_dbo.SweepStake] PRIMARY KEY CLUSTERED 
(
	[SweepStakesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SweepStakeEntry]    Script Date: 4/26/2018 1:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SweepStakeEntry]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SweepStakeEntry](
	[SweepstakesID] [int] NOT NULL,
	[UserName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PurchaseDateTime] [datetime] NOT NULL,
	[Cost] [int] NOT NULL,
	[OpenDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.SweepStakeEntry] PRIMARY KEY CLUSTERED 
(
	[SweepstakesID] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SweepStakeEntry]') AND name = N'IX_SweepstakesID')
CREATE NONCLUSTERED INDEX [IX_SweepstakesID] ON [dbo].[SweepStakeEntry]
(
	[SweepstakesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SweepStakeEntry]') AND name = N'IX_UserName')
CREATE NONCLUSTERED INDEX [IX_UserName] ON [dbo].[SweepStakeEntry]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SweepStakeEntry_Insert]    Script Date: 4/26/2018 1:31:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SweepStakeEntry_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SweepStakeEntry_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[SweepStakeEntry_Insert]
    @SweepstakesID [int],
    @UserName [nvarchar](20),
    @PurchaseDateTime [datetime],
    @Cost [int],
    @OpenDateTime [datetime]
AS
BEGIN
    INSERT [dbo].[SweepStakeEntry]([SweepstakesID], [UserName], [PurchaseDateTime], [Cost], [OpenDateTime])
    VALUES (@SweepstakesID, @UserName, @PurchaseDateTime, @Cost, @OpenDateTime)
END
GO
/****** Object:  StoredProcedure [dbo].[SweepStakeEntry_Update]    Script Date: 4/26/2018 1:31:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SweepStakeEntry_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SweepStakeEntry_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[SweepStakeEntry_Update]
    @SweepstakesID [int],
    @UserName [nvarchar](20),
    @PurchaseDateTime [datetime],
    @Cost [int],
    @OpenDateTime [datetime]
AS
BEGIN
    UPDATE [dbo].[SweepStakeEntry]
    SET [PurchaseDateTime] = @PurchaseDateTime, [Cost] = @Cost, [OpenDateTime] = @OpenDateTime
    WHERE (([SweepstakesID] = @SweepstakesID) AND ([UserName] = @UserName))
END
GO
/****** Object:  StoredProcedure [dbo].[SweepStakeEntry_Delete]    Script Date: 4/26/2018 1:31:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SweepStakeEntry_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SweepStakeEntry_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[SweepStakeEntry_Delete]
    @SweepstakesID [int],
    @UserName [nvarchar](20)
AS
BEGIN
    DELETE [dbo].[SweepStakeEntry]
    WHERE (([SweepstakesID] = @SweepstakesID) AND ([UserName] = @UserName))
END
GO
/****** Object:  StoredProcedure [dbo].[SweepStake_Insert]    Script Date: 4/26/2018 1:31:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SweepStake_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SweepStake_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[SweepStake_Insert]
    @OpenDateTime [datetime],
    @ClosedDateTime [datetime],
    @Prize [nvarchar](max),
    @Price [int],
    @UsernameWinner [nvarchar](20)
AS
BEGIN
    INSERT [dbo].[SweepStake]([OpenDateTime], [ClosedDateTime], [Prize], [Price], [UsernameWinner])
    VALUES (@OpenDateTime, @ClosedDateTime, @Prize, @Price, @UsernameWinner)
    
    DECLARE @SweepStakesID int
    SELECT @SweepStakesID = [SweepStakesID]
    FROM [dbo].[SweepStake]
    WHERE @@ROWCOUNT > 0 AND [SweepStakesID] = scope_identity()
    
    SELECT t0.[SweepStakesID]
    FROM [dbo].[SweepStake] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[SweepStakesID] = @SweepStakesID
END
GO
/****** Object:  StoredProcedure [dbo].[SweepStake_Update]    Script Date: 4/26/2018 1:31:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SweepStake_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SweepStake_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[SweepStake_Update]
    @SweepStakesID [int],
    @OpenDateTime [datetime],
    @ClosedDateTime [datetime],
    @Prize [nvarchar](max),
    @Price [int],
    @UsernameWinner [nvarchar](20)
AS
BEGIN
    UPDATE [dbo].[SweepStake]
    SET [OpenDateTime] = @OpenDateTime, [ClosedDateTime] = @ClosedDateTime, [Prize] = @Prize, [Price] = @Price, [UsernameWinner] = @UsernameWinner
    WHERE ([SweepStakesID] = @SweepStakesID)
END
GO
/****** Object:  StoredProcedure [dbo].[SweepStake_Delete]    Script Date: 4/26/2018 1:31:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SweepStake_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SweepStake_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[SweepStake_Delete]
    @SweepStakesID [int]
AS
BEGIN
    DELETE [dbo].[SweepStake]
    WHERE ([SweepStakesID] = @SweepStakesID)
END
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 4/26/2018 1:31:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserProfile](
	[Email] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FirstName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LastName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Account_UserName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_dbo.UserProfile] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile]') AND name = N'IX_Account_UserName')
CREATE NONCLUSTERED INDEX [IX_Account_UserName] ON [dbo].[UserProfile]
(
	[Account_UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[UserProfile_Insert]    Script Date: 4/26/2018 1:31:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UserProfile_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[UserProfile_Insert]
    @Email [nvarchar](128),
    @FirstName [nvarchar](50),
    @LastName [nvarchar](50),
    @Account_UserName [nvarchar](20)
AS
BEGIN
    INSERT [dbo].[UserProfile]([Email], [FirstName], [LastName], [Account_UserName])
    VALUES (@Email, @FirstName, @LastName, @Account_UserName)
END
GO
/****** Object:  StoredProcedure [dbo].[UserProfile_Update]    Script Date: 4/26/2018 1:31:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UserProfile_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[UserProfile_Update]
    @Email [nvarchar](128),
    @FirstName [nvarchar](50),
    @LastName [nvarchar](50),
    @Account_UserName [nvarchar](20)
AS
BEGIN
    UPDATE [dbo].[UserProfile]
    SET [FirstName] = @FirstName, [LastName] = @LastName, [Account_UserName] = @Account_UserName
    WHERE ([Email] = @Email)
END
GO
/****** Object:  StoredProcedure [dbo].[UserProfile_Delete]    Script Date: 4/26/2018 1:31:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UserProfile_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[UserProfile_Delete]
    @Email [nvarchar](128),
    @Account_UserName [nvarchar](20)
AS
BEGIN
    DELETE [dbo].[UserProfile]
    WHERE (([Email] = @Email) AND (([Account_UserName] = @Account_UserName) OR ([Account_UserName] IS NULL AND @Account_UserName IS NULL)))
END
GO
/****** Object:  Table [dbo].[ZipLocation]    Script Date: 4/26/2018 1:31:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZipLocation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ZipLocation](
	[ZipCodeId] [int] IDENTITY(1,1) NOT NULL,
	[ZipCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Address] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[City] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[State] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Latitude] [int] NOT NULL,
	[Longitude] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ZipLocation] PRIMARY KEY CLUSTERED 
(
	[ZipCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[ZipLocation_Insert]    Script Date: 4/26/2018 1:31:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZipLocation_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ZipLocation_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[ZipLocation_Insert]
    @ZipCode [nvarchar](10),
    @Address [nvarchar](max),
    @City [nvarchar](max),
    @State [nvarchar](max),
    @Latitude [int],
    @Longitude [int]
AS
BEGIN
    INSERT [dbo].[ZipLocation]([ZipCode], [Address], [City], [State], [Latitude], [Longitude])
    VALUES (@ZipCode, @Address, @City, @State, @Latitude, @Longitude)
    
    DECLARE @ZipCodeId int
    SELECT @ZipCodeId = [ZipCodeId]
    FROM [dbo].[ZipLocation]
    WHERE @@ROWCOUNT > 0 AND [ZipCodeId] = scope_identity()
    
    SELECT t0.[ZipCodeId]
    FROM [dbo].[ZipLocation] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[ZipCodeId] = @ZipCodeId
END
GO
/****** Object:  StoredProcedure [dbo].[ZipLocation_Update]    Script Date: 4/26/2018 1:31:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZipLocation_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ZipLocation_Update] AS' 
END
GO
ALTER PROCEDURE [dbo].[ZipLocation_Update]
    @ZipCodeId [int],
    @ZipCode [nvarchar](10),
    @Address [nvarchar](max),
    @City [nvarchar](max),
    @State [nvarchar](max),
    @Latitude [int],
    @Longitude [int]
AS
BEGIN
    UPDATE [dbo].[ZipLocation]
    SET [ZipCode] = @ZipCode, [Address] = @Address, [City] = @City, [State] = @State, [Latitude] = @Latitude, [Longitude] = @Longitude
    WHERE ([ZipCodeId] = @ZipCodeId)
END
GO
/****** Object:  StoredProcedure [dbo].[ZipLocation_Delete]    Script Date: 4/26/2018 1:31:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZipLocation_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ZipLocation_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[ZipLocation_Delete]
    @ZipCodeId [int]
AS
BEGIN
    DELETE [dbo].[ZipLocation]
    WHERE ([ZipCodeId] = @ZipCodeId)
END
GO
/****** Object:  Table [dbo].[AccountInterestTag]    Script Date: 4/26/2018 1:31:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountInterestTag]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AccountInterestTag](
	[Account_UserName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[InterestTag_TagName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.AccountInterestTag] PRIMARY KEY CLUSTERED 
(
	[Account_UserName] ASC,
	[InterestTag_TagName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AccountInterestTag]') AND name = N'IX_Account_UserName')
CREATE NONCLUSTERED INDEX [IX_Account_UserName] ON [dbo].[AccountInterestTag]
(
	[Account_UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AccountInterestTag]') AND name = N'IX_InterestTag_TagName')
CREATE NONCLUSTERED INDEX [IX_InterestTag_TagName] ON [dbo].[AccountInterestTag]
(
	[InterestTag_TagName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AccountInterestTag_Insert]    Script Date: 4/26/2018 1:31:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountInterestTag_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AccountInterestTag_Insert] AS' 
END
GO
ALTER PROCEDURE [dbo].[AccountInterestTag_Insert]
    @Account_UserName [nvarchar](20),
    @InterestTag_TagName [nvarchar](128)
AS
BEGIN
    INSERT [dbo].[AccountInterestTag]([Account_UserName], [InterestTag_TagName])
    VALUES (@Account_UserName, @InterestTag_TagName)
END
GO
/****** Object:  StoredProcedure [dbo].[AccountInterestTag_Delete]    Script Date: 4/26/2018 1:31:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountInterestTag_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AccountInterestTag_Delete] AS' 
END
GO
ALTER PROCEDURE [dbo].[AccountInterestTag_Delete]
    @Account_UserName [nvarchar](20),
    @InterestTag_TagName [nvarchar](128)
AS
BEGIN
    DELETE [dbo].[AccountInterestTag]
    WHERE (([Account_UserName] = @Account_UserName) AND ([InterestTag_TagName] = @InterestTag_TagName))
END
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 4/26/2018 1:31:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ContextKey] [nvarchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SaltSecurityAnswer]    Script Date: 4/26/2018 1:31:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SaltSecurityAnswer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SaltSecurityAnswer](
	[SaltId] [int] IDENTITY(1,1) NOT NULL,
	[SaltValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SecurityQuestionID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SaltSecurityAnswer] PRIMARY KEY CLUSTERED 
(
	[SaltId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SaltSecurityAnswer]') AND name = N'IX_SecurityQuestionID')
CREATE NONCLUSTERED INDEX [IX_SecurityQuestionID] ON [dbo].[SaltSecurityAnswer]
(
	[SecurityQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SaltSecurityAnswer]') AND name = N'IX_UserName')
CREATE NONCLUSTERED INDEX [IX_UserName] ON [dbo].[SaltSecurityAnswer]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LinkedInAccessToken]    Script Date: 4/26/2018 1:31:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinkedInAccessToken]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LinkedInAccessToken](
	[TokenId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Value] [nvarchar](2000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TokenCreation] [datetime] NOT NULL,
	[Expired] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.LinkedInAccessToken] PRIMARY KEY CLUSTERED 
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LinkedInAccessToken]') AND name = N'IX_UserName')
CREATE NONCLUSTERED INDEX [IX_UserName] ON [dbo].[LinkedInAccessToken]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 4/26/2018 1:31:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Address]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Address](
	[Email] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ZipCodeId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Address] PRIMARY KEY CLUSTERED 
(
	[Email] ASC,
	[ZipCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON

GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Address]') AND name = N'IX_Email')
CREATE NONCLUSTERED INDEX [IX_Email] ON [dbo].[Address]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Address]') AND name = N'IX_ZipCodeId')
CREATE NONCLUSTERED INDEX [IX_ZipCodeId] ON [dbo].[Address]
(
	[ZipCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Article_dbo.InterestTag_TagName]') AND parent_object_id = OBJECT_ID(N'[dbo].[Article]'))
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Article_dbo.InterestTag_TagName] FOREIGN KEY([TagName])
REFERENCES [dbo].[InterestTag] ([TagName])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Article_dbo.InterestTag_TagName]') AND parent_object_id = OBJECT_ID(N'[dbo].[Article]'))
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_dbo.Article_dbo.InterestTag_TagName]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AccountType_dbo.Account_Username]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountType]'))
ALTER TABLE [dbo].[AccountType]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AccountType_dbo.Account_Username] FOREIGN KEY([Username])
REFERENCES [dbo].[Account] ([UserName])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AccountType_dbo.Account_Username]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountType]'))
ALTER TABLE [dbo].[AccountType] CHECK CONSTRAINT [FK_dbo.AccountType_dbo.Account_Username]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AccountType_dbo.Permission_PermissionName]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountType]'))
ALTER TABLE [dbo].[AccountType]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AccountType_dbo.Permission_PermissionName] FOREIGN KEY([PermissionName])
REFERENCES [dbo].[Permission] ([PermissionName])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AccountType_dbo.Permission_PermissionName]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountType]'))
ALTER TABLE [dbo].[AccountType] CHECK CONSTRAINT [FK_dbo.AccountType_dbo.Permission_PermissionName]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.SecurityQuestionAccount_dbo.Account_Username]') AND parent_object_id = OBJECT_ID(N'[dbo].[SecurityQuestionAccount]'))
ALTER TABLE [dbo].[SecurityQuestionAccount]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SecurityQuestionAccount_dbo.Account_Username] FOREIGN KEY([Username])
REFERENCES [dbo].[Account] ([UserName])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.SecurityQuestionAccount_dbo.Account_Username]') AND parent_object_id = OBJECT_ID(N'[dbo].[SecurityQuestionAccount]'))
ALTER TABLE [dbo].[SecurityQuestionAccount] CHECK CONSTRAINT [FK_dbo.SecurityQuestionAccount_dbo.Account_Username]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.SecurityQuestionAccount_dbo.SecurityQuestion_SecurityQuestionID]') AND parent_object_id = OBJECT_ID(N'[dbo].[SecurityQuestionAccount]'))
ALTER TABLE [dbo].[SecurityQuestionAccount]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SecurityQuestionAccount_dbo.SecurityQuestion_SecurityQuestionID] FOREIGN KEY([SecurityQuestionID])
REFERENCES [dbo].[SecurityQuestion] ([SecurityQuestionID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.SecurityQuestionAccount_dbo.SecurityQuestion_SecurityQuestionID]') AND parent_object_id = OBJECT_ID(N'[dbo].[SecurityQuestionAccount]'))
ALTER TABLE [dbo].[SecurityQuestionAccount] CHECK CONSTRAINT [FK_dbo.SecurityQuestionAccount_dbo.SecurityQuestion_SecurityQuestionID]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.JAccessToken_dbo.Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[JAccessToken]'))
ALTER TABLE [dbo].[JAccessToken]  WITH CHECK ADD  CONSTRAINT [FK_dbo.JAccessToken_dbo.Account_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Account] ([UserName])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.JAccessToken_dbo.Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[JAccessToken]'))
ALTER TABLE [dbo].[JAccessToken] CHECK CONSTRAINT [FK_dbo.JAccessToken_dbo.Account_UserName]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.PartialAccountSalt_dbo.PartialAccount_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[PartialAccountSalt]'))
ALTER TABLE [dbo].[PartialAccountSalt]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PartialAccountSalt_dbo.PartialAccount_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[PartialAccount] ([UserName])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.PartialAccountSalt_dbo.PartialAccount_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[PartialAccountSalt]'))
ALTER TABLE [dbo].[PartialAccountSalt] CHECK CONSTRAINT [FK_dbo.PartialAccountSalt_dbo.PartialAccount_UserName]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Salt_dbo.Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[Salt]'))
ALTER TABLE [dbo].[Salt]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Salt_dbo.Account_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Account] ([UserName])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Salt_dbo.Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[Salt]'))
ALTER TABLE [dbo].[Salt] CHECK CONSTRAINT [FK_dbo.Salt_dbo.Account_UserName]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.SweepStakeEntry_dbo.Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[SweepStakeEntry]'))
ALTER TABLE [dbo].[SweepStakeEntry]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SweepStakeEntry_dbo.Account_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Account] ([UserName])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.SweepStakeEntry_dbo.Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[SweepStakeEntry]'))
ALTER TABLE [dbo].[SweepStakeEntry] CHECK CONSTRAINT [FK_dbo.SweepStakeEntry_dbo.Account_UserName]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.SweepStakeEntry_dbo.SweepStake_SweepstakesID]') AND parent_object_id = OBJECT_ID(N'[dbo].[SweepStakeEntry]'))
ALTER TABLE [dbo].[SweepStakeEntry]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SweepStakeEntry_dbo.SweepStake_SweepstakesID] FOREIGN KEY([SweepstakesID])
REFERENCES [dbo].[SweepStake] ([SweepStakesID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.SweepStakeEntry_dbo.SweepStake_SweepstakesID]') AND parent_object_id = OBJECT_ID(N'[dbo].[SweepStakeEntry]'))
ALTER TABLE [dbo].[SweepStakeEntry] CHECK CONSTRAINT [FK_dbo.SweepStakeEntry_dbo.SweepStake_SweepstakesID]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.UserProfile_dbo.Account_Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserProfile]'))
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserProfile_dbo.Account_Account_UserName] FOREIGN KEY([Account_UserName])
REFERENCES [dbo].[Account] ([UserName])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.UserProfile_dbo.Account_Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserProfile]'))
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_dbo.UserProfile_dbo.Account_Account_UserName]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AccountInterestTag_dbo.Account_Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountInterestTag]'))
ALTER TABLE [dbo].[AccountInterestTag]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AccountInterestTag_dbo.Account_Account_UserName] FOREIGN KEY([Account_UserName])
REFERENCES [dbo].[Account] ([UserName])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AccountInterestTag_dbo.Account_Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountInterestTag]'))
ALTER TABLE [dbo].[AccountInterestTag] CHECK CONSTRAINT [FK_dbo.AccountInterestTag_dbo.Account_Account_UserName]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AccountInterestTag_dbo.InterestTag_InterestTag_TagName]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountInterestTag]'))
ALTER TABLE [dbo].[AccountInterestTag]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AccountInterestTag_dbo.InterestTag_InterestTag_TagName] FOREIGN KEY([InterestTag_TagName])
REFERENCES [dbo].[InterestTag] ([TagName])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AccountInterestTag_dbo.InterestTag_InterestTag_TagName]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountInterestTag]'))
ALTER TABLE [dbo].[AccountInterestTag] CHECK CONSTRAINT [FK_dbo.AccountInterestTag_dbo.InterestTag_InterestTag_TagName]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.SaltSecurityAnswer_dbo.Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[SaltSecurityAnswer]'))
ALTER TABLE [dbo].[SaltSecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SaltSecurityAnswer_dbo.Account_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Account] ([UserName])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.SaltSecurityAnswer_dbo.Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[SaltSecurityAnswer]'))
ALTER TABLE [dbo].[SaltSecurityAnswer] CHECK CONSTRAINT [FK_dbo.SaltSecurityAnswer_dbo.Account_UserName]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.SaltSecurityAnswer_dbo.SecurityQuestion_SecurityQuestionID]') AND parent_object_id = OBJECT_ID(N'[dbo].[SaltSecurityAnswer]'))
ALTER TABLE [dbo].[SaltSecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SaltSecurityAnswer_dbo.SecurityQuestion_SecurityQuestionID] FOREIGN KEY([SecurityQuestionID])
REFERENCES [dbo].[SecurityQuestion] ([SecurityQuestionID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.SaltSecurityAnswer_dbo.SecurityQuestion_SecurityQuestionID]') AND parent_object_id = OBJECT_ID(N'[dbo].[SaltSecurityAnswer]'))
ALTER TABLE [dbo].[SaltSecurityAnswer] CHECK CONSTRAINT [FK_dbo.SaltSecurityAnswer_dbo.SecurityQuestion_SecurityQuestionID]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.LinkedInAccessToken_dbo.Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[LinkedInAccessToken]'))
ALTER TABLE [dbo].[LinkedInAccessToken]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LinkedInAccessToken_dbo.Account_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Account] ([UserName])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.LinkedInAccessToken_dbo.Account_UserName]') AND parent_object_id = OBJECT_ID(N'[dbo].[LinkedInAccessToken]'))
ALTER TABLE [dbo].[LinkedInAccessToken] CHECK CONSTRAINT [FK_dbo.LinkedInAccessToken_dbo.Account_UserName]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Address_dbo.UserProfile_Email]') AND parent_object_id = OBJECT_ID(N'[dbo].[Address]'))
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Address_dbo.UserProfile_Email] FOREIGN KEY([Email])
REFERENCES [dbo].[UserProfile] ([Email])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Address_dbo.UserProfile_Email]') AND parent_object_id = OBJECT_ID(N'[dbo].[Address]'))
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_dbo.Address_dbo.UserProfile_Email]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Address_dbo.ZipLocation_ZipCodeId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Address]'))
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Address_dbo.ZipLocation_ZipCodeId] FOREIGN KEY([ZipCodeId])
REFERENCES [dbo].[ZipLocation] ([ZipCodeId])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Address_dbo.ZipLocation_ZipCodeId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Address]'))
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_dbo.Address_dbo.ZipLocation_ZipCodeId]
GO

