

using SurveyBaskets.BLL.Contracts.Polls;

namespace SurveyBackets.PL.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollServices pollServices) : ControllerBase
    {
        private readonly IPollServices _pollServices = pollServices;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var poll = await _pollServices.GetAllAsync();
            var polls = poll.Adapt<IEnumerable<PollResponse>>();
            return poll is null ? NoContent() : Ok(polls);

        }
        [HttpGet("getById/{id}")]

        public async Task<IActionResult> getById(int id)
        {
            var poll = await pollServices.getByIdAsync(id);

            return poll is null ? NoContent() : Ok(poll.Adapt<PollResponse>());


        }
        [HttpPost("Add")]
        public async Task<IActionResult> add(PollRequest? poll,CancellationToken cancellationToken)
        {
            var map = poll.Adapt<Poll>();
            var x =await _pollServices.AddNewAsync(map,cancellationToken);
            return poll is null ? NoContent() : Created();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Poll pool,CancellationToken cancellationToken)
        {
            var result = await _pollServices.UpdateAsync(id, pool,cancellationToken);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delete(int id ,CancellationToken cancellationToken)
        {
            var result =await _pollServices.DeleteAsync(id,cancellationToken);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPatch("{id}/TogglePublish")]
        public async Task<IActionResult> TogglePublishStatus(int id,CancellationToken cancellationToken)
        {
            var result =await _pollServices.TogglePublishStatusAsync(id,cancellationToken);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}

