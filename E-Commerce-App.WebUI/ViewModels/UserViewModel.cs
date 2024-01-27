using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.WebUI.ViewModels
{
    public class UserViewModel
    {
        public class UserAccountViewModel
        {
            [Required(ErrorMessage = "Por favor introduzca su nombre y apellido.")]
            [StringLength(maximumLength: 40, MinimumLength = 4, ErrorMessage = "El nombre y apellido deben tener entre 5 y 40 caracteres.")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Por favor, introduzca su dirección de correo electrónico.")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [DataType(DataType.Password)]
            [StringLength(maximumLength:30,MinimumLength =8, ErrorMessage ="La contraseña debe tener entre 8 y 30 caracteres.")]
            public string NewPassword { get; set; }
            [DataType(DataType.Password)]
            [Compare("NewPassword", ErrorMessage ="Las contraseñas no coinciden")]
            public string RePassword { get; set; }
        }
        public class RegisterViewModel
        {
            [Required(ErrorMessage = "Por favor introduzca su nombre y apellido.")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Por favor, introduzca su dirección de correo electrónico.")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required(ErrorMessage = "Por favor, introduzca su contraseña.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
        public class LoginViewModel
        {
            [Required(ErrorMessage = "Por favor, introduzca su dirección de correo electrónico.")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required(ErrorMessage = "Por favor, introduzca su contraseña.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public string ReturnUrl { get; set; }
        }
        public class ResetPasswordViewModel
        {
            [Required]
            public string Token { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required(ErrorMessage = "Por favor, introduzca su contraseña.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
