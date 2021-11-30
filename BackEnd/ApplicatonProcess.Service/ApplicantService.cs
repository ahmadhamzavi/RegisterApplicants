using ApplicationProcess.Domain;
using ApplicationProcess.Domain.Interfaces;
using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationProcess.Service
{
    public class ApplicantService : IApplicantService
    {
        private readonly ApplicantValidator _applicantValidator;
        private readonly IRepository<Applicant, int> _applicantRepository;
        private readonly IMapper _mapper;
        public ApplicantService(IRepository<Applicant, int> applicantRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _applicantValidator = new ApplicantValidator();
            _mapper = mapper;
        }
        public async Task<Result<int>> CreateAsync(ApplicantDto applicantDto)
        {
            var result = new Result<int>();
            var validation = (await _applicantValidator.ValidateAsync(applicantDto));
            if (validation.IsValid)
            {
                try
                {
                    var applicant = _mapper.Map<Applicant>(applicantDto);
                    result.Data = await _applicantRepository.CreateAsync(applicant);
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    validation.Errors.Add(new ValidationFailure(null, ex.Message));
                }
            }
            result.Errors = validation.Errors;
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var applicant = await _applicantRepository.GetAsync(id);
            if (applicant != null)
            {
                await _applicantRepository.DeleteAsync(applicant);
            }
        }

        public async Task<ApplicantDto> GetAsync(int Id)
        {
            var applicant = await _applicantRepository.GetAsync(Id);
            var applicantDto = _mapper.Map<ApplicantDto>(applicant);
            return applicantDto;
        }

        public async Task<List<ApplicantDto>> GetAllAsync()
        {
            var applicants = await _applicantRepository.GetAllAsync();
            var applicantDtos = _mapper.Map<List<ApplicantDto>>(applicants);
            return applicantDtos;
        }

        public async Task<bool> UpdateAsync(ApplicantDto applicantDto)
        {
            if (_applicantValidator.Validate(applicantDto).IsValid)
            {
                var applicant = _mapper.Map<Applicant>(applicantDto);
                return await _applicantRepository.UpdateAsync(applicant);
            }
            return false;
        }
    }
}
