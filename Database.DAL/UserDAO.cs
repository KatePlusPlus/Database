using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Database.Entities;

namespace Database.DAL
{
    public class UserDAO
    {
        private string connnectionString = "Data Source=.;Initial Catalog=Users;Integrated Security=True";

        public int Add(User user)
        {
            using (SqlConnection connection = new SqlConnection(connnectionString))
            {
                SqlCommand cmd = new SqlCommand("Add", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                cmd.Parameters.AddWithValue("@Age", user.Age);

                var ID = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Output,
                    ParameterName = "@ID",
                    DbType = System.Data.DbType.Int32
                };
                cmd.Parameters.Add(ID);

                connection.Open();

                cmd.ExecuteNonQuery();

                return (int)ID.Value;
            }
        }

        public void Remove(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connnectionString))
            {
                SqlCommand cmd = new SqlCommand("Remove", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAll()
        {
            var result = new List<User>();
            using (SqlConnection connection = new SqlConnection(connnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAll", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var user = new User
                    {
                        ID = (int?)reader["ID"],
                        Name = (string)reader["Name"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Age = (Int16)reader["Age"]
                    };

                    result.Add(user);
                }
            }

            return result;
        }
    }
}
