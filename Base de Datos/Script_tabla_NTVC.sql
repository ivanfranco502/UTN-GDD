USE [GD2C2011]
GO
/****** Object:  Schema [NoTeVaConsultar]    Script Date: 10/15/2011 20:07:23 ******/
CREATE SCHEMA [NoTeVaConsultar] AUTHORIZATION [dbo]

/**********************************************CREACION DE TABLAS******************************************************/

/*FUNCIONALIDAD*/
CREATE TABLE FUNCIONALIDAD
	(COD_FUNCIONALIDAD INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 DESCRIPCION CHAR(50) NOT NULL)

/*ROL*/
CREATE TABLE ROL
	(COD_ROL INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 NOMBRE CHAR(30) NOT NULL,
	 HABILITACION INT NOT NULL)

/*ROL_FUNCIONALIDAD*/
CREATE TABLE ROL_FUNCIONALIDAD
	(COD_ROL INT REFERENCES ROL(COD_ROL),
	 COD_FUNCIONALIDAD INT REFERENCES FUNCIONALIDAD(COD_FUNCIONALIDAD))

/*USUARIO*/
CREATE TABLE USUARIO
	(COD_USUARIO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 USERNAME CHAR(30) UNIQUE NOT NULL,
	 PASSWORD CHAR(50) NOT NULL,
	 CANT_LOG_FALLA INT NOT NULL,
	 HABILITADO INT NOT NULL)

/*USUARIO_ROL*/
CREATE TABLE USUARIO_ROL
	(COD_ROL INT NOT NULL REFERENCES ROL(COD_ROL),
	 COD_USUARIO INT NOT NULL REFERENCES USUARIO(COD_USUARIO))

/*PROVINCIA*/
CREATE TABLE PROVINCIA
	(COD_PROVINCIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 NOMBRE CHAR(25) NOT NULL)

/*CLIENTE*/
CREATE TABLE CLIENTE
	(COD_CLIENTE INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 NOMBRE CHAR(50) NOT NULL,
	 APELLIDO CHAR(50) NOT NULL,
	 TIPO_DOC CHAR(3) NOT NULL,
	 DNI INT NOT NULL,
	 MAIL CHAR(50) NOT NULL,
	 TELEFONO INT NOT NULL,
	 COD_PROVINCIA INT NOT NULL REFERENCES PROVINCIA(COD_PROVINCIA),
	 DIR_CALLE CHAR(30) NOT NULL,
	 DIR_NRO INT NOT NULL,
	 DIR_PISO INT NULL,
	 DIR_DPTO CHAR(3) NULL,
	 HABILITADO INT NOT NULL)

/*TARJETA*/
CREATE TABLE TARJETA
	(COD_TARJETA INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 NRO_TARJETA INT NOT NULL,
	 FECHA_ALTA DATETIME NOT NULL,
	 CREDITO MONEY NOT NULL,
	 HABILITADO INT NOT NULL,
	 COD_CLIENTE INT NOT NULL REFERENCES CLIENTE(COD_CLIENTE))

/*RUBRO*/
CREATE TABLE RUBRO
	(COD_RUBRO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 DESCRIPCION CHAR(30) NOT NULL)

/*BENEFICIARIO*/
CREATE TABLE BENEFICIARIO
	(COD_BENEFICIARIO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 RAZON_SOCIAL CHAR(30) NOT NULL,
	 DIR_CALLE CHAR(30) NOT NULL,
	 DIR_NRO INT NOT NULL,
	 DIR_PISO INT NULL,
	 DIR_DPTO CHAR(3) NULL,
	 COD_RUBRO INT NOT NULL REFERENCES RUBRO(COD_RUBRO),
	 HABILITADO INT NOT NULL)

/*POSNET*/
CREATE TABLE POSNET
	(COD_POSNET INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 NRO_SERIE INT NOT NULL,
	 MARCA CHAR(30) NOT NULL,
	 MODELO CHAR(30) NOT NULL)

/*BENEFICIARIO_POSNET*/
CREATE TABLE BENEFICIARIO_POSNET
	(COD_BENEFICIARIO INT NOT NULL REFERENCES BENEFICIARIO(COD_BENEFICIARIO),
	 COD_POSNET INT NOT NULL REFERENCES POSNET(COD_POSNET))

/*MOVIMIENTO*/
CREATE TABLE MOVIMIENTO
	(COD_MOVIMIENTO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 TIPO_MOVIMIENTO INT NOT NULL,
	 COD_BENEFICIARIO INT NOT NULL REFERENCES BENEFICIARIO(COD_BENEFICIARIO),
	 COD_POSNET INT NOT NULL REFERENCES POSNET(COD_POSNET),
	 COD_TARJETA INT NOT NULL REFERENCES TARJETA(COD_TARJETA),
	 FECHA DATETIME NOT NULL,
	 MONTO MONEY NOT NULL)


/***************************************************MIGRACION*********************************************************/