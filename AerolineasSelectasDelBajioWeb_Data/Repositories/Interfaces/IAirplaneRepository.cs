using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AerolineasSelectasDelBajioWeb_Entities;

namespace AerolineasSelectasDelBajioWeb_Data.Repositories
{
    interface IAirplaneRepository
    {
        Task<Airplane> GetAirplane(int Id);
        IEnumerable<Airplane> GetAllAirplanes();

        Task<Airplane> Add(Airplane airplanes);

        Airplane Update(Airplane airplanes);

        bool Delete(Airplane airplanes);
    }
}
