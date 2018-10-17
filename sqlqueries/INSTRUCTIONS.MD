instructions:

1.) CreateMissingEntities.sql (create missing tables)
2.) AlterTableSala.sql 
If conflicts:
2.a) AlterTableSalaConflicts.sql
If something goes wrong:
2.a) dropMissingEntities,sql

3.)Insert some data:
Insert ... .sql
InsertMissingEntities.sql
4.) To set a constraint to a default value, not null
notNullDefaultConstraint.sql
5.) Update rows with default values e.g. 0
6.) There is also a database diagram created in dziekanat_hash which we can copy. It is called dbo.ZarzadzanieSalami
