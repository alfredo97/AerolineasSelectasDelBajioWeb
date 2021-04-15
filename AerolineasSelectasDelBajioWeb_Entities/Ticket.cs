using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AerolineasSelectasDelBajioWeb_Entities
{
    public partial class Ticket
    {
        [Display(Name = "Id")]
        public int TicketId { get; set; }
        
        [Display(Name = "# Asiento")]
        public int TicketNPlace { get; set; }

        [Display(Name = "Precio")]
        public decimal TicketPrice { get; set; }

        [Display(Name = "Hora salida")]
        public DateTime TicketDepartureTime { get; set; }

        [Display(Name = "Id Avión")]
        public int TicketAirplaneId { get; set; }
        
        [Display()]
        public int TicketSourceDestinyId { get; set; }

        [Display(Name = "Venta")]
        public int TicketSaleId { get; set; }

        [Display(Name = "Avión")]
        public virtual Airplane TicketAirplane { get; set; }
        public virtual Sale TicketSale { get; set; }

        [Display(Name = "Origen-Destino")]
        public virtual SourceDestiny TicketSourceDestiny { get; set; }

        [NotMapped]
        public bool InShopCart { get; set; }


    }
}
