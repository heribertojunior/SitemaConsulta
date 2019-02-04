using System;
namespace BLL.Model
{
    public class Consulta
    {
        public int Id { set; get; }
        public int IdMedico { set; get; }
        public int IdPaciente { set; get; }
        public String Obs { set; get; }
        public String DtCad { set; get; }


        public Consulta()
        {
        }
    }
}
