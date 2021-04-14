using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AerolineasSelectasDelBajioWeb_Entities
{
    public partial class Airplane
    {
        public Airplane()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int AirplaneId { get; set; }
        
        [Required]
        [Display(Name = "Cantidad de asientos")]
        public int AirplaneNplaces { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string AirplaneName { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }

}
