using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;

namespace DAL.Persistence
{
    public class ExameDal: Conexao
    {
        public void Salvar(Exame exame)
        {
            try
            {
                AbrirConexao();

                var sql = "insert into exame (idConsulta,idTipoExame,obs,dtCadastro)" +
                    "Values(@idConsulta,@idTipoExame,@obs,current_timestamp())";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idConsulta", exame.IdConsulta);
                command.Parameters.AddWithValue("@idTipoExame", exame.IdTipoExame);
                command.Parameters.AddWithValue("@obs", exame.Obs);
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
        public List<Exame> Listar()
        {

            try
            {
                AbrirConexao();

                var sql = "Select * from exame";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Exame> listaExame = new List<Exame>();

                while (dataReader.Read())
                {
                    Exame exame = new Exame();
                    exame.Id = Convert.ToInt32(dataReader["id"]);
                    exame.IdConsulta = Convert.ToInt32(dataReader["idConsulta"]);
                    exame.IdTipoExame = Convert.ToInt32(dataReader["idTipoExame"]);
                    exame.Obs = dataReader["obs"].ToString();


                }
                return listaExame;

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

        public ExameDal()

        {
        }
    }
}
