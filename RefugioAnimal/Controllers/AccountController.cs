using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RefugioAnimal.Models;
using RefugioAnimal.Models.DTOs;
using RefugioAnimal.Models.Entities;
using RefugioAnimal.Models.Enums;
using RefugioAnimal.Services;

public class AccountController : Controller
{
    private readonly SignInManager<User> signInManager;
    private readonly UserManager<User> userManager;
    private readonly DonorProtectorService donorProtectorService;
    private readonly NGOService ngoService;

    public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, DonorProtectorService donorProtectorService, NGOService ngoService)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.donorProtectorService = donorProtectorService;
        this.ngoService = ngoService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Email ou senha estão incorretos.");
                return View(model);
            }
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                FullName = model.Name,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                switch (model.UserType)
                {
                    case UserType.DonorProtector:
                        var donorProtector = new DonorProtectorDto
                        {
                            UserId = user.Id,
                            CPF = !string.IsNullOrEmpty(model.CPF) ? model.CPF : string.Empty,
                            Address = model.Address
                        };
                        await donorProtectorService.CreateDonorProtectorAsync(donorProtector);
                        break;

                    case UserType.NGO:
                        var ngo = new NGODto
                        {
                            UserId = user.Id,
                            CNPJ = !string.IsNullOrEmpty(model.CNPJ) ? model.CNPJ : string.Empty,
                            Responsible = model.Responsible,
                            ResponsiblePhoneNumber = model.ResponsiblePhoneNumber,
                            Address = model.Address
                        };
                        await ngoService.CreateNGOAsync(ngo);
                        break;
                }
                return RedirectToAction("Login", "Account");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        return View(model);
    }


    [HttpGet]
    public IActionResult VerifyEmail()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                ModelState.AddModelError("", "Nenhuma conta encontrada com este email.");
                return View(model);
            }
            else
            {
                return RedirectToAction("ChangePassword", "Account", new { username = user.UserName });
            }
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult ChangePassword(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            return RedirectToAction("VerifyEmail", "Account");
        }

        return View(new ChangePasswordViewModel { Email = username });
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user is not null)
            {
                var result = await userManager.RemovePasswordAsync(user);
                if (result.Succeeded)
                {
                    result = await userManager.AddPasswordAsync(user, model.NewPassword);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Email não encontrado!");
                return View(model);
            }
        }
        else
        {
            ModelState.AddModelError("", "Algo deu errado. Tente novamente.");
            return View(model);
        }
    }

    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
