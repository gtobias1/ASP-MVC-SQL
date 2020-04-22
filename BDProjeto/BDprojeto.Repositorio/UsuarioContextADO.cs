using BDprojeto.Repositorio;
using BDProjeto.DTO.Contrato;
using BDProjeto.DTO.ExemploBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BDProjeto.Repositorio
{
    public class UsuarioContextADO : IRepositorio<Usuarios>
    {
        private ConnectionHelper conexaoBD;

        public void Salvar(Usuarios user)
        {
            try
            {
                if (user.USUARIO_ID > 0)
                    AlterarDados(user);
                else
                    InserirDados(user);
            }
            catch (Exception exSalvar)
            {
                throw new Exception("Erro na tentativa de salvar dados na tabela! ", exSalvar);
            }
        }

        public void Excluir(Usuarios user)
        {
            try
            {
                var strQuery = "";
                strQuery += string.Format("DELETE FROM usuarios WHERE USUARIO_ID = {0}", user.USUARIO_ID);

                using (conexaoBD = new ConnectionHelper())
                    conexaoBD.ExecutaComando(strQuery);
            }
            catch (Exception exExcluirDados)
            {
                throw new Exception("Erro ao excluir usuario! ", exExcluirDados);
            }
        }

        public IEnumerable<Usuarios> GetAll()
        {
            try
            {
                using (conexaoBD = new ConnectionHelper())
                {
                    var strQuery = "SELECT * FROM usuarios;";
                    var reader = conexaoBD.ExecutaSelect(strQuery);
                    return ReaderEmLista(reader);
                }
            }
            catch (Exception exListarTodos)
            {
                throw new Exception("Erro ao recuperar os registros da tabela! ", exListarTodos);
            }
        }

        public Usuarios GetByID(string id)
        {
            try
            {
                using (conexaoBD = new ConnectionHelper())
                {
                    var strQuery = string.Format("SELECT * FROM usuarios WHERE USUARIO_ID = {0};", id);
                    var reader = conexaoBD.ExecutaSelect(strQuery);
                    return ReaderEmLista(reader).FirstOrDefault();
                }
            }
            catch (Exception exGetUsuarioById)
            {
                throw new Exception("Erro ao recuperar usuário! ", exGetUsuarioById);
            }
        }

        private void InserirDados(Usuarios user)
        {
            try
            {
                var strQuery = "";
                strQuery += "INSERT INTO usuarios (NOME, CARGO, DATAINSERCAO) ";
                strQuery += string.Format("VALUES ('{0}', '{1}', '{2}');", user.NOME, user.CARGO, DateTime.Now.ToString());

                using (conexaoBD = new ConnectionHelper())
                    conexaoBD.ExecutaComando(strQuery);

            }
            catch (Exception exInserirDados)
            {
                throw new Exception("Erro ao inserir novo usuário! ", exInserirDados);
            }
        }

        private void AlterarDados(Usuarios user)
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
            catch (Exception exAlterarDados)
            {
                throw new Exception("Erro ao editar usuário! ", exAlterarDados);
            }
        }

        private List<Usuarios> ReaderEmLista(SqlDataReader reader)
        {
            try
            {
                var resultMethod = new List<Usuarios>();

                while (reader.Read())
                {
                    var itemUser = new Usuarios()
                    {
                        USUARIO_ID = int.Parse(reader["USUARIO_ID"].ToString()),
                        NOME = reader["NOME"].ToString(),
                        CARGO = reader["CARGO"].ToString(),
                        DATAINSERCAO = DateTime.Parse(reader["DATAINSERCAO"].ToString())
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
