using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Gse.WebService.Repository;
using Gse.WebService.Entities;
using Gse.WebService.Data;

namespace Gse.Usuarios.ServicioWeb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class UsuarioService : IUsuariosService
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository(new GseDbContext());
        }
        public WebService.Entities.Usuario GetUsuario(Guid Id)
        {

            WebService.Data.Usuario usuario = _usuarioRepository.GetId(Id);
            WebService.Entities.Usuario result = new WebService.Entities.Usuario
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                NombreUsuario = usuario.NombreUsuario,
                Empresas = usuario.Empresas.Cast<WebService.Entities.Empresa>().ToList()
            };
            return result;
        }
        public IList<WebService.Entities.Usuario> GetAllUsuario()
        {
            IList<WebService.Entities.Usuario> lstResult = (from u in _usuarioRepository.GetAll()
                                                            select new WebService.Entities.Usuario
                                                            {
                                                                Id = u.Id,
                                                                Nombre = u.Nombre,
                                                                NombreUsuario = u.NombreUsuario,
                                                                Empresas = (from e in u.Empresas
                                                                            select new WebService.Entities.Empresa
                                                                            {
                                                                                Id = e.Id,
                                                                                UsuarioId = e.UsuarioId,
                                                                                Cif = e.Cif,
                                                                                Nombre = e.Nombre,
                                                                                FechaAlta = e.FechaAlta,
                                                                                FechaBaja = e.FechaBaja,
                                                                                FechaModificacion = e.FechaModificacion
                                                                            }).ToList()
                                                            })
                                                            .ToList();
            return lstResult;
        }
    }
}
