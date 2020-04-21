using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UI.Background
{
    class Program
    {
        static void Main(string[] args)
        {
            var bd = new ConnectionHelper();

            #region << Testes de chamada da classe ContextHelper >>
            var contexto = new ContextHelper();
            //Inserindo um novo usuário
            Console.WriteLine("Cadastro de Funcionários");
            Console.WriteLine("Digite o nome do usuário: ");
            var nomeA = Console.ReadLine();
            Console.WriteLine("Cargo do usuário: ");
            var cargoA = Console.ReadLine();
            DateTime dataInsercaoA = DateTime.Now;

            var user = new UsuariosDTO()
            {
                NOME = nomeA,
                CARGO = cargoA,
                DATAINSERCAO = dataInsercaoA.ToString()
            };

            //user.USUARIO_ID = 6;

            contexto.Salvar(user);
            //contexto.ExcluirDados(7);


            string strQueryA = "SELECT * FROM usuarios;";
            SqlDataReader dadosA = bd.ExecutaSelect(strQueryA);
            ExibirDados(contexto.ListarTodos());
            #endregion << Testes de chamada da classe ContextHelper >>

            #region << Segunda etapa, utilizando o ConnectionHelper >>
            //Inserindo um novo usuário
            //Console.WriteLine("Cadastro de Funcionários");
            //Console.WriteLine("Digite o nome do usuário: ");
            //var nomeA = Console.ReadLine();
            //Console.WriteLine("Cargo do usuário: ");
            //var cargoA = Console.ReadLine();
            //DateTime dataInsercaoA = DateTime.Now;

            //var strQueryInsertA= string.Format("INSERT INTO usuarios (NOME, CARGO, DATAINSERCAO) VALUES " +
            //                                 "('{0}', '{1}', '{2}')", nomeA, cargoA, dataInsercaoA);
            //bd.ExecutaComando(strQueryInsertA);

            //string strQueryA = "SELECT * FROM usuarios;";
            //SqlDataReader dadosA = bd.ExecutaSelect(strQueryA);
            //ExibirDados(dadosA);
            #endregion << Segunda etapa, utilizando o ConnectionHelper >>

            //PARÂMETROS DA CONEXÃO = 1º nome do servidor (data source); 
            //2º tipo de autenticação (Integrated Security), nesse caso usada a do windows SSPI;
            //3° nome do banco de dados (Initial Catalog)
            SqlConnection conexao = new SqlConnection(@"data source=DESKTOP-34F1MLC ; Integrated Security= SSPI; Initial Catalog=ExemploBD");
            conexao.Open(); //inicia a conexão

            string strQuery = "SELECT * FROM usuarios;";
            SqlCommand cmd = new SqlCommand(strQuery, conexao);

            //ExecuteReader é usado para executar os comandos de SELECT
            //Para executar comandos UPDATE, INSERT, DELETE... é executado o ExecuteNonQuery()
            SqlDataReader dados = cmd.ExecuteReader();
            //ExibirDados(dados);
            dados.Close();

            //Atualizando um registro da tabela
            var strQueryUpdate = "UPDATE usuarios SET NOME = 'Carlos Silva' WHERE USUARIO_ID = 2;";
            var cmdUpdate = new SqlCommand(strQueryUpdate, conexao);
            cmdUpdate.ExecuteNonQuery();

            ////Realizando um novo select
            //dados = cmd.ExecuteReader();
            //ExibirDados(dados);
            //dados.Close();

            //Excluindo um registro da tabela
            var strQueryDelete = "DELETE FROM usuarios WHERE USUARIO_ID = 2;";
            var cmdDelete = new SqlCommand(strQueryDelete, conexao);
            cmdDelete.ExecuteNonQuery();

            ////Realizando um novo select
            //dados = cmd.ExecuteReader();
            //ExibirDados(dados);
            //dados.Close();

            //Inserindo um novo usuário
            Console.WriteLine("Cadastro de Funcionários");
            Console.WriteLine("Digite o nome do usuário: ");
            var nome = Console.ReadLine();
            Console.WriteLine("Cargo do usuário: ");
            var cargo = Console.ReadLine();
            DateTime dataInsercao = DateTime.Now;

            var strQueryInsert = string.Format("INSERT INTO usuarios (NOME, CARGO, DATAINSERCAO) VALUES " +
                                                      "('{0}', '{1}', '{2}')", nome, cargo, dataInsercao);
            var cmdInsert = new SqlCommand(strQueryInsert, conexao);
            cmdInsert.ExecuteNonQuery();

            //Realizando um novo select
            //dados = cmd.ExecuteReader();
            ExibirDados(contexto.ListarTodos());
            //dados.Close();
        }

        private static void ExibirDados(SqlDataReader dados)
        {
            Console.WriteLine("Usuários cadastrados:");
            while (dados.Read())
            {
                DateTime aux = new DateTime();
                aux = Convert.ToDateTime(dados["DATAINSERCAO"]);
                Console.WriteLine("ID do usuário: {0}, Nome: {1}, Cargo: {2}, Data de admissão: {3}",
                                  dados["USUARIO_ID"], dados["NOME"], dados["CARGO"], aux.ToString("dd/MM/yyyy"));
            }
        }

        private static void ExibirDados(List<UsuariosDTO> dados)
        {
            Console.WriteLine("Usuários cadastrados:");
            foreach(var item in dados)
            {
                DateTime aux = new DateTime();
                aux = Convert.ToDateTime(item.DATAINSERCAO);
                Console.WriteLine("ID do usuário: {0}, Nome: {1}, Cargo: {2}, Data de admissão: {3}",
                                  item.USUARIO_ID, item.NOME, item.CARGO, aux.ToString("dd/MM/yyyy"));
            }
        }

    }
}
