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
        public void DeleteUsuario(Guid Id) {
            _usuarioRepository.Delete(Id);
            _usuarioRepository.Save();
        }
        public IList<WebService.Entities.Usuario> GetAllUsuario()
        {
            IList<WebService.Entities.Usuario> lstResult = (from u in _usuarioRepository.GetAll()
                                                            orderby u.FechaAlta descending
                                                            select new WebService.Entities.Usuario
                                                            {
                                                                Id = u.Id,
                                                                Nombre = u.Nombre,
                                                                NombreUsuario = u.NombreUsuario,
                                                                Apellidos = u.Apellidos,
                                                                FechaNacimiento = u.FechaNacimiento,
                                                                FechaAlta = u.FechaAlta,
                                                                FechaBaja = u.FechaBaja,
                                                                FechaModificacion = u.FechaModificacion,
                                                                Email = u.Email,
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

        public IList<WebService.Entities.Usuario> GetAllUsuarioByNombreUsuario(string nombreUsuario) {
            IList<WebService.Entities.Usuario> lstResult = (from u in _usuarioRepository.GetAll()
                                                            orderby u.FechaAlta descending
                                                            where u.NombreUsuario == nombreUsuario
                                                            select new WebService.Entities.Usuario
                                                            {
                                                                Id = u.Id,
                                                                Nombre = u.Nombre,
                                                                NombreUsuario = u.NombreUsuario,
                                                                Apellidos = u.Apellidos,
                                                                FechaNacimiento = u.FechaNacimiento,
                                                                FechaAlta = u.FechaAlta,
                                                                FechaBaja = u.FechaBaja,
                                                                FechaModificacion = u.FechaModificacion,
                                                                Email = u.Email,
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

        private byte[] createPass(int length) {
            byte[] array = new byte[length];
            Random random = new Random();
            random.NextBytes(array);
            return array;
        }
        public void AddUsuario(WebService.Entities.Usuario usuario) {
            _usuarioRepository.Add(new WebService.Data.Usuario() {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                NombreUsuario = usuario.NombreUsuario,
                Apellidos = usuario.Apellidos,
                Contrasenya = usuario.Contrasenya,
                Email = usuario.Email,
                Empresas = null,
                FechaAlta = usuario.FechaAlta,
                FechaModificacion = usuario.FechaModificacion,
                FechaNacimiento = usuario.FechaNacimiento,
                FechaBaja = null
            });
            _usuarioRepository.Save();
        }
    }
}
