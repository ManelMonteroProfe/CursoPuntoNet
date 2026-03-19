/* CONSULTAS (SELECTS) VARIOS PARA BDGIMNASIO*/


/* CUANTOS SOCIOS HAY*/
Select count(*) from socios;
GO

/* Cuantos socios hay que se llamen Pedro y hagan spinning*/
select count(*)
from socios join socios_actividades
on socios.idsocio = socios_actividades.idsocio
join actividades
on socios_actividades.idactividad = actividades.idactividad
where nombre='Pedro' and nom_actividad='Spinning';

GO


/* Dame NOMBRE, APELLIDO y NOM_PAIS de los socios*/
select nombre, apellido, nom_pais
from socios join paises
on socios.idpais = paises.idpais;
GO


/* Ver la tabla de actividades */

select * from actividades;
GO


/* Ver la tabla de paises */

select * from paises;
GO













