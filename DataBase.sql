--Crea la base de datos
Create database Evaluacion2_SWcons;
go

--Usar la base de datos
Use Evaluacion2_SWcons;
go

--Crea tabla alumnos
go
Create table Alumnos(
	IDAlumno int identity primary key,
	Nombre nvarchar(50),
	ApellidoPat nvarchar(50),
	ApellidoMat nvarchar(50),
	Email nvarchar(50),
	NumMatricula nvarchar(50)
);

--Crea tabla asignaturas
Create table Asignaturas(
	CodigoAsignatura int identity primary key,
	NombreAsignatura nvarchar(50),
	Creditos int
);
