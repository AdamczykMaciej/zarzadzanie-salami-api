-- =============================================
-- Author: Maciej Adamczyk
-- Create date: 2018/08/16
-- Description: add columns to Sala
-- =============================================

--ALTER Table: dbo.Sala
-- EXECUTE DURING THE CREATION
ALTER TABLE dziekanat_hash.dbo.Sala
   ADD IdRozkladSali INT NULL;
ALTER TABLE dziekanat_hash.dbo.Sala
	ADD LiczbaKomputerow INT NULL;
ALTER TABLE dziekanat_hash.dbo.Sala
	ADD IdKomputer INT NULL;
ALTER TABLE dziekanat_hash.dbo.Sala
	ADD Klimatyzacja BIT DEFAULT 0;