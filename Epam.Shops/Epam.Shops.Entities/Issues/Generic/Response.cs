namespace Epam.Shops.Entities.Issues.Generic
{
    public class Response<T> : Response
    {
        public T Content { get; set; }
    }
}
