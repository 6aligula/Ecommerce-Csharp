﻿using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared;
using E_Commerce_App.Core.Shared.Helper;
using E_Commerce_App.WebUI.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static E_Commerce_App.WebUI.ViewModels.UserViewModel;

namespace E_Commerce_App.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private ICartService _cartService;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;

        public AccountController(ICartService cartService,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender)
        {
            _cartService = cartService;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        // Pages
        //[Route("signin")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("my-profile")]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new UserAccountViewModel() { FullName = user.FullName, Email = user.Email, NewPassword = "", RePassword = "" };
            return View(model);
        }
        public async Task<IActionResult> ProfileEdit(UserAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if ((model.Email.Equals(user.Email) && model.FullName.Equals(user.FullName))
                    && string.IsNullOrEmpty(model.NewPassword))
                {
                    return Redirect("/my-profile");
                }

                user.Email = model.Email;
                user.FullName = model.FullName;
                if (!string.IsNullOrEmpty(model.NewPassword))
                {
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, model.NewPassword);
                }
                await _userManager.UpdateAsync(user);
                return Json(new { success = true, message = "La información del perfil se ha actualizado correctamente." });
            }
            return Redirect(nameof(Profile));
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        // Método GET para mostrar la vista de restablecimiento de contraseña
        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null) return RedirectToAction("Index", "Home");
            var model = new ResetPasswordViewModel
            {
                UserId = userId,
                Token = token
            };
            return View(model);
        }
        // Helper
        private async Task<bool> EmailExist(string email)
        {
            var resultUser = await _userManager.FindByEmailAsync(email);
            if (resultUser != null) return resultUser.Email != null ? true : false;
            return false;
        }
        // Helper
        private async Task SendVerificationEmail(User user, string email, string baseUrl)
        {
            //var siteUrl = "https://localhost:5001";
            //var html = $"Por favor confirme su cuenta de correo electrónico <a href='{siteUrl + baseUrl}'>linke</a> haga clic aquí.";
            ////await _emailSender.SendEmailAsync(model.Email, "Confirme su cuenta.", html);

            // generate token
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var url = Url.Action("ConfirmEmail", "Account", new
            {
                userId = user.Id,
                token = code
            });
            Console.Write(url);
            // email
            var siteUrl = "https://localhost:44373";
            var html2 = $"Por favor confirme su cuenta de correo electrónico <a href='{siteUrl + url}'>linke</a> haga clic aquí.";
            var emailUrl = siteUrl + url;
            var html = Messages.EMAIL_CONFIRM_HTML(user.FullName, emailUrl);
            await _emailSender.SendEmailAsync(user.Email, "Verificación de cuenta de usuario", html);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) // validar
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null) return Json(new { message = "La dirección de correo electrónico o la contraseña son incorrectas.", errorType = 1 });

                if (!await _userManager.IsEmailConfirmedAsync(user))
                    return Json(new { message = "Por favor revise sus correos electrónicos para confirmar su dirección de correo electrónico.", errorType = 2 });

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

                if (result.Succeeded)
                {
                    ViewData["user"] = user.Id;
                    return Json(new { success = true, redirectUrl = "/" });// Redirect(model.ReturnUrl ?? "~/");
                }

                else return Json(new { message = "La dirección de correo electrónico o la contraseña son incorrectas.", errorType = 1 });
            }
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    // Creemos el objeto del carrito.
                    await _cartService.InitializeCart(user.Id);
                    //CreateMessage("Tu cuenta ha sido confirmada", "Tu cuenta ha sido confirmada", "success");
                    //return Json(new { success=true, redirectUrl="/account/login", message="Su registro de usuario está completo. Puedes iniciar sesión." });
                    return RedirectToAction(nameof(Login));
                }
            }
            return Json(new { message = "No se encontró ningún usuario de este tipo." });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // email exist control
                if (await EmailExist(model.Email)) return Json(new { message = "El registro ya se ha realizado con su dirección de correo electrónico.", errorType = 3 });

                var user = new User { FullName = model.FullName, Email = model.Email, UserName = model.Email };
                var resultUser = await _userManager.CreateAsync(user, model.Password);


                // default user role adding
                await _userManager.AddToRoleAsync(user, "customer");
                if (resultUser.Succeeded)
                {
                    try
                    {
                        // generate token
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var baseUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token });

                        // email operations
                        await SendVerificationEmail(user, user.Email, baseUrl);
                        return Json(new { success = true, redirectUrl = "/account/login", message = "Registro de usuario exitoso. Por favor verifique su dirección de correo electrónico." });
                    }
                    catch (Exception)
                    {
                        await _userManager.DeleteAsync(user);
                        return Json(new { success = false, redirectUrl = "/account/register", message = "Hubo un error en el registro de usuario. Por favor, inténtelo de nuevo más tarde." });
                    }
                }
                else if (!resultUser.Succeeded)
                {
                    return Json(new { message = "La contraseña debe contener al menos 6 caracteres, 1 letra mayúscula, 1 expresión numérica y 1 signo de puntuación.", success = false });
                }
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null) // No confirmes ni niegues la existencia del correo electrónico por razones de seguridad.
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);

                // Construye el HTML del correo aquí...
                var htmlMessage = $"Por favor cambia la contraseña de tu cuenta haciendo clic <a href='{callbackUrl}'>aquí</a>.";

                await _emailSender.SendEmailAsync(model.Email, "Restablecer contraseña", htmlMessage);
            }

            // Independientemente de si el usuario existe o no, muestra el mismo mensaje.
            return View("ForgotPasswordConfirmation");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine($"Intentando restablecer la contraseña para el usuario: {model.UserId}");
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    // No revelar que el usuario no existe
                    Console.WriteLine($"No se encontró un usuario con el correo: {model.UserId}");
                    TempData["ErrorMessage"] = "Ha ocurrido un error al restablecer tu contraseña.";
                    return RedirectToAction("forgotpassword", "Account");
                }

                Console.WriteLine($"Restableciendo la contraseña para el usuario: {model.UserId}");
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    Console.WriteLine($"La contraseña para el usuario {model.UserId} ha sido restablecida con éxito.");
                    TempData["SuccessMessage"] = "Tu contraseña ha sido restablecida con éxito.";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    // Aquí puedes manejar diferentes tipos de errores, por ejemplo:
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        Console.WriteLine($"Error al restablecer la contraseña para el usuario {model.UserId}: {error.Description}");
                    }
                }
            }

            // Si llegamos hasta aquí, algo falló, vuelve a mostrar el formulario
            return View(model);
        }

    }
}
