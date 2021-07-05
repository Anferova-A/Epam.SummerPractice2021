using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.Entities.Issues.Generic
{
    public class Response<T> : Response
    {
        public T Content { get; set; }
    }
}
