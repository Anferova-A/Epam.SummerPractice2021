using Epam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.DAL.Interfaces
{
    public interface IFeedbackDAO
    {
        bool Add(Feedback newFeedback);
        bool Remove(Guid id);
        bool Update(Feedback feedback);
        IEnumerable<Feedback> GetAll();
        IEnumerable<Feedback> GetByShop(Guid shopId);
        IEnumerable<Feedback> GetByUser(Guid userId);
    }
}
