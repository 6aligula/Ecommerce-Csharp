using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Core.Shared.DTOs
{
    public class BaseDto
    {
        [Display(Name ="Fecha de creación")]
        public DateTime? CreationDate { get; set; }
        [Display(Name = "fecha de actualización")]
        public DateTime? DateOfUpdate { get; set; }
        public bool IsActive { get; set; }
    }
}
