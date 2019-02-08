using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using BLL.Model;
using System.Web.UI.WebControls;
using DAL.Persistence;

namespace View.Pages
{

    public partial class Consulta : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            bindespecialidades();
            bindmedico();
        }

        public void btnCadastrarConsulta(object sender, EventArgs e)
        {
            try
            {
                Paciente paciente = new Paciente();
                Medico medico = new Medico();
                Consulta1 consulta = new Consulta1();
                       consulta.Obs = obs.Text;
                         consulta.IdMedico = Int32.Parse(idMedico.SelectedValue);
                consulta.IdPaciente = Int32.Parse(idPaciente.SelectedValue);

                         ConsultaDal consultaDal = new ConsultaDal();
                      consultaDal.Salvar(consulta);

                string msg = "Consulta  " +
                              "  cadastrada com sucesso";
                lblMensagem.Text = msg;
                lblMensagem.Attributes.CssStyle.Add("color", "green");

                  Response.Redirect("/Pages/ConsultaCadastro.aspx");
                 lblMensagem.Attributes.CssStyle.Add("color", "red");

            }
            catch (Exception erro)
            {
                lblMensagem.Attributes.CssStyle.Add("color", "red");
                lblMensagem.Text = erro.ToString();
            }
        }

        public void bindespecialidades()
        {
            MedicoDal medicoDal = new MedicoDal();
            List<Medico> listamedico = new List<Medico>();

            listamedico = medicoDal.Listar();
            idMedico.Items.Clear();
            foreach (var especialidade in listamedico)
            {
                idMedico.Items.Insert(0, new ListItem(especialidade.Nome, especialidade.Id.ToString()));
            }




        }
        public void bindmedico()
        {
            PacienteDal pacienteDal = new PacienteDal();
            List<Paciente> listapaciente = new List<Paciente>();

            listapaciente = pacienteDal.Listar();
            idPaciente.Items.Clear();
            foreach (var especialidade in listapaciente)
            {
                idPaciente.Items.Insert(0, new ListItem(especialidade.Nome, especialidade.Id.ToString()));
            }




        }
    }
}
