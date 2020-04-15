using demoApi.Application;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace demoApi.Concrete
{
    public class MathApiController : Controller
    {
        private readonly IMathActions _mathActions;

        public MathApiController(IMathActions mathActions)
        {
            _mathActions = mathActions;
        }

        [HttpGet]
        [Route("Status")]
        public IActionResult Status()
        {
            return Ok("Status check");
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] ActionRequest request)
        {
            if (request == null)
                return BadRequest("request is empty");

            var result = await _mathActions.Add(request);
            return Ok(result);
        }

        [HttpPost]
        [Route("Devide")]
        public async Task<IActionResult> Devide([FromBody] ActionRequest request)
        {
            if (request == null)
                return BadRequest("request is empty");

            var result = await _mathActions.Devide(request);
            return Ok(result);
        }
    }
}
