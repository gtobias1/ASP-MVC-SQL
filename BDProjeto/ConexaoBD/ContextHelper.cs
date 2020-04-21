using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UI.Background
{
    public class ContextHelper
    {
        private ConnectionHelper conexaoBD;

        public void Salvar(UsuariosDTO user)
        {
            try
            {
                if (user.USUARIO_ID > 0)
                    AlterarDados(user);
                else
                    InserirDados(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na tentativa de salvar dados na tabela! ", ex);
            }
        }

        public void ExcluirDados(int id)
        {
            try
            {
                var strQuery = "";
                strQuery += string.Format("DELETE FROM usuarios WHERE USUARIO_ID = {0}", id);

                using (conexaoBD = new ConnectionHelper())
                    conexaoBD.ExecutaComando(strQuery);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir usuario! ", ex);
            }
        }

        public List<UsuariosDTO> ListarTodos()
        {
            try
            {
                using (conexaoBD = new ConnectionHelper())
                {
                    var strQuery = "SELECT * FROM usuarios;";
                    var reader =  conexaoBD.ExecutaSelect(strQuery);
                    return ReaderEmLista(reader);
                }
            }
            catch (Exception exListarTodos)
            {
                throw new Exception("Erro ao recuperar os registros da tabela! ", exListarTodos);
            }
        }

        private void InserirDados(UsuariosDTO user)
        {
            try
            {
                var strQuery = "";
                strQuery += "INSERT INTO usuarios (NOME, CARGO, DATAINSERCAO) ";
                strQuery += string.Format("VALUES ('{0}', '{1}', '{2}');", user.NOME, user.CARGO, user.DATAINSERCAO);

                using (conexaoBD = new ConnectionHelper())
                    conexaoBD.ExecutaComando(strQuery);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir novo usuário! ", ex);
            }
        }

        private void AlterarDados(UsuariosDTO user)
        {
            try
            {
                var strQuery = "";
                strQuery += "UPDATE usuarios SET ";
                strQuery += string.Format("NOME = '{0}', CARGO = '{1}' ", user.NOME, user.CARGO);
                strQuery += string.Format("WHERE USUARIO_ID = {0};", user.USUARIO_ID);

                using (conexaoBD = new ConnectionHelper())
                    conexaoBD.ExecutaComando(strQuery);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar usuário! ", ex);
            }
        }

        private List<UsuariosDTO> ReaderEmLista(SqlDataReader reader)
        {
            try
            {
                var resultMethod = new List<UsuariosDTO>();

                while (reader.Read())
                {
                    var auxData = new DateTime();
                    auxData = DateTime.Parse(reader["DATAINSERCAO"].ToString());
                    var itemUser = new UsuariosDTO()
                    {
                        USUARIO_ID = int.Parse(reader["USUARIO_ID"].ToString()),
                        NOME = reader["NOME"].ToString(),
                        CARGO = reader["CARGO"].ToString(),
                        DATAINSERCAO = auxData.ToString("dd/MM/yyyy")
                    };

                    resultMethod.Add(itemUser);
                }

                reader.Close();
                return resultMethod;
            }
            catch (Exception exReaderEmLista)
            {
                throw new Exception("Erro ao recuperar lista de objetos! ", exReaderEmLista);
            }

        }

    }
}
