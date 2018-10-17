-- =============================================
-- Author: Maciej Adamczyk
-- Create date: 2018/08/03
-- Description: 
-- =============================================
USE [dziekanat_hash]
GO
ALTER TABLE dbo.Sala DROP CONSTRAINT Sala_Komputer
GO
ALTER TABLE dbo.Sala DROP CONSTRAINT Sala_RozkladSali
GO
ALTER TABLE dbo.Komputer DROP CONSTRAINT Komputer_Monitor
GO
ALTER TABLE dbo.OprogramowanieKomputerow DROP CONSTRAINT Komputer_OprogramowanieKomputerow
GO
ALTER TABLE dbo.MaszynaWirtualnaKomputer DROP CONSTRAINT MaszynaWirtualnaKomputer_Komputer
GO
ALTER TABLE dbo.MaszynaWirtualnaKomputer DROP CONSTRAINT MaszynaWirtualnaKomputer_MaszynaWirtualna
GO
ALTER TABLE dbo.OprogramowanieKomputerow DROP CONSTRAINT Oprogramowanie_OprogramowanieKomputerow
GO	
/****** Object:  Table [dbo].[Oprogramowanie]    Script Date: 2018-08-16 14:57:38 ******/
DROP TABLE [dbo].[Oprogramowanie]
GO
/****** Object:  Table [dbo].[Monitor]    Script Date: 2018-08-16 14:57:38 ******/
DROP TABLE [dbo].[Monitor]
GO
/****** Object:  Table [dbo].[MaszynaWirtualna]    Script Date: 2018-08-16 14:57:38 ******/
DROP TABLE [dbo].[MaszynaWirtualna]
GO
/****** Object:  Table [dbo].[Komputer]    Script Date: 2018-08-16 14:57:38 ******/
DROP TABLE [dbo].[RozkladSali]
GO
DROP TABLE [dbo].[Komputer]
GO
DROP TABLE [dbo].[OprogramowanieKomputerow]
GO
DROP TABLE [dbo].[MaszynaWirtualnaKomputer]
GO
