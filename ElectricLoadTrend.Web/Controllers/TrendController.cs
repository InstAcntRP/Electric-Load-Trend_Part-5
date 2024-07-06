using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ElectricLoadTrend.Services;
using ElectricLoadTrend.Model;

namespace ElectricLoadTrend.Web;

[ApiController]
[Route("[controller]")]
public class TrendController : ControllerBase
{
    private IGenerationDataService _genenerationDataService;

    public TrendController(IGenerationDataService genenerationDataService)
    {
        _genenerationDataService = genenerationDataService;
    }

     [HttpGet("[action]")]
    public IActionResult GetCurrentTime()
    {
        string dt = string.Empty;
        dt = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
        return Ok(dt);
    }

      [HttpGet("[action]")]

        public IActionResult GetGenerationData()
        {
            List<GenerationData> generationDataList = new List<GenerationData>();
            generationDataList =_genenerationDataService.GetGenerationData();
            return Ok(generationDataList);
        }
}
