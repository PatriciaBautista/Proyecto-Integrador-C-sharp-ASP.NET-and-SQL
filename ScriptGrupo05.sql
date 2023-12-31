Create database ProyectoWendyGrupo05
use ProyectoWendyGrupo05
GO

--------------------------------------------------------------------------------------------------
/*
GRUPO DE TRABAJO: 05
PROYECTO NOMBRE: WENDY
INTEGRANTES: CUEVA CARBAJAL, EMERSON ALEXANDER CARNET: CC21045
			 CABEZAS S�NCHEZ, ANTONIO NATANAEL CARNET: CS21062
			 FLORES BAUTISTA, PATRICIA GUADALUPE CARNET: FB21010
			 RAYMUNDO SALAZAR, ANDREA ESMERALDA CARNET: RS21037
			 VIVAS NIETO, RIKELMY ALDUBI CARNET: VN21007
*/
--------------------------------------------------------------------------------------------------

--Creando las tablas
--///////////////////////////////////////////////////////////////////////////////////

--Creando la tabla empleado detalles laborales
-- Creando la tabla detallesLaborales
CREATE TABLE detallesLaborales (
    idDetalleLaboral INT PRIMARY KEY IDENTITY,
    codDetalles VARCHAR(10),
    fechaIngreso VARCHAR(50),
    fechaRenuncia VARCHAR(50),
    tipoContrato VARCHAR(100),
    fechaEmision DATETIME DEFAULT GETDATE(),
    activoDetalle BIT DEFAULT 1
);

-- Creando la tabla direccionEmpleado
CREATE TABLE direccionEmpleado (
    idDireccion INT PRIMARY KEY IDENTITY,
    codDireccion VARCHAR(10),
    sucursalEmpleado VARCHAR(100),
    paisEmpleado VARCHAR(100),
    estado VARCHAR(100),
    nombreCalle VARCHAR(100),
    coloniaEmpleado VARCHAR(100),
    codigoPostal INT,
    activoDireccion BIT DEFAULT 1
);

-- Crear la tabla empleadoWendy
CREATE TABLE empleadoWendy (
    idEmpleadoWendy INT PRIMARY KEY IDENTITY,
	identificadorPersonal VARCHAR(30),
    nombreEmpleado VARCHAR(100),
    edadEmpleado INT,
    cargoEmpleado VARCHAR(100),
    telefonoEmpleado VARCHAR(50),
    sexoEmpleado VARCHAR(50),
    monto DECIMAL(10,2),
    activoEmpleado BIT DEFAULT 1,
    idDireccion INT FOREIGN KEY REFERENCES direccionEmpleado(idDireccion),
    idDetalleLaboral INT FOREIGN KEY REFERENCES detallesLaborales(idDetalleLaboral)
);
select * from empleadoWendy


--Crear la tabla de usurio
CREATE TABLE Usuario (
    idUsuario INT PRIMARY KEY IDENTITY,
    nombreUsuario VARCHAR(100),
    apellidoUsuario VARCHAR(100),
    correo VARCHAR(100),
    clave VARCHAR(150),
    restablecerUsuario BIT DEFAULT 1,
	activo BIT DEFAULT 1,
    fechaRegistro DATETIME DEFAULT GETDATE()
);
GO

--creando los insert para llenado de las tablas
--llenado de tabla Usuarios 
select * from Usuario
INSERT INTO Usuario (nombreUsuario, apellidoUsuario, correo, clave)
VALUES ('Emerson', 'Carbajal', 'cc21045@ues.edu.sv', 'e46ca4e5ffdc4884edeca322119757bd6d3c53529b87f1f7f4c32683effd3864'),
	   ('Andrea', 'Salazar', 'RS21037@ues.edu.sv', '78f7c8e192d902768d7eef82d8b33927d28e520283489d6d1f0fb06a917a60f3'),
	   ('Patricia', 'Flores', 'FB21010@ues.edu.sv', '4ed06a1a6755850ea9964af6be4c7235cc502bead9de45ed347e8d597f72b91b');
	   --2d1ba8
--/////////////////////////////////////////////////////////////////////////////////////////////////////
-- Insertar datos en la tabla detallesLaborales
INSERT INTO detallesLaborales (codDetalles, fechaIngreso, fechaRenuncia, tipoContrato)
VALUES
('CD001', '2022-01-01', '2022-12-31', 'Eventual'),
('CD002', '2021-06-15', '2023-03-31', 'Permanente'),
('CD003', '2022-03-10', '2022-09-30', 'Eventual'),
('CD004', '2023-02-01', '2023-08-31', 'Permanente'),
('CD005', '2022-07-15', '2023-01-31', 'Eventual'),
('CD006', '2022-04-20', '2022-10-31', 'Permanente'),
('CD007', '2023-01-10', '2023-07-31', 'Eventual'),
('CD008', '2022-08-05', '2023-02-28', 'Permanente'),
('CD009', '2022-11-15', '2023-05-31', 'Eventual'),
('CD010', '2022-09-01', '2023-03-31', 'Permanente'),
('CD011', '2022-06-10', '2022-12-31', 'Eventual'),
('CD012', '2023-03-01', '2023-09-30', 'Permanente'),
('CD013', '2022-02-15', '2022-08-31', 'Eventual'),
('CD014', '2022-12-10', '2023-06-30', 'Permanente'),
('CD015', '2022-08-20', '2023-02-28', 'Eventual'),
('CD016', '2022-07-01', '2023-01-31', 'Permanente'),
('CD017', '2023-04-15', '2023-10-31', 'Eventual'),
('CD018', '2022-11-10', '2023-05-31', 'Permanente'),
('CD019', '2023-01-01', '2023-07-31', 'Eventual'),
('CD020', '2022-09-15', '2023-03-31', 'Permanente');

-- Insertar datos en la tabla direccionEmpleado
INSERT INTO direccionEmpleado (codDireccion, sucursalEmpleado, paisEmpleado, estado, nombreCalle, coloniaEmpleado, codigoPostal)
VALUES
('CDIR001', 'Sucursal AMSS', 'El Salvador', 'San Salvador', 'Calle Principal 1', 'Colonia flor blanca', 1001),
('CDIR002', 'Sucursal AMSS2', 'El Salvador', 'San Salvador', 'Calle Principal 2', 'Colonia Balencia', 1002),
('CDIR003', 'Sucursal AMSS3', 'El Salvador', 'San Salvador', 'Calle Principal 3', 'Colonia san martin', 1003),
('CDIR004', 'Sucursal 7', 'El Salvador', 'Santa Ana', 'Calle Principal 4', 'Colonia ads', 1004),
('CDIR005', 'Sucursal 5', 'El Salvador', 'Santa Ana', 'Calle Principal 5', 'Colonia el matazano ', 1005),
('CDIR006', 'Sucursal 6', 'Mexico', 'Ciudad de M�xico', 'Calle Principal 6', 'Colonia CMX', 2001),
('CDIR007', 'Sucursal 7', 'Mexico', 'Ciudad de M�xico', 'Calle Principal 7', 'Colonia CMX', 2002),
('CDIR008', 'Sucursal Monterrey', 'Mexico', 'Monterrey', 'Calle Principal 8', 'Colonia Monterrey', 2003),
('CDIR009', 'Sucursal Monterrey2', 'Mexico', 'Monterrey', 'Calle Principal 9', 'Colonia Monterrey2', 2004),
('CDIR010', 'Sucursal Guadalajara', 'Mexico', 'Guadalajara', 'Calle Principal 10', 'Colonia Guadalajara', 2005),
('CDIR011', 'Sucursal Madrid', 'Espa�a', 'Madrid', 'Calle Principal 11', 'Colonia Madrid', 3001),
('CDIR012', 'Sucursal Bar', 'Espa�a', 'Barcelona', 'Calle Principal 12', 'Colonia Barcelona', 3002),
('CDIR013', 'Sucursal valencia', 'Espa�a', 'Valencia', 'Calle Principal 13', 'Colonia espa�a', 3003),
('CDIR014', 'Sucursal Sevilla', 'Espa�a', 'Sevilla', 'Calle Principal 14', 'Colonia cordova', 3004),
('CDIR015', 'Sucursal Malaga', 'Espa�a', 'M�laga', 'Calle Principal 15', 'Colonia malaga', 3005);

-- Insertar datos en la tabla empleadoWendy
INSERT INTO empleadoWendy (identificadorPersonal, nombreEmpleado, edadEmpleado, cargoEmpleado, telefonoEmpleado, sexoEmpleado, monto, idDireccion, idDetalleLaboral)
VALUES
('00365489-4', 'Juan P�rez', 30, 'Gerente', '+(503)7141-6640', 'Masculino', 2500.00, 1, 1),
('02545896-8', 'Mar�a L�pez', 28, 'Analista', '+(503)7121-0125', 'Femenino', 2000.00, 2, 2),
('00123565-0', 'Carlos G�mez', 35, 'Supervisor', '+(503)6545-0075', 'Masculino', 2200.00, 3, 3),
('12547889-6', 'Ana Rodr�guez', 32, 'Asistente', '+(503)7756-0125', 'Femenino', 1800.00, 4, 4),
('32547896-8', 'Pedro Mart�nez', 29, 'T�cnico', '+(503)7677-8899', 'Masculino', 1900.00, 5, 5),
('02321584-2', 'Laura Herrera', 27, 'Analista', '+(52)1254-8659', 'Femenino', 2100.00, 6, 6),
('00002565-0', 'Miguel Torres', 33, 'Supervisor', '+(52)1254-8659', 'Masculino', 2300.00, 7, 7),
('01259614-1', 'Sof�a Vargas', 30, 'Asistente', '+(52)5625-0000', 'Femenino', 1700.00, 8, 8),
('21584563-9', 'Javier Castro', 31, 'T�cnico', '+(52)5845-8659', 'Masculino', 2000.00, 9, 9),
('01010203-9', 'Luisa Ram�rez', 29, 'Analista', '+(52)1557-8009', 'Femenino', 2400.00, 10, 10),
('01236548-5', 'Roberto S�nchez', 34, 'Gerente', '+(2)1524-8659', 'Masculino', 2700.00, 11, 11),
('01236541-8', 'Isabel Montoya', 31, 'Analista', '+(2)2222-8650', 'Femenino', 1950.00, 12, 12),
('01364589-9', 'Mario Aguilar', 26, 'T�cnico', '+(2)2585-0102', 'Masculino', 1800.00, 13, 13),
('01325618-8', 'Daniela Navarro', 29, 'Supervisor', '+(2)2599-0001', 'Femenino', 2150.00, 14, 14),
('11110000-9', 'Ricardo Medina', 28, 'Asistente', '+(2)5585-4154', 'Masculino', 1750.00, 15, 15);


--////////////////////////////////////////////////////////////////////////////////////////////////////////
--selector de tablas

		SELECT * FROM Usuario;
		SELECT * FROM detallesLaborales;
		SELECT * FROM direccionEmpleado;
		SELECT * FROM empleadoWendy;
		
--////////////////////////////////////////////////////////////////////////////////////////////////////////
--procedimiento almacenado para guardar datos en tabla usuario
--REGISTRAR DATOS O GUARDAR EN LA BD--
create proc sp_registrarUsuario(
@nombreUsuario varchar (100), 
@apellidoUsuario varchar(100),
@correo varchar(100),
@clave varchar(150),
@activo bit,
@mensaje varchar(500) output,
@resultado int output
)
as
begin
	SET @resultado = 0
	if not exists (select * from Usuario where correo = @correo)
	begin
	insert into Usuario(nombreUsuario, apellidoUsuario, correo, clave, activo) values
	(@nombreUsuario, @apellidoUsuario,@correo,@clave,@activo)
	set @resultado = SCOPE_IDENTITY()--devuelve el �ltimo id
	end
	else
	set @mensaje = 'El correo que ha proporcionado ya esta en uso'
end

--//////////////////////////////////////////////////////////////////////////////////////////////////////////--
--procedimiento almacenado para editar usuarios------------
--EDITAR EN LA BD
create proc sp_editarUsuario(
@idUsuario int,
@nombreUsuario varchar (100), 
@apellidoUsuario varchar(100),
@correo varchar(100),
@activo bit,
@mensaje varchar(500) output,
@resultado bit output
)
as begin
	set @resultado = 0
	if not exists (select * from Usuario where correo = @correo and idUsuario != @idUsuario)
	begin
	update top(1) Usuario set
	nombreUsuario = @nombreUsuario,
	apellidoUsuario = @apellidoUsuario,
	correo = @correo,
	activo = @activo
	where idUsuario = @idUsuario
	set @resultado = 1
	end
	else
	set @mensaje = 'El correo que ha proporcionado ya esta en uso'
end

--//////////////////////////////////////////////////////////////////////////////////////////////////////--
--Procedimiento almacenado para tabla detalle empleado
--prodecimiento para insert o registrar datos
--Creamos el procedimiento con los datos a usar
CREATE PROCEDURE sp_RegistrarDetalles (
    @codDetalles VARCHAR(10),
    @fechaIngreso VARCHAR(50),
    @fechaRenuncia VARCHAR(50),
    @tipoContrato VARCHAR(100),
    @activoDetalle BIT,
    @Mensaje VARCHAR(500) OUTPUT,
    @Resultado INT OUTPUT
)
AS
BEGIN--seleccionamos la tabla y el atributo que no se tiene que repetir
    SET @Resultado = 0
    IF NOT EXISTS (SELECT * FROM detallesLaborales WHERE codDetalles = @codDetalles)
    BEGIN
        INSERT INTO detallesLaborales (codDetalles, fechaIngreso, fechaRenuncia, tipoContrato, activoDetalle)
        VALUES (@codDetalles, @fechaIngreso, @fechaRenuncia, @tipoContrato, @activoDetalle)

        SET @Resultado = SCOPE_IDENTITY() -- devuelve el �ltimo id
    END
    ELSE
        SET @Mensaje = 'El c�digo ya est� en uso'
END

--comprobando que el procedimiento funciona
DECLARE @Mensaje VARCHAR(500)
DECLARE @Resultado INT
EXEC sp_RegistrarDetalles
    @codDetalles = 'CD021',--la logica esta en el c�digo si este es igual a alg�n registro de la bd nos mostrara el mensaje
    @fechaIngreso = '2022-01-01',
    @fechaRenuncia = '2022-02-01',
    @tipoContrato = 'Permanente',
    @activoDetalle = 1,
    @mensaje = @mensaje OUTPUT,
    @resultado = @resultado OUTPUT
SELECT @Mensaje AS Mensaje, @Resultado AS Resultado

select*from detallesLaborales --el procedimiento funciona al 100 por ciento
----------------------------------------------------------

--procedimiento para actualizar los datos de la tabla detalles laborales del empleado
CREATE PROCEDURE sp_ActualizarDetalles (
    @idDetalleLaboral INT,
    @codDetalles VARCHAR(10),
    @fechaIngreso VARCHAR(50),
    @fechaRenuncia VARCHAR(50),
    @tipoContrato VARCHAR(100),
    @activoDetalle BIT,
    @Mensaje VARCHAR(500) OUTPUT,
    @Resultado BIT OUTPUT
)
AS
BEGIN
    SET @Resultado = 0
	--consultad direcctamente la tabla y los campos que no se deben repetir
    IF NOT EXISTS (SELECT * FROM detallesLaborales WHERE codDetalles = @codDetalles AND idDetalleLaboral != @idDetalleLaboral)
    BEGIN
        UPDATE TOP(1) detallesLaborales SET
            codDetalles = @codDetalles,
            fechaIngreso = @fechaIngreso,
            fechaRenuncia = @fechaRenuncia,
            tipoContrato = @tipoContrato,
            activoDetalle = @activoDetalle
        WHERE idDetalleLaboral = @idDetalleLaboral

        SET @Resultado = 1
    END
    ELSE
        SET @Mensaje = 'El c�digo ya est� en uso'
END

--verificando que el procedimiento almacenado para actualizar datos esta correcto

DECLARE @Mensaje VARCHAR(500)
DECLARE @Resultado BIT
EXEC sp_ActualizarDetalles
    @idDetalleLaboral = 3,
    @codDetalles = 'CD003',
    @fechaIngreso = '2022-03-01',
    @fechaRenuncia = '2022-04-01',
    @tipoContrato = 'Eventual',
    @activoDetalle = 0,
    @Mensaje = @Mensaje OUTPUT,
    @Resultado = @Resultado OUTPUT
SELECT @Mensaje AS Mensaje, @Resultado AS Resultado

select * from detallesLaborales--verificaci�n en la tabla 

--procedimiento almacenado para eliminar el detalle
CREATE PROCEDURE sp_EliminarDetalle (
    @idDetalleLaboral INT, 
    @Mensaje VARCHAR(500) OUTPUT,
    @Resultado BIT OUTPUT
)
AS 
BEGIN
    SET @Resultado = 0
    IF NOT EXISTS (SELECT * FROM empleadoWendy e 
        INNER JOIN detallesLaborales d ON d.idDetalleLaboral = e.idDetalleLaboral
        WHERE e.idDetalleLaboral = @idDetalleLaboral)
    BEGIN
        DELETE TOP (1) FROM detallesLaborales WHERE idDetalleLaboral = @idDetalleLaboral
        SET @Resultado = 1
    END
    ELSE
        SET @Mensaje = 'El detalle laboral se relaciona con empleado wendy, no se puede eliminar'
END


--verificando que el codigo realmente funciona
DECLARE @Mensaje VARCHAR(500)
DECLARE @Resultado BIT
-- Ejemplo 1: Eliminaci�n exitosa
EXEC sp_EliminarDetalle
    @idDetalleLaboral = 1,
    @Mensaje = @Mensaje OUTPUT,
    @Resultado = @Resultado OUTPUT
SELECT @Mensaje AS Mensaje, @Resultado AS Resultado;

select * from detallesLaborales



--////////////////////////////////////////////////////////////////////////////////////////////////////--
--procedimientos almacenado para tabla de direccion
--procedimiento para almacenar

CREATE PROCEDURE sp_RegistrarDireccion (
    @codDireccion VARCHAR(10),
    @sucursalEmpleado VARCHAR(100),
    @paisEmpleado VARCHAR(100),
    @estado VARCHAR(100),
	@nombreCalle VARCHAR(100),
	@coloniaEmpleado VARCHAR(100),
	@codigoPostal int,
    @activoDireccion BIT,
    @Mensaje VARCHAR(500) OUTPUT,
    @Resultado INT OUTPUT
)
AS
BEGIN
    SET @Resultado = 0
	--selecciona la tabla de direccion y valida el campo unico
    IF NOT EXISTS (SELECT * FROM direccionEmpleado WHERE codDireccion = @codDireccion)
    BEGIN--inserta los datos necesarios por medio de la siguiente consulta
        INSERT INTO direccionEmpleado (codDireccion, sucursalEmpleado, paisEmpleado, estado, nombreCalle,
		coloniaEmpleado,codigoPostal, activoDireccion)
        VALUES (@codDireccion, @sucursalEmpleado, @paisEmpleado, @estado, @nombreCalle, @coloniaEmpleado,
		@codigoPostal, @activoDireccion)

        SET @Resultado = SCOPE_IDENTITY() -- devuelve el �ltimo id
    END
    ELSE
        SET @Mensaje = 'El c�digo ya est� en uso'
END
--------------------------COMPROBANDO QUE EL PROCEDIMIENTO GUARDAR PARA DIRECCION ES CORRECTO---------------------------
DECLARE @Mensaje VARCHAR(500)
DECLARE @Resultado INT
EXEC sp_RegistrarDireccion 
    @codDireccion = 'CDIR016',
    @sucursalEmpleado = 'Sucursal A',
    @paisEmpleado = 'Espa�a',
    @estado = 'Estado A',
    @nombreCalle = 'Calle Principal',
    @coloniaEmpleado = 'Colonia X',
    @codigoPostal = 12345,
    @activoDireccion = 1,
    @Mensaje = @Mensaje OUTPUT,
    @Resultado = @Resultado OUTPUT
SELECT @Mensaje AS Mensaje, @Resultado AS Resultado

SELECT * FROM direccionEmpleado;

--////////////////////////////////////////////////////////////////////////////////////////////////////--
--procedimiento para editar o actualizar la direcci�n
CREATE PROCEDURE sp_ActualizarDireccion (
    @idDireccion INT,--campos oa tributos necesarios para el funcionamiento del editar
    @codDireccion VARCHAR(10),
    @sucursalEmpleado VARCHAR(100),
    @paisEmpleado VARCHAR(100),
    @estado VARCHAR(100),
	@nombreCalle VARCHAR(100),
	@coloniaEmpleado VARCHAR(100),
	@codigoPostal int,
    @activoDireccion BIT,
    @Mensaje VARCHAR(500) OUTPUT,
    @Resultado BIT OUTPUT
)
AS
BEGIN
    SET @Resultado = 0
	--seleccion a la tabla y campo �nico
    IF NOT EXISTS (SELECT * FROM direccionEmpleado WHERE codDireccion = @codDireccion AND idDireccion != @idDireccion)
    BEGIN
        UPDATE TOP(1) direccionEmpleado SET
            codDireccion = @codDireccion,
            sucursalEmpleado = @sucursalEmpleado,
            paisEmpleado = @paisEmpleado,
            estado = @estado,
            nombreCalle = @nombreCalle,
			coloniaEmpleado = @coloniaEmpleado,
			codigoPostal = @codigoPostal,
			activoDireccion = @activoDireccion
        WHERE idDireccion = @idDireccion

        SET @Resultado = 1
    END
    ELSE
        SET @Mensaje = 'El c�digo ya est� en uso'
END

--------------COMPROBANDO QUE EL PROCEDIMIENTO ACTUALIZAR PARA DIRECCION ES CORRECTO-----------------------
DECLARE @idDireccion INT, @codDireccion VARCHAR(10), @sucursalEmpleado VARCHAR(100), @paisEmpleado VARCHAR(100), @estado VARCHAR(100), @nombreCalle VARCHAR(100), @coloniaEmpleado VARCHAR(100), @codigoPostal INT, @activoDireccion BIT, @Mensaje VARCHAR(500), @Resultado BIT
SET @idDireccion = 1
SET @codDireccion = 'CDIR001'
SET @sucursalEmpleado = 'Sucursal A'
SET @paisEmpleado = 'El Salvador'
SET @estado = 'San Miguel'
SET @nombreCalle = 'Calle Principal 123'
SET @coloniaEmpleado = 'Colonia Centro'
SET @codigoPostal = 10000
SET @activoDireccion = 1
EXEC sp_ActualizarDireccion @idDireccion, @codDireccion, @sucursalEmpleado, @paisEmpleado, @estado, @nombreCalle, @coloniaEmpleado, @codigoPostal, @activoDireccion, @Mensaje OUTPUT, @Resultado OUTPUT
SELECT @Mensaje AS Mensaje, @Resultado AS Resultado

select * from direccionEmpleado;

--////////////////////////////////////////////////////////////////////////////////////////////////////--
--procedimiento para Eliminar
CREATE PROCEDURE sp_EliminarDireccion (
    @idDireccion INT, 
    @Mensaje VARCHAR(500) OUTPUT,
    @Resultado BIT OUTPUT
)
AS 
BEGIN
    SET @Resultado = 0
    IF NOT EXISTS (SELECT * FROM empleadoWendy e 
        INNER JOIN direccionEmpleado d ON d.idDireccion = e.idDireccion
        WHERE e.idDireccion = @idDireccion)
    BEGIN
        DELETE TOP (1) FROM direccionEmpleado WHERE idDireccion = @idDireccion
        SET @Resultado = 1
    END
    ELSE
        SET @Mensaje = 'La direcci�n se relaciona con empleado wendy, no se puede eliminar'
END

--------------COMPROBANDO QUE EL PROCEDIMIENTO ELIMINAR PARA DIRECCION ES CORRECTO-----------------------
DECLARE @Mensaje VARCHAR(500)
DECLARE @Resultado BIT
-- Ejemplo 1: Eliminaci�n exitosa
EXEC sp_EliminarDireccion
   @idDireccion = 1,
    @Mensaje = @Mensaje OUTPUT,
    @Resultado = @Resultado OUTPUT
SELECT @Mensaje AS Mensaje, @Resultado AS Resultado;

SELECT * FROM direccionEmpleado;

