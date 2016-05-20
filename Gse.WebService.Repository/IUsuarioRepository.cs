using Gse.WebService.Data;
using System;
using System.Collections.Generic;

namespace Gse.WebService.Repository
{
    public interface IUsuarioRepository : IDisposable
    {
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Guid Id);
        void Save();
        IEnumerable<Usuario> GetAll();
        Usuario GetId(Guid Id);
    }
}
