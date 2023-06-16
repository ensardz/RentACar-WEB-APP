using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentACar.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        db_RentContext db = new db_RentContext();
        // GET: api/<AdminController>
        [HttpGet]
        public IActionResult getAdmin() //za select svega
        {
            List<Admin> podaci = db.Admins.ToList();
            return Ok(podaci);
        }

        [HttpGet]
        public IActionResult vozila()
        {
            List<Vozilo> podaci = db.Vozilos.ToList();
            return Ok(podaci);
        }
        [HttpGet]
        public IActionResult korisnici()
        {
            List<Korisnik> podaci = db.Korisniks.ToList();
            return Ok(podaci);
        }

        [HttpGet]
        public IActionResult poruke()
        {
            List<Poruke> podaci = db.Porukes.ToList();
            return Ok(podaci);
        }

        [HttpGet]
        public IActionResult prikaziznajmljeno()
        {
            List<AdminPregledIznajmljena> podaci = db.AdminPregledIznajmljenas.OrderByDescending(r => r.VoziloId).ToList();
            return Ok(podaci);
        }

        [HttpPost]
        public IActionResult unosVozila([FromBody] Vozilo voziloPodaci)
        {
            db.Add(voziloPodaci);
            db.SaveChanges();
            return Ok(voziloPodaci.VoziloId);

        }

        [HttpDelete("{param:int}")]
        public IActionResult obrisiPodatak(int param)
        {
            Vozilo rezultat = db.Vozilos.Where(a => a.VoziloId == param).FirstOrDefault();
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

       

    }
}
