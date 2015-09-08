ALTER PROCEDURE spBuscarDetalleProyecto(@IDProyecto int)
as

declare @Sql nvarchar(max), @columnas varchar(max),@columnas1 varchar(max)


 set @columnas= (SELECT SUBSTRING(
	(SELECT ',[' + IDConcepto+']'
	FROM tblConceptos  
	order by tblConceptos.ORDENINSERT ASC
	FOR XML PATH('')),2,200000) 
	)
	
	
	set @Sql=N'select IDEmpleado, Nombre, '+@columnas+' 
				 from (select c.IDConcepto,dp.IDEmpleado,
				e.Nombre + '' '' + coalesce(e.Paterno, '' '') + '' ''+  coalesce(e.Materno,'' '') as Nombre,CAP1
				from TblDetalleProyectos dp with (nolock) 
					inner join TblConceptos c  with (nolock)on dp.IDConcepto = c.IDConcepto
					inner join TblEmpleados	e  with (nolock)on dp.IDEmpleado = e.IDEmpleado
				where dp.IDProyecto = '+ CONVERT(varchar,@IDProyecto)+') as t
				PIVOT (SUM(CAP1) FOR IDConcepto IN ('+@columnas+') ) AS temp order by IDEmpleado ';
	
	print @sql
		
		Exec sp_executesql @Sql
				