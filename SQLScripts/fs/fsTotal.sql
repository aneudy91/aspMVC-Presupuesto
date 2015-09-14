CREATE FUNCTION fsTotal(@IDProyecto int
					 ,@IDEmpleado int
					 ,@IDConcepto varchar(20)						 
)RETURNS  decimal (10,2) AS
BEGIN

	RETURN (SELECT ISNULL(TOTAL,0)
			FROM TblDetalleProyectos 
			WHERE IDProyecto = @IDProyecto AND IDEmpleado = @IDEmpleado AND IDConcepto = @IDConcepto)

END;
						  
	