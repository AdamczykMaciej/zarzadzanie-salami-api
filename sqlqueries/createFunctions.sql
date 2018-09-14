USE [dziekanat_hash]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_ŒredniaZaRokDlaStudenta]    Script Date: 14/09/2018 13:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[fn_ŒredniaZaRokDlaStudenta] (@IdOsoba INT) 
RETURNS TABLE
AS
     RETURN
     SELECT FORMAT(ROUND(SUM(Ocena)/COUNT(OCENA), 2), '0.######') Œrednia, IdOsoba
	 from dbo.Ocena
	 where IdOsoba = @IdOsoba
	 Group By IdOsoba;