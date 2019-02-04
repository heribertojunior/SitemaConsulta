using System;
namespace BLL.Model
{
    public class Exame
    {
        public int Id { get; set; }
        public int IdConsulta { get; set; }
        public int IdTipoExame { get; set; }
        public String Obs { get; set; }
        public String DtCad { get; set; }
        public Exame()
        {
        }
    }
}
