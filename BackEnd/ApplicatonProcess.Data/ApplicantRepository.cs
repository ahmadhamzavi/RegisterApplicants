using ApplicationProcess.Domain;
using ApplicationProcess.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationProcess.Data
{
    public class ApplicantRepository : IRepository<Applicant, int>
    {
        private ApplicationDBContext _context;
        public ApplicantRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();
            return applicant.Id;
        }

        public async Task DeleteAsync(Applicant applicant)
        {
            _context.Applicants.Remove(applicant);
            await _context.SaveChangesAsync();
        }

        public async Task<Applicant> GetAsync(int Id)
        {
            return await _context.Applicants.FindAsync(Id);
        }

        public async Task<List<Applicant>> GetAllAsync()
        {
            return await _context.Applicants.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Applicant applicant)
        {
            _context.Update(applicant);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
