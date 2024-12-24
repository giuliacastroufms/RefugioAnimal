using Microsoft.AspNetCore.Mvc;

// Controller para gerenciar ações relacionadas à conta do usuário (exemplo: Login, Registro, etc.)
public class AccountController : Controller
{
    // Action para exibir a página de login
    [HttpGet]
    public IActionResult Login()
    {
        // Retorna a view correspondente à página de login (Login.cshtml)
        return View();
    }

    // Action para processar os dados enviados pelo formulário de login
    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Armazena o email do usuário em TempData
        // TempData é usado para passar dados temporários entre requisições (por exemplo, redirecionamentos)
        TempData["UserEmail"] = model.Email;

        // Redireciona o usuário para a action "Index" no controller "Home"
        // Após o login bem-sucedido, o usuário será enviado para a página inicial
        return RedirectToAction("Index", "Home");
    }
}
