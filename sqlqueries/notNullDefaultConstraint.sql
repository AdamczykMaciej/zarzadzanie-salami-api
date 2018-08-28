-- =============================================
-- Author: Maciej Adamczyk
-- Create date: 2018/08/03
-- Description: 
-- =============================================

-- This helped me to change constraint to not null, default(0) for an existing column
ALTER TABLE dziekanat_hash.dbo.Sala DROP CONSTRAINT [DF__Sala__Klimatyzac__026B6FE9];
GO
ALTER TABLE dziekanat_hash.dbo.Sala ALTER COLUMN Klimatyzacja INT NOT NULL;
GO
ALTER TABLE dziekanat_hash.dbo.Sala ADD CONSTRAINT [DF__Sala__Klimatyzac__026B6FE9] DEFAULT 0 FOR [Klimatyzacja];
GO