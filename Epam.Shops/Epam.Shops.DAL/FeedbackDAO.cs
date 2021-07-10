using Epam.Shops.DAL.Interfaces;
using Epam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace Epam.Shops.DAL
{
    public class FeedbackDAO : IFeedbackDAO
    {
        public bool Add(Feedback newFeedback)
        {
            int result;

            using (var db = new ShopsDB())
            {
                var id = new SqlParameter("@id", Guid.NewGuid());
                var text = new SqlParameter("@text", newFeedback.Text);
                var score = new SqlParameter("@score", newFeedback.Score);
                var date = new SqlParameter("@date", newFeedback.Date);
                var shopId = new SqlParameter("@shop_id", newFeedback.Shop.Id);
                var userId = new SqlParameter("@user_id", newFeedback.User.Id);

                result = db.Database.ExecuteSqlCommand("AddFeedback @id, @text, @score, @date, @shop_id, @user_id", id, text, score, date, shopId, userId);
            }
            return result == -1;
        }

        public IEnumerable<Feedback> GetAll()
        {
            var feedbacks = new List<Feedback>();
            using (var db = new ShopsDB())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var queryResult = db.Feedbacks.SqlQuery("GetAllFeedbacks");

                feedbacks = LoadFeedbacks(db, queryResult);
            }

            return feedbacks;
        }

        public IEnumerable<Feedback> GetByShop(Guid shopId)
        {
            var feedbacks = new List<Feedback>();
            using (var db = new ShopsDB())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var param = new SqlParameter("@shop_id", shopId);
                var queryResult = db.Feedbacks.SqlQuery("GetFeedbacksByShop @shop_id", param);

                feedbacks = LoadFeedbacks(db, queryResult);
            }

            return feedbacks;
        }

        public IEnumerable<Feedback> GetByUser(Guid userId)
        {
            var feedbacks = new List<Feedback>();
            using (var db = new ShopsDB())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var param = new SqlParameter("@id", userId);
                var queryResult = db.Feedbacks.SqlQuery("GetFeedbacksByUser @id", param);

                feedbacks = LoadFeedbacks(db, queryResult);
            }

            return feedbacks;
        }

        public bool Remove(Guid id)
        {
            int result;

            using (var db = new ShopsDB())
            {
                var param = new SqlParameter("@id", id);

                result = db.Database.ExecuteSqlCommand("RemoveFeedback @id", param);
            }

            return result != 0;
        }

        public bool Update(Feedback feedback)
        {
            int result;

            using (var db = new ShopsDB())
            {
                var id = new SqlParameter("@id", feedback.Id);
                var text = new SqlParameter("@text", feedback.Text);
                var score = new SqlParameter("@score", feedback.Score);
                var date = new SqlParameter("@date", feedback.Date);
                var shopId = new SqlParameter("@shop_id", feedback.Shop.Id);
                var userId = new SqlParameter("@user_id", feedback.User.Id);

                result = db.Database.ExecuteSqlCommand("UpdateFeedback @id, @text, @score, @date, @shop_id, @user_id", id, text, score, date, shopId, userId);
            }
            return result != 0;
        }

        private List<Feedback> LoadFeedbacks(ShopsDB db, DbSqlQuery<Feedback> queryResult)
        {
            var result = new List<Feedback>();

            foreach (var item in queryResult.ToArray())
            {
                db.Entry(item).Reference(t => t.Shop).Load();
                db.Entry(item.Shop).Reference(t => t.Category).Load();
                db.Entry(item).Reference(t => t.User).Load();

                result.Add(item);
            }

            return result;
        }
    }
}
