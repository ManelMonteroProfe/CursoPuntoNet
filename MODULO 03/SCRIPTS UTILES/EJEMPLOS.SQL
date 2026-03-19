bases de datos

- entorno gráfico
SQL MANAGEMENT STUDIO

ESTRUCTURAS DE DATOS
LENGUAJE : DDL
CREATE	Crea
ALTER	Modifica
DROP	Destruye


LENGUAJE DML
SELECT		Mostrar 
INSERT		Insertar nuevos
UPDATE		Modificar
DELETE		Borrar

/* Para abrir una Base de Datos */
USE [bdprueba01]
GO

/* EJEMPLO INSERT */

insert into dbo.Alumnos99
( idalumno, nombre, apellido, email,telefono)
values
(4, 'Maria', 'Lopez', 'ad@google.com','555777888');
GO


/* EJEMPLO UPDATE  */

update Alumnos99
set nombre='Mario'
where idalumno=2;

GO



/* ejemplo borrado - delete */

delete 
from alumnos99
where idalumno=2;

go



/* EJEMPLO DE SELECT*/
select  nombre, email
from Alumnos99
where (idalumno >0)
and ciudad='cadiz';

go
