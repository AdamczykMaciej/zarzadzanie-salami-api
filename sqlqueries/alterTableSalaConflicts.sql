-- =============================================
-- Author: Maciej Adamczyk
-- Create date: 2018/08/16
-- Description: when foreign key conflicts
-- =============================================

-- IMPORTANT --
-- mainly for deletion purposes
-- IdRozkladSali conflict - Sala_RozkladSali
ALTER TABLE dziekanat_hash.dbo.Sala
	DROP CONSTRAINT Sala_RozkladSali;
GO
ALTER TABLE dziekanat_hash.dbo.Sala
	DROP COLUMN IdRozkladSali;
GO
ALTER TABLE dziekanat_hash.dbo.Sala
   ADD IdRozkladSali INT NULL;
GO
ALTER TABLE dziekanat_hash.dbo.Sala ADD CONSTRAINT Sala_RozkladSali
    FOREIGN KEY (IdRozkladSali)
    REFERENCES dziekanat_hash.dbo.RozkladSali (IdRozkladSali);
GO
-- IdKomputer conflict - Sala_Komputer

ALTER TABLE dziekanat_hash.dbo.Sala
	DROP CONSTRAINT Sala_Komputer;
GO
ALTER TABLE dziekanat_hash.dbo.Sala
	DROP COLUMN IdKomputer;
GO
ALTER TABLE dziekanat_hash.dbo.Sala
   ADD IdKomputer INT NULL;
GO
ALTER TABLE dziekanat_hash.dbo.Sala ADD CONSTRAINT Sala_Komputer
    FOREIGN KEY (IdKomputer)
    REFERENCES dziekanat_hash.dbo.Komputer (IdKomputer);
GO