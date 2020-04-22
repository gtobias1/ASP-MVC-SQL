using BDProjeto.Repositorio;
using BDProjeto.RepositorioEF;

namespace BDProjeto.Aplicacao
{
    public class UsuarioContextConstrutor
    {
        //Construtor para o bd utilizando ADO
        public static UsuarioContextBS UsuarioApADO()
        {
            return new UsuarioContextBS(new UsuarioContextADO());
        }

        //Construtor para o bd utilizando Entity Framework
        public static UsuarioContextBS UsuarioApEF()
        {
            return new UsuarioContextBS(new UsuarioRepositorioEF());
        }
    }
}
