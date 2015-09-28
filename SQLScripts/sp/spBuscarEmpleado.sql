alter procedure spBuscarEmpleado(@IDEmpleado int)
as
select e.IDEmpleado,e.Nombre,e.Paterno,e.Materno,p.IDPuesto,p.Descripcion as Puesto
from TblEmpleados e with (nolock)
	inner join TblPuestos p with (nolock) on e.IDPuesto = p.IDPuesto
where e.IDEmpleado = @IDEmpleado