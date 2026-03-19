/* Creacion de GIMNASIO */
create database bdgimnasio;
GO

use bdgimnasio;
GO

/* Primero las borramos */
drop table socios_actividades;
drop table socios;
drop table actividades;
drop table paises;
GO

/* Creamos las tablas */
create table paises(idpais  integer NOT NULL, 
                    nom_pais nvarchar(50) NOT NULL,
                    primary key(idpais));

create table actividades(idactividad integer NOT NULL, 
                         nom_actividad varchar(20) NOT NULL,
                         horas_semanales integer,
                         primary key(idactividad));


create table socios(idsocio integer NOT NULL,
                    nombre varchar(20) NOT NULL,
                    apellido varchar(20) NOT NULL,
                    telefono varchar(11) NOT NULL,
                    email varchar(20) NOT NULL,
                    idpais integer NULL,
                    primary key(idsocio));

create table socios_actividades(idsocio integer NOT NULL,
                                idactividad integer NOT NULL,
                                primary key(idsocio, idactividad));

GO

/* CREAMOS LA FOREIGN KEY DE SOCIOS A PAISES
 Se indica desde la hija hacia la madre    */
alter table socios add constraint FK_PAISES 
foreign key (idpais) 
references paises(idpais);

/* CREAMOS LA FOREIGN KEY DE SOCIOS_ACTIVIDADES A ACTIVIDADES
# Se indica desde la hija hacia la madre  */
alter table socios_actividades add constraint FK_ACTIVIDAD 
foreign key (idactividad)
references actividades (idactividad);

/* CREAMOS LA FOREIGN KEY DE SOCIOS_ACTIVIDADES A SOCIOS
# Se indica desde la hija hacia la madre  */

alter table socios_actividades add constraint FK_SOCIO 
foreign key (idsocio)
references socios (idsocio);

/* ENSEÑAMOS LAS TABLAS QUE TENEMOS*/
select name as "mis tablas" from sys.tables;
go