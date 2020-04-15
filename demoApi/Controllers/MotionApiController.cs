using demoApi.Application.Abstract.Motion;
using demoApi.Application.Concrete;
using demoApi.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace demoApi.Concrete
{
    public class MotionApiController : Controller
    {
        private readonly IMotionService _moveService;
        public MotionApiController(IMotionService moveService)
        {
            _moveService = moveService;
        }


        [HttpGet]
        [Route("Save")]
        public async Task<IActionResult> SavePosition([FromBody] HandlerRequest request)
        {
            var position = await _moveService.SavePosition();

            if (position.Status == CommandStatus.Ack)
                return Ok(position);
            return StatusCode(422, position);
        }

        [HttpGet]
        [Route("Lock")]
        public async Task<IActionResult> Lock()
        {
            var response = await _moveService.Lock();
            if (response.Status == CommandStatus.Ack)
                return Ok(response);
            return StatusCode(422, response);
        }

        [HttpGet]
        [Route("UnLock")]
        public async Task<IActionResult> UnLock()
        {
            var response = await _moveService.Unlock();
            if (response.Status == CommandStatus.Ack)
                return Ok(response);
            return StatusCode(422, response);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetCurrentPosition()
        {
            var currentPosition = await _moveService.GetCurrentPosition();

            if (currentPosition.Status == CommandStatus.Ack)
                return Ok(currentPosition);
            return StatusCode(422, currentPosition);
        }

        [HttpPost]
        [Route("Get")]
        public async Task<IActionResult> GetPosition([FromBody] HandlerRequest request)
        {
            var position = await _moveService.GetPosition(request.Position.PositionId);

            if (position.Status == CommandStatus.Ack)
                return Ok(position);
            return StatusCode(422, position);
        }

        [HttpPost]
        [Route("Move")]
        public async Task<IActionResult> Move([FromBody] HandlerRequest request)
        {
            var response = await _moveService.Move(request.Position);
            if (response.Status == CommandStatus.Ack)
                return Ok(response);
            return StatusCode(422, response);
        }
    }
}
