using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AerolineasSelectasDelBajioWeb_Entities
{
    public partial class Sale
    {
        public Sale()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int SaleId { get; set; }
        [Display(Name = "Impuesto")]
        public decimal SaleTax { get; set; }
        
        [Display(Name = "Subtotal")]

        public decimal SaleSubtotal { get; set; }
        
        [Display(Name = "Total")]
        public decimal SaleTotal { get; set; }
        public string SaleAspnetusersId { get; set; }

        [Display(Name = "Numero de tarjeta")]
        public string SaleCreditcard { get; set; }
        
        [Display(Name = "Fecha de compra")]

        public DateTime SaleDate { get; set; }

        [Display(Name = "Tipo Pasajero")]

        public string SalePassengerType { get; set; }
        
        [Display(Name = "Nombre")]

        public string SaleName { get; set; }

        [Display(Name = "Usuario")]

        public virtual AspNetUsers SaleAspnetusers { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
