using Microsoft.AspNetCore.Mvc;
using freecourse_api.Models;
using freecourse_api.Data;

namespace freecourse_api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Users>> GetUsers()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }
    [HttpPost]
    public ActionResult<Users> CreateUser(CreateUserReq userReq)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var existingUser = _context.Users.FirstOrDefault(u => u.Email == userReq    .Email);
        if (existingUser != null)
            return Conflict("User with this email already exists.");
        var user = new Users
        {
            Name = userReq.Name,
            Email = userReq.Email,
            Password = userReq.Password
        };
        _context.Users.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
            return NotFound();
        _context.Users.Remove(user);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, CreateUserReq userReq)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var user = _context.Users.Find(id);
        if (user == null)
            return NotFound();
        user.Name = userReq.Name;
        user.Email = userReq.Email;
        user.Password = userReq.Password;
        _context.SaveChanges();
        return NoContent();
    }

}
