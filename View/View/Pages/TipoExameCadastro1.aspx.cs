using System;
using BLL.Model;
using DAL.Persistence;
using System.Web;
using System.Web.UI;

namespace View.Pages
{

    public partial class TipoExameCadastro1 : System.Web.UI.Page
    {      protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = "Iniciando o cadastro";
        }

        protected void btnCadastrarTipoExame(object sender, EventArgs e)
        {
            try
            {
                TipoExame estado = new TipoExame();
                estado.Descricao = descricao.Text;

                
                TipoExameDal estadoDal = new TipoExameDal();
                estadoDal.Salvar(estado);

                descricao.Text = "";


                string msg = "Tipo de Exame : " + estado.Descricao +
                              " - " +
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
