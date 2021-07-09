using Epam.Shops.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.DAL
{
    public class FeedbackDAO : IFeedbackDAO
    {
        public bool Add(Shops.Entities.Feedback newFeedback)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shops.Entities.Feedback> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shops.Entities.Feedback> GetByCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shops.Entities.Feedback> GetByShopName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shops.Entities.Feedback> GetByUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shops.Entities.Feedback feedback)
        {
            throw new NotImplementedException();
        }
    }
}
