BULK INSERT dbo.alumnos
FROM 'd:\\proyectos\\sql\\alumnos.csv'
WITH (
    FIRSTROW = 2,                 -- salta la cabecera
    FIELDTERMINATOR = ';',        -- separador de columnas
    ROWTERMINATOR = '0x0a',       -- fin de línea (LF). En Windows a veces '0x0d0a'
    CODEPAGE = '65001',           -- UTF-8 (útil si hay tildes/ñ)
    TABLOCK,
    KEEPNULLS
);