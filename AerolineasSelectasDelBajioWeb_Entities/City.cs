using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AerolineasSelectasDelBajioWeb_Entities
{
    public partial class City
    {
        public City()
        {
            SourceDestinySourceDestinyFromNavigation = new HashSet<SourceDestiny>();
            SourceDestinySourceDestinyToNavigation = new HashSet<SourceDestiny>();
        }

        
        public int CityId { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string CityName { get; set; }

        public virtual ICollection<SourceDestiny> SourceDestinySourceDestinyFromNavigation { get; set; }
        public virtual ICollection<SourceDestiny> SourceDestinySourceDestinyToNavigation { get; set; }
    }
}
