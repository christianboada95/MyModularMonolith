using Microsoft.AspNetCore.Mvc;
using MyMonolith.Users.Application.Interfaces;
using MyMonolith.Users.Domain.Entities;

namespace MyMonolith.Users.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("[module]/[controller]")]
internal class UserController : Controller
{
    private readonly IPlaceHolderClient _placeHolderClient;

    public UserController(IPlaceHolderClient placeHolderClient)
    {
        _placeHolderClient = placeHolderClient;
    }

    // GET: api/users
    [HttpGet]
    public async Task<IEnumerable<User>> GetAsync()
    {
        return await _placeHolderClient.GetUsersAsync();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<User> Get(int id)
    {
        return await _placeHolderClient.GetUserAsync(id);
    }

    //// POST api/values
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/values/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/values/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}

