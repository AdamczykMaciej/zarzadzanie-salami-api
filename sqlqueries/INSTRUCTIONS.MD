instructions:

1.) CreateMissingEntities.sql
2.) AlterTableSala.sql
If conflicts:
2.a) AlterTableSalaConflicts.sql
If something goes wrong:
2.a) dropMissingEntities,sql
Insert some data:
3.)Insert ... .sql
InsertMissingEntities.sql
4.) To set a constraint to a default value, not null
notNullDefaultConstraint.sql
5.) Update rows with default values e.g. 0