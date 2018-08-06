using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZarzadzanieSalamiApi.Models;


namespace ZarzadzanieSalamiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class RoomsController : ControllerBase
    {
        private readonly ZarzadzanieSalamiRepository _provider;
        
        public RoomsController()
        {
            string connectionString = "Data Source=sql-ag1-listen.pjwstk.edu.pl;Initial Catalog=dziekanat_hash;Integrated Security=True";
            _provider = new ZarzadzanieSalamiRepository(connectionString);
        }

        [HttpGet("budynek")]
        public ActionResult<List<Budynek>> GetAllBudynek()
        {
            return _provider.GetAllBudynek().ToList();
        }

        [HttpGet("budynek/{id}")]
        public ActionResult<Budynek> GetBudynek(int id)
        {
            Budynek b = _provider.GetBudynek(id);
            if (b == null)
                return NotFound();
            return b;
        }

        [HttpPost("budynek")]
        public IActionResult AddBudynek([FromBody] Budynek b)
        {
            _provider.AddBudynek(b);
            return CreatedAtRoute("api", new { IdBudynek = b.IdBudynek }, b);
        }

        [HttpGet("funkcjasali")]
        public ActionResult<List<FunkcjaSali>> GetAllFunkcjaSali()
        {
            return _provider.GetAllFunkcjaSali().ToList();
        }

        [HttpGet("funkcjasali/{id}")]
        public ActionResult<FunkcjaSali> GetFunkcjaSali(int id)
        {
            FunkcjaSali fs = _provider.GetFunkcjaSali(id);
            if (fs == null)
                return NotFound();
            return fs;
        }

        [HttpGet("kampus")]
        public ActionResult<List<Kampus>> GetAllKampus()
        {
            return _provider.GetAllKampus().ToList();
        }

        [HttpGet("kampus/{id}")]
        public ActionResult<Kampus> GetKampus(int id)
        {
            Kampus k = _provider.GetKampus(id);
            // to give some information to the browser
            if (k == null)
                return NotFound();
            return k;
        }

        [HttpGet("rozkladsali")]
        public ActionResult<List<RozkladSali>> GetAllRozkladSali()
        {
            return _provider.GetAllRozkladSali().ToList();
        }

        [HttpGet("rozkladsali/{id}")]
        public ActionResult<RozkladSali> GetRozkladSali(int id)
        {
            RozkladSali rs = _provider.GetRozkladSali(id);
            if (rs == null)
                return NotFound();
            return rs;
        }

        [HttpGet("sala")]
        public ActionResult<List<Sala>> GetAllSala()
        {
            return _provider.GetAllSala().ToList();
        }

        [HttpPost("sala")]
        public IActionResult AddSala([FromBody] Sala s)
        {
            _provider.AddSala(s);
            return CreatedAtRoute("api", new { IdSala = s.IdSala }, s);
        }

        [HttpGet("sala/{id}")]
        public ActionResult<Sala> GetSala(int id)
        {
            Sala s = _provider.GetSala(id);
            if (s == null)
                return NotFound();
            return s;
        }

        [HttpGet("saladydaktyczna")]
        public ActionResult<List<SalaDydaktyczna>> GetAllSalaDydaktyczna()
        {
            return _provider.GetAllSalaDydaktyczna().ToList();
        }

        [HttpGet("saladydaktyczna/{id}")]
        public ActionResult<SalaDydaktyczna> GetSalaDydaktyczna(int id)
        {
            SalaDydaktyczna sd = _provider.GetSalaDydaktyczna(id);
            if (sd == null)
                return NotFound();
            return sd;
        }

    }
}