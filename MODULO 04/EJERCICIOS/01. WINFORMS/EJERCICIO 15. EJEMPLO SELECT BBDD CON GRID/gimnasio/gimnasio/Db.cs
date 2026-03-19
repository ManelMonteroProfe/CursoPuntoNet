using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gimnasio
{
    /// Acceso a datos MUY simple (ADO.NET).
    public static class Db
    {
        // Cambia el servidor si no usas .\SQLEXPRESS
        // Ejemplo LocalDB: (localdb)\MSSQLLocalDB
        public static string ConnectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=bdprueba01;Trusted_Connection=True;TrustServerCertificate=True;";

        public static DataTable Query(string sql)
        {
            using (var cn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                cn.Open();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
