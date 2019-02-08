using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using BLL.Model;
using System.Web.UI.WebControls;
using DAL.Persistence;

namespace View.Pages
{

    public partial class MedicoCadastro : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            bindespecialidades();
        }

        public void btnCadastrarMedico(object sender, EventArgs e)
        {
            try
            {
                Especialidade especialidade = new Especialidade();
                Medico medico = new Medico();
                medico.Nome = nome.Text;
                medico.Crm = crm.Text;
                medico.IdEspecialidade = Int32.Parse(idEspecialidade.SelectedValue);

                MedicoDal medicoDal = new MedicoDal();
                medicoDal.Salvar(medico);

                nome.Text = "";
                crm.Text = "";
                idEspecialidade.Text = "";

                string msg = "medico  " + medico.Nome +
                              "  cadastrada com sucesso";
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
            EspecialidadeDal especialidadeDal = new EspecialidadeDal();
            List<Especialidade> listaespecialidade = new List<Especialidade>();

            listaespecialidade = especialidadeDal.Listar();
            idEspecialidade.Items.Clear();
            foreach (var especialidade in listaespecialidade)
            {
                idEspecialidade.Items.Insert(0, new ListItem(especialidade.Descricao, especialidade.Id.ToString()));
            }




        }

    }
}
