using System;
using BLL.Model;
using DAL.Persistence;
using System.Web;
using System.Web.UI;

namespace View.Pages
{

    public partial class EspecialidadeCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = "Iniciando o cadastro";
        }

        protected void btnCadastrarEspecialidade(object sender, EventArgs e)
        {
            try
            {
                Especialidade estado = new Especialidade();
                estado.Descricao =  descricao.Text;
               

                EspecialidadeDal estadoDal = new EspecialidadeDal();
                estadoDal.Salvar(estado);

                descricao.Text = "";
              

                string msg = "Especialidade : " + estado.Descricao +
                              " - "  +
                              " foi cadastrado com sucesso";
                lblMensagem.Text = msg;
                lblMensagem.Attributes.CssStyle.Add("color", "green");



                // Response.Redirect("/Pages/EstadoCadastro.aspx");
                //lblMensagem.Attributes.CssStyle.Add("color", "red");


            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.ToString();
            }

        }
    }

}

