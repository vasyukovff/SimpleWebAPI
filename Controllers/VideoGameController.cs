using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Dto;
using SimpleWebAPI.Models;
using SimpleWebAPI.Repositories.Interfaces;

namespace SimpleWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGameController : Controller
    {
        private readonly IVideoGameRepository _repository;

        public VideoGameController(IVideoGameRepository rep)
        {
            _repository = rep;
        }

        [HttpGet]
        public IActionResult GetAll(int take = 10)
        {
            return Ok(_repository.GetAll(take));
        }

        [HttpPost]
        public IActionResult Add([FromBody] VideoGameModelDto data)
        {
            var result = _repository.Add(data);

            if (result.IsSuccess)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        [HttpPut]
        public IActionResult Update([FromBody] VideoGameModel data)
        {
            var result = _repository.Update(data);

            if (result.IsSuccess)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _repository.Remove(id);

            if (result.IsSuccess)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("find")]
        public IActionResult Find([FromQuery] IEnumerable<string> genres)
        {
            return Ok(_repository.Find(genres));
        }

    }
}
