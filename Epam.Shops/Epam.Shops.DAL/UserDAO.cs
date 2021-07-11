using Epam.Shops.DAL.Interfaces;
using Epam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Epam.Shops.DAL
{
    public class UserDAO : IUserDAO
    {
        public bool Add(User newUser)
        {
            int result;

            using (var db = new ShopsDB())
            {
                var id = new SqlParameter("@id", Guid.NewGuid());
                var firstName = new SqlParameter("@first_name", newUser.FirstName);
                var lastName = new SqlParameter("@last_name", newUser.LastName);
                var age = new SqlParameter("@age", newUser.Age);
                var gender = new SqlParameter("@gender", newUser.Gender);
                var email = new SqlParameter("@email", newUser.Email);
                var phoneNumber = new SqlParameter("@phone_number", newUser.PhoneNumber);
                var password = new SqlParameter("@password", newUser.Password);
                

                result = db.Database.ExecuteSqlCommand("AddUser @id, @first_name, @last_name, @age, @gender, @email, @phone_number, @password", id, firstName, lastName, age, gender, email, phoneNumber, password);
            }
            return result == -1;
        }

        public User GetByEmail(string email)
        {
            User result;
            using (var db = new ShopsDB())
            {
                var param = new SqlParameter("@email", email);
                result = db.Users.SqlQuery("GetUserByEmail @email", param).FirstOrDefault();
            }

            return result;
        }
        public bool ContainsEmail(string email)
        {
            bool result;
            using (var db = new ShopsDB())
            {
                var param = new SqlParameter("@email", email);
                result = db.Users.SqlQuery("GetUserByEmail @email", param).Count() != 0;
            }

            return result;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> result;
            using (var db = new ShopsDB())
            {
                result = db.Users.SqlQuery("GetAllUsers").ToList();
            }

            return result;
        }

       

        public bool Remove(Guid id)
        {
            int result;

            using (var db = new ShopsDB())
            {
                var param = new SqlParameter("@id", id);

                result = db.Database.ExecuteSqlCommand("RemoveUser @id", param);
            }

            return result != 0;
        }

        public bool Update(User user)
        {
            int result;

            using (var db = new ShopsDB())
            {
                var id = new SqlParameter("@id", user.Id);
                var firstName = new SqlParameter("@first_name", user.FirstName);
                var lastName = new SqlParameter("@last_name", user.LastName);
                var age = new SqlParameter("@age", user.Age);
                var gender = new SqlParameter("@gender", user.Gender);
                var email = new SqlParameter("@email", user.Email);
                var phoneNumber = new SqlParameter("@phone_number", user.PhoneNumber);
                var password = new SqlParameter("@password", user.Password);


                result = db.Database.ExecuteSqlCommand("UpdateUser @id, @first_name, @last_name, @age, @gender, @email, @phone_number, @password", id, firstName, lastName, age, gender, email, phoneNumber, password);
            }
            return result != 0;
        }

     }
}
