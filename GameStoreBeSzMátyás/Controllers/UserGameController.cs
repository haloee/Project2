using GameStoreBeSzMátyás.Context;
using GameStoreBeSzMátyás.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameStoreBeSzMatyas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGameController : ControllerBase
    {
        // GET: api/<ValuesController>
       private GameStoreContext _gameStoreContext;
        public UserGameController(GameStoreContext gameStoreContext)
        {
            _gameStoreContext = gameStoreContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetVideoGameUsers()
        {
            return Ok(await _gameStoreContext.UserVideo.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateGameUser(uservideo uservideo)
        {
            await _gameStoreContext.UserVideo.AddAsync(uservideo);
            await _gameStoreContext.SaveChangesAsync();
            return Ok(new {message="UserGame created"});
        }
    }
}
