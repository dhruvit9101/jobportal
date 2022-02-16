using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Recruiters;
using Microsoft.AspNetCore.Mvc;
using API.Models.Recruiters;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecruitersController : ControllerBase
    {
        private readonly DataContext _context;
        public RecruitersController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recruiter>>> GetRecruiters()
        {
            return await _context.Recruiters.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Recruiter>> GetRecruiters(int id)
        {
            return await _context.Recruiters.FindAsync(id);
        }
    }
}