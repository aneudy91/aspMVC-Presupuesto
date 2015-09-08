ALTER PROCEDURE spBuscarProyectos(@Tipo int) 
/* 0: Inactivos 1 : Activos : 2 : Todos */
as

if (@Tipo=2)
begin
	SELECT IDProyecto,Nombre
	FROM TblProyectos with (nolock)
end else
begin
	SELECT IDProyecto,Nombre
	FROM TblProyectos with (nolock)
	WHERE Activo = @Tipo
end;