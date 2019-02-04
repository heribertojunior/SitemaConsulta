using System;
namespace BLL.Model
{
    public class Paciente
    {
        public int Id { set; get; }
        public int IdCidade { set; get; }
        public String Nome { set; get; }
        public String DtCad { set; get; }
        public Paciente()
        {
        }
    }
}
