ALTER PROCEDURE spBuscarProyecto(@IDProyecto int) 
as

DECLARE @CostoTotal		money,
        @CostoRestante	money,
        @AbonosTotal	money
        
        select @CostoTotal = TOTAL
        from TblDetalleProyectos with (nolock)
        where (IDProyecto = @IDProyecto) and (IDConcepto = 'PREF') 
        
        select @AbonosTotal=SUM(Total)
        from TblAbonosProyectos
        where IDProyecto = @IDProyecto
        
        set @CostoRestante = (@CostoTotal - @AbonosTotal);
        
		select p.IDProyecto,p.IDCliente,c.NombreComercial as Cliente,p.Nombre,p.Decripcion,p.FechaInicio,p.FechaFin,
			   p.Activo,p.IDCliente,p.IDEstatus,e.Descripcion as Estatus, isnull(@CostoTotal,0) as CostoTotal,isnull(@CostoRestante,0) as CostoRestante, 
			   isnull(@AbonosTotal,0) as AbonosTotal
		from TblProyectos  p with (nolock)
			inner join TblClientes c with (nolock) on p.IDCliente = c.IDCliente
			left join TblEstatus e with (nolock) on p.IDEstatus = e.IDEstatus
		where IDProyecto = @IDProyecto
		        
/*
        
SELECT *
from TblConceptos
order by OrdenInsert asc

select *
from TblDetalleProyectos

select *
from TblAbonosProyectos

select *
from tblProyectos


*/

exec spBuscarProyecto 3