using GameStoreBeSzMátyás.Context;
using GameStoreBeSzMátyás.Models;
using GameStoreBeSzMátyás.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Core;
using System.Security.Cryptography;
using System.Text;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameStoreBeSzMátyás.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GameStoreContext _context;

        public UserController(GameStoreContext context)
        {
            _context = context;
        }

        // 1. nincs repo
        // 2. interface, implementálni a repoba, és DI (program.cs-be)
        
        // GET: api/<ValuesController>
        [HttpGet]
        
        //public async Task<ActionResult> GetByIdAsync(int id)
        //{
        //    var data = await _context.User.FirstOrDefaultAsync(a => a.Id == id);
        //    return Ok(data);
        //}
        public async Task<ActionResult<IEnumerable<User_entity>>> GetAllUsers()
        {
            var users=await _context.User.Include(u=>u.VideoGame_Entities).ToListAsync();
            return Ok(users);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        public async Task<ActionResult<User_entity>> GetUserById(int id)
        {
            var user=await _context.User.Include(u=>u.VideoGame_Entities).FirstOrDefaultAsync(u=>u.Id==id);
            if(user==null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<ValuesController>

        //[HttpPost]
        //public async Task<ActionResult> Create1( User_entity createuser)
        //{
        //    User_entity user = new User_entity();
        //    user.Id=createuser.Id;
        //    user.Email = createuser.Email;
        //    user.PasswordHash = createuser.PasswordHash;
                
           
        //    _context.Add(user);
        //   _context.Add(createuser);
        //    _context.Add(user);
        //    await _context.SaveChangesAsync();
        //    _context.SaveChanges();
        //    return Ok(_context);
            
        //}
        [HttpPost("Create")]
        //public async Task Create(User_entity user)
        //{
        //    _context.User.Add(user);
        //    await _context.SaveChangesAsync();
        //}
        public async Task<ActionResult<User_entity>> Create(User_entity user)
        {
var passwordHasher=new PasswordHasher<User_entity>();
            user.PasswordHash = passwordHasher.HashPassword(user, user.PasswordHash);
            _context.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUserById",new {id=user.Id},user);
        }
        //[HttpGet("GetAll")]
        //public IEnumerable<User_entity> GetAll() 
        //{

        //    var data = _context.User.ToList();
        //    return data;
        //}

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        public async Task<ActionResult<User_entity>> Update(int id,User_entity user)
        {
            if (id !=user.Id)
            {
                return BadRequest();
            }
            var existingUser=await _context.User.FindAsync(id);
            if(existingUser == null)
            {
                return NotFound();
            }
            existingUser.Email = user.Email;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //[HttpPut] 
        //public async Task Update1(int id, User_entity entity)
        //{
        //    var data=_context.User.Where(a=>a.Id==id).FirstOrDefault();
        //    if (data!=null)
        //    {
        //        data.Id = id;
        //        data.Email = entity.Email;
        //        await _context.SaveChangesAsync();
        //    }
        //}

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        public async Task<ActionResult<User_entity>> Delete(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user==null)
            {
                return NotFound();
            }
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //public string HashPassword(string password,out byte[] salt)
        //{
        //    const int keysize = 255;
        //    HashAlgorithmName hashAlgorithmName = HashAlgorithmName.SHA512;
        //    const int iterations = 350000;
        //    salt=RandomNumberGenerator.GetBytes(keysize);
        //    var hash = Rfc2898DeriveBytes.Pbkdf2(
        //        Encoding.UTF8.GetBytes(password), salt, iterations, hashAlgorithmName, keysize);
        //    return Convert.ToHexString(hash);
        //}
    }
}
