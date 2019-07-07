using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiControllers.Models;
using CryptChatWebApi.App.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Manage.Internal;
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
        [Route("adduser")]
        public string AddUser(
            int requestId,
            string login,
            string password,
            string nickname,
            colour color,
            int rank)
        {
            var user = new User
            {
                Login = login, Password = password,
                Color = color, Nickname = nickname
            };

            repository.AddUser(user);

            return "Success. User " + user.Login +" added";
            //return "Success. User" + request.data.str + " added";
        }

        [HttpPost]
        [Route("getusers")]
        public IEnumerable<User> GetUsers(int requestId,
            int from,
            int count)
        {
            var userlist = repository.Users.Where(t =>
                t.UserId >= from && t.UserId < from + count);

            return userlist;
        }


        [HttpPost]
        [Route("muteuser")]
        public string MuteUser(int requestId,
            int id,
            int timestamp)
        {
            var user = repository[id];
            user.timestamp = timestamp;

            return String.Format("Success. Used id-{0} nickname-{1} muted until {2}", user.UserId, user.Nickname, timestamp);
        }

        [HttpPost]
        [Route("banuser")]
        public string BanUser(int requestId,
            int id,
            int timestamp)
        {
            var user = repository[id];
            user.timestamp = timestamp;

            return String.Format("Success. Used id-{0} banned name-{1} muted until {2}", user.UserId, user.Nickname, timestamp);
        }

        [HttpPost]
        [Route("setrank")]
        public string SetRank(int requestId,
            int id,
            int rank)
        {
            var user = repository[id];
            user.rank = rank;

            return "Success. New rank " + user.rank + ".";
        }


        [HttpPost]
        [Route("changename")]
        public string ChangeName(int requestId,
            int id,
            string name)
        {
            var user = repository[id];
            user.Nickname = name;

            return "Success. new nickname - " + user.Nickname + ".";
        }

        [HttpPost]
        [Route("changecolor")]
        public string ChangeColor(int requestId,
            int id,
            colour color)
        {
            var user = repository[id];
            user.Color = color;
            return "Success";
        }
    }
}