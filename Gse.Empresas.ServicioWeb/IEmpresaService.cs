using Gse.WebService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Gse.Empresas.ServicioWeb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEmpresaService
    {
        [OperationContract]
        IList<EmpresaData> GetAllEmpresa();

        [OperationContract]
        EmpresaData GetEmpresa(Guid Id);

        [OperationContract]
        void AddEmpresa(EmpresaData empresa);

        [OperationContract]
        void DeleteEmpresa(Guid Id);
    }

    
}
