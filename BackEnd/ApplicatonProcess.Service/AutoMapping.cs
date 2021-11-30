using ApplicationProcess.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationProcess.Service
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Applicant,ApplicantDto>(); // means you want to map from Applicant to ApplicantDto
            CreateMap<ApplicantDto, Applicant>(); // means you want to map from ApplicantDto to Applicant
        }
    }
}
