using System.ServiceModel;
using Gse.WebService.Entities;
using System.Collections.Generic;
using System;

namespace Gse.Usuarios.ServicioWeb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuariosService
    {
        // TODO: agregue aquí sus operaciones de servicio
        [OperationContract]
        IList<Usuario> GetAllUsuario();

        [OperationContract]
        Usuario GetUsuario(Guid Id);

        [OperationContract]
        void AddUsuario(Usuario usuario);
    }
}
