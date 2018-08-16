-- =============================================
-- Author: Maciej Adamczyk
-- Create date: 2018/08/03
-- Description: create missing entities for ZarzadzanieSalami
-- =============================================

--CREATE TABLES--
-- Table: Komputer
CREATE TABLE dziekanat_hash.dbo.Komputer (
    IdKomputer int  NOT NULL IDENTITY(1,1),
    IdMonitor int  NOT NULL,
    Procesor varchar(100)  NOT NULL,
    RAM varchar(100)  NOT NULL,
    KartaGraficzna varchar(100)  NOT NULL,
    IdMaszynaWirtualna int  NULL,
    CONSTRAINT Komputer_pk PRIMARY KEY  (IdKomputer)
);

-- Table: MaszynaWirtualna
CREATE TABLE dziekanat_hash.dbo.MaszynaWirtualna (
    IdMaszynaWirtualna int  NOT NULL IDENTITY(1,1),
    Nazwa varchar(50)  NOT NULL,
    CONSTRAINT MaszynaWirtualna_pk PRIMARY KEY  (IdMaszynaWirtualna)
);

-- Table: Monitor
CREATE TABLE dziekanat_hash.dbo.Monitor (
    IdMonitor int  NOT NULL IDENTITY(1,1),
    RozmiarMonitora int  NOT NULL,
    CONSTRAINT Monitor_pk PRIMARY KEY  (IdMonitor)
);

-- Table: Oprogramowanie
CREATE TABLE dziekanat_hash.dbo.Oprogramowanie (
    IdOprogramowanie int  NOT NULL IDENTITY(1,1),
    Nazwa varchar(100)  NOT NULL,
    CONSTRAINT Oprogramowanie_pk PRIMARY KEY  (IdOprogramowanie)
);

-- Table: OprogramowanieKomputerow
CREATE TABLE dziekanat_hash.dbo.OprogramowanieKomputerow (
    IdKomputer int  NOT NULL,
    IdOprogramowanie int  NOT NULL,
    CONSTRAINT OprogramowanieKomputerow_pk PRIMARY KEY  (IdKomputerow,IdOprogramowanie)
);

-- Table: RozkladSali
CREATE TABLE dziekanat_hash.dbo.RozkladSali (
    IdRozkladSali int  NOT NULL IDENTITY(1,1),
    NazwaRozkladuSali varchar(50)  NOT NULL,
    CONSTRAINT RozkladSali_pk PRIMARY KEY  (IdRozkladSali)
);

-- foreign keys
-- Reference: Komputer_MaszynaWirtualna (table: Komputer)
ALTER TABLE dziekanat_hash.dbo.Komputer ADD CONSTRAINT Komputer_MaszynaWirtualna
    FOREIGN KEY (IdMaszynaWirtualna)
    REFERENCES dziekanat_hash.dbo.MaszynaWirtualna (IdMaszynaWirtualna);

-- Reference: Komputer_Monitor (table: Komputer)
ALTER TABLE dziekanat_hash.dbo.Komputer ADD CONSTRAINT Komputer_Monitor
    FOREIGN KEY (IdMonitor)
    REFERENCES dziekanat_hash.dbo.Monitor (IdMonitor);

-- Reference: Komputer_OprogramowanieKomputerow (table: OprogramowanieKomputerow)
ALTER TABLE dziekanat_hash.dbo.OprogramowanieKomputerow ADD CONSTRAINT Komputer_OprogramowanieKomputerow
    FOREIGN KEY (IdKomputerow)
    REFERENCES dziekanat_hash.dbo.Komputer (IdKomputer);

-- Reference: Sala_Komputer (table: Sala)
ALTER TABLE dziekanat_hash.dbo.Sala ADD CONSTRAINT Sala_Komputer
    FOREIGN KEY (IdKomputer)
    REFERENCES dziekanat_hash.dbo.Komputer (IdKomputer);
	
-- Reference: Sala_RozkladSali (table: Sala)
ALTER TABLE dziekanat_hash.dbo.Sala ADD CONSTRAINT Sala_RozkladSali
	FOREIGN KEY (IdRozkladSali)
	REFERENCES dziekanat_hash.dbo.RozkladSali (IdRozkladSali);

-- Reference: SpecjalistyczneOprogramowanie_OprogramowanieKomputerow (table: OprogramowanieKomputerow)
ALTER TABLE dziekanat_hash.dbo.OprogramowanieKomputerow ADD CONSTRAINT Oprogramowanie_OprogramowanieKomputerow
    FOREIGN KEY (IdOprogramowanie)
    REFERENCES dziekanat_hash.dbo.Oprogramowanie (IdOprogramowanie);

-- End of file.

