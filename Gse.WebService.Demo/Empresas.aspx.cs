using Gse.WebService.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gse.WebService.Demo
{
    public partial class Empresas : System.Web.UI.Page
    {
        Gse.WebService.Demo.EmpresaServiceReference.EmpresaServiceClient _empresaService;

        private List<EmpresaData> _empresas;

        public Empresas()
        {
            _empresas = null;
            _empresaService = new EmpresaServiceReference.EmpresaServiceClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void refreshGridView()
        {
            _empresas = _empresaService.GetAllEmpresa().ToList();
            Label7.Text = _empresas.Count.ToString();
            GridView1.DataSource = _empresas;
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            refreshGridView();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EmpresaData _empresaData = new EmpresaData {
                Id = Guid.NewGuid(),
                Nombre = "Gse-Empresa-lUiS",
                Cif = "B000000",
                FechaAlta = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaBaja = null,
                UsuarioId = null
            };

            CultureInfo ci = CultureInfo.InvariantCulture;
            DateTime dtIni = DateTime.Now;
            Label1.Text = dtIni.ToString("hh:mm:ss.FFF", ci);

            _empresaService.AddEmpresa(_empresaData);

            DateTime dtFin = DateTime.Now;
            Label2.Text = dtFin.ToString("hh:mm:ss.FFF", ci);
            Label5.Text = dtFin.Subtract(dtIni).ToString();

            refreshGridView();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            DateTime dtIni = DateTime.Now;
            Label3.Text = dtIni.ToString("hh:mm:ss.FFF", ci);

            int numEmpresas = 100;
            for (int i = 0; i < numEmpresas; i++)
            {
                EmpresaData emp = new EmpresaData
                {
                    Id = Guid.NewGuid(),
                    Nombre = "Gse-Empresa-lUiS",
                    Cif = "B000000",
                    FechaAlta = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    FechaBaja = null,
                    UsuarioId = null
                };
                _empresaService.AddEmpresa(emp);
            }
            DateTime dtFin = DateTime.Now;
            Label4.Text = dtFin.ToString("hh:mm:ss.FFF", ci);
            Label6.Text = dtFin.Subtract(dtIni).ToString();

            refreshGridView();
        }
    }
}