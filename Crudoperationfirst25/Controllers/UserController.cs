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
            var users= _context.Usersabc.ToList();

            return Ok(users);  //200 OK = Request successful
        }


        //get: getting data for specific data

        [HttpGet("GetByID/{id}")]
        public IActionResult Get(int id)
        {
            var user= _context.Usersabc.Find(id);

            if (user == null)
            {

                return NotFound();  //404 not found= Resourse not found in the database
            }
            return Ok(user); //200 ok
        }
        //Post: create a new resource
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



    }
}
