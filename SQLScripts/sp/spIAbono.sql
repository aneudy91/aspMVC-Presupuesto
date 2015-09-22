ALTER PROCEDURE spIAbono(@IDProyecto int
						,@Fecha Date					
						,@Total money				
						,@RecibiDe varchar(150)
)
as
	Declare @ITBIS decimal(10,2),
		    @SubTotal decimal(10,2),
		    @Impuesto decimal(10,2)	

	
	Select @ITBIS=CONVERT(decimal(10,2),valor)
	from tblListaConfig with (nolock)
	where Nombre = 'ITBIS'
	
	set @Impuesto = @Total * (@ITBIS / 100)
	
	set @SubTotal = @Total - @Impuesto
	
	insert into TblAbonosProyectos(IDProyecto,Fecha,SubTotal,Impuesto,Total,RecibiDe)
	select @IDProyecto,@Fecha,@SubTotal,@Impuesto,@Total,@RecibiDe
	
	GO
	DELETE TblAbonosProyectos
