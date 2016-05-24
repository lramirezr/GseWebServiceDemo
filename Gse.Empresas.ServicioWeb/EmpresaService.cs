using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Gse.WebService.Data;
using Gse.WebService.Entities;
using Gse.WebService.Repository;

namespace Gse.Empresas.ServicioWeb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class EmpresaService : IEmpresaService
    {
        private IEmpresaRepository _empresaRepository;

        public EmpresaService()
        {
            _empresaRepository = new EmpresaRepository(new GseDbContext());
        }
        public void AddEmpresa(EmpresaData empresa)
        {
            _empresaRepository.Add(new Empresa {
                Id = empresa.Id,
                Nombre = empresa.Nombre,
                Cif = empresa.Cif,
                FechaAlta = empresa.FechaAlta,
                FechaModificacion = empresa.FechaModificacion,
                FechaBaja = empresa.FechaBaja,
                UsuarioId = empresa.UsuarioId
            });
            _empresaRepository.Save();
        }

        public void DeleteEmpresa(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IList<EmpresaData> GetAllEmpresa()
        {
            IList<Empresa> lstResult = (from e in _empresaRepository.GetAll() select e).ToList();

            IList<EmpresaData> lstResultData = lstResult
                                                .Select<Empresa, EmpresaData>(e => new EmpresaData {
                                                                                        Id = e.Id,
                                                                                        Nombre = e.Nombre,
                                                                                        Cif = e.Cif,
                                                                                        FechaAlta = e.FechaAlta,
                                                                                        FechaBaja = e.FechaBaja,
                                                                                        FechaModificacion = e.FechaModificacion,
                                                                                        UsuarioId = e.UsuarioId
                                                                                    })
                                                                                    .ToList();

            return lstResultData;
        }

        public EmpresaData GetEmpresa(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
