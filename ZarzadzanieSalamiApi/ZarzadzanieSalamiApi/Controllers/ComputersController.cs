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
    [Route("api")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly ZarzadzanieSalamiRepository _provider;

        public ComputersController()
        {
            string connectionString = "Data Source=sql-ag1-listen.pjwstk.edu.pl;Initial Catalog=dziekanat_hash;Integrated Security=True";
            _provider = new ZarzadzanieSalamiRepository(connectionString);
        }

        [HttpGet("komputer")]
        public ActionResult<List<Komputer>> GetAllKomputer()
        {
            return _provider.GetAllKomputer().ToList();
        }

        [HttpGet("maszynawirtualna")]
        public ActionResult<List<MaszynaWirtualna>> GetAllMaszynaWirtualna()
        {
            return _provider.GetAllMaszynaWirtualna().ToList();
        }

        [HttpGet("monitor")]
        public ActionResult<List<Monitor>> GetAllMonitor()
        {
            return _provider.GetAllMonitor().ToList();
        }

        [HttpGet("oprogramowanie")]
        public ActionResult<List<Oprogramowanie>> GetAllOprogramowanie()
        {
            return _provider.GetAllOprogramowanie().ToList();
        }

        [HttpGet("oprogramowaniekomputerow")]
        public ActionResult<List<OprogramowanieKomputerow>> GetAllOprogramowanieKomputerow()
        {
            return _provider.GetAllOprogramowanieKomputerow().ToList();
        }
    }
}