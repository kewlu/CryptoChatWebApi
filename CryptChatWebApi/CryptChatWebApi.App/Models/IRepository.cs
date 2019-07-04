using System.Collections.Generic;
using CryptChatWebApi.App.Models.Entity;

namespace ApiControllers.Models
{

    public interface IRepository
    {

        IEnumerable<User> Users { get; }
        User this[int id] { get; }

        User AddUser(User User);
        User UpdateUser(User User);
        void DeleteUser(int id);
    }
}