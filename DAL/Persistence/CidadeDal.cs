using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;
using System.Data;

namespace DAL.Persistence
{
    public class CidadeDal : Conexao
    {

        public void Salvar(Cidade cidade)
        {
            try
            {
                AbrirConexao();
                var sql = "INSERT INTO cidade(idEstado, descricao, dtCadastro)" +
                          "VALUES(@idEstado, @descricao, CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idEstado", cidade.IdEstado);
                command.Parameters.AddWithValue("@descricao", cidade.Descricao);
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

        public DataTable ListarN(string descricao)
        {

            try
            {


                AbrirConexao();
                var sql = "SELECT * FROM cidade where descricao like '%"+descricao+"%' ";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();


                List<Cidade> listaCidade = new List<Cidade>();

                while (dataReader.Read())
                {
                    EstadoDal estadoDal = new EstadoDal();
                    Cidade cidade = new Cidade();

                    cidade.Id = Convert.ToInt32(dataReader["id"]);
                    cidade.IdEstado = Convert.ToInt32(dataReader["idEstado"]);
                    cidade.estado = estadoDal.pesquisarEstado(cidade.IdEstado);
                    cidade.Descricao = dataReader["descricao"].ToString();
                    cidade.DtCadastro = dataReader["dtCadastro"].ToString();

                    listaCidade.Add(cidade);
                    
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("idCidade");
                dt.Columns.Add("cidade");
                dt.Columns.Add("Estado");
                dt.Columns.Add("Sigla");
                foreach(var cidade in listaCidade){
                    dt.Rows.Add(cidade.Id,cidade.Descricao,cidade.estado.Nome,cidade.estado.Sigla);


                }
                return dt;

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
        public List<Cidade> Listar()
        {

            try
            {


                AbrirConexao();
                var sql = "SELECT * FROM cidade ";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();


                List<Cidade> listaCidade = new List<Cidade>();

                while (dataReader.Read())
                {
                    EstadoDal estadoDal = new EstadoDal();
                    Cidade cidade = new Cidade();

                    cidade.Id = Convert.ToInt32(dataReader["id"]);
                    cidade.IdEstado = Convert.ToInt32(dataReader["idEstado"]);
                    cidade.estado.Nome = estadoDal.pesquisarEstado(cidade.IdEstado).Nome;
                    cidade.Descricao = dataReader["descricao"].ToString();
                    cidade.DtCadastro = dataReader["dtCadastro"].ToString();

                    listaCidade.Add(cidade);
                }
                return listaCidade;

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

        public CidadeDal()
        {
        }
    }
}
