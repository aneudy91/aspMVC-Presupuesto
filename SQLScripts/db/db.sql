CREATE DATABASE dbPresupuestos ON  PRIMARY 
( NAME = N'dbPresupuestos', FILENAME = N'\\psf\Home\Documents\A2BSYSTEM\DESARROLLO\VS\Análisis Financiero\SQLSCripts\db\dbPresupuestos.mdf' , SIZE = 5MB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbPresupuestos_log', FILENAME = N'\\psf\Home\Documents\A2BSYSTEM\DESARROLLO\VS\Análisis Financiero\SQLSCripts\db\dbPresupuestos_log.ldf' , SIZE = 5MB , MAXSIZE = 1GB , FILEGROWTH = 10%)
GO