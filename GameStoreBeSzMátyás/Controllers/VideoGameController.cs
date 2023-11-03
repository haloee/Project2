using GameStoreBeSzMátyás.Context;
using GameStoreBeSzMátyás.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameStoreBeSzMátyás.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly GameStoreContext _context;
        public VideoGameController(GameStoreContext context)
        {
            _context = context;
        }
        // GET: api/<VideoGameController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<VideoGameController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<VideoGameController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<VideoGameController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<VideoGameController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGame_entity>>> GetAllVideoGames()
        {
            var videoGames = await _context.VideoGame.ToListAsync();
            return Ok(videoGames);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame_entity>> GetVideoGameById(int id)
        {
            var videoGame = await _context.VideoGame.FindAsync(id);

            if (videoGame == null)
            {
                return NotFound();
            }

            return Ok(videoGame);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame_entity>> CreateVideoGame(VideoGame_entity videoGame)
        {
            _context.VideoGame.Add(videoGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideoGameById", new { id = videoGame.Id }, videoGame);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VideoGame_entity>> UpdateVideoGame(int id, VideoGame_entity videoGame)
        {
            if (id != videoGame.Id)
            {
                return BadRequest();
            }

            var existingVideoGame = await _context.VideoGame.FindAsync(id);
            if (existingVideoGame == null)
            {
                return NotFound();
            }

            existingVideoGame.Title = videoGame.Title;
            existingVideoGame.Description = videoGame.Description;
            existingVideoGame.Type = videoGame.Type;
            existingVideoGame.Price = videoGame.Price;
            existingVideoGame.Rating = videoGame.Rating;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VideoGame_entity>> DeleteVideoGame(int id)
        {
            var videoGame = await _context.VideoGame.FindAsync(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            _context.VideoGame.Remove(videoGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
