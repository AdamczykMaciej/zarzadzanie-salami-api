Update dbo.Sala
SET Poziom = 'II pi�tro'
Where Poziom Like 'II';

Update dbo.Sala
SET Poziom = 'III pi�tro'
Where Poziom Like 'IIIpi�tro';

Update dbo.Sala
SET Poziom = NULL
Where Poziom Like '';

Update dbo.Sala
Set Poziom = 'I pi�tro'
Where Poziom Like '%I pietro%';
