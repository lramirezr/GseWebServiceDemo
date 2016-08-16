using Gse.WebService.Data;
using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Linq;

namespace Gse.WebService.Repository
{
    public class EmpresaRepository : IEmpresaRepository, IDisposable
    {
        private DbContext _dbContext;
        public EmpresaRepository(DbContext db)
        {
            _dbContext = db;
        }

        public void Add(Empresa empresa)
        {
            this._dbContext.Set<Empresa>().Add(empresa);
        }

        public void Update(Empresa empresa)
        {
            this._dbContext.Entry(empresa).State = EntityState.Modified;
        }

        public void Delete(Guid Id)
        {
            Empresa empresa = this._dbContext.Set<Empresa>().Find(Id);
            this._dbContext.Set<Empresa>().Remove(empresa);
        }

        public void Save()
        {
            this._dbContext.SaveChanges();
        }

        public IEnumerable<Empresa> GetAll()
        {
            return this._dbContext.Set<Empresa>()
                .AsNoTracking()
                .Include(e => e.Usuario)
                .ToList();
        }

        public Empresa GetId(Guid Id)
        {
            return this._dbContext.Set<Empresa>().Find(Id);
        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~EmpresaRepository() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
