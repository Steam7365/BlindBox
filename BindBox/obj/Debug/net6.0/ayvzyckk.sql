IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'ao') IS NULL EXEC(N'CREATE SCHEMA [ao];');
GO

IF SCHEMA_ID(N'ro') IS NULL EXEC(N'CREATE SCHEMA [ro];');
GO

CREATE TABLE [ro].[box_folder] (
    [BoxFolderId] int NOT NULL IDENTITY,
    [BoxFolderName] nvarchar(20) NOT NULL,
    [IsDelete] bit NOT NULL,
    CONSTRAINT [PK_box_folder] PRIMARY KEY ([BoxFolderId])
);
GO

CREATE TABLE [ro].[grade] (
    [GradeId] int NOT NULL IDENTITY,
    [GradeName] nvarchar(20) NOT NULL,
    [Probability] float NOT NULL,
    [IsDelete] bit NOT NULL,
    CONSTRAINT [PK_grade] PRIMARY KEY ([GradeId])
);
GO

CREATE TABLE [ro].[staff] (
    [StaffId] int NOT NULL IDENTITY,
    [StaffName] nvarchar(20) NOT NULL,
    [StaffWages] money NOT NULL,
    [StaffGender] char(2) NOT NULL,
    [StaffPhone] nvarchar(11) NOT NULL,
    [StaffCode] nvarchar(18) NOT NULL,
    [StaffEntryTime] date NOT NULL DEFAULT (getdate()),
    [StaffPosition] nvarchar(20) NOT NULL,
    [StaffState] nvarchar(20) NULL,
    [Image] Image NULL,
    [Province] nvarchar(20) NULL,
    [City] nvarchar(20) NULL,
    [Area] nvarchar(20) NULL,
    [Details] nvarchar(200) NULL,
    CONSTRAINT [PK_staff] PRIMARY KEY ([StaffId])
);
GO

CREATE TABLE [ao].[userinfo] (
    [UserInfoId] int NOT NULL IDENTITY,
    [UserName] nvarchar(20) NOT NULL,
    [UserGender] char(2) NOT NULL,
    [UserNumber] nvarchar(20) NOT NULL,
    [UserPwd] nvarchar(20) NOT NULL,
    [UserPhone] nvarchar(11) NULL,
    [HeadPortrait] Image NULL,
    [Birthday] datetime2 NULL,
    [IsDelete] bit NOT NULL,
    CONSTRAINT [PK_userinfo] PRIMARY KEY ([UserInfoId])
);
GO

CREATE TABLE [ro].[box_commodity] (
    [BoxCommodityId] int NOT NULL IDENTITY,
    [CommodityName] nvarchar(20) NOT NULL,
    [CoverPhoto] Image NOT NULL,
    [Desc] nvarchar(400) NOT NULL,
    [Price] money NOT NULL,
    [BoxFolderId] int NULL,
    [IsDelete] bit NOT NULL,
    CONSTRAINT [PK_box_commodity] PRIMARY KEY ([BoxCommodityId]),
    CONSTRAINT [FK_box_commodity_box_folder_BoxFolderId] FOREIGN KEY ([BoxFolderId]) REFERENCES [ro].[box_folder] ([BoxFolderId])
);
GO

CREATE TABLE [ro].[box_commodity_detail] (
    [CommdityDetailId] int NOT NULL IDENTITY,
    [ComminfoName] nvarchar(20) NOT NULL,
    [ComminfoSpec] nvarchar(10) NOT NULL,
    [ComminfoPrice] money NOT NULL,
    [OfficiaPrice] money NULL,
    [ComminfoImg] Image NOT NULL,
    [GradeId] int NULL,
    [IsDelete] bit NOT NULL,
    CONSTRAINT [PK_box_commodity_detail] PRIMARY KEY ([CommdityDetailId]),
    CONSTRAINT [FK_box_commodity_detail_grade_GradeId] FOREIGN KEY ([GradeId]) REFERENCES [ro].[grade] ([GradeId])
);
GO

CREATE TABLE [ro].[login] (
    [LoginId] int NOT NULL IDENTITY,
    [LoginName] nvarchar(20) NOT NULL,
    [Password] nvarchar(20) NOT NULL,
    [StaffId] int NULL,
    CONSTRAINT [PK_login] PRIMARY KEY ([LoginId]),
    CONSTRAINT [FK_login_staff_StaffId] FOREIGN KEY ([StaffId]) REFERENCES [ro].[staff] ([StaffId])
);
GO

CREATE TABLE [ao].[addressinfo] (
    [AddressInfoId] int NOT NULL IDENTITY,
    [Province] nvarchar(20) NOT NULL,
    [City] nvarchar(20) NOT NULL,
    [Area] nvarchar(20) NOT NULL,
    [AddressDetails] nvarchar(200) NOT NULL,
    [Name] nvarchar(20) NOT NULL,
    [Phone] nvarchar(11) NOT NULL,
    [Phone2] nvarchar(11) NULL,
    [IsDefault] bit NOT NULL,
    [UserInfoId] int NOT NULL,
    [IsDelete] bit NOT NULL,
    CONSTRAINT [PK_addressinfo] PRIMARY KEY ([AddressInfoId]),
    CONSTRAINT [FK_addressinfo_userinfo_UserInfoId] FOREIGN KEY ([UserInfoId]) REFERENCES [ao].[userinfo] ([UserInfoId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ro].[box_connect] (
    [BoxCommoditiesBoxCommodityId] int NOT NULL,
    [CommdityDetailsCommdityDetailId] int NOT NULL,
    CONSTRAINT [PK_box_connect] PRIMARY KEY ([BoxCommoditiesBoxCommodityId], [CommdityDetailsCommdityDetailId]),
    CONSTRAINT [FK_box_connect_box_commodity_BoxCommoditiesBoxCommodityId] FOREIGN KEY ([BoxCommoditiesBoxCommodityId]) REFERENCES [ro].[box_commodity] ([BoxCommodityId]) ON DELETE CASCADE,
    CONSTRAINT [FK_box_connect_box_commodity_detail_CommdityDetailsCommdityDetailId] FOREIGN KEY ([CommdityDetailsCommdityDetailId]) REFERENCES [ro].[box_commodity_detail] ([CommdityDetailId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ro].[describetype] (
    [DescribeTypeId] int NOT NULL IDENTITY,
    [DescTitle] nvarchar(200) NOT NULL,
    [DescContent] nvarchar(200) NOT NULL,
    [CommdityDetailsCommdityDetailId] int NULL,
    [IsDelete] bit NOT NULL,
    CONSTRAINT [PK_describetype] PRIMARY KEY ([DescribeTypeId]),
    CONSTRAINT [FK_describetype_box_commodity_detail_CommdityDetailsCommdityDetailId] FOREIGN KEY ([CommdityDetailsCommdityDetailId]) REFERENCES [ro].[box_commodity_detail] ([CommdityDetailId])
);
GO

CREATE TABLE [ro].[draw] (
    [DrawId] nvarchar(450) NOT NULL,
    [CommdityDetailId] int NULL,
    [UserInfoId] int NULL,
    [IsDelete] bit NOT NULL,
    CONSTRAINT [PK_draw] PRIMARY KEY ([DrawId]),
    CONSTRAINT [FK_draw_box_commodity_detail_CommdityDetailId] FOREIGN KEY ([CommdityDetailId]) REFERENCES [ro].[box_commodity_detail] ([CommdityDetailId]),
    CONSTRAINT [FK_draw_userinfo_UserInfoId] FOREIGN KEY ([UserInfoId]) REFERENCES [ao].[userinfo] ([UserInfoId])
);
GO

CREATE TABLE [ao].[orderinfo] (
    [OrderInfoId] int NOT NULL IDENTITY,
    [Order] nvarchar(450) NOT NULL,
    [OrderState] nvarchar(20) NOT NULL,
    [Count] nvarchar(max) NOT NULL,
    [TotalPrice] money NOT NULL,
    [ActualPrice] money NOT NULL,
    [Freight] money NOT NULL,
    [Channel] nvarchar(10) NOT NULL,
    [CreateTime] datetime NOT NULL,
    [PaymentTime] datetime NULL,
    [DeliverTime] datetime NULL,
    [AddressInfoId] int NULL,
    [DrawId] nvarchar(450) NULL,
    CONSTRAINT [PK_orderinfo] PRIMARY KEY ([OrderInfoId]),
    CONSTRAINT [FK_orderinfo_addressinfo_AddressInfoId] FOREIGN KEY ([AddressInfoId]) REFERENCES [ao].[addressinfo] ([AddressInfoId]),
    CONSTRAINT [FK_orderinfo_draw_DrawId] FOREIGN KEY ([DrawId]) REFERENCES [ro].[draw] ([DrawId])
);
GO

CREATE INDEX [IX_addressinfo_UserInfoId] ON [ao].[addressinfo] ([UserInfoId]);
GO

CREATE INDEX [IX_box_commodity_BoxFolderId] ON [ro].[box_commodity] ([BoxFolderId]);
GO

CREATE INDEX [IX_box_commodity_detail_GradeId] ON [ro].[box_commodity_detail] ([GradeId]);
GO

CREATE INDEX [IX_box_connect_CommdityDetailsCommdityDetailId] ON [ro].[box_connect] ([CommdityDetailsCommdityDetailId]);
GO

CREATE INDEX [IX_describetype_CommdityDetailsCommdityDetailId] ON [ro].[describetype] ([CommdityDetailsCommdityDetailId]);
GO

CREATE INDEX [IX_draw_CommdityDetailId] ON [ro].[draw] ([CommdityDetailId]);
GO

CREATE INDEX [IX_draw_UserInfoId] ON [ro].[draw] ([UserInfoId]);
GO

CREATE INDEX [IX_login_StaffId] ON [ro].[login] ([StaffId]);
GO

CREATE INDEX [IX_orderinfo_AddressInfoId] ON [ao].[orderinfo] ([AddressInfoId]);
GO

CREATE INDEX [IX_orderinfo_DrawId] ON [ao].[orderinfo] ([DrawId]);
GO

CREATE UNIQUE INDEX [IX_orderinfo_Order] ON [ao].[orderinfo] ([Order]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221226081128_Init', N'7.0.1');
GO

COMMIT;
GO

