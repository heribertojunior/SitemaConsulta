using System;
namespace BLL.Model
{
    public class Medico
    {
        public int Id { get; set; }
        public int IdEspecialidade { get; set; }
        public String Nome { get; set; }
        public String Crm { get; set; }
        public String DtCad { get; set; }

        public Medico()
        {
        }
    }
}
