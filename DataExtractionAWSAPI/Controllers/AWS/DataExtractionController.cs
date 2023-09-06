using DataExtractionService.Srvc.ConfigparamsSrvc.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DataExtractionAWSAPI.Controllers.AWS
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataExtractionController : Controller
    {

        private readonly IConfigParamsService _configParamsService;

        public DataExtractionController(IConfigParamsService configParamsService)
        {
            _configParamsService = configParamsService;
        }
        [HttpGet("GetAllFileFromAWS")]
        public async Task<IActionResult> GetAllFilesFROMAWSAsync(string bucketName)
        {
            try
            {
                return Ok(await _configParamsService.GetByConfigParamsValName(bucketName));
            }
            catch (TimeoutException timeoutexception)
            {
                return StatusCode(StatusCodes.Status408RequestTimeout, timeoutexception.Message);
            }
            catch (Exception exp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exp.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(string bucketName,string fileName)
        {
            try
            {
                return Ok(await _configParamsService.DeleteAsync(fileName, bucketName));
            }
            catch (TimeoutException timeoutexception)
            {
                return StatusCode(StatusCodes.Status408RequestTimeout, timeoutexception.Message);
            }
            catch (Exception exp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exp.Message);
            }
        }
        
    }
}
