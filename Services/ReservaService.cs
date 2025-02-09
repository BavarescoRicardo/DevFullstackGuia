using DevFullstackGuia.DAO;
using DevFullstackGuia.DTO;
using DevFullstackGuia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFullstackGuia.Services
{
    public class ReservaService
    {
        private readonly ILogger<ReservaService> _logger;
        private readonly AppDbContext _context;

        public ReservaService(ILogger<ReservaService> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Reserva> FazerReserva(ReservaDTO reservaDTO)
        {
            // Fetch the related entities from the database using their codes
            var motel = await _context.Motel.FirstOrDefaultAsync(m => m.Id.ToString() == reservaDTO.Motel);
            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Id.ToString() == reservaDTO.Cliente);
            var suite = await _context.Suite.FirstOrDefaultAsync(s => s.Id.ToString() == reservaDTO.Suite);            

            if (motel == null || cliente == null || suite == null)
            {
                throw new ArgumentException("Invalid Motel, Cliente, or Suite code.");
            }

            // Create the Reserva entity
            var reserva = new Reserva
            {
                Data = reservaDTO.Data,
                Motel = motel,
                Cliente = cliente,
                Suite = suite
            };

            // Add the Reserva to the database
            _context.Reserva.Add(reserva);
            await _context.SaveChangesAsync();

            return reserva;
        }

        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            try
            {
                var reservas = await _context.Reserva
                    .Include(r => r.Motel)
                    .Include(r => r.Cliente)
                    .Include(r => r.Suite) 
                    .ToListAsync();
                return reservas;                
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error fetching motels from the database");
                return null;
            }
        }
    }
}