using Crudoperationfirst25.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crudoperationfirst25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        // what are the http methods?




        //get: retrieve data from server
        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            var users = _context.Usersabc.ToList();

            return Ok(users);  //200 OK = Request successful
        }


        //get: getting data for specific data


        // api/User/GetByID/7

        //Url:   //api/User/Getbyusernameandpasswrord/username:rama/Password:133
        [HttpGet("GetByID/{id}")]
        public IActionResult Get(int id)
        {
            var user = _context.Usersabc.Find(id);

            if (user == null)
            {

                return NotFound();  //404 not found= Resourse not found in the database
            }
            return Ok(user); //200 ok
        }
        //Post: create a new resource

        //api/User/Add
        [HttpPost("Add")]
        public IActionResult Create(User user)
        {
            _context.Usersabc.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get),
                  new { id = user.Id },
                  user);
            //201 Created= Record created successfully
        }

        //Put = api/User/Update/1
        //put =used to change the entire resource
        [HttpPut("Update/{id}")]

        public IActionResult Update(int id, User user)
        {

            var existingUser = _context.Usersabc.Find(id);

            if (existingUser == null)
            {
                return NotFound();  //404 not found 
            }
            if (!string.IsNullOrEmpty(user.Name))
            {
                existingUser.Name = user.Name;
            }
            if (!string.IsNullOrEmpty(user.Email))
            {
                existingUser.Email = user.Email;
            }
            _context.SaveChanges();
            return Ok(existingUser); /// 200 ok
        }

        //Patch= api/User/Patch/22

        //Patch== it is used to update only specific fields of resource

        [HttpPatch("Patch/{id}")]
        public IActionResult UpdatePatch(int id, User user)

        {
            var existUser = _context.Usersabc.Find(id);
            if(existUser==null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(user.Name))
            {
                existUser.Name = user.Name;
            }
            _context.SaveChanges();
            return Ok(existUser); //200 ok
        }

        [HttpDelete("Delete/{id}")]

        public IActionResult Delete(int id)
        {
            var user = _context.Usersabc.Find(id);
            if (user == null)
            {
                return NotFound();

            }

            _context.Usersabc.Remove(user);
            _context.SaveChanges();


            return NoContent();  // 204 no content deleted successfully
        }
    }
}
