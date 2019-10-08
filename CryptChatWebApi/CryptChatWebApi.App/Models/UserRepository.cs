using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiControllers.Models;
using CryptChatWebApi.App.Models.Entity;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CryptChatWebApi.App.Models
{
    public class UserRepository : IRepository
    {
        private Dictionary<int, User> items;

        public UserRepository()
        {
            items = new Dictionary<int, User>();
            new List<User> {
                new User { Login = "Alice", Password = "Board Room" },
                new User { Login = "Bob", Password = "Lecture Hall" },
                new User { Login = "Joe", Password = "Meeting Room 1" }
            }.ForEach(r => AddUser(r));
        }

        public IEnumerable<User> Users => items.Values;

        public User this[int id] => items.ContainsKey(id) ? items[id] : null;

        public User AddUser(User user)
        {
            if (user.UserId == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                user.UserId = key;
            }
            items[user.UserId] = user;
            return user;
        }

        public User UpdateUser(User user)
            => AddUser(user);

        public void DeleteUser(int id) =>
            items.Remove(id);

    }
}
