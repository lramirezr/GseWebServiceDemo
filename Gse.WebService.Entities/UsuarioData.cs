using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Gse.WebService.Entities
{
    [DataContract]
    public class UsuarioData
    {
        public UsuarioData()
        {
        }
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string NombreUsuario { get; set; }
        [DataMember]
        public Byte[] Contrasenya { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellidos { get; set; }
        [DataMember]
        public DateTime? FechaNacimiento { get; set; }
        [DataMember]
        public DateTime FechaAlta { get; set; }
        [DataMember]
        public DateTime? FechaBaja { get; set; }
        [DataMember]
        public DateTime FechaModificacion { get; set; }
        [DataMember]
        public virtual ICollection<EmpresaData> Empresas { get; set; }
    }
}