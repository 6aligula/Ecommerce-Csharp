using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Core.Shared.DTOs
{
    public class CampaignDto : BaseDto
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de campaña")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string Name { get; set; }

        [Display(Name = "Imagen de campaña")]
        public string ImagePath { get; set; }

        [Display(Name = "Nombre de la etiqueta de la imagen de la campaña")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string ImageAltTag { get; set; }

        [Display(Name = "¿Debería aparecer en la página de inicio?")]
        public bool IsHome { get; set; }
    }
}
