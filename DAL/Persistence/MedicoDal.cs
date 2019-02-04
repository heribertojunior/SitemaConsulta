using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;
namespace DAL.Persistence
{
    public class MedicoDal:Conexao
    {
        public void Salvar(Medico medico)
        {
            try
            {
                AbrirConexao();
                var sql = "INSERT INTO medico(idespecialidade, nome,crm ,dtCadastro)" +
                          "VALUES(@idespecialidade, @nome, @crm,CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idespecialidade", medico.IdEspecialidade);
                command.Parameters.AddWithValue("@crm", medico.Crm);
                command.Parameters.AddWithValue("@nome", medico.Nome);
                command.ExecuteNonQuery();

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.ToString());
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Medico> Listar()
        {
            try
            {
                AbrirConexao();
                var sql = "SELECT * FROM medico";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Medico> listamedico = new List<Medico>();

                while (dataReader.Read())
                {
                    Medico medico = new Medico();

                    medico.Id = Convert.ToInt32(dataReader["id"]);
                    medico.Nome = dataReader["nome"].ToString();
                    medico.Crm = dataReader["crm"].ToString();
                    medico.DtCad = dataReader["dtCadastro"].ToString();

                    listamedico.Add(medico);
                }
                return listamedico;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
            }
            finally
            {
                FecharConexao();
            }
        }

        public MedicoDal()
        {
        }
    }
}
