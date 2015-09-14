/*
	0 : Todos
	1 : De captura
	2 : Totales
*/
create PROCEDURE spBuscarConceptos(@Tipo int)
as

	if (@Tipo = 0 )
	begin
		select IDConcepto,Descripcion as Concepto
		from TblConceptos		
		order by OrdenInsert asc
	end
	
	if (@Tipo = 1 )
	begin
		select IDConcepto,Descripcion as Concepto
		from TblConceptos
		WHERE IDConcepto NOT IN ('ITBIS','SOLU','GTE','GTET','GTEF','ITBIS','EST','PREF','GAN','COS')
		order by OrdenInsert asc	
	end
	
	if (@Tipo = 2 )
	begin
		select IDConcepto,Descripcion as Concepto
		from TblConceptos
		where IDConcepto not in ('IMP','HORAS','COM','CON','ALOJ','HERR')
		order by OrdenInsert asc
	end
	
	
	
