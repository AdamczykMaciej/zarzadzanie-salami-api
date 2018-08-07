--ALTER Table: dbo.Sala

ALTER TABLE dziekanat_hash.dbo.Sala
    ALTER COLUMN IdRozkladSali INT NULL;
ALTER TABLE dziekanat_hash.dbo.Sala
	ALTER COLUMN LiczbaKomputerow INT NULL;
ALTER TABLE dziekanat_hash.dbo.Sala
	ALTER COLUMN IdKomputer INT NULL;

-- EXECUTE DURING THE CREATION
--ALTER TABLE dziekanat_hash.dbo.Sala
--    ADD IdRozkladSali INT NULL;
--ALTER TABLE dziekanat_hash.dbo.Sala
--	ADD LiczbaKomputerow INT NULL;
--ALTER TABLE dziekanat_hash.dbo.Sala
--	ADD IdKomputer INT NULL;
--ALTER TABLE dziekanat_hash.dbo.Sala
--	ADD Klimatyzacja BIT DEFAULT 0;