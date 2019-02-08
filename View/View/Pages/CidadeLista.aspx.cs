using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Data;

namespace View.Pages
{

    public partial class CidadeLista : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            CidadeDal estadoDal = new CidadeDal();

            dridListaCidade.DataSource = estadoDal.ListarN(descricao.Text);
            dridListaCidade.DataBind();
        }
        protected void btnPesquisarCidade(object sender, EventArgs e)
        {
            try
            {

                CidadeDal estadoDal = new CidadeDal();

                dridListaCidade.DataSource = estadoDal.ListarN(descricao.Text);
                dridListaCidade.DataBind();


            }
            catch (Exception erro)
            {
                throw new Exception("Erro");
            }
            finally
            {

            }
        }

    }
}
