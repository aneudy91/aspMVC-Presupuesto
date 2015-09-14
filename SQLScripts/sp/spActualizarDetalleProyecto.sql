create PROCEDURE spActualizarDetalleProyecto(@IDProyecto int,@Concepto varchar(20), @IDEmpleado int,@Cap1 decimal(10,2))
as

	Declare @chPos int

	select  @chPos=patindex('%-%', @Concepto)-1;
	if @chPos>0
		select @Concepto=LTRIM(RTRIM( SUBSTRING(@Concepto,1,@chPos)))	
	
	update TblDetalleProyectos
		set CAP1 = @Cap1
	where (IDProyecto = @IDProyecto) and  (IDEmpleado = @IDEmpleado) and (IDConcepto = @Concepto)
	

/*
select *
from TblDetalleProyectos

sp_help TblDetalleProyectos

sp_help tblconceptos

*/