using Database.DAL;
using Database.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Database.BLL
{
    public class UserLogic
    {
        private UserDAO userDAO;

        public UserLogic()
        {
            this.userDAO = new UserDAO();
        }

        public int Add(User user)
        {
            return this.userDAO.Add(user);
        }

        public void Remove(int ID)
        {
            this.userDAO.Remove(ID);
        }

        public IEnumerable<User> GetAll()
        {
            return this.userDAO.GetAll();
        }

        public IEnumerable<User> GetByName(string name)
        {
            var users = this.userDAO.GetAll();
            var result = new List<User>();

            foreach (var currentUser in users)
            {
                if (currentUser.Name.StartsWith(name))
                {
                    result.Add(currentUser);
                }
            }

            return result;
        }

        public IEnumerable<User> OrderByDateOfBirth()
        {
            var users = this.userDAO.GetAll();
            var result = users.OrderBy(item => item.DateOfBirth);

            return result;
        }
    }
}
