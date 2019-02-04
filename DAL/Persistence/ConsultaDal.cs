using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;
namespace DAL.Persistence
{
    public class ConsultaDal:Conexao
    {
        public void Salvar(Consulta1 consulta)
        {
            try
            {
                AbrirConexao();

                var sql = "insert into consulta (idMedico,idPaciente,obs,dtCadastro)" +
                    "Values(@idMedico,@idPaciente,@obs,current_timestamp())";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idMedico", consulta.IdMedico);
                command.Parameters.AddWithValue("@idPaciente", consulta.IdPaciente);
                command.Parameters.AddWithValue("@obs", consulta.Obs);
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
        public List<Consulta1> Listar()
        {

            try
            {
                AbrirConexao();

                var sql = "Select * from consulta";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Consulta1> listaConsulta = new List<Consulta1>();

                while (dataReader.Read())
                {
                    Consulta1 consulta = new Consulta1();
                    consulta.Id = Convert.ToInt32(dataReader["id"]);
                    consulta.IdMedico = Convert.ToInt32(dataReader["idMedico"]); 
                    consulta.IdPaciente = Convert.ToInt32(dataReader["idPaciente"]);
                    consulta.Obs = dataReader["obs"].ToString();


                }
                return listaConsulta;

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

        public ConsultaDal()
        {
        }
    }
}
