alter PROCEDURE spCrearDetallePeriodo(@IDProyecto int)
as
	DECLARE @i int, @TotalReg int, @IDEmp int
	
	select @i = 1,@TotalReg=0;

	CREATE TABLE #TblEmp(ID int identity(1,1) primary key,IDEmpleado int)
	
	insert into #TblEmp(IDEmpleado)
	select IDEmpleado
	from TblProyectosEmpleados with (nolock)
	where IDProyecto = @IDProyecto

	select @TotalReg=COUNT(*)
	from #TblEmp
	
	while (@i <= @TotalReg) 
	begin
		
		select @IDEmp = IDEmpleado
		from #TblEmp
		where ID = @i
		
		insert into TblDetalleProyectos(IDProyecto,IDConcepto,IDEmpleado)
		select @IDProyecto,IDConcepto,@IDEmp
		from TblConceptos with (nolock)
		where IDConcepto not in (select IDConcepto 
								from TblDetalleProyectos 
								where IDProyecto  =@IDProyecto and IDEmpleado = @IDEmp)
				 
		set @i = @i + 1;
	end;
	
	drop table #TblEmp
	

	

