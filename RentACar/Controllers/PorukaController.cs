using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentACar.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PorukaController : ControllerBase
    {
        db_RentContext db = new db_RentContext();

        [HttpGet]
        public IActionResult poruke() 
        {
            List<Poruke> podaci = db.Porukes.ToList();
            return Ok(podaci);
        }

        [HttpPost]
        public IActionResult unosPoruke([FromBody] Poruke porukaPodaci)
        {
            db.Add(porukaPodaci);
            db.SaveChanges();
            return Ok(porukaPodaci.PorukaId);

        }

       
       
    }
}
