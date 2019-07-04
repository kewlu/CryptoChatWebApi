using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiControllers.Models;
using CryptChatWebApi.App.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CryptChatWebApi.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private IRepository repository;

        public AdminController(IRepository repo) => repository = repo;

        [HttpGet]
        public IEnumerable<User> Get() => repository.Users;

        [HttpGet("{id}")]
        public User Get(int id) => repository[id];

        [HttpPost]
        public User Post([FromBody] User res) =>
            repository.AddUser(new User
            {
                Login = res.Login,
                Password = res.Password
            });

        [HttpPut]
        public User Put([FromBody] User res) =>
            repository.UpdateUser(res);

        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id,
            [FromBody]JsonPatchDocument<User> patch)
        {
            User res = Get(id);
            if (res != null)
            {
                patch.ApplyTo(res);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteUser(id);
    }
}