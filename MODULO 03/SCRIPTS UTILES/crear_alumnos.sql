CREATE TABLE [dbo].[Alumnos]
(   [idalumno] [int] NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellido] [varchar](20) NOT NULL,
	[email] [varchar](30) NOT NULL,
	[telefono] [varchar](10) NOT NULL,
    CONSTRAINT [PK_Alumnos] PRIMARY KEY ([idalumno])
 );
 
 select * from alumnos;
 
