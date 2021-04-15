using AerolineasSelectasDelBajioWeb_Entities;
using AerolineasSelectasDelBajioWeb_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineasSelectasDelBajioWeb_Data.Repositories.Classes
{
    class AirplanesRepository : IAirplaneRepository
    {
        private AerolineasSelectasDelBajioContext _context;

        public AirplanesRepository(AerolineasSelectasDelBajioContext context)
        {
            _context = context;        }
        public async Task<Airplane> Add(Airplane airplane)
        {
            await _context.AddAsync(airplane);
            await _context.SaveChangesAsync();
            return airplane;
        }

        public bool Delete(Airplane airplane)
        {
            _context.Airplane.Remove(airplane);

            return true;
            
        }

        public async Task<Airplane> GetAirplane(int Id)
        {
            return await _context.Airplane.FindAsync(Id);
        }

        public IEnumerable<Airplane> GetAllAirplanes()
        {
            return _context.Airplane.ToList();
        }

        public Airplane Update(Airplane airplanes)
        {
            return _context.Airplane.Update(airplanes).Entity;
        }
    }
}
