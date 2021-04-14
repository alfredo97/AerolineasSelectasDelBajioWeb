using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AerolineasSelectasDelBajioWeb_Entities
{
    public partial class SourceDestiny
    {
        public SourceDestiny()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int SourceDestinyId { get; set; }
        
        [Display(Name = "Origen")]
        public int SourceDestinyFrom { get; set; }

        [Display(Name = "Destino")]
        public int SourceDestinyTo { get; set; }

        [Display(Name = "Origen")]
        public virtual City SourceDestinyFromNavigation { get; set; }

        [Display(Name = "Destino")]
        public virtual City SourceDestinyToNavigation { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }

        [NotMapped]
        public string custom { get { return SourceDestinyFromNavigation.CityName + " - " + SourceDestinyToNavigation.CityName; } set { } }



    }
}
