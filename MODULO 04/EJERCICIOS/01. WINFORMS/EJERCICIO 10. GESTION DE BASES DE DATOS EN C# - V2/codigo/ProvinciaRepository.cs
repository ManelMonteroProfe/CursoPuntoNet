using System.Data;
using System.Data.SqlClient;
using WinFormBaseDatosv1.Models;

namespace WinFormBaseDatosv1.Data
{
    /// DATA / REPOSITORY:
    /// Aquí está TODO lo que habla con SQL Server (ADO.NET):
    /// - SELECT (leer)
    /// - INSERT (crear)
    /// - UPDATE (actualizar)
    /// - DELETE (borrar)
    public class ProvinciaRepository
    {
        private readonly string _connectionString;

        public ProvinciaRepository(string connectionString)
        {
            // Guardamos la cadena de conexión para reutilizarla.
            _connectionString = connectionString;
        }

        /// Devuelve todas las provincias como DataTable (ideal para DataGridView).
        public DataTable GetAllAsDataTable()
        {
            // DataTable es una “tabla en memoria”.
            DataTable tabla = new DataTable();

            // SqlConnection representa la conexión a SQL Server.
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                // Consulta: traemos id y nombre.
                string sql = "SELECT idprovincia, provincia FROM dbo.Provincias ORDER BY provincia;";

                // SqlDataAdapter: ejecuta el SELECT y rellena el DataTable.
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    da.Fill(tabla);
                }
            }

            return tabla;
        }

        /// Inserta una provincia y devuelve el ID nuevo.
        public int Insert(Provincia provincia)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                // INSERTA UN NUEVO REGISTRO
                string sql = @"INSERT INTO dbo.Provincias 
                               (idprovincia, provincia) 
                               VALUES (@id, @prov);";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    // Parámetros: seguridad + evita errores con comillas.
                    cmd.Parameters.AddWithValue("@id", provincia.IdProvincia);
                    cmd.Parameters.AddWithValue("@prov", provincia.Nombre);

                    cn.Open();

                    // ExecuteScalar: devuelve un solo valor (el nuevo id).
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        /// Actualiza una provincia por ID. Devuelve true si actualiza 1 fila.
        public bool Update(Provincia provincia)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE dbo.Provincias
                                SET provincia = @provincia
                                WHERE idprovincia = @id;";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@provincia", provincia.Nombre);
                    cmd.Parameters.AddWithValue("@id", provincia.IdProvincia);

                    cn.Open();

                    // ExecuteNonQuery: devuelve cuántas filas cambió.
                    int filas = cmd.ExecuteNonQuery();
                    return filas == 1;
                }
            }
        }

        /// Borra una provincia por ID. Devuelve true si borra 1 fila.
        public bool Delete(int idProvincia)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM dbo.Provincias " +
                              "WHERE idprovincia = @id;";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idProvincia);

                    cn.Open();

                    int filas = cmd.ExecuteNonQuery();
                    return filas == 1;
                }
            }
        }
    }
}
