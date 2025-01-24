
using SurveyBackets.BLL.Services;

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
            return poll is null ? NoContent() : Ok(poll);
            
        }
        [HttpGet("getById/{id}")]
        
        public IActionResult getById(int id)
        {
           var poll=pollServices.getById(id);
            return poll is null ? NoContent() : Ok(poll);


        }
        [HttpPost("Add")]
        public IActionResult add(Poll pool)
        {
            var poll = _pollServices.AddNew(pool);
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
