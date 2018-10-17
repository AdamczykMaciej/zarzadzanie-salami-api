CREATE TYPE dbo.MaszynaWirtualnaType AS TABLE
   ( 
   IdMaszynaWirtualna int PRIMARY KEY, 
   Nazwa varchar(50)
   );
GO

CREATE TYPE dbo.OprogramowanieType AS TABLE
   ( 
   IdOprogramowanie int PRIMARY KEY, 
   Nazwa varchar(100)
   );
GO

CREATE TYPE dbo.FunkcjaSaliType AS TABLE
   ( 
   IdFunkcjaSali INT PRIMARY KEY,
   Nazwa varchar(50)
   );
GO
CREATE TYPE dbo.BudynekTableType AS TABLE
  (
     IdBudynek INT PRIMARY KEY,
     Nazwa VARCHAR(50)
  );