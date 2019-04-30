using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.Models;

namespace LetsEat.DAL.SQL
{
    public class FamilySqlDAL : IFamilyDAL
    {
        string connectionString;
        private string SQL_GetFamily = "SELECT *, users.id AS user_id FROM family JOIN users ON family.id = users.family_id WHERE family_id = @family_id";
        private string SQL_CreateFamily = "INSERT INTO family (name) VALUES (@name); SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public FamilySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Family GetFamily(int familyId)
        {
            Family output = new Family();
            output.Members = new List<User>();
            output.Id = familyId;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetFamily, conn);
                    cmd.Parameters.AddWithValue("@family_id", familyId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Name = Convert.ToString(reader["name"]);
                        output.Members.Add(MapRowToUser(reader));
                    }
                }
            }
            catch
            {
                output = null;
            }

            return output;
        }

        public int Create(Family newFamily)
        {
            int output;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_CreateFamily, conn);
                    cmd.Parameters.AddWithValue("@name", newFamily.Name);

                    output = (int)cmd.ExecuteScalar();
                }
            }
            catch
            {
                output = 0;
            }

            return output;
        }

        private User MapRowToUser(SqlDataReader reader)
        {
            User u = new User();

            u.Id = Convert.ToInt32(reader["user_id"]);
            u.DisplayName = Convert.ToString(reader["display_name"]);
            u.Email = Convert.ToString(reader["email"]);
            u.Password = Convert.ToString(reader["password"]);
            u.Salt = Convert.ToString(reader["salt"]);
            u.Role = Convert.ToString(reader["role"]);
            if (!reader.IsDBNull(reader.GetOrdinal("family_id")))
            {
                u.FamilyId = Convert.ToInt32(reader["family_id"]);
            }
            if (!reader.IsDBNull(reader.GetOrdinal("family_role")))
            {
                u.FamilyRole = Convert.ToString(reader["family_role"]);
            }

            return u;
        }
    }
}
