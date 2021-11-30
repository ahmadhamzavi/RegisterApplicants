using ApplicationProcess.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationProcess.Web
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : Controller
    {
        private readonly IApplicantService _applicantService;
        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        /// <summary>         
        /// POST for Creating an Object –> returning an 201 on successful creation of the object
        /// </summary>
        /// <param name="applicantDto"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(ApplicantDto), typeof(ApplicantExample))]
        public async Task<IActionResult> Create([FromBody] ApplicantDto applicantDto)
        {
            var result = await _applicantService.CreateAsync(applicantDto);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Errors);
        }

        /// <summary>        
        /// GET with id parameter –> to ask for an object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ApplicantDto> Get(int id)
        {
            return await _applicantService.GetAsync(id);
        }
        /// <summary>        
        /// GET All
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ApplicantDto>> GetAll()
        {
            return await _applicantService.GetAllAsync();
        }
        /// <summary>        
        /// PUT – to update the object with the given id
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerRequestExample(typeof(ApplicantDto), typeof(ApplicantExample))]
        public async Task<IActionResult> Put([FromBody] ApplicantDto applicantDto)
        {
            var result = await _applicantService.UpdateAsync(applicantDto);
            if (result) { return Ok(); }
            return BadRequest();
        }
        /// <summary>        
        /// DELETE – to delete the object with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _applicantService.DeleteAsync(id);
            return Ok();
        }
    }
}
