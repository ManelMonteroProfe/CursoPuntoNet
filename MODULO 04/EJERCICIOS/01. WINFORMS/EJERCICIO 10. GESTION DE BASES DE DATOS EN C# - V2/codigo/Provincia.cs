namespace WinFormBaseDatosv1.Models
{
    /// MODELO: representa una provincia (una fila de la tabla Provincias).
    public class Provincia
    {
        /// idprovincia: clave primaria.
        public int IdProvincia { get; set; }

        /// provincia: nombre de la provincia.
        public string Nombre { get; set; } = string.Empty;
    }
}
