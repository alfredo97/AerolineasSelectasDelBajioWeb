using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AerolineasSelectasDelBajioWeb_UI.ViewModels
{
    public class TicketViewModel
    {
        public List<AerolineasSelectasDelBajioWeb_Entities.Ticket> TicketList { get; set; }

        public string CreditCard { get; set; }

        public string Name { get; set; }

        public string PassengerType { get; set; }
    }
}
