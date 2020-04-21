using BDProjeto.Aplicacao;
using BDProjeto.DTO.ExemploBD;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class FuncionarioController : Controller
    {
        public ActionResult Index()
        {
            var bs = new UsuarioContext();
            var listUsuarios = bs.ListarTodos();

            return View(listUsuarios);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(UsuariosDTO user)
        {
            if (ModelState.IsValid)
            {
                var contexto = new UsuarioContext();
                contexto.Salvar(user);
                return RedirectToAction("Index");
            }
            else
                return View(user);
        }
    }
}