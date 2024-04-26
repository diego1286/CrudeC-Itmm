
using System.Data.Entity;
using ebooksItm.Data;
using ebooksItm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace ebooksItm.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }


        //all users
        [HttpGet(Name = "GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }


        //user for ID
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        //Creation de users
        [HttpPost(Name = "PostUser")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetUser", new { id = user.Id }, user);
        }

        //Update user
        [HttpPut("{id}")]
        public async Task<ActionResult>Put(int id, User user){
            if(id != user.Id){
                return BadRequest();
            }
           _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

              try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

         // Agregar una reseña a un libro
    [HttpPost("{userId}/reviews")]
    public async Task<ActionResult<Review>> AddReview(int userId, Review review)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
            return NotFound("Usuario no encontrado");
        }

        var ebook = await _context.Ebooks.FindAsync(review.EbookId);
        if (ebook == null)
        {
            return NotFound("Libro no encontrado");
        }

        // Asignar el usuario y el libro a la revisión
        review.UserId = userId;
        review.User = user;
        review.Ebook = ebook;

        // Agregar la revisión a la base de datos
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReview", new { id = review.Id }, review);
    }



        





    }
}