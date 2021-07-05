using System.Collections.Generic;

namespace Epam.Shops.Entities.Issues
{
    public class Response
    {
        public bool Success { get; set; }

        public ICollection<string> Errors { get; }

        public string Description { get; set; }

        public Response()
        {
            Errors = new List<string>();
        }
    }
}
