namespace WinFormBaseDatosv1.Data
{
    /// Configuración de base de datos.
    /// Guardamos la cadena de conexión en un solo sitio.
    public static class DbConfig
    {
        // Servidor local: LocalDB
        public static string ConnectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=bdprueba01;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}
