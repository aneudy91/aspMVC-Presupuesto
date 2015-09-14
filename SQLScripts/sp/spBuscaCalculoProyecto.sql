alter procedure spBuscaCalculoProyecto(@IDProyecto INT)
as
 DECLARE @LISTA_CONCEPTO NVARCHAR(MAX)
		,@Sql nvarchar(max), @columnas varchar(max),@columnas1 varchar(max)
		
	set @IDProyecto = 3
		
	set @columnas= (SELECT SUBSTRING(
		(SELECT ',[' + IDConcepto+']'
		FROM tblConceptos 
		where IDConcepto not in ('IMP','HORAS','COM','CON','ALOJ','HERR')
		order by tblConceptos.OrdenInsert ASC

		FOR XML PATH('')),2,200000)
		)
	/*
	SELECT  DT.ID_EMPLEADO 
				 ,coalesce(e.paterno,'' '') + '' '' + coalesce(e.materno,'' '') + '' '' + e.nombre as NOMBRE_EMPLEADO
				 ,DT.CLAVE_CONCEPTO, dt.CAP1			       
		FROM tblProyectoDetalle dp with (nolock) 
				INNER JOIN tblConceptos c on dt.CLAVE_CONCEPTO = c.CLAVE_CONCEPTO and (DT.CLAVE_CONCEPTO IN (SELECT * FROM DBO.Split('''+@LISTA_CONCEPTO+''',''|'')))		
				INNER JOIN tblEmpleados e with (nolock) on dt.ID_EMPLEADO = e.ID_EMPLEADO
		WHERE (dt.CLAVE_TIPO_NOMINA = '''+@ID_NOMINA+''') AND (dt.CLAVE_PERIODO = '+ CONVERT(VARCHAR,@ID_PERIODO)+')


*/
set @Sql=N'SELECT IDEmpleado as [CLAVE],Nombre, '+@columnas+'
		from (
				select dp.IDEmpleado
					,coalesce(e.paterno,'' '') + '' '' + coalesce(e.materno,'' '') + '' '' + e.nombre as Nombre
					,dp.IDConcepto,dp.TOTAL
				from TblDetalleProyectos dp
					inner join TblConceptos c on dp.IDConcepto = c.IDConcepto
					inner join TblEmpleados e on dp.IDEmpleado = e.IDEmpleado
				where dp.IDProyecto = ' +CONVERT(varchar,@IDProyecto) + '
				) tbl
				PIVOT (SUM(TOTAL) FOR IDConcepto IN ('+@columnas+') ) AS temp order by IDEmpleado '



		print @sql
		
		Exec sp_executesql @Sql
		
		
	