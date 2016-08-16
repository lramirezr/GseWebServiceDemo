using Gse.WebService.Data;
using System;
using System.Collections.Generic;

namespace Gse.WebService.Repository
{
    public interface IEmpresaRepository : IDisposable
    {
        void Add(Empresa empresa);
        void Update(Empresa empresa);
        void Delete(Guid Id);
        void Save();
        IEnumerable<Empresa> GetAll();
        Empresa GetId(Guid Id);
    }
}
