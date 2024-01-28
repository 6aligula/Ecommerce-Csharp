using E_Commerce_App.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Core.Shared.DTOs
{
    public class OrderDto : BaseDto
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; }
        [Display(Name = "Fecha de orden")]
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Monto de compras")]
        public double TotalPrice { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        [MinLength(2, ErrorMessage = "Este campo puede constar de al menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "Este campo puede contener hasta 50 letras.")]
        public string FirstName { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        [MinLength(2, ErrorMessage = "Este campo puede constar de al menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "Este campo puede contener hasta 50 letras.")]
        public string LastName { get; set; }
        [Display(Name = "DIRECCIÓN")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        [MinLength(10, ErrorMessage = "Este campo puede constar de al menos 10 letras.")]
        [MaxLength(120, ErrorMessage = "Este campo puede contener hasta 120 letras.")]
        public string Address { get; set; }
        [Display(Name = "Provincia")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string City { get; set; }
        public string District { get; set; }
        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string PaymentId { get; set; }
        public string ConversationId { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        [Display(Name = "Estado del pedido")]
        public EnumOrderState OrderState { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
