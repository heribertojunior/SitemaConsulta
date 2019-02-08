using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using BLL.Model;
using System.Web.UI.WebControls;
using DAL.Persistence;

namespace View.Pages
{

    public partial class PacienteCadastro : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            bindespecialidades();
        }

        public void btnCadastrarPaciente(object sender, EventArgs e)
        {
            try
            {
                Cidade especialidade = new Cidade();
                Paciente medico = new Paciente();
                medico.IdCidade = Int32.Parse(idcidade.SelectedValue);
                medico.Nome = nome.Text;
               

                PacienteDal medicoDal = new PacienteDal();
                medicoDal.Salvar(medico);

                nome.Text = "";
                idcidade.Text = "";

                string msg = "Paciente  " + medico.Nome +
                              "  cadastrado com sucesso";
                lblMensagem.Text = msg;
                lblMensagem.Attributes.CssStyle.Add("color", "green");

                // Response.Redirect("/Pages/medicoCadastro.aspx");
                //lblMensagem.Attributes.CssStyle.Add("color", "red");

            }
            catch (Exception erro)
            {
                lblMensagem.Attributes.CssStyle.Add("color", "red");
                lblMensagem.Text = erro.ToString();
            }
        }

        public void bindespecialidades()
        {
            CidadeDal especialidadeDal = new CidadeDal();
            List<Cidade> listaCidade = new List<Cidade>();

            listaCidade = especialidadeDal.Listar();
            idcidade.Items.Clear();
            foreach (var especialidade in listaCidade)
            {
                idcidade.Items.Insert(0, new ListItem(especialidade.Descricao, especialidade.Id.ToString()));
            }




        }


    }
}
