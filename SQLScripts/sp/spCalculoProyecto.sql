alter procedure spCalculoProyecto( @IDProyecto int)
as

DECLARE @IDEmpleado int
		,@CAP1 DECIMAL(10,2)
		,@TOTAL DECIMAL (10,2)
		,@TotalEmpPRE decimal (10,2)
		,@IDDetalleProyecto int
		,@IDEmpProyecto int
		
		

	set @IDEmpProyecto = 4

	/*
	CREATE drop TABLE #Temp ( ID int identity(1,1) primary key
						,IDDetalleProyecto int
						,CAP1 DECIMAL(10,2)
						)
	
	*/
	DECLARE EmpP CURSOR LOCAL SCROLL FOR
		select IDEmpleado
		from TblProyectosEmpleados
		where IDProyecto = @IDProyecto and IDEmpleado <> @IDEmpProyecto
		union
		select IDEmpleado
		from TblEmpleados
		where IDEmpleado = @IDEmpProyecto
		
	OPEN EmpP
	FETCH NEXT FROM EmpP INTO @IDEmpleado
	            
	WHILE (@@FETCH_STATUS = 0)                                 
	BEGIN
		--IDConcepto           Descripcion                   OrdenInsert Tipo		
		--IMP                  Importe por Hora              1           3
			update TblDetalleProyectos
			set TOTAL = CAP1
			where IDConcepto = 'IMP' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
	
		-- HORAS                Horas del proyecto            2           3
			update TblDetalleProyectos
			set TOTAL = CAP1
			where IDConcepto = 'HORAS' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado

		-- CON                  Cosumo                        3           1
			update TblDetalleProyectos
			set TOTAL = CAP1
			where IDConcepto = 'CON' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
								
		-- ALOJ                 Alojamiento                   4           1
			update TblDetalleProyectos
			set TOTAL = CAP1
			where IDConcepto = 'ALOJ' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
			
		-- HERR                 Herramientas                  5           1
			update TblDetalleProyectos
			set TOTAL = CAP1
			where IDConcepto = 'HERR' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
		
		-- COM                 Comisión					      5           1
			select @CAP1=CAP1
			from TblDetalleProyectos
			where IDConcepto = 'COM' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
			
			if (@CAP1 > 0)
			begin
				update TblDetalleProyectos
				set TOTAL = CAP1
				where IDConcepto = 'COM' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
			end
			else
			begin
				
				set @TOTAL = ( dbo.fsTotal(@IDProyecto,@IDEmpleado,'IMP') * dbo.fsTotal(@IDProyecto,@IDEmpleado,'HORAS') );
				
				update TblDetalleProyectos
				set TOTAL = @TOTAL,
					CAP1 = @TOTAL
				where IDConcepto = 'COM' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
				
				set @TOTAL = 0;
			end
				
		-- COS                  Costo                         6           3
			
			update TblDetalleProyectos
			set TOTAL = (select SUM(TOTAL)
							from TblDetalleProyectos
							where IDConcepto in ('CON','ALOJ','HERR','COM' ) and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado)
			where IDConcepto = 'COS' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
			
		-- EST                  Estimado                      7           3
		
			set @TOTAL = (select dbo.fsTotal(@IDProyecto,@IDEmpleado,'COS'))
		
			update TblDetalleProyectos
			set TOTAL = ( @TOTAL * 1.5) + @TOTAL
			where IDConcepto = 'EST' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
			
			set @TOTAL = 0;
		-- PRE                  Precio                        8           3
			select @CAP1=CAP1
			from TblDetalleProyectos
			where IDConcepto = 'PRE' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
			
			if (@CAP1 > 0)
			begin				
				select @TotalEmpPRE=SUM(TOTAL)
				from TblDetalleProyectos
				where IDConcepto = 'PRE' and IDProyecto=@IDProyecto and IDEmpleado <> @IDEmpProyecto	
			
				update TblDetalleProyectos
				set TOTAL = @CAP1 - @TotalEmpPRE
				where IDConcepto = 'PRE' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado	
			end else
			begin
				set @TOTAL = dbo.fsTotal(@IDProyecto,@IDEmpleado,'EST') 
				
				update TblDetalleProyectos
				set TOTAL = ( @TOTAL * 0.4) + @TOTAL
				where IDConcepto = 'PRE' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
				
				set @TOTAL = 0;
				set @TotalEmpPRE = 0;	
			end;
				
		
		-- ITBIS                Impuesto                      9           2
				update TblDetalleProyectos
				set TOTAL = (select dbo.fsTotal(@IDProyecto,@IDEmpleado,'PRE') * 0.18)
				where IDConcepto = 'ITBIS' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
	
		-- PREF                 Precio Final                  10          3		
				update TblDetalleProyectos
				set TOTAL =  ( select dbo.fsTotal(@IDProyecto,@IDEmpleado,'PRE') + dbo.fsTotal(@IDProyecto,@IDEmpleado,'ITBIS') )
				where IDConcepto = 'PREF' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
				
		-- GAN                  Ganancia                      11          3
				update TblDetalleProyectos
				set TOTAL =  (select dbo.fsTotal(@IDProyecto,@IDEmpleado,'PREF') ) - 
							( (select dbo.fsTotal(@IDProyecto,@IDEmpleado,'COS')) + ( select dbo.fsTotal(@IDProyecto,@IDEmpleado,'ITBIS')) )
				where IDConcepto = 'GAN' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
				
		-- SOLU                 Solumedios                    12          3
			
				update TblDetalleProyectos
				set TOTAL = ( (select dbo.fsTotal(@IDProyecto,@IDEmpleado,'GAN')) * 0.34)
				where IDConcepto = 'SOLU' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
				
		-- GTE                  Gerente de proyecto           13          3
				update TblDetalleProyectos
				set TOTAL = ( (select dbo.fsTotal(@IDProyecto,@IDEmpleado,'GAN')) * 0.33)
				where IDConcepto = 'GTE' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
				
				
		-- GTEF                 Gerente Financiero            14          3
				update TblDetalleProyectos
				set TOTAL = ( ( select dbo.fsTotal(@IDProyecto,@IDEmpleado,'GAN')) * 0.33)
				where IDConcepto = 'GTEF' and IDProyecto=@IDProyecto and IDEmpleado = @IDEmpleado
			
		FETCH NEXT FROM EmpP INTO @IDEmpleado
	END;
	
	
	CLOSE EmpP
	DEALLOCATE EmpP
/*
select @IDDetalleProyecto=IDDetalleProyecto,@CAP1=CAP1
			from TblDetalleProyectos
			where IDConcepto = 'IMP' and IDProyecto=@IDProyecto
*/
