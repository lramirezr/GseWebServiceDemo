using Gse.WebService.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gse.WebService.Ui.Demo
{
    public partial class _Default : Page
    {
        private Gse.WebService.Demo.UsuarioServiceReference.UsuariosServiceClient _usuarioService;

        private List<Usuario> _usuarios;
        public List<Usuario> Usuarios
        {
            get
            {
              return _usuarios ?? new List<Usuario>();
            }
        }
        public _Default()
        {
            _usuarioService = new Gse.WebService.Demo.UsuarioServiceReference.UsuariosServiceClient();
            _usuarios = null;
            // _db = new GseDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                // UsuariosServiceClient client = new UsuariosServiceClient();
                //Gse.WebService.Demo.UsuarioServiceReference.UsuariosServiceClient usuarioService = new Gse.WebService.Demo.UsuarioServiceReference.UsuariosServiceClient();
                //_usuarios = usuarioService.GetAllUsuario().ToList();
                GridView1.DataSource = _usuarioService.GetAllUsuario().ToList();
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario
            {
                Id = Guid.NewGuid(),
                Nombre = "lUis",
                NombreUsuario = "Gse-lUis",
                Apellidos = "rAmiREz ReDOndO",
                Email = "lUis@gse.com",
                Contrasenya = Encoding.ASCII.GetBytes("lUis"),
                Empresas = null,
                FechaAlta = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = null,
                FechaBaja = null
            };

            CultureInfo ci = CultureInfo.InvariantCulture;

            Label1.Text = DateTime.Now.ToString("hh:mm:ss.FFF" , ci);
            _usuarioService.AddUsuario(usu);
            Label2.Text = DateTime.Now.ToString("hh:mm:ss.FFF", ci);

            GridView1.DataSource = _usuarioService.GetAllUsuario().ToList();
            GridView1.DataBind(); 
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            GridView1.DataSource = _usuarioService.GetAllUsuario().ToList();
            GridView1.DataBind();
        }
    }
}