using System;
using System.Runtime.Serialization;

namespace Gse.WebService.Entities
{
    [DataContract]
    public class EmpresaData
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Cif { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public DateTime FechaAlta { get; set; }
        [DataMember]
        public DateTime? FechaBaja { get; set; }
        [DataMember]
        public DateTime FechaModificacion { get; set; }
        [DataMember]
        public Guid? UsuarioId { get; set; }
    }
}