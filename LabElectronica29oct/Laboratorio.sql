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
@nivel > 0 AND @range <= 10
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
