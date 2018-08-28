-- =============================================
-- Author: Maciej Adamczyk
-- Create date: 2018/08/03
-- Description: 
-- =============================================
USE dziekanat_hash
INSERT INTO dbo.Monitor (RozmiarMonitora) VALUES (20);
INSERT INTO dbo.Komputer (IdMonitor, Procesor, RAM, KartaGraficzna)
 VALUES (1,'IBM', 'sth else', 'sth else');
 INSERT INTO dbo.MaszynaWirtualna (Nazwa) VALUES ('Gentoo');
 INSERT INTO dbo.MaszynaWirtualna (Nazwa) VALUES ('Ubuntu 16.04');
 INSERT INTO dbo.Oprogramowanie (Nazwa) VALUES ('Photoshop');
 INSERT INTO dbo.OprogramowanieKomputerow (IdKomputer, IdOprogramowanie)
 VALUES (1,1);
 INSERT INTO dbo.RozkladSali (NazwaRozkladuSali) VALUES ('Trapez');
 INSERT INTO dbo.MaszynaWirtualnaKomputer (IdMaszynaWirtualna, IdKomputer) VALUES (1,1);