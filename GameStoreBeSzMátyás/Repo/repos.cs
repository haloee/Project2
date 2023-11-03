using System.Net;
using GameStoreBeSzMátyás.Context;
using GameStoreBeSzMátyás.Models;
using GameStoreBeSzMátyás.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBeSzMátyás.Repo
{
    public class repos
    {
        private readonly GameStoreContext _context;
        public repos(GameStoreContext context)
        {
             _context=context;
        }
        public IEnumerable<User_entity> GetAll()
        {
            var data= _context.User.ToList();
            return data;
        }
        public User_entity GetById(int inputid) 
        { 
        var data=_context.User.FirstOrDefault(a=>a.Id==inputid);
            return data;
        }
        public async Task Create(User_entity user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User_entity>> GetByIdAsync(int inputid)=>await _context.User.Where(c=>c.Id==inputid).ToListAsync();
    }
}
