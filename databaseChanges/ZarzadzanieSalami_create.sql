-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2018-07-31 11:27:06.711

-- tables
-- Table: Budynek
CREATE TABLE dbo.Budynek (
    IdBudynek int  NOT NULL IDENTITY(1, 1),
    Nazwa varchar(20)  NOT NULL,
    IdMiasto int  NULL,
    Adres_budynku varchar(100)  NULL,
    Opis varchar(255)  NULL,
    Istnieje bit  NULL,
    IdKampus int  NULL,
    CONSTRAINT PK__Budynek__3E88198C PRIMARY KEY  (IdBudynek)
)
ON PRIMARY;

-- Table: Funkcja_sali
CREATE TABLE dbo.Funkcja_sali (
    IdFunkcja_sali int  NOT NULL IDENTITY(1, 1),
    Funkcja_sali varchar(50)  NULL,
    Opis_funkcji char(5)  NULL,
    FunkcjaSaliAng varchar(128)  NULL,
    CONSTRAINT Funkcja_sali_PK PRIMARY KEY  (IdFunkcja_sali)
)
ON PRIMARY;

-- Table: Kampus
CREATE TABLE dbo.Kampus (
    IdKampus int  NOT NULL IDENTITY(1, 1),
    Nazwa_kampusu varchar(100)  NOT NULL,
    Opis varchar(255)  NULL,
    CONSTRAINT "dbo.Kampus_pk" PRIMARY KEY  (IdKampus)
)
ON PRIMARY;

-- Table: Komputer
CREATE TABLE Komputer (
    IdKomputer int  NOT NULL,
    IdMonitor int  NOT NULL,
    Procesor varchar(100)  NOT NULL,
    RAM varchar(100)  NOT NULL,
    KartaGraficzna varchar(100)  NOT NULL,
    IdMaszynaWirtualna int  NULL,
    CONSTRAINT Komputer_pk PRIMARY KEY  (IdKomputer)
);

-- Table: MaszynaWirtualna
CREATE TABLE MaszynaWirtualna (
    IdMaszynaWirtualna int  NOT NULL,
    Nazwa varchar(50)  NOT NULL,
    CONSTRAINT MaszynaWirtualna_pk PRIMARY KEY  (IdMaszynaWirtualna)
);

-- Table: Monitor
CREATE TABLE Monitor (
    IdMonitor int  NOT NULL,
    RozmiarMonitora int  NOT NULL,
    CONSTRAINT Monitor_pk PRIMARY KEY  (IdMonitor)
);

-- Table: Oprogramowanie
CREATE TABLE Oprogramowanie (
    IdOprogramowanie int  NOT NULL,
    Nazwa varchar(100)  NOT NULL,
    CONSTRAINT Oprogramowanie_pk PRIMARY KEY  (IdOprogramowanie)
);

-- Table: OprogramowanieKomputerow
CREATE TABLE OprogramowanieKomputerow (
    IdKomputerow int  NOT NULL,
    IdOprogramowanie int  NOT NULL,
    CONSTRAINT OprogramowanieKomputerow_pk PRIMARY KEY  (IdKomputerow,IdOprogramowanie)
);

-- Table: RozkladSali
CREATE TABLE RozkladSali (
    IdRozkladSali int  NOT NULL,
    NazwaRozkladuSali varchar(50)  NOT NULL,
    CONSTRAINT RozkladSali_pk PRIMARY KEY  (IdRozkladSali)
);

-- Table: Sala
CREATE TABLE dbo.Sala (
    IdSala int  NOT NULL IDENTITY(1, 1),
    Nazwa_sali varchar(50)  NULL,
    Liczba_miejsc int  NULL,
    Pow_m2 numeric(6,2)  NULL,
    Uwagi varchar(2000)  NULL,
    IdBudynek int  NOT NULL,
    Istnieje bit  NOT NULL,
    IdFunkcja_sali int  NULL,
    Poziom varchar(50)  NULL,
    Dostep_dla_niepelnosprawnych bit  NULL,
    Uzytkownik varchar(50)  NULL,
    Kolejnosc int  NULL,
    IdRozkladSali int  NULL,
    LiczbaKomputerow int  NULL,
    IdKomputer int  NULL,
    Klimatyzacja bit  NOT NULL DEFAULT 0,
    CONSTRAINT PK__Sala__023D5A04 PRIMARY KEY  (IdSala)
)
ON PRIMARY;

-- Table: Sala_dydaktyczna
CREATE TABLE dbo.Sala_dydaktyczna (
    IdSala int  NOT NULL,
    Liczba_gniazd_sieciowych int  NULL,
    TV bit  NULL,
    Projektor bit  NULL,
    Liczba_miejsc_dydaktycznych int  NULL,
    CONSTRAINT Sala_dydaktyczna_PK PRIMARY KEY  (IdSala)
)
ON PRIMARY;

-- foreign keys
-- Reference: FK_0 (table: Budynek)
ALTER TABLE dbo.Budynek ADD CONSTRAINT FK_0
    FOREIGN KEY (IdKampus)
    REFERENCES dbo.Kampus (IdKampus);

-- Reference: FK_Sala_Budynek (table: Sala)
ALTER TABLE dbo.Sala ADD CONSTRAINT FK_Sala_Budynek
    FOREIGN KEY (IdBudynek)
    REFERENCES dbo.Budynek (IdBudynek);

-- Reference: FK_Sala_Funkcja_sali (table: Sala)
ALTER TABLE dbo.Sala ADD CONSTRAINT FK_Sala_Funkcja_sali
    FOREIGN KEY (IdFunkcja_sali)
    REFERENCES dbo.Funkcja_sali (IdFunkcja_sali);

-- Reference: Komputer_MaszynaWirtualna (table: Komputer)
ALTER TABLE Komputer ADD CONSTRAINT Komputer_MaszynaWirtualna
    FOREIGN KEY (IdMaszynaWirtualna)
    REFERENCES MaszynaWirtualna (IdMaszynaWirtualna);

-- Reference: Komputer_Monitor (table: Komputer)
ALTER TABLE Komputer ADD CONSTRAINT Komputer_Monitor
    FOREIGN KEY (IdMonitor)
    REFERENCES Monitor (IdMonitor);

-- Reference: Komputer_OprogramowanieKomputerow (table: OprogramowanieKomputerow)
ALTER TABLE OprogramowanieKomputerow ADD CONSTRAINT Komputer_OprogramowanieKomputerow
    FOREIGN KEY (IdKomputerow)
    REFERENCES Komputer (IdKomputer);

-- Reference: Sala_Komputer (table: Sala)
ALTER TABLE dbo.Sala ADD CONSTRAINT Sala_Komputer
    FOREIGN KEY (IdKomputer)
    REFERENCES Komputer (IdKomputer);

-- Reference: Sala_RozkladSali (table: Sala)
ALTER TABLE dbo.Sala ADD CONSTRAINT Sala_RozkladSali
    FOREIGN KEY (IdRozkladSali)
    REFERENCES RozkladSali (IdRozkladSali);

-- Reference: Sala_dydaktyczna_Sala_FK (table: Sala_dydaktyczna)
ALTER TABLE dbo.Sala_dydaktyczna ADD CONSTRAINT Sala_dydaktyczna_Sala_FK
    FOREIGN KEY (IdSala)
    REFERENCES dbo.Sala (IdSala)
    ON DELETE  CASCADE;

-- Reference: SpecjalistyczneOprogramowanie_OprogramowanieKomputerow (table: OprogramowanieKomputerow)
ALTER TABLE OprogramowanieKomputerow ADD CONSTRAINT SpecjalistyczneOprogramowanie_OprogramowanieKomputerow
    FOREIGN KEY (IdOprogramowanie)
    REFERENCES Oprogramowanie (IdOprogramowanie);

-- End of file.

