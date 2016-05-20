using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Gse.WebService.Data
{
    public class Usuario
    {
        public Usuario()
        {
            Empresas = new List<Empresa>();
        }
        public Guid Id { get; set; }
        public string NombreUsuario { get; set; }
        public Byte[] Contrasenya { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}