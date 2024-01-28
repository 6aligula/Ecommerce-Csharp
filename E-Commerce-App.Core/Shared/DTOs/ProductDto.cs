using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Core.Shared.DTOs
{
    public class ProductDto : BaseDto
    {
        public string Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        [MinLength(2, ErrorMessage = "El nombre del producto puede constar de al menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "El nombre del producto puede constar de un máximo de 50 letras.")]
        public string Name { get; set; }

        [Display(Name = "Conexión")]
        [MinLength(2, ErrorMessage = "El enlace del producto puede constar de al menos 2 letras.")]
        [MaxLength(80, ErrorMessage = "El enlace del producto puede constar de un máximo de 80 letras.")]
        public string Url { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        [Range(1, 1000000, ErrorMessage = "Debe ingresar un valor entre 1 y 1000000.")]
        public double? Price { get; set; }

        [Display(Name = "Tasa de descuento")]
        [Range(1, 100, ErrorMessage = "Debe ingresar un valor entre 1 y 100.")]
        public double? Discount { get; set; }

        [Display(Name = "Explicación")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string ShortDescription { get; set; }

        [Display(Name = "Descripción detallada")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string Description { get; set; }

        [Display(Name = "¿El producto debería aparecer en la página de inicio?")]
        public bool IsHome { get; set; }

        [Display(Name = "Foto de cubierta")]
        public string MainImage { get; set; }


        public ICollection<ImageDto> Images { get; set; }
        public ICollection<ProductColorDto> ProductColors { get; set; }
        public ICollection<ProductCategoryDto> ProductCategories { get; set; }
    }
}
