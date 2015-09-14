ALTER procedure spBuscaGranTotal(@IDProyecto INT)
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

set @Sql=N'SELECT '+@columnas+'
		from (
				select dp.IDConcepto,dp.TOTAL
				from TblDetalleProyectos dp
					inner join TblConceptos c on dp.IDConcepto = c.IDConcepto
					
				where dp.IDProyecto = ' +CONVERT(varchar,@IDProyecto) + '
				) tbl
				PIVOT (SUM(TOTAL) FOR IDConcepto IN ('+@columnas+') ) AS temp  '



		print @sql
		
		Exec sp_executesql @Sql
		
		
		
		
		
		
	
		
				