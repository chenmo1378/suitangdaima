USE [HRMSYSDB]
GO
/****** Object:  Table [dbo].[T_Setting]    Script Date: 12/26/2012 16:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Setting](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_T_Setting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_Setting] ([Id], [Name], [Value]) VALUES (N'7dcaa54e-f829-46f4-a94a-1a86846a219b', N'公司网站', N'http://ww.itcast.cn')
INSERT [dbo].[T_Setting] ([Id], [Name], [Value]) VALUES (N'2322f003-7b2f-4802-849a-3349bf2dee5b', N'启用生日提醒', N'True')
INSERT [dbo].[T_Setting] ([Id], [Name], [Value]) VALUES (N'35916c7d-a922-42e5-937d-66520206404f', N'员工工号前缀', N'YuanG')
INSERT [dbo].[T_Setting] ([Id], [Name], [Value]) VALUES (N'fafd177f-56d7-4e9b-8ff2-7b11a3d846cd', N'公司名称', N'黑马程序员')
INSERT [dbo].[T_Setting] ([Id], [Name], [Value]) VALUES (N'e976b062-971c-4339-9a40-fdf2120b4bff', N'生日提醒天数', N'3')
/****** Object:  Table [dbo].[T_SalarySheetItem]    Script Date: 12/26/2012 16:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SalarySheetItem](
	[Id] [uniqueidentifier] NOT NULL,
	[SheetId] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[Bonus] [money] NOT NULL,
	[BaseSalary] [money] NOT NULL,
	[Fine] [money] NOT NULL,
	[Other] [money] NOT NULL,
 CONSTRAINT [PK_T_SalarySheetItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_SalarySheetItem] ([Id], [SheetId], [EmployeeId], [Bonus], [BaseSalary], [Fine], [Other]) VALUES (N'808647f3-0ca4-4d7e-99bd-14b70e5a5c32', N'b3bc266f-9641-4644-a7d0-a3cf5c7c3785', N'e0fc6e6b-5e78-4005-83d0-bf7fe29598d0', 0.0000, 0.0000, 0.0000, 0.0000)
INSERT [dbo].[T_SalarySheetItem] ([Id], [SheetId], [EmployeeId], [Bonus], [BaseSalary], [Fine], [Other]) VALUES (N'0f300617-acec-44d8-9468-1e656f87382a', N'b3bc266f-9641-4644-a7d0-a3cf5c7c3785', N'a21eb469-94ac-46e0-8ab8-5e90fef8dbce', 0.0000, 0.0000, 0.0000, 0.0000)
/****** Object:  Table [dbo].[T_SalarySheet]    Script Date: 12/26/2012 16:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SalarySheet](
	[Id] [uniqueidentifier] NOT NULL,
	[Year] [int] NOT NULL,
	[Month] [int] NOT NULL,
	[DepartmentId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_T_SalarySheet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_SalarySheet] ([Id], [Year], [Month], [DepartmentId]) VALUES (N'b3bc266f-9641-4644-a7d0-a3cf5c7c3785', 2012, 12, N'7c444dbb-8f93-460f-b113-8ad1df6876d1')
/****** Object:  Table [dbo].[T_Operator]    Script Date: 12/26/2012 16:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Operator](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[RealName] [nvarchar](50) NOT NULL,
	[IsLocked] [bit] NOT NULL,
 CONSTRAINT [PK_T_Operator] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_Operator] ([Id], [UserName], [Password], [IsDeleted], [RealName], [IsLocked]) VALUES (N'd2edb784-2e11-454b-b7e7-20fe33185e0e', N'itcast', N'64ffd427749155c7521677d1948b5a1e', 0, N'传智播客', 0)
INSERT [dbo].[T_Operator] ([Id], [UserName], [Password], [IsDeleted], [RealName], [IsLocked]) VALUES (N'5c6d672b-dfc2-4fa1-a6f2-2c665c7b3cac', N'test', N'796bfc5359969ef246cc9924e1763e6e', 0, N'1234', 0)
INSERT [dbo].[T_Operator] ([Id], [UserName], [Password], [IsDeleted], [RealName], [IsLocked]) VALUES (N'ec260c5a-f641-49fe-b474-93ac209ea33c', N'yzk', N'c79493ddc71171170a3d1e568b5fc6de', 1, N'杨中科', 0)
INSERT [dbo].[T_Operator] ([Id], [UserName], [Password], [IsDeleted], [RealName], [IsLocked]) VALUES (N'dad58f47-2867-4aba-bde0-a5bab4bbaa4f', N'yyy', N'796bfc5359969ef246cc9924e1763e6e', 0, N'燕子口镇', 0)
/****** Object:  Table [dbo].[T_OperationLog]    Script Date: 12/26/2012 16:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_OperationLog](
	[Id] [uniqueidentifier] NOT NULL,
	[OperatorId] [uniqueidentifier] NOT NULL,
	[MakeDate] [datetime] NOT NULL,
	[ActionDesc] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_T_OperationLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'7c2f37c5-26d2-4d5d-8933-0416606370b1', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A13000F681CD AS DateTime), N'尝试登录失败')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'ef8e2adf-5004-4e53-a732-07f4d74e3a7f', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A130012764AC AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'a93f01ac-40c9-4304-a196-0af920b4d3d4', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A13000F6B5AA AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'6a1110a8-a8da-4d5b-a6ae-169da2938322', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A13000FEB23E AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'9f500fea-7689-45e7-996d-1711e6488d4b', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A1300116D2F7 AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'8121bdf1-2972-48d6-b026-214dab0b698c', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A130011570C5 AS DateTime), N'修改操作员test')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'4aa0ffd1-0d57-4ef7-9f8a-2c2979a11c56', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A1300115D055 AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'21d9b97a-4973-449e-a91b-324a7c6c42b3', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A13000FE219E AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'208a807c-bd5b-47c4-b023-373caa322a34', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A1300116F352 AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'470714df-f21b-4b9a-a38c-42e5b83f5150', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A13000FDBC08 AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'a9bf3a11-de0c-453e-9809-452c8a908e96', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A13000F6DAC7 AS DateTime), N'新增操作员test')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'27db5ae2-de7e-4631-b8fc-4939fe8d4ae3', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A130011566CB AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'fc28420c-820c-4ef0-9d8a-55917b3f6f2f', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A1300115AFBE AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'641ecfa8-a129-4e78-928d-7a040c06137a', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A13001270414 AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'3e0e4462-a1f5-47db-a59f-87b542f88a35', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A13000FDFB7A AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'782f5dc7-d8f7-400d-88d4-c1091398d72c', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A13001278528 AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'24aec38d-b7fe-49c4-b4b3-c3901823aedf', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A130012728B5 AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'82a06800-3304-4b1b-94e6-c7e8cb5ec141', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A130010D8866 AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'8a6633cd-e402-49e2-9eee-cfa6ef17a1db', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A130010D6EE8 AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'd5ec5709-ff0d-4dc7-b406-d17852708ae0', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A1300120B80E AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'20f14c1c-40a8-4570-a47a-d5feeaaab66a', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A13000F68633 AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'8b1e5e16-4924-4d7c-b07f-d7fb2119828f', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A13000F6D00F AS DateTime), N'新增操作员yyy')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'ddd95513-3201-46b5-a4ec-e133a5236eaa', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A1300116602E AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'486fa0d2-471e-43ed-a2e3-e7648bff5de3', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A13001158DE1 AS DateTime), N'修改操作员test')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'ab740ca4-7ac6-4a76-8b22-f36724239880', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A1300126A8ED AS DateTime), N'登录成功')
INSERT [dbo].[T_OperationLog] ([Id], [OperatorId], [MakeDate], [ActionDesc]) VALUES (N'ad60a8a4-df18-4b06-b82a-fc1e9b8683f5', N'd2edb784-2e11-454b-b7e7-20fe33185e0e', CAST(0x0000A13001267002 AS DateTime), N'登录成功')
/****** Object:  Table [dbo].[T_IdName]    Script Date: 12/26/2012 16:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_IdName](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'010f2847-dfbe-497a-b0cb-365f3c594264', N'专科', N'学历')
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'f0e73f7a-aae0-49c5-b556-4c198ab54312', N'本科', N'学历')
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'ccd51b95-b8c0-494b-8613-549127777df6', N'未婚', N'婚姻状况')
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'7eed0dac-e4dd-4b61-8d98-6cea02b7d985', N'女', N'性别')
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'5a915954-6815-4541-a606-7cbc0507c19f', N'高中及以下', N'学历')
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'e750dad8-f2ad-4163-b6e2-9b9941e0e8c2', N'党员', N'政治面貌')
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'6e719cf1-96ad-4df5-bc6d-ada0e55be3de', N'男', N'性别')
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'f700b36d-085c-4b02-b6cf-afb76ee1084c', N'博士', N'学历')
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'f68abf06-e57f-44bc-94e6-c2587e867e2f', N'团员', N'政治面貌')
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'31f55cbd-80d7-40d6-89a3-c5f84a9b7a79', N'民主党派', N'政治面貌')
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'4d75ee7f-768c-40b6-a75e-f291152197ca', N'硕士', N'学历')
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'eaeda3b7-9925-403f-b06f-fa87dff22a6d', N'群众', N'政治面貌')
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'f17587a8-f9f4-456f-b044-fb13244b1b91', N'已婚', N'婚姻状况')
INSERT [dbo].[T_IdName] ([Id], [Name], [Category]) VALUES (N'91b073bf-cc31-4ea1-b42a-ffb39af14102', N'未知性别', N'性别')
/****** Object:  Table [dbo].[T_Employee]    Script Date: 12/26/2012 16:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Employee](
	[Id] [uniqueidentifier] NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BirthDay] [datetime] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[MarriageId] [uniqueidentifier] NOT NULL,
	[PartyStatusId] [uniqueidentifier] NOT NULL,
	[Nationality] [nvarchar](50) NOT NULL,
	[NativeAddr] [nvarchar](250) NOT NULL,
	[EducationId] [uniqueidentifier] NOT NULL,
	[Major] [nvarchar](50) NULL,
	[School] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NOT NULL,
	[BaseSalary] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[IdNum] [nvarchar](50) NOT NULL,
	[TelNum] [nvarchar](50) NOT NULL,
	[EmergencyContact] [nvarchar](max) NULL,
	[DepartmentId] [uniqueidentifier] NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[ContractStartDay] [datetime] NOT NULL,
	[ContractEndDay] [datetime] NOT NULL,
	[Resume] [nvarchar](max) NULL,
	[Remarks] [nvarchar](max) NULL,
	[IsStopped] [bit] NOT NULL,
	[GenderId] [uniqueidentifier] NOT NULL,
	[Photo] [image] NULL,
 CONSTRAINT [PK_T_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'Number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入职时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'InDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'婚姻状况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'MarriageId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'政治面貌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'PartyStatusId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'民族' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'Nationality'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'籍贯' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'NativeAddr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学历' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'EducationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专业' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'Major'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'毕业院校' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'School'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'基本工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'BaseSalary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'IdNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'TelNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'紧急联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'EmergencyContact'
GO
INSERT [dbo].[T_Employee] ([Id], [Number], [Name], [BirthDay], [InDate], [MarriageId], [PartyStatusId], [Nationality], [NativeAddr], [EducationId], [Major], [School], [Address], [BaseSalary], [Email], [IdNum], [TelNum], [EmergencyContact], [DepartmentId], [Position], [ContractStartDay], [ContractEndDay], [Resume], [Remarks], [IsStopped], [GenderId], [Photo]) VALUES (N'a21eb469-94ac-46e0-8ab8-5e90fef8dbce', N'YG', N'苏坤', CAST(0x00008EA200000000 AS DateTime), CAST(0x0000A12B00000000 AS DateTime), N'ccd51b95-b8c0-494b-8613-549127777df6', N'e750dad8-f2ad-4163-b6e2-9b9941e0e8c2', N'汉族', N'得到的', N'f0e73f7a-aae0-49c5-b556-4c198ab54312', N'3333', N'反反复复', N'顶顶顶顶顶顶顶顶顶顶', 3333, N'@itcast.cn', N'333333333333333333333333', N'333333', NULL, N'7c444dbb-8f93-460f-b113-8ad1df6876d1', N'讲师', CAST(0x0000A12B00000000 AS DateTime), CAST(0x0000A29800000000 AS DateTime), NULL, NULL, 0, N'6e719cf1-96ad-4df5-bc6d-ada0e55be3de', NULL)
INSERT [dbo].[T_Employee] ([Id], [Number], [Name], [BirthDay], [InDate], [MarriageId], [PartyStatusId], [Nationality], [NativeAddr], [EducationId], [Major], [School], [Address], [BaseSalary], [Email], [IdNum], [TelNum], [EmergencyContact], [DepartmentId], [Position], [ContractStartDay], [ContractEndDay], [Resume], [Remarks], [IsStopped], [GenderId], [Photo]) VALUES (N'e0fc6e6b-5e78-4005-83d0-bf7fe29598d0', N'YG008', N'杨中科', CAST(0x000073E000000000 AS DateTime), CAST(0x0000A12B00000000 AS DateTime), N'f17587a8-f9f4-456f-b044-fb13244b1b91', N'eaeda3b7-9925-403f-b06f-fa87dff22a6d', N'汉族', N'河北廊坊', N'f0e73f7a-aae0-49c5-b556-4c198ab54312', N'物流工程', N'山东大学', N'北京市海淀区中关村软件园9号楼二区3层', 2500, N'yzk@itcast.cn', N'1328261903211111', N'1388888888', NULL, N'7c444dbb-8f93-460f-b113-8ad1df6876d1', N'讲师', CAST(0x0000A12B00000000 AS DateTime), CAST(0x0000A13500000000 AS DateTime), NULL, NULL, 0, N'6e719cf1-96ad-4df5-bc6d-ada0e55be3de', NULL)
/****** Object:  Table [dbo].[T_Department]    Script Date: 12/26/2012 16:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Department](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsStopped] [bit] NOT NULL,
 CONSTRAINT [PK_T_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_Department] ([Id], [Name], [IsStopped]) VALUES (N'6c4bf5ea-4309-41b2-b770-55b3256eb9dd', N'学生工作部', 0)
INSERT [dbo].[T_Department] ([Id], [Name], [IsStopped]) VALUES (N'17a56aa9-f5f8-40c4-ad86-55dde2c298a0', N'人力资源部', 0)
INSERT [dbo].[T_Department] ([Id], [Name], [IsStopped]) VALUES (N'f2fcbdb1-562c-4367-95d9-5d50f0989133', N'行政部', 0)
INSERT [dbo].[T_Department] ([Id], [Name], [IsStopped]) VALUES (N'7c444dbb-8f93-460f-b113-8ad1df6876d1', N'.net教学部', 0)
INSERT [dbo].[T_Department] ([Id], [Name], [IsStopped]) VALUES (N'394d8cdc-4adb-4bfd-8f61-cc66eecf386d', N'网络营销部', 0)
/****** Object:  Default [DF_T_IdName_Id]    Script Date: 12/26/2012 16:39:09 ******/
ALTER TABLE [dbo].[T_IdName] ADD  CONSTRAINT [DF_T_IdName_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_T_SalarySheet_Id]    Script Date: 12/26/2012 16:39:09 ******/
ALTER TABLE [dbo].[T_SalarySheet] ADD  CONSTRAINT [DF_T_SalarySheet_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_T_SalarySheetItem_Id]    Script Date: 12/26/2012 16:39:09 ******/
ALTER TABLE [dbo].[T_SalarySheetItem] ADD  CONSTRAINT [DF_T_SalarySheetItem_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_T_Setting_Id]    Script Date: 12/26/2012 16:39:09 ******/
ALTER TABLE [dbo].[T_Setting] ADD  CONSTRAINT [DF_T_Setting_Id]  DEFAULT (newid()) FOR [Id]
GO
