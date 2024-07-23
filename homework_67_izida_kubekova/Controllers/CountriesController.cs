using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using homework_67_izida_kubekova.Models;
using homework_67_izida_kubekova.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace homework_67_izida_kubekova.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly CountryContext _db;

        public CountriesController(CountryContext db)
        {
            _db = db;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get(int? id, string name)
        {
            if (id.HasValue)
            {
                Country country = await _db.Countries.FirstOrDefaultAsync(c => c.Id == id);
                if (country == null)
                    return NotFound();
                return new ObjectResult(country);
            }

            if (!string.IsNullOrEmpty(name))
            {
                Country country = await _db.Countries.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
                if (country == null)
                    return NotFound();
                return new ObjectResult(country);
            }
            
            return await _db.Countries.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Country>> Post(Country country)
        {
            if (country == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _db.Countries.Add(country);
            await _db.SaveChangesAsync();
            return Ok(country);
        }
        
        [HttpPut]
        public async Task<ActionResult<Country>> Put(Country country)
        {
            if (country == null)
                return BadRequest();
            if (!_db.Countries.Any(s => s.Id == country.Id))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _db.Update(country);
            await _db.SaveChangesAsync();
            return Ok(country);
        }

        [HttpDelete]
        public async Task<ActionResult<Country>> Delete(int id)
        {
            Country country = _db.Countries.FirstOrDefault(s => s.Id == id);
            if (country == null)
                return NotFound();
            _db.Countries.Remove(country);
            await _db.SaveChangesAsync();
            return Ok(country);
        }
    }
}