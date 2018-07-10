using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Classes;
using Mutantes;
using Microsoft.EntityFrameworkCore;

namespace Mutant.Controllers
{
    [Route("[controller]")]
    public class MutantController : ControllerBase
    {
        private readonly Classes.MutantContext _context;

        public MutantController(MutantContext context)
        {
            _context = context;
    }  

        [Route("/mutant/stats")]
        [HttpGet]
        public Classes.Stats  Get()
        {
            List<Classes.Mutant> l = _context.Mutants.ToList();
            Classes.Stats _stats = new Stats();
            functions _f = new functions();

            _stats = _f.statistics(l);
            
            return _stats;
        }

        [HttpPost]
        public void Post([FromBody] Classes.Mutant m)
        {
            if (m == null)
                this.HttpContext.Response.StatusCode = 500;
            else
            {
                if (m.DNA.Length > 0)
                {
                    
                    _context.Add(m);
                    _context.SaveChanges();
                    functions _f = new functions();
                    if (_f.isMutant(m))
                        this.HttpContext.Response.StatusCode = 200;
                    else
                        this.HttpContext.Response.StatusCode = 403;
                }
                else
                {
                    this.HttpContext.Response.StatusCode = 500;
                }
            }
        }



    }
    
}
