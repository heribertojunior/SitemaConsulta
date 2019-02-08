using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Threading;

namespace View.Pages
{

    public partial class EstadoPesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnPesquisarEstado(object sender, EventArgs e)
        {
            try
            {

                Estado estado = new Estado();
                estado.Id = Convert.ToInt32(id.Text);

                lblMensagem.Text = "";
                EstadoDal estadoDal = new EstadoDal();
                estado = estadoDal.pesquisarEstado(estado.Id);
                if (estado.Id != 0)
                {
                    nome.Text = estado.Nome;
                    sigla.Text = estado.Sigla;


                }
                else
                {
                    nome.Text = "";
                    sigla.Text = "";
                    lblMensagem.Text = "Estado nao encontrado";
                }


            }
            catch (Exception erro)
            {
                throw new Exception("Erro");
            }
            finally
            {

            }
        }
        protected void btnAlterarEstado(object sender, EventArgs e)
        {
            try
            {
                Estado estado = new Estado();
                estado.Id = Convert.ToInt32(id.Text);
                estado.Nome = nome.Text;
                estado.Sigla = sigla.Text;

                EstadoDal estadoDal = new EstadoDal();
                estadoDal.Alterar(estado);

                nome.Text = "";
                sigla.Text = "";

                string msg = "Estado de " + estado.Nome +
                              " - " + estado.Sigla +
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

