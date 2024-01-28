using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Core.Shared.DTOs
{
    public class CategoryDto : BaseDto
    {
        public int Id { get; set; }
        [Display(Name="Nombre de la categoría")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string Name { get; set; }

        [Display(Name="Enlace de categoría")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string Url { get; set; }
    }
}
