using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptChatWebApi.App.Models.Entity
{
    public enum colour
    {
        black,
        white,
        red

    }

    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

        public string Nickname { get; set; }

        public colour Color { get; set; } = 0;

        public int rank { get; set; } = 0;

        public int timestamp { get; set; } = 0;
    }
}
