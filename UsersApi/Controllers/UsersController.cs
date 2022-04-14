using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Models;
using UsersApi.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserServices _UserService;

        public UsersController(UserServices userServices) =>
            _UserService = userServices;




        [HttpGet]
        public ActionResult<List<User>> GetAllItem()
        {
            return _UserService.Get();
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var user = _UserService.Get(id);
            if(user == null)
            {
                return NotFound();
            }
            //return user;
            return Ok(user);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody]User user)
        {
            var user1=_UserService.Create(user);
            return CreatedAtAction(nameof(Get), new { id = user.id }, user);
            //return Ok(user1);

        }
        [HttpPut("{id}")]
        public IActionResult update(int id, User UserIn)
        {
            var user = _UserService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            UserIn._id = user._id;
            _UserService.Update(id, UserIn);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _UserService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            _UserService.Remove(user);
            return NoContent();
        }

        //[HttpGet("{id:length(24)}")]
        //public async Task<ActionResult<User>> Get(string id)
        //{
        //    var user = await _UserService.GetAsync(id);

        //    if (user is null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post(User newUser)
        //{
        //    await _UserService.CreateAsync(newUser);

        //    return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        //}

        //[HttpPut("{id:length(24)}")]
        //public async Task<IActionResult> Update(string id, User updatedUser)
        //{
        //    var user = await _UserService.GetAsync(id);

        //    if (user is null)
        //    {
        //        return NotFound();
        //    }

        //    updatedUser.Id = user.Id;

        //    await _UserService.UpdateAsync(id, updatedUser);

        //    return NoContent();
        //}

        //[HttpDelete("{id:length(24)}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var user = await _UserService.GetAsync(id);

        //    if (user is null)
        //    {
        //        return NotFound();
        //    }

        //    await _UserService.RemoveAsync(id);

        //    return NoContent();
        //}
    }
}