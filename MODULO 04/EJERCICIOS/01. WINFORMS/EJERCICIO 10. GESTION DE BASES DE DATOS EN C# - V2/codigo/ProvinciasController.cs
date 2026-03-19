using System;
using System.Data;
using WinFormBaseDatosv1.Data;
using WinFormBaseDatosv1.Models;

namespace WinFormBaseDatosv1.Controllers
{
    /// CONTROLLER (Reglas de negocio):
    /// - Valida datos (por ejemplo: no permitir vacío).
    /// - Llama al Repository para ejecutar SQL.
    public class ProvinciasController
    {
        private readonly ProvinciaRepository _repo;

        public ProvinciasController(ProvinciaRepository repo)
        {
            _repo = repo;
        }

        /// Lista todas las provincias en un DataTable (para el grid).
        public DataTable ListarTabla()
        {
            return _repo.GetAllAsDataTable();
        }

        /// Crea una provincia nueva.
        public int Crear(int idprov, string nombreProvincia)
        {
            // Regla básica: no permitir vacío.
            if (string.IsNullOrWhiteSpace(nombreProvincia))
                throw new ArgumentException("La provincia no puede estar vacía.");

            // Quitamos espacios delante y detrás.
            nombreProvincia = nombreProvincia.Trim();

            // Creamos el modelo.
            Provincia p = new Provincia
            {
                IdProvincia = idprov,
                Nombre = nombreProvincia
            };

            // Insertamos en BD y devolvemos el ID.
            return _repo.Insert(p);
        }

        /// Modifica una provincia existente.
        public bool Modificar(int idProvincia, string nombreProvincia)
        {
            // Validamos ID.
            if (idProvincia <= 0)
                throw new ArgumentException("Id inválido.");

            // Validamos nombre.
            if (string.IsNullOrWhiteSpace(nombreProvincia))
                throw new ArgumentException("La provincia no puede estar vacía.");

            nombreProvincia = nombreProvincia.Trim();

            Provincia p = new Provincia
            {
                IdProvincia = idProvincia,
                Nombre = nombreProvincia
            };

            return _repo.Update(p);
        }

        /// Elimina una provincia por ID.
        public bool Eliminar(int idProvincia)
        {
            if (idProvincia <= 0)
                throw new ArgumentException("Id inválido.");

            return _repo.Delete(idProvincia);
        }
    }
}
