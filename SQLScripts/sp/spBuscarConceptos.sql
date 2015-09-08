alter PROCEDURE spBuscarConceptos
as
select IDConcepto,Descripcion as Concepto,OrdenInsert,Tipo
from TblConceptos
order by OrdenInsert