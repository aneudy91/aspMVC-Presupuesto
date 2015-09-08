-- =============================================
-- Author:		Ing. Aneudy Abreu
-- Create date: 02/02/2015
-- Description:	Valida Accedo del Usuario
-- =============================================
CREATE PROCEDURE spLogIn(
	 @NombreCuenta varchar(150)
	,@Clave nvarchar(100)
) as

	if (Select COUNT(IDUsuario) 
		from TblUsuarios with (nolock) 
		where NombreCuenta = @NombreCuenta and Clave = @Clave) > 0
	begin
		select IDUsuario,Nombre,NombreCuenta
		from TblUsuarios with (nolock)
		where NombreCuenta = @NombreCuenta and Clave = @Clave;	
	end else 
	begin
		select IDUsuario,Nombre,NombreCuenta
		from TblUsuarios with (nolock)	
		where IDUsuario = 0;
	end;