using Gse.WebService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gse.WebService.Ui.Demo
{
    public partial class _Default : Page
    {
       private List<Usuario> _usuarios;
        // private GseDbContext _db;
        //private IUsuarioRepository _usuarioRepository;

        public List<Usuario> Usuarios
        {
            get
            {
              return _usuarios ?? new List<Usuario>();
            }
            // set;
        }
        public _Default()
        {
            _usuarios = null;
            // _db = new GseDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                // UsuariosServiceClient client = new UsuariosServiceClient();

                Gse.WebService.Demo.UsuarioServiceReference.UsuariosServiceClient usuarioService = new Gse.WebService.Demo.UsuarioServiceReference.UsuariosServiceClient();
                _usuarios = usuarioService.GetAllUsuario().ToList();
                GridView1.DataSource = _usuarios;
                GridView1.DataBind();
            }
        }
    }
}