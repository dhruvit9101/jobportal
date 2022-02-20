using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using API.Models.Recruiters;
using Microsoft.EntityFrameworkCore;
using API.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class RecruitersController : BaseAPIController
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
        [HttpPost("register")]
        public async Task<ActionResult<Recruiter>> Register(RecruiterDTOs recruiterDTOs)
        {
            using var hmac = new HMACSHA512();

            var recruiter = new Recruiter
            {
                UserName = recruiterDTOs.username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(recruiterDTOs.password)),
                PasswordSalt = hmac.Key
            };
            _context.Recruiters.Add(recruiter);
            await _context.SaveChangesAsync();

            return recruiter;
        }
    }
}