/* Creacion BBDD  */
create table Provincias
	(
	   idprovincia int NOT NULL,
	   provincia varchar(30) NOT NULL,
	   CONSTRAINT pk_prov PRIMARY KEY (idprovincia)
	);
	
create table Alumnos
	(
	   idalumno int NOT NULL,
	   nombre varchar(30) NOT NULL,
	   apellido varchar(30) NOT NULL,
	   email varchar(30),
	   telefono varchar(10),
	   idprovincia int, 
	   CONSTRAINT pk_alumno PRIMARY KEY (idalumno)
	);

/* CREAMOS LA FOREIGN KEY DE ALUMNOS A PROVINCIAS */
alter table ALUMNOS add constraint FK_provincias 
foreign key (idprovincia) 
references provincias(idprovincia);



