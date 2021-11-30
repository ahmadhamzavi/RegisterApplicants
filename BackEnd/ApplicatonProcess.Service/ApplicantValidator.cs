using FluentValidation;
using ApplicationProcess.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationProcess.Service
{
    public class ApplicantValidator : AbstractValidator<ApplicantDto>
    {
        public ApplicantValidator()
        {
            RuleFor(applicant => applicant.Name).NotEmpty().WithMessage("Name is missing").MinimumLength(5).WithMessage("FamilyName must be at least 5."); 
            RuleFor(applicant => applicant.FamilyName).NotEmpty().WithMessage("FamilyName is missing").MinimumLength(5).WithMessage("FamilyName must be at least 5.");
            RuleFor(applicant => applicant.Address).NotEmpty().WithMessage("Address is missing").MinimumLength(10).WithMessage("Address must be at least 10.");
            RuleFor(applicant => applicant.EMailAddress).NotEmpty().WithMessage("EMailAddress is missing").EmailAddress().WithMessage("EMailAddress is not a valid email.");
            RuleFor(applicant => applicant.Age).GreaterThanOrEqualTo(20).LessThanOrEqualTo(60).WithMessage("Age must be between 20 and 60.");
            RuleFor(applicant => applicant.Hired).NotNull().WithMessage("Hires is missing"); 
            RuleFor(applicant => applicant.CountryOfOrigign).NotEmpty().WithMessage("Country is not valid");
        }
       
    }
}
