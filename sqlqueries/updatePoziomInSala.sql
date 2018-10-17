Update dbo.Sala
SET Poziom = 'II piêtro'
Where Poziom Like 'II';

Update dbo.Sala
SET Poziom = 'III piêtro'
Where Poziom Like 'IIIpiêtro';

Update dbo.Sala
SET Poziom = NULL
Where Poziom Like '';

Update dbo.Sala
Set Poziom = 'I piêtro'
Where Poziom Like '%I pietro%';
