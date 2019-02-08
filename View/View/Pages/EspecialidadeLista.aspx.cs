using System;
using System.Web;
using System.Web.UI;
using DAL.Persistence;

namespace View.Pages
{

    public partial class EspecialidadeLista : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            EspecialidadeDal estadoDal = new EspecialidadeDal();

            dridListaEspecialidade.DataSource = estadoDal.Listar();
            dridListaEspecialidade.DataBind();
        }
    }
}
