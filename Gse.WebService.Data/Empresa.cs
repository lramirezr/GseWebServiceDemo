using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Gse.WebService.Data
{
    [DataContract(IsReference = true)]
    public class Empresa
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
        [DataMember]
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}