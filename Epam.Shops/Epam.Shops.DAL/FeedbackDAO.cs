using Epam.Shops.DAL.Interfaces;
using Epam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.DAL
{
    public class FeedbackDAO : IFeedbackDAO
    {
        public bool Add(Feedback newFeedback)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetByCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetByShopName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetByUser(Guid userId)
        {
            var feedbacks = new List<Feedback>();
            using (var db = new ShopsDB())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var param = new SqlParameter("@id", userId);
                var querryResult = db.Feedbacks.SqlQuery("GetFeedbacksByUser @id", param).ToList();

                foreach (var item in querryResult)
                {
                    db.Entry(item).Reference(t => t.Shop).Load();
                    db.Entry(item.Shop).Reference(t => t.Category).Load();
                    db.Entry(item).Reference(t => t.User).Load();

                    feedbacks.Add(item);
                }
            }

            return feedbacks;
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Feedback feedback)
        {
            throw new NotImplementedException();
        }
    }
}
