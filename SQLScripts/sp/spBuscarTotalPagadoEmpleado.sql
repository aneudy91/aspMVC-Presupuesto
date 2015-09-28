CREATE PROCEDURE spBuscarTotalPagadoEmpleado(@IDEmpleado int)
as
select SUM(dp.TOTAL) as Total
from TblDetalleProyectos dp
	INNER JOIN TblProyectosEmpleados pe on (dp.IDEmpleado = pe.IDEmpleado and dp.IDProyecto = pe.IDProyecto and pe.Pagado = 1)
where dp.IDConcepto= 'COM' and dp.IDEmpleado = @IDEmpleado



