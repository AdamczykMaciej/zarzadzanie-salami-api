-- =============================================
-- Author: Maciej Adamczyk
-- Create date: 2018/08/03
-- Description: 
-- =============================================

--CREATE TABLES--
USE [dziekanat_hash]
-- Table: Komputer
GO
CREATE TABLE dbo.Komputer (
    IdKomputer int  NOT NULL IDENTITY(1,1),
    IdMonitor int  NOT NULL,
    Procesor varchar(100)  NOT NULL,
    RAM varchar(100)  NOT NULL,
    KartaGraficzna varchar(100)  NOT NULL,
    CONSTRAINT Komputer_pk PRIMARY KEY  (IdKomputer)
);
GO
-- Table: MaszynaWirtualna
CREATE TABLE dbo.MaszynaWirtualna (
    IdMaszynaWirtualna int  NOT NULL IDENTITY(1,1),
    Nazwa varchar(50)  NOT NULL,
    CONSTRAINT MaszynaWirtualna_pk PRIMARY KEY  (IdMaszynaWirtualna)
);
GO
-- Table: MaszynaWirtualnaKomputer
CREATE TABLE dbo.MaszynaWirtualnaKomputer (
    IdMaszynaWirtualna int  NOT NULL,
    IdKomputer int  NOT NULL,
    CONSTRAINT MaszynaWirtualnaKomputer_pk PRIMARY KEY  (IdMaszynaWirtualna,IdKomputer)
);
GO
-- Table: Monitor
CREATE TABLE dbo.Monitor (
    IdMonitor int  NOT NULL IDENTITY(1,1),
    RozmiarMonitora int  NOT NULL,
    CONSTRAINT Monitor_pk PRIMARY KEY  (IdMonitor)
);
GO
-- Table: Oprogramowanie
CREATE TABLE dbo.Oprogramowanie (
    IdOprogramowanie int  NOT NULL IDENTITY(1,1),
    Nazwa varchar(100)  NOT NULL,
    CONSTRAINT Oprogramowanie_pk PRIMARY KEY  (IdOprogramowanie)
);
GO
-- Table: OprogramowanieKomputerow
CREATE TABLE dbo.OprogramowanieKomputerow (
    IdKomputer int  NOT NULL,
    IdOprogramowanie int  NOT NULL,
    CONSTRAINT OprogramowanieKomputerow_pk PRIMARY KEY  (IdKomputer,IdOprogramowanie)
);
GO
-- Table: RozkladSali
CREATE TABLE dbo.RozkladSali (
    IdRozkladSali int  NOT NULL IDENTITY(1,1),
    NazwaRozkladuSali varchar(50)  NOT NULL,
    CONSTRAINT RozkladSali_pk PRIMARY KEY  (IdRozkladSali)
);
GO
USE [dziekanat_hash]
GO
-- foreign keys
-- Reference: Komputer_Monitor (table: Komputer)
ALTER TABLE dbo.Komputer ADD CONSTRAINT Komputer_Monitor
    FOREIGN KEY (IdMonitor)
    REFERENCES dbo.Monitor (IdMonitor);
GO
-- Reference: Komputer_OprogramowanieKomputerow (table: OprogramowanieKomputerow)
ALTER TABLE dbo.OprogramowanieKomputerow ADD CONSTRAINT Komputer_OprogramowanieKomputerow
    FOREIGN KEY (IdKomputer)
    REFERENCES dbo.Komputer (IdKomputer);
GO
-- Reference: MaszynaWirtualnaKomputer_Komputer (table: MaszynaWirtualnaKomputer)
ALTER TABLE dbo.MaszynaWirtualnaKomputer ADD CONSTRAINT MaszynaWirtualnaKomputer_Komputer
    FOREIGN KEY (IdKomputer)
    REFERENCES dbo.Komputer (IdKomputer);
GO
-- Reference: MaszynaWirtualnaKomputer_MaszynaWirtualna (table: MaszynaWirtualnaKomputer)
ALTER TABLE dbo.MaszynaWirtualnaKomputer ADD CONSTRAINT MaszynaWirtualnaKomputer_MaszynaWirtualna
    FOREIGN KEY (IdMaszynaWirtualna)
    REFERENCES dbo.MaszynaWirtualna (IdMaszynaWirtualna);
GO
-- Reference: Oprogramowanie_OprogramowanieKomputerow (table: OprogramowanieKomputerow)
ALTER TABLE dbo.OprogramowanieKomputerow ADD CONSTRAINT Oprogramowanie_OprogramowanieKomputerow
    FOREIGN KEY (IdOprogramowanie)
    REFERENCES dbo.Oprogramowanie (IdOprogramowanie);
GO
-- Reference: Sala_Komputer (table: Sala)
ALTER TABLE dbo.Sala ADD CONSTRAINT Sala_Komputer
    FOREIGN KEY (IdKomputer)
    REFERENCES dbo.Komputer (IdKomputer);

GO
-- Reference: Sala_RozkladSali (table: Sala)
GO
ALTER TABLE dbo.Sala ADD CONSTRAINT Sala_RozkladSali
    FOREIGN KEY (IdRozkladSali)
    REFERENCES dziekanat_hash.dbo.RozkladSali (IdRozkladSali);

-- End of file.

