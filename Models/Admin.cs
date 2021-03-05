using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace BlogApplication_Mcsf19a002.Models
{
    public class Admin
    {
        public List<Profile> post = new List<Profile>();
        public List<Profile> AddPost()
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            try
            {
                string query = $"Select * from Post";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //dr.Read();
                    Profile p = new Profile();
                    p.Name = dr["Title"].ToString();
                    p.Email = dr["Content"].ToString();
                    p.Password = dr["Email"].ToString();
                    post.Add(p);
                }
                return post;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { connection.Close(); }
        }
        public string GetEmail(int id)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            try
            {
                int a = 0;
                Post p = new Post();
                string query = $"Select * from Post";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read() && a == 0)
                {
                    p.ID = (int)dr["Id"];
                    if (p.ID == id)
                    {
                        p.Email = dr["Email"].ToString();
                        a = 1;
                    }
                }
                return p.Email;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { connection.Close(); }
        }
        public void DeleteAccount(string email)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            try
            {
                string query = $"DELETE FROM Signup where Email='{email}'";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception )
            {
                throw;
            }
            finally { connection.Close(); }
        }
        public void UpdatePost(Profile p)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            if (p.NewPassword == null && p.ConfirmPassword == null)
            {
                try
                {
                    string query = $"UPDATE Post SET Name='{p.Name}' where Email='{p.Email}'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                }
                catch (Exception )
                {
                    throw;
                }
                finally { connection.Close(); }
            }
        }
        public bool UpdateUserAccount(Profile p)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            if (p.NewPassword == null && p.ConfirmPassword == null)
            {
                try
                {
                    string query = $"UPDATE Signup SET Name='{p.Name}',Password='{p.Password}' where Email='{p.Email}'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    return true;
                }
                catch (Exception )
                {
                    throw;
                }
                finally { connection.Close(); }
            }
            else if (p.ConfirmPassword == p.NewPassword)
            {
                try
                {
                    p.Password = p.NewPassword;
                    string query = $"UPDATE Signup SET Name='{p.Name}',Email='{p.Email}',Password='{p.Password}' where Email='{p.Email}'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    return true;
                }
                catch (Exception )
                {
                    throw;
                }
                finally { connection.Close(); }
            }
            else
            {
                return false;
            }


        }
        public Profile UserAccountData(string email)
        {

            Profile obj = new Profile();
            obj.Email = email;
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
           
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            try
            {
                string query = $"select * from Signup where Email='{email}'";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    obj.Name = dr["Name"].ToString();
                    obj.Password = dr["Password"].ToString();
                    return obj;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { connection.Close(); }
            return obj;
        }
    }
}

