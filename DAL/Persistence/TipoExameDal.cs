using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;
namespace DAL.Persistence
{
    public class TipoExameDal : Conexao
    {
        public void Salvar(TipoExame tipoExame)
        {

            try
            {
                AbrirConexao();

                var sql = "insert into tipoExame (descricao,dtCadastro)" +
                    "Values(@descricao,current_timestamp())";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@descricao", tipoExame.Descricao);
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
        public List<TipoExame> Listar()
        {

            try
            {
                AbrirConexao();

                var sql = "Select * from es";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<TipoExame> listaTipoExame = new List<TipoExame>();

                while (dataReader.Read())
                {
                    TipoExame tipoExame = new TipoExame();
                    tipoExame.Id = Convert.ToInt32(dataReader["id"]);
                    tipoExame.Descricao = dataReader["descricao"].ToString();

                    listaTipoExame.Add(tipoExame);

                }
                return listaTipoExame;

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
        public TipoExameDal()
        {
        }
    }
}
