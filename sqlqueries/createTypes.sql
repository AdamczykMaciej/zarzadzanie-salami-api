CREATE TYPE dbo.MaszynaWirtualnaType AS TABLE
   ( 
   IdMaszynaWirtualna int NOT NULL, 
   Nazwa varchar(50)
   );
GO

CREATE TYPE dbo.OprogramowanieType AS TABLE
   ( 
   IdOprogramowanie int NOT NULL, 
   Nazwa varchar(100)
   );
GO