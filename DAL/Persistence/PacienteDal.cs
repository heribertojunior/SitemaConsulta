using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;
namespace DAL.Persistence
{
    public class PacienteDal:Conexao
    {

        public void Salvar(Paciente p)
        {
            try
            {
                AbrirConexao();

                var sql = "insert into paciente (idCidade,nome,dtCadastro)" +
                    "Values(@idCidade,@nome,current_timestamp())";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idCidade", p.IdCidade);
                command.Parameters.AddWithValue("@nome", p.Nome);
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
        public List<Paciente> Listar()
        {

            try
            {
                AbrirConexao();

                var sql = "Select * from paciente";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Paciente> listaPaciente = new List<Paciente>();

                while (dataReader.Read())
                {
                    Paciente paciente = new Paciente();
                    paciente.Id = Convert.ToInt32(dataReader["id"]);
                    paciente.IdCidade = Convert.ToInt32(dataReader["idCidade"]);
                    paciente.Nome = dataReader["nome"].ToString();

                    listaPaciente.Add(paciente);
                }
                return listaPaciente;

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

        public PacienteDal()
        {
        }
    }
}
