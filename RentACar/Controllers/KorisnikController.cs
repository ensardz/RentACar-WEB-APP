using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentACar.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        db_RentContext db = new db_RentContext();
       // GET: api/<KorisnikController>
       [HttpGet]
        public IActionResult prikaz() 
        {
            List<Vozilo> podaci = db.Vozilos.ToList();
            return Ok(podaci);
        }
        [HttpGet]
        public IActionResult getVozila() //za select svega
        {
            List<Vozilo> podaci = db.Vozilos.OrderBy(r => r.VoziloId).ToList();
            return Ok(podaci);
        }

        [HttpPost]
        public IActionResult unosKorisnika([FromBody] Korisnik korisnikPodaci)
        {
            db.Add(korisnikPodaci);
            db.SaveChanges();
            return Ok(korisnikPodaci.KorisnikId);

        }

       






        // GET api/<KorisnikController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

       
    }
}
