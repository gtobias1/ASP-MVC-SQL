using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ConexaoBD
{
    public class ConnectionHelper : IDisposable
    {
        //readonly define que a variável não pode receber nenhum valor,
        //ou seja, servirá apenas para leitura
        private readonly SqlConnection conexao;

        public ConnectionHelper()
        {
            //faz a chamada das informações referentes ao banco de dados diretamente do XML do App.config
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ExemploBD"].ConnectionString);
            conexao.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            try
            {
                var cmd = new SqlCommand()
                {
                    CommandText = strQuery,
                    CommandType = System.Data.CommandType.Text,
                    Connection = conexao
                };
                cmd.ExecuteNonQuery();
            }
            catch (Exception exExecutaComando)
            {
                throw new Exception("Erro ao exceutar query. ", exExecutaComando);
            }
        }

        public SqlDataReader ExecutaSelect(string strQuery)
        {
            try
            {
                var cmd = new SqlCommand(strQuery, conexao);
                return cmd.ExecuteReader();
            }
            catch (Exception exExecutaSelect)
            {
                throw new Exception("Erro ao realixar SELECT. ", exExecutaSelect);
            }
        }

        public void Dispose()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }
    }
}
