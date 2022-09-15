CREATE DATABASE Laboratorio

USE Laboratorio

CREATE SCHEMA Persona
CREATE SCHEMA Aula

CREATE TABLE Persona.Empleado
(
	RPE_Empleado BIGINT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(40) NOT NULL,
	Domicilio VARCHAR(100) NOT NULL,
	Correo VARCHAR(50) NOT NULL,
	Celular VARCHAR NOT NULL,
	EmpleadoDesde DATE NOT NULL,
	Antiguedad VARCHAR(20) NOT NULL,
	TipoEmpleado VARCHAR(20) NOT NULL,

	CONSTRAINT PK_EMPLEADO PRIMARY KEY (RPE_Empleado)
)

CREATE TABLE Persona.Colaborador
(
	RPE_Colaborador BIGINT NOT NULL,
	Fecha_nac DATE NOT NULL,
	Hrs_sem BIGINT NOT NULL,
	Generacion VARCHAR(10) NOT NULL,

	CONSTRAINT FK_COLABRADOR FOREIGN KEY (RPE_Colaborador)
			REFERENCES Persona.Empleado(RPE_Empleado)
)

CREATE TABLE Persona.Becario
(
	RPE_Becario BIGINT NOT NULL,
	Fecha_nac DATE NOT NULL,
	Hrs_sem BIGINT NOT NULL,
	Generacion VARCHAR(10) NOT NULL,

	CONsTRAINT FK_BECARIO FOREIGN KEY (RPE_Becario)
			REFERENCES Persona.Empleado(RPE_Empleado)
)

CREATE TABLE Persona.Responsable
(
	RPE_Responsable BIGINT NOT NULL,
	Fecha_nac DATE NOT NULL,
	Hrs_sem BIGINT NOT NULL,
	Generacion VARCHAR(10) NOT NULL,

	CONSTRAINT FK_RESPONSABLE FOREIGN KEY (RPE_Responsable)
			REFERENCES Persona.Empleado(RPE_Empleado)
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

