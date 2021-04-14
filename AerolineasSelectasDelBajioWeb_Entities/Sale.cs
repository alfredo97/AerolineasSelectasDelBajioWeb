using System;
using System.Collections.Generic;

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
        public decimal SaleTax { get; set; }
        public decimal SaleSubtotal { get; set; }
        public decimal SaleTotal { get; set; }
        public string SaleAspnetusersId { get; set; }

        public virtual AspNetUsers SaleAspnetusers { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
