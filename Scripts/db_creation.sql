/****** Object:  Table [dbo].[SYS_Laboratory]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_Laboratory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SYS_Category]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SYS_ActiveIngredient]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_ActiveIngredient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[States]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Acronym] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SYS_LeafletType]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_LeafletType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[MedicalSpecialties]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalSpecialties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[MedicalEntities]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Licenses]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licenses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[IsSuspended] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[EdmMetadata]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EdmMetadata](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelHash] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[People]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[UrlIdentifier] [nvarchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Gender] [smallint] NOT NULL,
	[MaritalStatus] [smallint] NULL,
	[BirthPlace] [nvarchar](max) NULL,
	[CPF] [nvarchar](max) NULL,
	[CPFOwner] [int] NULL,
	[Profession] [nvarchar](max) NULL,
	[EMail] [nvarchar](max) NULL,
	[GravatarEmailHash] [nvarchar](max) NULL,
	[RefererId] [int] NULL,
	[Street] [nvarchar](max) NULL,
	[Complement] [nvarchar](max) NULL,
	[Neighborhood] [nvarchar](max) NULL,
	[StateProvince] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[CEP] [nvarchar](max) NULL,
	[Observations] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Practices]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Practices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[NameUrlFriendly] [nvarchar](max) NOT NULL,
	[LicenseId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Key] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[StateId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SYS_Medicine]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_Medicine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[LaboratoryId] [int] NULL,
	[CategoryId] [int] NOT NULL,
	[ApprovementDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SYS_Leaflet]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_Leaflet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LeaftletTypeId] [int] NOT NULL,
	[URL] [nvarchar](max) NULL,
	[LeafletType_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PasswordSalt] [nvarchar](max) NOT NULL,
	[LastActiveOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SYS_MedicineSYS_ActiveIngredient]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_MedicineSYS_ActiveIngredient](
	[SYS_Medicine_Id] [int] NOT NULL,
	[SYS_ActiveIngredient_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SYS_Medicine_Id] ASC,
	[SYS_ActiveIngredient_Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SYS_MedicineConcentration]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_MedicineConcentration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Medicine_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SYS_LeafletSYS_Medicine]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_LeafletSYS_Medicine](
	[SYS_Leaflet_Id] [int] NOT NULL,
	[SYS_Medicine_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SYS_Leaflet_Id] ASC,
	[SYS_Medicine_Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[PracticesUsers]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PracticesUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PracticeId] [int] NOT NULL,
	[Role] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CRM] [nvarchar](max) NOT NULL,
	[MedicalEntityId] [int] NOT NULL,
	[MedicalSpecialtyId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [int] NOT NULL,
	[Chart] [nvarchar](max) NULL,
	[Bed] [nvarchar](max) NULL,
	[Coverage] [nvarchar](max) NULL,
	[Registration] [nvarchar](max) NULL,
	[ExpectedReturnDate] [datetime] NULL,
	[DoctorId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 01/01/2012 13:15:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedById] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[PracticeId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [Person_Referer]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [Person_Referer] FOREIGN KEY([RefererId])
REFERENCES [dbo].[People] ([Id])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [Person_Referer]
GO
/****** Object:  ForeignKey [Practice_License]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[Practices]  WITH CHECK ADD  CONSTRAINT [Practice_License] FOREIGN KEY([LicenseId])
REFERENCES [dbo].[Licenses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Practices] CHECK CONSTRAINT [Practice_License]
GO
/****** Object:  ForeignKey [City_State]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [City_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [City_State]
GO
/****** Object:  ForeignKey [SYS_Category_Medicines]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[SYS_Medicine]  WITH CHECK ADD  CONSTRAINT [SYS_Category_Medicines] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[SYS_Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SYS_Medicine] CHECK CONSTRAINT [SYS_Category_Medicines]
GO
/****** Object:  ForeignKey [SYS_Laboratory_Medicines]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[SYS_Medicine]  WITH CHECK ADD  CONSTRAINT [SYS_Laboratory_Medicines] FOREIGN KEY([LaboratoryId])
REFERENCES [dbo].[SYS_Laboratory] ([Id])
GO
ALTER TABLE [dbo].[SYS_Medicine] CHECK CONSTRAINT [SYS_Laboratory_Medicines]
GO
/****** Object:  ForeignKey [SYS_Leaflet_LeafletType]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[SYS_Leaflet]  WITH CHECK ADD  CONSTRAINT [SYS_Leaflet_LeafletType] FOREIGN KEY([LeafletType_Id])
REFERENCES [dbo].[SYS_LeafletType] ([Id])
GO
ALTER TABLE [dbo].[SYS_Leaflet] CHECK CONSTRAINT [SYS_Leaflet_LeafletType]
GO
/****** Object:  ForeignKey [User_TypeConstraint_From_Person_To_Users]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [User_TypeConstraint_From_Person_To_Users] FOREIGN KEY([Id])
REFERENCES [dbo].[People] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [User_TypeConstraint_From_Person_To_Users]
GO
/****** Object:  ForeignKey [SYS_Medicine_ActiveIngredients_Source]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[SYS_MedicineSYS_ActiveIngredient]  WITH CHECK ADD  CONSTRAINT [SYS_Medicine_ActiveIngredients_Source] FOREIGN KEY([SYS_Medicine_Id])
REFERENCES [dbo].[SYS_Medicine] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SYS_MedicineSYS_ActiveIngredient] CHECK CONSTRAINT [SYS_Medicine_ActiveIngredients_Source]
GO
/****** Object:  ForeignKey [SYS_Medicine_ActiveIngredients_Target]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[SYS_MedicineSYS_ActiveIngredient]  WITH CHECK ADD  CONSTRAINT [SYS_Medicine_ActiveIngredients_Target] FOREIGN KEY([SYS_ActiveIngredient_Id])
REFERENCES [dbo].[SYS_ActiveIngredient] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SYS_MedicineSYS_ActiveIngredient] CHECK CONSTRAINT [SYS_Medicine_ActiveIngredients_Target]
GO
/****** Object:  ForeignKey [SYS_MedicineConcentration_Medicine]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[SYS_MedicineConcentration]  WITH CHECK ADD  CONSTRAINT [SYS_MedicineConcentration_Medicine] FOREIGN KEY([Medicine_Id])
REFERENCES [dbo].[SYS_Medicine] ([Id])
GO
ALTER TABLE [dbo].[SYS_MedicineConcentration] CHECK CONSTRAINT [SYS_MedicineConcentration_Medicine]
GO
/****** Object:  ForeignKey [SYS_Leaflet_Medicines_Source]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[SYS_LeafletSYS_Medicine]  WITH CHECK ADD  CONSTRAINT [SYS_Leaflet_Medicines_Source] FOREIGN KEY([SYS_Leaflet_Id])
REFERENCES [dbo].[SYS_Leaflet] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SYS_LeafletSYS_Medicine] CHECK CONSTRAINT [SYS_Leaflet_Medicines_Source]
GO
/****** Object:  ForeignKey [SYS_Leaflet_Medicines_Target]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[SYS_LeafletSYS_Medicine]  WITH CHECK ADD  CONSTRAINT [SYS_Leaflet_Medicines_Target] FOREIGN KEY([SYS_Medicine_Id])
REFERENCES [dbo].[SYS_Medicine] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SYS_LeafletSYS_Medicine] CHECK CONSTRAINT [SYS_Leaflet_Medicines_Target]
GO
/****** Object:  ForeignKey [UserPractice_Practice]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[PracticesUsers]  WITH CHECK ADD  CONSTRAINT [UserPractice_Practice] FOREIGN KEY([PracticeId])
REFERENCES [dbo].[Practices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PracticesUsers] CHECK CONSTRAINT [UserPractice_Practice]
GO
/****** Object:  ForeignKey [UserPractice_User]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[PracticesUsers]  WITH CHECK ADD  CONSTRAINT [UserPractice_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PracticesUsers] CHECK CONSTRAINT [UserPractice_User]
GO
/****** Object:  ForeignKey [Doctor_MedicalEntity1]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [Doctor_MedicalEntity1] FOREIGN KEY([MedicalEntityId])
REFERENCES [dbo].[MedicalEntities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [Doctor_MedicalEntity1]
GO
/****** Object:  ForeignKey [Doctor_MedicalSpecialty1]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [Doctor_MedicalSpecialty1] FOREIGN KEY([MedicalSpecialtyId])
REFERENCES [dbo].[MedicalSpecialties] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [Doctor_MedicalSpecialty1]
GO
/****** Object:  ForeignKey [Doctor_TypeConstraint_From_Person_To_Doctors]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [Doctor_TypeConstraint_From_Person_To_Doctors] FOREIGN KEY([Id])
REFERENCES [dbo].[People] ([Id])
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [Doctor_TypeConstraint_From_Person_To_Doctors]
GO
/****** Object:  ForeignKey [Doctor_User1]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [Doctor_User1] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [Doctor_User1]
GO
/****** Object:  ForeignKey [Patient_Doctor1]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [Patient_Doctor1] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([Id])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [Patient_Doctor1]
GO
/****** Object:  ForeignKey [Patient_TypeConstraint_From_Person_To_Patients]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [Patient_TypeConstraint_From_Person_To_Patients] FOREIGN KEY([Id])
REFERENCES [dbo].[People] ([Id])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [Patient_TypeConstraint_From_Person_To_Patients]
GO
/****** Object:  ForeignKey [Appointment_CreatedBy]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [Appointment_CreatedBy] FOREIGN KEY([CreatedById])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [Appointment_CreatedBy]
GO
/****** Object:  ForeignKey [Appointment_Doctor]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [Appointment_Doctor] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [Appointment_Doctor]
GO
/****** Object:  ForeignKey [Appointment_Patient]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [Appointment_Patient] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [Appointment_Patient]
GO
/****** Object:  ForeignKey [Appointment_Practice]    Script Date: 01/01/2012 13:15:31 ******/
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [Appointment_Practice] FOREIGN KEY([PracticeId])
REFERENCES [dbo].[Practices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [Appointment_Practice]
GO
