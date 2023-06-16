using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentACar.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NarudzbaController : ControllerBase
    {
        // GET: api/<NarudzbaController>
        db_RentContext db = new db_RentContext();
        // GET: api/<KorisnikController>

        [HttpGet]
        public IActionResult prikaz() //Select svega
        {
            List<Iznajmljeno> podaci = db.Iznajmljenos.OrderByDescending(r => r.VoziloId).ToList();
            return Ok(podaci);
        }

        [HttpGet]
        public IActionResult IznajmljenaVozila() //Select svega
        {
            List<IznamljenaVozila> podaci = db.IznamljenaVozilas.OrderByDescending(r => r.VoziloId).ToList();
            return Ok(podaci);
        }

        [HttpPost]
        public IActionResult unosNarudzbe([FromBody] Iznajmljeno narudzbaPodaci)
        {
            db.Add(narudzbaPodaci);
            db.SaveChanges();
            return Ok(narudzbaPodaci.IznajmljenoId);

        }

        [HttpDelete("{param}")]
        public IActionResult obrisiPodatak(string param)
        {
            Iznajmljeno rezultat = db.Iznajmljenos.Where(a => a.Brojvozacke== param).FirstOrDefault();
            if (rezultat == null)
            {
                return NotFound($"Podatak sa ID = {param} nije pronadjen");
            }
            else
            {
                db.Remove(rezultat);
                db.SaveChanges();
            }
            return Ok("Obrisano");
        }


        // GET api/<NarudzbaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

      
    }
}
