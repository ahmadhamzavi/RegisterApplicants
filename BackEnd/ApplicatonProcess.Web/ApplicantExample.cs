
using ApplicationProcess.Service;
using Swashbuckle.AspNetCore.Filters;

namespace ApplicationProcess.Web
{
    public class ApplicantExample : IExamplesProvider<ApplicantDto>
    {
        public ApplicantDto GetExamples()
        {
            return new ApplicantDto()
            {
                Name = "13245",
                FamilyName = "123465",
                CountryOfOrigign = "aruba",
                Age = 30,
                Address = "01234567891234567",
                EMailAddress = "asfd@gdfg.fgfd",
            };
        }
    }
}
