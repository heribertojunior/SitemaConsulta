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
                    especialidade.DtCadastro = dataReader["dtCadastro"].ToString();

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

        public Especialidade pesquisarEspecialidade(int id)
        {
            try
            {
                var sql = "SELECT * FROM especialidade WHERE id = " + id;
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                Especialidade especialidade = new Especialidade();

                if (dataReader.Read())
                {

                    especialidade.Id = Convert.ToInt32(dataReader["id"]);
                    especialidade.Descricao = dataReader["descricao"].ToString();


                }
                return especialidade;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
            }
            finally
            {

            }
        }
        public EspecialidadeDal()
        {
        }
    }
}
