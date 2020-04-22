using BDProjeto.Aplicacao;
using BDProjeto.DTO.ExemploBD;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class FuncionarioController : Controller
    {
        private UsuarioContextBS business;
        
        public FuncionarioController()
        {
            business = UsuarioContextConstrutor.UsuarioApEF();
        }

        [HttpGet]
        public ActionResult Index()
        {
            //Linhas comentadas usam as chamdas do ADO para trabalhar com o banco de dados
            //var business = UsuarioContextConstrutor.UsuarioApADO();
            var listUsuarios = business.ListarTodos();

            return View(listUsuarios);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuarios user)
        {
            if (ModelState.IsValid)
            {
                //var contexto = UsuarioContextConstrutor.UsuarioApADO();
                //contexto.Salvar(user);
                business.Salvar(user);
                return RedirectToAction("Index");
            }
            else
                return View(user);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            //var business = UsuarioContextConstrutor.UsuarioApADO();
            var user = business.GetUsuarioById(id.ToString());

            if (user == null)
                return HttpNotFound();
            else
                return View(user);
        }

        [HttpPost]
        public ActionResult Editar(Usuarios user)
        {
            if (ModelState.IsValid)
            {
                //var business = UsuarioContextConstrutor.UsuarioApADO();
                business.Salvar(user);
                return RedirectToAction("Index");
            }
            else
                return View(user);
        }

        [HttpGet]
        public ActionResult Detalhes(int id)
        {
            //var business = UsuarioContextConstrutor.UsuarioApADO();
            var user = business.GetUsuarioById(id.ToString());

            if (user == null)
                return HttpNotFound();
            else
                return View(user);
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            //var business = UsuarioContextConstrutor.UsuarioApADO();
            var user = business.GetUsuarioById(id.ToString());

            if (user == null)
                return HttpNotFound();
            else
                return View(user);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            //var business = UsuarioContextConstrutor.UsuarioApADO();
            var user = business.GetUsuarioById(id.ToString());
            business.ExcluirDados(user);
            return RedirectToAction("Index");
        }

    }
}