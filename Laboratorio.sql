CREATE DATABASE Laboratorio
USE Laboratorio

CREATE SCHEMA Persona
CREATE SCHEMA Aula

CREATE TABLE Persona.Empleado
(
	RPE_Empleado BIGINT NOT NULL,
	Nombre VARCHAR(100) NOT NULL,
	Domicilio VARCHAR(200) NOT NULL,
	Correo VARCHAR(200) NOT NULL,
	Celular VARCHAR(10) NOT NULL,
	EmpleadoDesde DATE NOT NULL,
	Antiguedad VARCHAR(20) NOT NULL,
	TipoEmpleado VARCHAR(40) NOT NULL,

	CONSTRAINT PK_EMPLEADO PRIMARY KEY (RPE_Empleado)
)

CREATE TABLE Persona.Colaborador
(
	RPE_Colaborador BIGINT NOT NULL,
	Desc_act TEXT NOT NULL,
	Hrs_sem BIGINT NOT NULL,

	CONSTRAINT FK_COLABRADOR FOREIGN KEY (RPE_Colaborador)
			REFERENCES Persona.Empleado(RPE_Empleado)
			ON DELETE CASCADE			
)

CREATE TABLE Persona.Becario
(
	RPE_Becario BIGINT NOT NULL,
	Fecha_nac DATE NOT NULL,
	Hrs_sem BIGINT NOT NULL,
	Generacion VARCHAR(10) NOT NULL,

	CONSTRAINT FK_BECARIO FOREIGN KEY (RPE_Becario)
			REFERENCES Persona.Empleado(RPE_Empleado)
			ON DELETE CASCADE
)

CREATE TABLE Persona.Responsable
(
	RPE_Responsable BIGINT NOT NULL,
	Antiguedad DATE NOT NULL,
	Grado VARCHAR(20) NOT NULL,
	Fecha_Inicio DATE NOT NULL,
	Fecha_Fin DATE NOT NULL,

	CONSTRAINT FK_RESPONSABLE FOREIGN KEY (RPE_Responsable)
			REFERENCES Persona.Empleado(RPE_Empleado)
			ON DELETE CASCADE
)

CREATE TABLE Persona.Alumno
(
	Clave_Unica BIGINT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(40) NOT NULL,
	Generacion BIGINT NOT NULL,
	Carrera VARCHAR(20) NOT NULL,
	Adeudo BIGINT NOT NULL,

	CONSTRAINT PK_CLAVE PRIMARY KEY (Clave_Unica)
)

CREATE TABLE Aula.Equipo
(
	NumInv BIGINT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(40) NOT NULL,
	Modelo VARCHAR(20) NOT NULL,
	Descripcion VARCHAR(100) NOT NULL,
	UbicacionEnLab VARCHAR(30) NOT NULL,
	Marca VARCHAR(20) NOT NULL,
	TipoEquipo VARCHAR(10) NOT NULL,

	CONSTRAINT PK_NUMINV PRIMARY KEY (NumInv)

)

CREATE TABLE Aula.Sancion
(
	Clave_Unica BIGINT NOT NULL,
	RPE_Empleado BIGINT NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
	F_liquidacion DATE NOT NULL,
	Fecha DATE NOT NULL,
	Monto BIGINT NOT NULL,

	CONSTRAINT FK_EMPLEADO FOREIGN KEY (RPE_Empleado)
			REFERENCES Persona.Empleado(RPE_Empleado),
	CONSTRAINT FK_CLAVE FOREIGN KEY (Clave_Unica)
			REFERENCES Persona.Alumno(Clave_Unica)
)

CREATE TABLE Aula.Prestamo
(
	Id_Prestamo BIGINT IDENTITY(1,1) NOT NULL,
	NumInv BIGINT NOT NULL,
	Clave_Unica BIGINT NOT NULL,
	RPE_Empleado BIGINT NOT NULL,
	FechaEntrega DATE NOT NULL,
	FechaPrestamo DATE NOT NULL,

	CONSTRAINT PK_IDPRESTAMO PRIMARY KEY (Id_Prestamo),

	CONSTRAINT FK_NUMINV FOREIGN KEY(NumInv)
		REFERENCES Aula.Equipo(NumInv),
	CONSTRAINT FK_CL FOREIGN KEY(Clave_Unica)
		REFERENCES Persona.Alumno(Clave_Unica),
	CONSTRAINT FK_EMPLE FOREIGN KEY(RPE_Empleado)
		REFERENCES Persona.Empleado(RPE_Empleado)
)

CREATE TABLE Aula.Asistencia
(
    Clave_Unica BIGINT NOT NULL,
	RPE_Empleado BIGINT NOT NULL,
	Clave_Materia BIGINT NOT NULL,
	Fecha DATE NOT NULL,
	Hr_entrada DATE NOT NULL,
	Hr_salida DATE NOT NULL,

	

	
	CONSTRAINT FK_CLA FOREIGN KEY(Clave_Unica)
		REFERENCES Persona.Alumno(Clave_Unica),
	CONSTRAINT FK_EMPLEA FOREIGN KEY(RPE_Empleado)
		REFERENCES Persona.Empleado(RPE_Empleado),
	CONSTRAINT FK_MATERIA FOREIGN KEY(Clave_Materia)
		REFERENCES Aula.Materia(ClaveMateria)
)

ALTER TABLE Aula.Asistencia
DROP COLUMN Hr_salida 

ALTER TABLE Aula.Asistencia
ADD Hr_entrada TIME,Hr_salida TIME


CREATE TABLE Aula.BitacoraEntrega
(
	Id_Prestamo BIGINT NOT NULL,
	RPE_Empleado BIGINT NOT NULL,
	Fecha_Entrega DATE NOT NULL,

	CONSTRAINT FK_IDPRESTAMO FOREIGN KEY (Id_Prestamo)
		REFERENCES Aula.Prestamo (Id_Prestamo)
)
CREATE TABLE Aula.Materia
(
	ClaveMateria BIGINT IDENTITY(1,1),
	Nombre VARCHAR(100) NOT NULL,
	Nivel BIGINT NOT NULL,
)

--Reglas

CREATE RULE tipo_equipos
AS 
@tipo IN ('Osciloscopio', 'Multimetro', 'Fuente de voltaje', 'Pinzas de corte')
EXEC sp_bindrule 'tipo_equipos' , 'Aula.Equipo.TipoEquipo'

CREATE RULE nivel_range
AS
@nivel > 0 AND @nivel <= 10
EXEC sp_bindrule 'nivel_range' , 'Aula.Materia.Nivel'
	
--Disparadores
CREATE TRIGGER tr_hr_prestamo
ON Aula.Prestamo

FOR INSERT, DELETE, UPDATE AS
		DECLARE @FechaPrestamo as DATE

BEGIN
	IF EXISTS (SELECT * FROM inserted)
	BEGIN 
		SELECT @FechaPrestamo = FechaPrestamo FROM inserted

		UPDATE Aula.Prestamo SET @FechaPrestamo
	END
END

--Cambios en la tabla sancion
alter table Aula.Sancion add id bigint identity(1,1) not null
ALTER TABLE Aula.Sancion ADD PRIMARY KEY (id)

--Disparadores
--Trigger 01
--Cuando se entrega un equipo, revisar que la fecha de entrega no est?? vencida, 
--en caso contrario se sanciona al alumno
--no funciona
CREATE TRIGGER TR_ENTREGA_EQUIPO
ON Aula.BitacoraEntrega 
AFTER INSERT,UPDATE AS
DECLARE @idPrestamo AS BIGINT
DECLARE @FechaEntregado AS DATE
DECLARE @FechaE AS DATE
DECLARE @IdAlumno AS BIGINT
DECLARE @FechaLiq AS DATE
DECLARE @FechaHoy AS DATE
DECLARE @AUX AS DATE
DECLARE @RPE AS BIGINT

IF EXISTS (SELECT * FROM INSERTED)
BEGIN
	SELECT @idPrestamo = Id_Prestamo FROM inserted	
	SELECT @FechaE = FechaEntrega FROM Aula.Prestamo WHERE Id_Prestamo = @idPrestamo
	SELECT @FechaEntregado = Fecha_Entrega FROM inserted
	SELECT @IdAlumno = Clave_Unica FROM Aula.Prestamo WHERE Id_Prestamo = @idPrestamo
	SELECT @RPE = RPE_Empleado FROM inserted
	SELECT @FechaHoy = GETDATE()
	select @FechaLiq = DATEADD(DAY,10,@FechaHoy)
	--SELECT @FechaLiq = @FechaHoy+10 --agrega 10 dias a la fecha actual
	IF(@FechaEntregado > @FechaE)
	BEGIN
		INSERT INTO Aula.Sancion (Clave_Unica,RPE_Empleado,Descripcion,F_liquidacion,Fecha,Monto) 
		VALUES(@IdAlumno,@RPE,'Plazo de entrega vencido',@FechaLiq,@FechaHoy,100);
	END
		
END
--Trigger 05
--Despues de insertar en sancion el campo adeudo de la tabla alumno se actualiza
CREATE TRIGGER TR_ACTUALIZAR_ADEUDO
ON Aula.Sancion
AFTER INSERT,UPDATE AS
DECLARE @Cantidad AS BIGINT
DECLARE @IdAlumno AS BIGINT
IF EXISTS (SELECT * FROM INSERTED)
BEGIN
	SELECT @Cantidad = Monto FROM inserted
	SELECT @IdAlumno = Clave_Unica FROM inserted
	UPDATE Persona.Alumno SET Adeudo = @Cantidad WHERE Clave_Unica = @IdAlumno
END

--Trigger 06
--Antes de insertar en prestamo, se debe revisar si el alumno no tiene
--adeudos, cancelar insercion si hay adeudos.
CREATE TRIGGER TR_CANCELAR_INSERCION
ON Aula.Prestamo
AFTER INSERT AS
DECLARE @Adeudos AS BIGINT
DECLARE @IdAlumno AS BIGINT
DECLARE @IdPrestamo AS BIGINT
IF EXISTS (SELECT * FROM INSERTED)
BEGIN
	SELECT @IdAlumno = Clave_unica FROM inserted
	SELECT @IdPrestamo =Id_Prestamo FROM inserted
	SELECT @Adeudos = Adeudo FROM Persona.Alumno WHERE Clave_Unica = @IdAlumno
	IF(@Adeudos > 0)
	BEGIN
		DELETE FROM Aula.Prestamo WHERE Id_Prestamo = @IdPrestamo
		RAISERROR(
			N'Error:El alumno con clave ??nica %d tiene adeudos sin saldar.',1,10,@IdAlumno
		)		
	END
END



CREATE TRIGGER tr_hr_Asistencia
ON Aula.Asistencia
FOR INSERT, DELETE,UPDATE AS
		DECLARE @FechaAsistencia as DATE
		DECLARE @FechaAsistenciaCorta as DATE
		DECLARE @Aux as TIME
	IF EXISTS (SELECT * FROM inserted)
	BEGIN 
		Select
		@FechaAsistencia =  GETDATE()
		select @FechaAsistenciaCorta = CONVERT(varchar,@FechaAsistencia,1) 
		select @Aux =CONVERT(nvarchar(10), GETDATE(), 108)
		
		UPDATE Aula.Asistencia SET Hr_entrada=@Aux
		UPDATE Aula.Asistencia SET  Fecha= @FechaAsistenciaCorta
		
	END

	SELECT NOMBRE FROM Aula.Materia WHERE Nombre ='Calculo A'
	SELECT Nombre FROM Aula.Materia WHERE Nombre='" "';

	ALTER TABLE Aula.Asistencia
	ADD Hr_entrada TIME

	DROP TRIGGER IF EXISTS tr_hr_Asistencia
	ON ALL SERVER

	ALTER TABLE Aula.Asistencia
	ADD Id_Asistencia BIGINT IDENTITY(1,1) NOT NULL

	SELECT * FROM Aula.Sancion
	SELECT * FROM Aula.Asistencia