using Epam.Shops.Entities;
using Epam.Shops.Entities.Issues;
using Epam.Shops.Entities.Issues.Generic;
using System;
using System.Collections.Generic;

namespace Epam.Shops.BLL.Interfaces
{
    public interface IFeedbackLogic
    {
        Response Add(Feedback newFeedback);
        Response Remove(Guid id);
        Response Update(Feedback feedback);
        Response<IEnumerable<Feedback>> GetAll();
        Response<IEnumerable<Feedback>> GetByShop(Guid shopId);
        Response<IEnumerable<Feedback>> GetByUser(Guid userId);
    }
}
