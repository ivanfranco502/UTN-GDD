USE [GD2C2011]
GO
/****** Object:  Schema [NTVC]    Script Date: 10/15/2011 20:07:23 ******/
CREATE SCHEMA [NTVC] AUTHORIZATION [gd]

/**********************************************CREACION DE TABLAS******************************************************/

/*FUNCIONALIDAD*/
CREATE TABLE NTVC.FUNCIONALIDAD
	(COD_FUNCIONALIDAD INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 DESCRIPCION CHAR(50) NOT NULL)
GO


/*ROL*/
CREATE TABLE NTVC.ROL
	(COD_ROL INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 NOMBRE CHAR(30) NOT NULL,
	 HABILITACION INT NOT NULL DEFAULT 1)
GO


/*ROL_FUNCIONALIDAD*/
CREATE TABLE NTVC.ROL_FUNCIONALIDAD
	(COD_ROL INT REFERENCES NTVC.ROL(COD_ROL),
	 COD_FUNCIONALIDAD INT REFERENCES NTVC.FUNCIONALIDAD(COD_FUNCIONALIDAD))
GO


/*USUARIO*/
CREATE TABLE NTVC.USUARIO
	(COD_USUARIO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 USERNAME CHAR(30) UNIQUE NOT NULL,
	 PASSWORD VARCHAR(255) NOT NULL,
	 CANT_LOG_FALLA INT NOT NULL DEFAULT 0,
	 HABILITADO INT NOT NULL DEFAULT 1)
GO


/*USUARIO_ROL*/
CREATE TABLE NTVC.USUARIO_ROL
	(COD_ROL INT NOT NULL REFERENCES NTVC.ROL(COD_ROL),
	 COD_USUARIO INT NOT NULL REFERENCES NTVC.USUARIO(COD_USUARIO))
GO


/*PROVINCIA*/
CREATE TABLE NTVC.PROVINCIA
	(COD_PROVINCIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 NOMBRE CHAR(25) NOT NULL)
GO


/*CLIENTE*/
CREATE TABLE NTVC.CLIENTE
	(COD_CLIENTE INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 NOMBRE CHAR(50) NOT NULL,
	 APELLIDO CHAR(50) NOT NULL,
	 TIPO_DOC CHAR(3) NOT NULL,
	 DOC INT NOT NULL,
	 MAIL CHAR(150) NOT NULL,
	 TELEFONO CHAR(30) NOT NULL,
	 COD_PROVINCIA INT NOT NULL REFERENCES NTVC.PROVINCIA(COD_PROVINCIA),
	 DIR_CALLE CHAR(30) NOT NULL,
	 DIR_NRO INT NOT NULL,
	 DIR_PISO CHAR(5) NULL,
	 DIR_DPTO CHAR(5) NULL,
	 HABILITADO INT NOT NULL DEFAULT 1)
GO


/*TARJETA*/
CREATE TABLE NTVC.TARJETA
	(COD_TARJETA INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 NRO_TARJETA INT UNIQUE NOT NULL,
	 FECHA_ALTA DATETIME NOT NULL,
	 CREDITO MONEY NOT NULL,
	 HABILITADO INT NOT NULL DEFAULT 1,
	 COD_CLIENTE INT NOT NULL REFERENCES NTVC.CLIENTE(COD_CLIENTE))
GO


/*RUBRO*/
CREATE TABLE NTVC.RUBRO
	(COD_RUBRO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 CODIGO INT NOT NULL,
	 DESCRIPCION CHAR(30) NOT NULL)
GO


/*BENEFICIARIO*/
CREATE TABLE NTVC.BENEFICIARIO
	(COD_BENEFICIARIO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 RAZON_SOCIAL CHAR(30) NOT NULL,
	 DIR_CALLE CHAR(30) NOT NULL,
	 DIR_NRO INT NOT NULL,
	 DIR_PISO CHAR(5) NULL,
	 DIR_DPTO CHAR(5) NULL,
	 COD_RUBRO INT NOT NULL REFERENCES NTVC.RUBRO(COD_RUBRO),
	 HABILITADO INT NOT NULL DEFAULT 1)
GO


/*POSTNET*/
CREATE TABLE NTVC.POSTNET
	(COD_POSTNET INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 NRO_SERIE INT NOT NULL UNIQUE,
	 MARCA CHAR(30) NOT NULL,
	 MODELO CHAR(30) NOT NULL)
GO


/*BENEFICIARIO_POSTNET*/
CREATE TABLE NTVC.BENEFICIARIO_POSTNET
	(COD_BENEFICIARIO INT NOT NULL REFERENCES NTVC.BENEFICIARIO(COD_BENEFICIARIO),
	 COD_POSTNET INT NOT NULL REFERENCES NTVC.POSTNET(COD_POSTNET))
GO


/*CARGA*/
CREATE TABLE NTVC.CARGA
	(COD_CARGA INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 COD_TARJETA INT NOT NULL REFERENCES NTVC.TARJETA(COD_TARJETA),
	 FECHA DATETIME NOT NULL,
	 MONTO MONEY NOT NULL)
GO


/*COMPRA*/
CREATE TABLE NTVC.COMPRA
	(COD_COMPRA INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 CODIGO INT NOT NULL,
	 FECHA DATETIME NOT NULL,
	 MONTO MONEY NOT NULL,
	 COD_TARJETA INT NOT NULL REFERENCES NTVC.TARJETA(COD_TARJETA),
	 COD_BENEFICIARIO INT NOT NULL REFERENCES NTVC.BENEFICIARIO(COD_BENEFICIARIO),
	 COD_POSTNET INT NOT NULL REFERENCES NTVC.POSTNET(COD_POSTNET),
	 PAGADO INT NOT NULL DEFAULT 0)
GO


/*PAGO*/
CREATE TABLE NTVC.PAGO
	(COD_PAGO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	 FECHA_PAGO DATETIME NOT NULL,
	 MONTO MONEY NOT NULL,
	 COD_BENEFICIARIO INT NOT NULL REFERENCES NTVC.BENEFICIARIO(COD_BENEFICIARIO),
	 COD_COMPRA INT NOT NULL REFERENCES NTVC.COMPRA(COD_COMPRA))
GO


/************************************************STORED PROCEDURES*********************************************************/

/*VALIDACION DE DNIs REPETIDOS Y ACTUALIZACION*/
CREATE PROCEDURE NTVC.DNIREPETIDOS AS
	BEGIN
		DECLARE @CANTDNIREPE INT
		DECLARE @DNI INT
		DECLARE CURSORDNI CURSOR FOR
			SELECT *
			FROM NTVC.CLIENTE
			WHERE DOC = (SELECT TOP 1 DOC
							FROM NTVC.CLIENTE
							GROUP BY DOC
							HAVING COUNT(DOC) > 1
							ORDER BY DOC ASC) OR
				  DOC = (SELECT TOP 1 DOC
							FROM NTVC.CLIENTE
							GROUP BY DOC
							HAVING COUNT(DOC) > 1
							ORDER BY DOC DESC)
			FOR UPDATE OF DOC

		OPEN CURSORDNI
			FETCH NEXT FROM CURSORDNI
			WHILE @@FETCH_STATUS = 0
				BEGIN
					SELECT TOP 1 @DNI = DOC 
								FROM NTVC.CLIENTE 
								WHERE DOC = (SELECT TOP 1 DOC
												FROM NTVC.CLIENTE
												GROUP BY DOC
												HAVING COUNT(DOC) > 1
												ORDER BY DOC ASC) OR
									  DOC = (SELECT TOP 1 DOC
												FROM NTVC.CLIENTE
												GROUP BY DOC
												HAVING COUNT(DOC) > 1
												ORDER BY DOC DESC)
					SELECT @CANTDNIREPE = COUNT(*) 
										FROM NTVC.CLIENTE
										GROUP BY DOC
										HAVING DOC = @DNI
					IF @CANTDNIREPE > 1
						BEGIN
							UPDATE NTVC.CLIENTE SET DOC = (@DNI * -1) WHERE CURRENT OF CURSORDNI
						END
					FETCH NEXT FROM CURSORDNI
				END
		CLOSE CURSORDNI
		DEALLOCATE CURSORDNI
	END
GO


/*ACTUALIZACION DEL CREDITO EN LA TARJETA*/
CREATE PROCEDURE NTVC.CREDITOTARJETA AS
	BEGIN
		UPDATE NTVC.TARJETA 
			SET TARJETA.CREDITO = AUXILIAR.SALDO
			FROM NTVC.TARJETA AS TARJETA,
				 (SELECT COMPRA.COD_TARJETA, CARGA - COMPRA AS SALDO
					FROM (SELECT COD_TARJETA, SUM(MONTO) AS COMPRA
							FROM NTVC.COMPRA
							GROUP BY COD_TARJETA) AS COMPRA,
						 (SELECT COD_TARJETA, SUM(MONTO) AS CARGA
							FROM NTVC.CARGA
							GROUP BY COD_TARJETA) AS CARGA
					WHERE COMPRA.COD_TARJETA = CARGA.COD_TARJETA) AS AUXILIAR
			WHERE TARJETA.COD_TARJETA = AUXILIAR.COD_TARJETA
	END
GO


/*ACTUALIZACION DE TABLA COMPRAS SI ESTA PAGO O NO A LOS BENEFICIARIOS*/
CREATE PROCEDURE NTVC.ACTUALIZARPAGO AS
	BEGIN
		UPDATE NTVC.COMPRA
			SET COMPRA.PAGADO = AUXILIAR.PAGADO
			FROM NTVC.COMPRA AS COMPRA,
				(SELECT C.COD_COMPRA, PAGADO + 1 AS PAGADO
					FROM NTVC.COMPRA AS C, (SELECT COD_COMPRA FROM NTVC.PAGO) AS P
					WHERE C.COD_COMPRA = P.COD_COMPRA) AS AUXILIAR
			WHERE COMPRA.COD_COMPRA = AUXILIAR.COD_COMPRA
	END
GO

/*FUNCION CLIENTES PREMIUM*/
CREATE FUNCTION NTVC.CLIENTEPREMIUM (@YEAR INT) 
RETURNS TABLE
AS
	RETURN
		 SELECT TOP 30 NOMBRE, APELLIDO, DOC, NRO_TARJETA, SUM(MONTO) AS MONTO_ACUMULADO, 
						(SELECT TOP 1 FECHA
							FROM NTVC.COMPRA
							WHERE TARJETA.COD_TARJETA = COMPRA.COD_TARJETA AND YEAR(FECHA) = @YEAR
							ORDER BY COD_TARJETA, FECHA DESC) AS FECHA_ULTIMA_COMPRA
			FROM NTVC.CLIENTE, NTVC.TARJETA, NTVC.COMPRA
			WHERE CLIENTE.COD_CLIENTE = TARJETA.COD_CLIENTE AND COMPRA.COD_TARJETA = TARJETA.COD_TARJETA AND YEAR(FECHA) =  @YEAR
			GROUP BY NOMBRE, APELLIDO, DOC, NRO_TARJETA, TARJETA.COD_TARJETA
			ORDER BY SUM(MONTO) DESC
GO


/***************************************************INICIALIZACION*********************************************************/

/*SETEO DE PROVINCIAS*/
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('BUENOS AIRES');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('CATAMARCA');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('CHACO');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('CHUBUT');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('CORDOBA');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('CORRIENTES');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('ENTRE RIOS');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('FORMOSA');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('JUJUY');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('LA PAMPA');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('LA RIOJA');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('MENDOZA');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('MISIONES');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('NEUQUEN');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('RIO NEGRO');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('SALTA');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('SAN JUAN');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('SAN LUIS');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('SANTA CRUZ');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('SANTA FE');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('SANTIAGO DEL ESTERO');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('TIERRA DEL FUEGO');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('TUCUMAN');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('CAPITAL FEDERAL');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('EXTERIOR');
INSERT INTO NTVC.PROVINCIA(NOMBRE) VALUES ('MIGRADA');


/*CREACION de los ROLES*/
INSERT INTO NTVC.ROL(NOMBRE) VALUES ('Administrador General');
INSERT INTO NTVC.ROL(NOMBRE) VALUES ('Gestor');
INSERT INTO NTVC.ROL(NOMBRE) VALUES ('Punto de Venta');


/*SETEO DE FUNCIONALIDADES*/
INSERT INTO NTVC.FUNCIONALIDAD(DESCRIPCION) VALUES ('ABM de Tarjetas');
INSERT INTO NTVC.FUNCIONALIDAD(DESCRIPCION) VALUES ('ABM de Rol');
INSERT INTO NTVC.FUNCIONALIDAD(DESCRIPCION) VALUES ('ABM de Usuario');
INSERT INTO NTVC.FUNCIONALIDAD(DESCRIPCION) VALUES ('ABM de Cliente');
INSERT INTO NTVC.FUNCIONALIDAD(DESCRIPCION) VALUES ('ABM de Beneficiarios/Empresas');
INSERT INTO NTVC.FUNCIONALIDAD(DESCRIPCION) VALUES ('Carga de credito');
INSERT INTO NTVC.FUNCIONALIDAD(DESCRIPCION) VALUES ('Efectuar Compra');
INSERT INTO NTVC.FUNCIONALIDAD(DESCRIPCION) VALUES ('Pago a empresas');
INSERT INTO NTVC.FUNCIONALIDAD(DESCRIPCION) VALUES ('Inactividad de tarjetas');
INSERT INTO NTVC.FUNCIONALIDAD(DESCRIPCION) VALUES ('Clientes Premium');


/*SETEO DE LAS FUNCIONALIDADES DEL ADMINISTRADOR GENERAL*/
INSERT INTO NTVC.ROL_FUNCIONALIDAD(COD_ROL,COD_FUNCIONALIDAD)
	SELECT ROL.COD_ROL,FUNCIONALIDAD.COD_FUNCIONALIDAD 
		FROM NTVC.ROL, NTVC.FUNCIONALIDAD
		WHERE ROL.NOMBRE = 'Administrador General';


/*SETEO DE LAS FUNCIONALIDADES DEL GESTOR*/
INSERT INTO NTVC.ROL_FUNCIONALIDAD(COD_ROL, COD_FUNCIONALIDAD)
	SELECT ROL.COD_ROL, FUNCIONALIDAD.COD_FUNCIONALIDAD
		FROM NTVC.ROL, NTVC.FUNCIONALIDAD
		WHERE ROL.NOMBRE = 'Gestor' AND FUNCIONALIDAD.DESCRIPCION LIKE 'ABM %'


/*SETEO DE LAS FUNCIONALIDADES DEL PUNTO DE VENTA*/
INSERT INTO NTVC.ROL_FUNCIONALIDAD(COD_ROL, COD_FUNCIONALIDAD)
	SELECT ROL.COD_ROL, FUNCIONALIDAD.COD_FUNCIONALIDAD
		FROM NTVC.ROL, NTVC.FUNCIONALIDAD
		WHERE ROL.NOMBRE = 'Punto de Venta' AND 
			(FUNCIONALIDAD.DESCRIPCION = 'Carga de credito' OR FUNCIONALIDAD.DESCRIPCION = 'Efectuar Compra')


/*CREACION DEL USUARIO ADMIN*/
INSERT INTO NTVC.USUARIO(USERNAME, PASSWORD) VALUES ('admin', 'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7');


/*SETEO DEL ROL AL USUARIO ADMIN*/
INSERT INTO NTVC.USUARIO_ROL(COD_USUARIO, COD_ROL)
	SELECT USUARIO.COD_USUARIO, ROL.COD_ROL 
		FROM NTVC.USUARIO, NTVC.ROL
		WHERE (USUARIO.USERNAME = 'admin') AND (ROL.NOMBRE = 'Administrador General');


/****************************************************MIGRACION*************************************************************/

/*CARGA RUBRO*/
INSERT INTO NTVC.RUBRO (CODIGO, DESCRIPCION)
	SELECT DISTINCT BENEFICIARIO_RUBRO_CODIGO, BENEFICIARIO_RUBRO_DESC
		FROM GD_ESCHEMA.MAESTRA
		WHERE (BENEFICIARIO_RUBRO_CODIGO != 0);


/*CARGA POSTNET*/
INSERT INTO NTVC.POSTNET (NRO_SERIE, MARCA, MODELO)
	SELECT DISTINCT POSTNET_NRO_SERIE, POSTNET_MODELO, POSTNET_MARCA
		FROM GD_ESCHEMA.MAESTRA
		GROUP BY POSTNET_NRO_SERIE, POSTNET_MODELO, POSTNET_MARCA
		HAVING POSTNET_NRO_SERIE != 0;


/*CARGA CLIENTE*/ 
/*LO CARGA TENIENDO EN CUENTA QUE SEA DISTINTO LA COMBINACION DE DNI, NOMBRE Y APELLIDO*/
/*DESPUES SE VALIDA SI HAY REPETIDOS CON UN STORED PROCEDURE.*/
/*ASI NOS ASEGURAMOS QUE TODOS LOS DATOS SE MIGREN, DESPUES LOS VALIDAMOS*/
INSERT INTO NTVC.CLIENTE (NOMBRE, APELLIDO, TIPO_DOC, DOC, MAIL, TELEFONO, DIR_CALLE, DIR_NRO, DIR_PISO, DIR_DPTO, COD_PROVINCIA)
	SELECT DISTINCT CAST(CLIENTE_NOMBRE AS CHAR(50)), CAST(CLIENTE_APELLIDO AS CHAR(50)), CAST(CLIENTE_TIPO_DNI AS CHAR(3)),
					CLIENTE_DNI, CAST(CLIENTE_MAIL AS CHAR(150)), CAST(CLIENTE_TELEFONO AS CHAR(30)), 
					CAST(CLIENTE_CALLE AS CHAR(30)), CLIENTE_NRO, CAST(CLIENTE_PISO AS CHAR(5)), CAST(CLIENTE_DEPTO AS CHAR(5)),
					COD_PROVINCIA
		FROM GD_ESCHEMA.MAESTRA, NTVC.PROVINCIA
		WHERE CLIENTE_NOMBRE IS NOT NULL AND NOMBRE = 'MIGRADA';


/*VALIDO QUE NO HAYAN DNIs REPETIDOS*/
EXEC NTVC.DNIREPETIDOS


/*CARGA TARJETA*/ 
/*CARGO TODAS LAS TARJETAS CON CREDITO NULO*/
/*DESPUES AL REALIZAR LAS MIGRACIONES DE COMPRA Y CARGA LE ACTUALIZO EL CREDITO COMO SUM(CARGA) - SUM(COMPRA)*/
INSERT INTO NTVC.TARJETA (NRO_TARJETA, FECHA_ALTA, CREDITO, COD_CLIENTE)
	SELECT DISTINCT TARJETA_NRO, TARJETA_FECHA_ALTA, 0,COD_CLIENTE
		FROM GD_ESCHEMA.MAESTRA AS MASTER, NTVC.CLIENTE AS CLIENTE
		WHERE TARJETA_NRO != 0 AND MASTER.CLIENTE_NOMBRE = CLIENTE.NOMBRE AND MASTER.CLIENTE_APELLIDO = CLIENTE.APELLIDO AND
				MASTER.CLIENTE_TIPO_DNI = CLIENTE.TIPO_DOC AND MASTER.CLIENTE_DNI = CLIENTE.DOC;


/*CARGA BENEFICIARIO*/
INSERT INTO NTVC.BENEFICIARIO (RAZON_SOCIAL, DIR_CALLE, DIR_NRO, DIR_PISO, DIR_DPTO, COD_RUBRO)
	SELECT DISTINCT BENEFICIARIO_NOMBRE, BENEFICIARIO_CALLE, BENEFICIARIO_NRO, BENEFICIARIO_PISO, BENEFICIARIO_DEPTO, COD_RUBRO
		FROM GD_ESCHEMA.MAESTRA AS MAESTRA, NTVC.RUBRO AS RUBRO
		WHERE BENEFICIARIO_NOMBRE IS NOT NULL AND MAESTRA.BENEFICIARIO_RUBRO_CODIGO = RUBRO.CODIGO;


/*CARGA TABLA CARGA DE CREDITO*/
INSERT INTO NTVC.CARGA (FECHA, MONTO, COD_TARJETA)
	SELECT CARGA_FECHA, CARGA_MONTO, COD_TARJETA
		FROM GD_ESCHEMA.MAESTRA AS MAESTRA, NTVC.TARJETA AS TARJETA
		WHERE CARGA_MONTO > 0 AND MAESTRA.TARJETA_NRO = TARJETA.NRO_TARJETA/*YEAR(CARGA_FECHA)> 1990 */;


/*CARGA TABLA COMPRA*/
INSERT INTO NTVC.COMPRA (CODIGO, FECHA, MONTO, COD_TARJETA, COD_BENEFICIARIO, COD_POSTNET)
	SELECT COMPRA_CODIGO, COMPRA_FECHA, COMPRA_MONTO, COD_TARJETA, COD_BENEFICIARIO, COD_POSTNET
		FROM GD_ESCHEMA.MAESTRA AS MAESTRA, NTVC.TARJETA AS TARJETA, NTVC.BENEFICIARIO AS BENEFICIARIO, NTVC.POSTNET AS POSTNET
		WHERE COMPRA_MONTO > 0 AND MAESTRA.TARJETA_NRO = TARJETA.NRO_TARJETA AND MAESTRA.POSTNET_NRO_SERIE = POSTNET.NRO_SERIE
				AND MAESTRA.BENEFICIARIO_NOMBRE = BENEFICIARIO.RAZON_SOCIAL;


/*ACTUALIZO EL CREDITO DE LAS TARJETAS*/
EXEC NTVC.CREDITOTARJETA


/*CARGA TABLA PAGO*/ 
/*AL MIGRAR LE ASIGNO A PAGADO 0, ES DECIR QUE TODAVIA NO LO SE, LUEGO EJECUTO EL STORED PROCEDURE QUE VERIFICA SI ESTAN PAGOS*/
INSERT INTO NTVC.PAGO (FECHA_PAGO, MONTO, COD_BENEFICIARIO, COD_COMPRA)
	SELECT T1.PAGO_FECHA, T1.PAGO_MONTO,C.COD_BENEFICIARIO, C.COD_COMPRA
	FROM (SELECT M.PAGO_FECHA, M.PAGO_MONTO, B.COD_BENEFICIARIO, M.PAGO_TRANS_CODIGO
			FROM GD_ESCHEMA.MAESTRA AS M, NTVC.BENEFICIARIO AS B
			WHERE M.BENEFICIARIO_NOMBRE = B.RAZON_SOCIAL
					AND PAGO_MONTO >0) AS T1,
		 NTVC.COMPRA AS C
	WHERE T1.PAGO_TRANS_CODIGO = C.CODIGO;


/*COMPRUEBO SI LAS COMPRAS YA FUERON PAGADAS*/
EXEC NTVC.ACTUALIZARPAGO


/*CARGA BENEFICIARIO_POSTNET*/
INSERT INTO NTVC.BENEFICIARIO_POSTNET (COD_POSTNET, COD_BENEFICIARIO)
	SELECT DISTINCT COD_POSTNET, COD_BENEFICIARIO
	FROM (SELECT COD_BENEFICIARIO, POSTNET_NRO_SERIE
			FROM GD_ESCHEMA.MAESTRA, NTVC.BENEFICIARIO
			WHERE BENEFICIARIO_NOMBRE = RAZON_SOCIAL 
					AND POSTNET_NRO_SERIE !=0) AS T1, NTVC.POSTNET
	WHERE POSTNET_NRO_SERIE = NRO_SERIE;
