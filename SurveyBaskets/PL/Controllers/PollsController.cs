




using SurveyBaskets.BLL.Contracts.Requests;

namespace SurveyBackets.PL.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollServices pollServices) : ControllerBase
    {
        private readonly IPollServices _pollServices = pollServices;
        [HttpGet]
        public IActionResult GetAll() 
        {
            var poll= _pollServices.GetAll();
            var polls=poll.Adapt<IEnumerable<PollResponse>>();
            return poll is null ? NoContent() : Ok(polls);
            
        }
        [HttpGet("getById/{id}")]
        
        public IActionResult getById(int id)
        {
           var poll=pollServices.getById(id);
            
            return poll is null ? NoContent() : Ok(poll.Adapt<PollResponse>());


        }
        [HttpPost("Add")]
        public IActionResult add(CreatePollRequest? poll)
        {
            var map = poll.Adapt<Poll>();
            var x = _pollServices.AddNew(map);
            return poll is null ? NoContent() : Created();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,Poll pool)
        {
            var result =_pollServices.Update(id, pool);
            if(!result)
            {
                return NotFound();
            }
            return NoContent(); 
        }
        [HttpDelete("Delete{id}")]
        public IActionResult Delete(int id)
        {
            var result=_pollServices.Delete(id);
            if(!result)
                return NotFound();
            return Ok();
        }
    }
}
