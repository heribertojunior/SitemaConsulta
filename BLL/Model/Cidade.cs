using System;
namespace BLL.Model
{
    public class Cidade
    {
        public int Id { get; set; }
        public int IdEstado { get; set; }
        public Estado estado { get; set; }
        public string Descricao { get; set; }
        public string DtCadastro { get; set; }

        public Cidade()
        {
        }
    }
}
