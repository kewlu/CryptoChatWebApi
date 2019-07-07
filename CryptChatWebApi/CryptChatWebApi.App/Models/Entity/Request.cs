using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptChatWebApi.App.Models.Entity
{
    public class Request<T>
    {
        public int requestId { get; set; }

        public T data { get; set; }
    }
}
