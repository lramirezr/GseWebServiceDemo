using Gse.WebService.Data;
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
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // refreshGridView();
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
            DateTime dtIni = DateTime.Now;
            Label1.Text = dtIni.ToString("hh:mm:ss.FFF" , ci);
            _usuarioService.AddUsuario(usu);
            DateTime dtFin = DateTime.Now;
            Label2.Text = dtFin.ToString("hh:mm:ss.FFF", ci);
            Label5.Text = dtFin.Subtract(dtIni).ToString();

            refreshGridView();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            refreshGridView();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;

            DateTime dtIni = DateTime.Now;
            Label3.Text = dtIni.ToString("hh:mm:ss.FFF", ci);

            int numUsuarios = 100;
            for (int i = 0; i < numUsuarios; i++) {
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
                _usuarioService.AddUsuario(usu);
            }

            DateTime dtFin = DateTime.Now;
            Label4.Text = dtFin.ToString("hh:mm:ss.FFF", ci);
            Label6.Text = dtFin.Subtract(dtIni).ToString();

            refreshGridView();
        }

        private string nombreUsuarioToDelete = "mropru"; // "Gse-lUis";
        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                
                if (!string.IsNullOrEmpty(DropDownList1.SelectedValue))
                {
                    nombreUsuarioToDelete = DropDownList1.SelectedValue;
                    _usuarios = _usuarioService.GetAllUsuarioByNombreUsuario(nombreUsuarioToDelete).ToList();
                    foreach (Usuario usuario in _usuarios)
                    {
                        _usuarioService.DeleteUsuario(usuario.Id);
                    }

                    lblMsgError.Text = (_usuarios.Count > 0) ?
                                        "Los usuarios creados fueron correctamente borrados."
                                        : string.Format("No existen usuarios con NombreUsuario: {0}", nombreUsuarioToDelete);
                    lblMsgError.Font.Bold = true;
                }
                else {
                    throw new Exception("Selecciona un elemento para eliminar");
                }
            }
            catch (Exception ex)
            {
                lblMsgError.Text = ex.Message;
                lblMsgError.BackColor = System.Drawing.Color.Red;
                lblMsgError.ForeColor = System.Drawing.Color.White;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;

            GridView2.DataSource = _usuarioService.GetAllUsuarioByNombreUsuario("Gse-lUis").ToList();
            GridView2.DataBind();
        }

        private void refreshGridView() {

            _usuarios = _usuarioService.GetAllUsuario().ToList();
            Label7.Text = _usuarios.Count.ToString();
            GridView1.DataSource = _usuarios;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;

            DateTime dtIni = DateTime.Now;
            Label8.Text = dtIni.ToString("hh:mm:ss.FFF", ci);

            refreshGridView();

            DateTime dtFin = DateTime.Now;
            Label9.Text = dtFin.ToString("hh:mm:ss.FFF", ci);
            Label10.Text = dtFin.Subtract(dtIni).ToString();
        }
    }
}