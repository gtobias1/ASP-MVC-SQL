using BDProjeto.Aplicacao;
using BDProjeto.DTO.ExemploBD;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class FuncionarioController : Controller
    {
        [HttpGet]
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

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var contexto = new UsuarioContext();
            var user = contexto.GetUsuarioById(id);

            if (user == null)
                return HttpNotFound();
            else
                return View(user);
        }

        [HttpPost]
        public ActionResult Editar(UsuariosDTO user)
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

        [HttpGet]
        public ActionResult Detalhes(int id)
        {
            var contexto = new UsuarioContext();
            var user = contexto.GetUsuarioById(id);

            if (user == null)
                return HttpNotFound();
            else
                return View(user);
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            var contexto = new UsuarioContext();
            var user = contexto.GetUsuarioById(id);

            if (user == null)
                return HttpNotFound();
            else
                return View(user);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var contexto = new UsuarioContext();
            contexto.ExcluirDados(id);
            return RedirectToAction("Index");
        }

    }
}