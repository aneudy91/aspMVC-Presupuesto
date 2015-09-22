CREATE PROCEDURE spBuscarAbonos(@IDProyecto int)
as

select Fecha,SubTotal,Impuesto,Total,RecibiDe
from TblAbonosProyectos with (nolock)
where IDProyecto = @IDProyecto


go
exec spBuscarAbonos 3