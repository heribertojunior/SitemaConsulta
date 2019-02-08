using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
namespace View.Pages
{

    public partial class EstadoLista : System.Web.UI.Page
    {
        public void Page_Load(object sender,EventArgs e){
            EstadoDal estadoDal = new EstadoDal();

            dridListaEstado.DataSource = estadoDal.Listar();
            dridListaEstado.DataBind();
        }
    }
}
