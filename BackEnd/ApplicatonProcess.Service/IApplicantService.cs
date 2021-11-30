using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationProcess.Service
{
    public interface IApplicantService
    {
        public Task<Result<int>> CreateAsync(ApplicantDto applicantDto);
        public Task<ApplicantDto> GetAsync(int Id);
        public Task<List<ApplicantDto>> GetAllAsync();
        public Task<bool> UpdateAsync(ApplicantDto applicantDto);
        public Task DeleteAsync(int id);

    }
}
