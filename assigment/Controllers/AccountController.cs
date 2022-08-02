using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model.Model;
using Model.ViewModels;

namespace assignment.Controllers.MVC
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private IHostingEnvironment _HostingEnviroment;


        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,  
             IHostingEnvironment hostingEnviroment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _HostingEnviroment = hostingEnviroment;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpGet]
        public IActionResult RegisterAndLogin()
        {
            ViewData["PhoneConfirmed"] = false;
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {


                /*Add user*/
                ApplicationUser user = new ApplicationUser
                {
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email,
                    PhoneNumber = registerViewModel.PhoneNumber
                };
                var result = await userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {



                    /*End add nationalcard,profile,recommendation pictures first*/

                    /*login and redirect user*/
                    if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administration");

                    }

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "People");

                    /*End login and redirect user*/

                }
                /*End Add user*/


                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }



            }//end modelState

            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password,model.RememberMe,lockoutOnFailure:false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                   
                        return Redirect(returnUrl);

                    }
                    return RedirectToAction("Index", "home");
                }
           
                    ModelState.AddModelError(string.Empty, "Invalid login Attempt");
                
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
          await  signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }





    }
}
