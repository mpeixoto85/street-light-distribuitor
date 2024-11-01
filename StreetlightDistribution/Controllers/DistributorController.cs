using Microsoft.AspNetCore.Mvc;
using StreetlightDistribution.Logic.Interfaces;
using StreetlightDistribution.Model.DTO;

namespace StreetlightDistribution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistributorController : ControllerBase
    {
        
        private readonly ILogger<DistributorController> _logger;
        private readonly IStreetlightDistributor _distributor;

        public DistributorController(ILogger<DistributorController> logger, IStreetlightDistributor distributor)
        {
            _logger = logger;
            _distributor = distributor;
        }

        [HttpGet("LightDistributionResponse")]
        public ActionResult LightDistributionResponse([FromBody] StreetlightRequest neighbourhood)
        {
            if(neighbourhood == null || neighbourhood.Neighbourhood == null)
            {
                return BadRequest(error: "The neighbourhood can't be empty");
            }
            try
            {
                var response = _distributor.DistributeStreetlights(neighbourhood);
                return Ok(response);
            }
            
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }
            
        }
    }
}
