
using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Threading;

namespace View.Pages
{

    public partial class EspecialidadePesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnPesquisarEspecialidade(object sender, EventArgs e)
        {
            try
            {

                Especialidade Especialidade = new Especialidade();
                Especialidade.Id = Convert.ToInt32(id.Text);

                lblMensagem.Text = "";
                EspecialidadeDal EspecialidadeDal = new EspecialidadeDal();
                Especialidade = EspecialidadeDal.pesquisarEspecialidade(Especialidade.Id);
                if (Especialidade.Id != 0)
                {
                    nome.Text = Especialidade.Descricao;



                }
                else
                {
                    nome.Text = "";

                    lblMensagem.Text = "Especialidade nao encontrado";
                }


            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.ToString();
            }
            finally
            {

            }
        }
    }
}

