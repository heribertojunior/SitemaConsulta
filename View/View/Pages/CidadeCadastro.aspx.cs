using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using BLL.Model;
using System.Web.UI.WebControls;
using DAL.Persistence;

namespace View.Pages
{
    public partial class CidadeCadastro : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            
            bindEstados();

        }

        public void btnCadastrarCidade(object sender, EventArgs e){
            try
            {
                Estado estado = new Estado();
                Cidade cidade = new Cidade();
                cidade.Descricao = descricao.Text;
                cidade.IdEstado = Int32.Parse(idEstado.SelectedValue);

                CidadeDal cidadeDal = new CidadeDal();
                cidadeDal.Salvar(cidade);

                descricao.Text = "";
                idEstado.Text = "";

                string msg = "Cidade  " + cidade.Descricao +                             
                              "  cadastrada com sucesso";
                lblMensagem.Text = msg;
                lblMensagem.Attributes.CssStyle.Add("color", "green");

               // Response.Redirect("/Pages/CidadeCadastro.aspx");
                //lblMensagem.Attributes.CssStyle.Add("color", "red");

            }
            catch (Exception erro)
            {
                lblMensagem.Attributes.CssStyle.Add("color", "red");
                lblMensagem.Text = erro.ToString();
            }

        }

        public void bindEstados(){

            EstadoDal estadoDal = new EstadoDal();
            List<Estado> listaEstado = new List<Estado>();
            Estado e = new Estado();
            listaEstado = estadoDal.Listar();
            foreach (var estado in listaEstado){

                idEstado.Items.Insert(0, new ListItem( estado.Nome, estado.Id.ToString()));
            }



           
        }
    
    }
    

}
