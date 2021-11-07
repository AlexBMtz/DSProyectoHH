using DSProyectoHH.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserHelper userHelper;

        public AccountsController(IUserHelper userHelper)
        {
            this.userHelper = userHelper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)

                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await userHelper.LoginAsync(login.Email, login.Password, login.RememberMe);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Error de inicio de sesión");
                return View(login);
            }

            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
