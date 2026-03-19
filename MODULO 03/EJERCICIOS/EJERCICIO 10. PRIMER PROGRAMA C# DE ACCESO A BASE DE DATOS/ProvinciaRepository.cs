using System;
using System.Collections.Generic;
using System.Data.SqlClient;  // Instala el paquete NuGet: Microsoft.Data.SqlClient
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BasesdeDatos01.Program;

namespace BasesdeDatos01
{
    // ============================================================
    // CLASE "MODELO" (o ENTIDAD)
    // Representa un registro de la tabla dbo.Provincias.
    // ============================================================
    public class Provincia
    {
        // Se corresponde con la columna idprovincia (INT) de la tabla.
        public int IdProvincia { get; set; }
        // Se corresponde con la columna provincia (VARCHAR) de la tabla.
        // Inicializamos con "" para evitar null
        public string ProvinciaNombre { get; set; } = "";
    }

    // ============================================================
    // CLASE REPOSITORIO (Acceso a Datos)
    // Encapsula (centraliza) todo el código que habla con SQL Server.
    // Ventajas:
    //   - El resto del programa no necesita saber SQL.
    //   - Reutilización de código.
    //   - Más fácil de mantener.
    // ============================================================
    public class ProvinciaRepository
    {
        // Guardamos la cadena de conexión para poder abrir conexiones a la BD.
        // readonly => se asigna en el constructor y no cambia.
        private readonly string _connectionString;

        // Constructor: recibe la cadena de conexión desde fuera (Program, Form, etc.)
        public ProvinciaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ============================================================
        // SELECT: Obtener todas las provincias
        // Devuelve una lista de objetos Provincia.
        // ============================================================
        public List<Provincia> GetAll()
        {
            // Creamos una lista para almacenar los registros que vengan de la BD.
            var lista = new List<Provincia>();

            // using(...) => garantiza que la conexión y el comando se cierran y liberan recursos
            // automáticamente (aunque haya error).
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Texto SQL: seleccionamos columnas concretas (mejor que SELECT *).
                // ORDER BY provincia => devuelve ordenado alfabéticamente.
                cmd.CommandText = @"
                    SELECT idprovincia, provincia
                    FROM dbo.Provincias
                    ORDER BY provincia;";

                // Ahora nos conectamos a la Base de Datos
                conn.Open();

                // ExecuteReader() se usa en SELECT (cuando esperamos filas como resultado).
                using (var reader = cmd.ExecuteReader())
                {
                    // Leemos fila a fila.
                    while (reader.Read())
                    {
                        // Convertimos la fila actual en un objeto Provincia.
                        // reader.GetInt32(0) => columna 0 (idprovincia)
                        // reader.GetString(1) => columna 1 (provincia)
                        lista.Add(new Provincia
                        {
                            IdProvincia = reader.GetInt32(0),
                            ProvinciaNombre = reader.GetString(1)
                        });
                    }
                }
            }

            // Devolvemos la lista ya cargada.
            return lista;
        }

        // ============================================================
        // SELECT con filtro: Obtener una provincia por su Id
        // Devuelve una Provincia o null si no existe.
        // ============================================================
        public Provincia GetById(int idProvincia)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Usamos parámetro (@id) para:
                //  - Evitar inyección SQL
                //  - Evitar errores con comillas
                //  - Dejar que SQL Server trate el tipo de dato correctamente
                cmd.CommandText = @"
                    SELECT idprovincia, provincia
                    FROM dbo.Provincias
                    WHERE idprovincia = @id;";

                // Asignamos el valor al parámetro.
                cmd.Parameters.AddWithValue("@id", idProvincia);

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    // Si no hay filas, devolvemos null.
                    if (!reader.Read()) return null;

                    // Si hay una fila, la convertimos a objeto Provincia.
                    return new Provincia
                    {
                        IdProvincia = reader.GetInt32(0),
                        ProvinciaNombre = reader.GetString(1)
                    };
                }
            }
        }

        // ============================================================
        // INSERT: Insertar una nueva provincia
        // ============================================================
        public void Insert(int idProvincia, string provinciaNombre)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // INSERT con parámetros.
                // Nota didáctica: aquí estás insertando el id a mano.
                // Si idprovincia fuera IDENTITY, NO se insertaría el id.
                cmd.CommandText = @"
                    INSERT INTO dbo.Provincias (idprovincia, provincia)
                    VALUES (@id, @provincia);";

                // Parámetros con sus valores.
                cmd.Parameters.AddWithValue("@id", idProvincia);
                cmd.Parameters.AddWithValue("@provincia", provinciaNombre);

                conn.Open();

                // ExecuteNonQuery() se usa cuando NO esperamos filas de resultado:
                // INSERT, UPDATE, DELETE.
                cmd.ExecuteNonQuery();
            }
        }

        // ============================================================
        // UPDATE: Modificar una provincia existente
        // ============================================================
        public void Update(int idProvincia, string provinciaNombre)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Actualizamos el nombre de provincia de la fila cuyo id coincide.
                cmd.CommandText = @"
                    UPDATE dbo.Provincias
                    SET provincia = @provincia
                    WHERE idprovincia = @id;";

                cmd.Parameters.AddWithValue("@id", idProvincia);
                cmd.Parameters.AddWithValue("@provincia", provinciaNombre);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ============================================================
        // DELETE: Borrar una provincia por Id
        // ============================================================
        public void Delete(int idProvincia)
        {
            // using => asegura cierre de conexión/comando incluso si hay excepción.
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Sentencia DELETE con parámetro (@id).
                cmd.CommandText = @"
                    DELETE FROM dbo.Provincias
                    WHERE idprovincia = @id;";

                // Valor del parámetro.
                cmd.Parameters.AddWithValue("@id", idProvincia);

                conn.Open();

                // Filas afectadas: 0 si no existía, 1 si borró, >1 si hubiera IDs repetidos (no debería).
                int filasBorradas = cmd.ExecuteNonQuery();

                // Para clase: se puede usar filasBorradas para informar al usuario.
                // Ejemplo:
                // if (filasBorradas == 0) Console.WriteLine("No existe esa provincia.");
                // else Console.WriteLine("Provincia borrada correctamente.");
            }
        }
    }
}
