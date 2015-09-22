IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblListaConfig]') AND type in (N'U'))
    DROP TABLE [dbo].[tblListaConfig]
GO
CREATE TABLE tblListaConfig(
	 Nombre varchar(100) not null primary key
	,Valor varchar(500)	
	,Descripcion NVARCHAR(1000)
);
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblEmpresa]') AND type in (N'U'))
    DROP TABLE [dbo].[TblEmpresa]
GO
CREATE TABLE TblEmpresa(
	 IDEmpresa int identity(1,1) primary key 
	,NombreComercial varchar(300)
	,RazonSocial varchar(300) not null
	,RFC varchar(50) unique not null
	,DomicilioFiscal_calle varchar(500)
	,DomicilioFiscal_noExterior varchar(100)
	,DomicilioFiscal_colonia varchar(500)
	,DomicilioFiscal_localidad varchar(500)
	,DomicilioFiscal_municipio varchar(500)
	,DomicilioFiscal_estado varchar(500)
	,DomicilioFiscal_pais varchar(500)
	,DomicilioFiscal_codigoPostal varchar(100)
);
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblUsuarios]') AND type in (N'U'))
    DROP TABLE [dbo].[TblUsuarios]
GO
CREATE TABLE TblUsuarios(
	 IDUsuario int identity(1,1) primary key not null	
	,Nombre varchar(150) not null
	,NombreCuenta varchar(100) not null
	,Clave nvarchar(100) not null
	,Active bit default 1 /*Corregir*/
);
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblClientes]') AND type in (N'U'))
    DROP TABLE [dbo].[TblClientes]
GO
CREATE TABLE TblClientes(
	IDCliente int identity(1,1) primary key
   ,NombreComercial varchar(200) not null
   ,RazonSocial varchar(255)
   ,RFC varchar(20)
   ,Activo bit default 1
);
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblPuestos]') AND type in (N'U'))
    DROP TABLE [dbo].[TblPuestos]
GO
CREATE TABLE TblPuestos(
	 IDPuesto int identity(1,1) primary key not null
	,Descripcion varchar(100) not null
);
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblEmpleados]') AND type in (N'U'))
    DROP TABLE [dbo].[TblEmpleados]
GO
CREATE TABLE TblEmpleados(
	 IDEmpleado int identity(1,1) primary key not null
	,Nombre varchar(100) not null
	,Paterno varchar(100) not null
	,Materno varchar(60) null
	,IDPuesto int CONSTRAINT Fk_TblEmpleados_IDPuesto foreign key references TblPuestos(IDPuesto)	
);
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblConceptos]') AND type in (N'U'))
    DROP TABLE [dbo].[TblConceptos]
GO
CREATE TABLE TblConceptos(
	 IDConcepto varchar(20) primary key not null
	,Descripcion varchar(200) not null
	,OrdenInsert int not null
	,Tipo int not null /* 1 = Percepcion 2 = Deduccion 3 = Concepto*/
)
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblEstatus]') AND type in (N'U'))
    DROP TABLE [dbo].[TblEstatus]
GO
CREATE TABLE TblEstatus(
	 IDEstatus int identity(1,1) primary key
	,Descripcion varchar(30) not null
)
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblProyectos]') AND type in (N'U'))
    DROP TABLE [dbo].[TblProyectos]
GO
CREATE TABLE TblProyectos(
	 IDProyecto int identity(1,1) primary key
	,IDCliente int CONSTRAINT fk_TblProyectos_IDCliente FOREIGN KEY REFERENCES TblClientes(IDCliente) ON DELETE CASCADE 
	,Nombre varchar(200) not null
	,Decripcion varchar(1000) null
	,FechaInicio Date default getdate()
	,FechaFin date
	,Activo bit default 1
	,IDEstatus int CONSTRAINT fk_TblProyectos_IDEstatus FOREIGN KEY REFERENCES TblEstatus(IDEstatus)
);
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblProyectosEmpleados]') AND type in (N'U'))
    DROP TABLE [dbo].[TblProyectosEmpleados]
GO
CREATE TABLE TblProyectosEmpleados(
	 IDProyectoEmpleado int identity(1,1) primary key not null
	,IDProyecto int CONSTRAINT fk_TblProyectosEmpleados_IDProyecto FOREIGN KEY REFERENCES TblProyectos(IDProyecto) ON DELETE CASCADE
	,IDEmpleado int CONSTRAINT fk_TblProyectosEmpleados_IDEmpleado FOREIGN KEY REFERENCES TblEmpleados(IDEmpleado) ON DELETE CASCADE
);
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblDetalleProyectos]') AND type in (N'U'))
    DROP TABLE [dbo].[TblDetalleProyectos]
GO
CREATE TABLE TblDetalleProyectos(
	 IDDetalleProyecto int identity(1,1) primary key not null
	,IDProyecto int CONSTRAINT fk_TblDetalleProyectos_IDProyecto FOREIGN KEY REFERENCES TblProyectos(IDProyecto) ON DELETE CASCADE
	,IDConcepto varchar(20) CONSTRAINT fk_TblDetalleProyectos_IDConcepto FOREIGN KEY REFERENCES TblConceptos (IDConcepto)
	,IDEmpleado int CONSTRAINT fk_TblDetalleProyectos_IDEmpleado FOREIGN KEY REFERENCES TblEmpleados(IDEmpleado)
	,CAP1 DECIMAL(10,2) DEFAULT 0
	,CAP2 DECIMAL(10,2) DEFAULT 0
	,CAP3 DECIMAL(10,2) DEFAULT 0
	,TOTAL DECIMAL(10,2) DEFAULT 0
);
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblAbonosProyectos]') AND type in (N'U'))
    DROP TABLE [dbo].[TblAbonosProyectos]
GO
CREATE TABLE TblAbonosProyectos(
	 IDAbonosProyectos int identity(1,1) primary key
	,IDProyecto int CONSTRAINT fk_TblAbonosProyectos_IDProyecto FOREIGN KEY REFERENCES TblProyectos(IDProyecto) ON DELETE CASCADE
	,Fecha Date not null		
	,SubTotal money not null 	-- 820
	,Impuesto money 			-- 180
	,Total money				-- 1,000
	,RecibiDe varchar(150)
	,FechaReg datetime default getdate()
);
