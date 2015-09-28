
alter procedure spBuscarEmpleadoProyecto(@IDEmpleado int)
as
select p.Nombre as Proyecto,p.Decripcion as Descripción,e.Descripcion as Estatus,
(select dbo.fsTotal(p.IDProyecto,@IDEmpleado,'COM')) as Comision,convert(varchar,p.FechaFin) as [Fecha de Finalizar],
Pagado = case when pe.Pagado = 1 then 'SI' else 'NO' end
from TblProyectos p
	inner join TblProyectosEmpleados pe on (pe.IDProyecto = p.IDProyecto and pe.IDEmpleado = @IDEmpleado)
	inner join TblEstatus e on p.IDEstatus = e.IDEstatus
order by pe.IDProyectoEmpleado desc

go

exec spBuscarEmpleadoProyecto 3


