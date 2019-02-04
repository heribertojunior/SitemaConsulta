using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;
namespace DAL.Persistence
{
    public class EspecialidadeDal:Conexao
    {
        public void Salvar(Especialidade especialidade)
        {
            try
            {
                AbrirConexao();

                var sql = "insert into especialidade (descricao,dtCadastro)" +
                    "Values(@descricao,current_timestamp())";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@descricao", especialidade.Descricao);
                command.ExecuteNonQuery();

            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public List<Especialidade> Listar()
        {

            try
            {
                AbrirConexao();

                var sql = "Select * from especialidade";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Especialidade> listaEspecialidade = new List<Especialidade>();

                while (dataReader.Read())
                {
                    Especialidade especialidade = new Especialidade();
                    especialidade.Id = Convert.ToInt32(dataReader["id"]);
                    especialidade.Descricao = dataReader["descricao"].ToString();

                    listaEspecialidade.Add(especialidade);

                }
                return listaEspecialidade;

            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                FecharConexao();
            }

        }

        public EspecialidadeDal()
        {
        }
    }
}
