using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWspolnota.Models;
using Microsoft.Extensions.Logging;

namespace APIWspolnota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblInvoicesController : ControllerBase
    {
        private readonly HousingAssociationContext _context;
        private readonly ILogger _logger;

        public TblInvoicesController(HousingAssociationContext context, ILogger<TblInvoicesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Pobieranie Informacji o finansach
        /// </summary>
        /// <returns>Lista faktur</returns>
        // GET: api/TblInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblInvoices>>> GetTblInvoices()
        {
            return await _context.TblInvoices.ToListAsync();
        }

        /// <summary>
        /// Pobieranie Informacji o finansach
        /// </summary>
        /// <param name="id">id faktury</param>
        /// <returns>Faktura o wskazanym id</returns>
        // GET: api/TblInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblInvoices>> GetTblInvoices(int id)
        {
            _logger.LogInformation($"Ktoś wywołał zapytanie o fakturę o id: {id}");

            var tblInvoices = await _context.TblInvoices.FindAsync(id);

            if (tblInvoices == null)
            {
                _logger.LogError($"Faktura o id {id} nie istnieje, a ktoś jej szuka.");
                return NotFound();
            }

            return tblInvoices;
        }

        // PUT: api/TblInvoices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblInvoices(int id, TblInvoices tblInvoices)
        {
            if (id != tblInvoices.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblInvoices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblInvoicesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblInvoices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblInvoices>> PostTblInvoices(TblInvoices tblInvoices)
        {
            _context.TblInvoices.Add(tblInvoices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblInvoices", new { id = tblInvoices.Id }, tblInvoices);
        }

        // DELETE: api/TblInvoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblInvoices>> DeleteTblInvoices(int id)
        {
            var tblInvoices = await _context.TblInvoices.FindAsync(id);
            if (tblInvoices == null)
            {
                return NotFound();
            }

            _context.TblInvoices.Remove(tblInvoices);
            await _context.SaveChangesAsync();

            return tblInvoices;
        }

        private bool TblInvoicesExists(int id)
        {
            return _context.TblInvoices.Any(e => e.Id == id);
        }
    }
}
