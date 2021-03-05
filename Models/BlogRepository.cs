using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Windows;
using BlogApplication_Mcsf19a002.Controllers;
namespace BlogApplication_Mcsf19a002.Models
{
    public class BlogRepository
    {
        public List<Post> post = new List<Post>();
        public List<Blog> b = new List<Blog>();
        public List<Post> AddPost()
        {

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            try
            {
                string query = $"Select * from Post";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Post p = new Post();
                    p.Name=dr["Name"].ToString();
                    p.Title = dr["Title"].ToString();
                    p.Content = dr["Content"].ToString();
                    p.Email = dr["Email"].ToString();
                    p.ID = (int)dr["Id"];
                    post.Add(p);

                }
                return post;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { con.Close(); }

        }
        public List<Blog> AllUsers()
        {

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            try
            {
                string query = $"Select * from Signup";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Blog p = new Blog();
                    p.ID = (int)dr["Id"];
                    p.Name = dr["Name"].ToString();
                    p.Email = dr["Email"].ToString();
                    p.Password = dr["Password"].ToString();
                    b.Add(p);

                }
                return b;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { con.Close(); }

        }
        public string GetName()
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            try
            {
                int x = 0;
                Blog p = new Blog();
                string query = $"Select * from Signup";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (x == 0)
                    {

                        p.Email = dr["Email"].ToString();
                        if (p.Email == Gmail.gmail)
                        {
                            p.Name = dr["Name"].ToString();
                            x = 1;
                        }
                    }
                }
                Post np = new Post();
                np.Name = p.Name;
                return np.Name;
            }
            catch (Exception )
            {
                throw;
            }
            finally { connection.Close(); }
        }
        public void Image(Blog b)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(conString);

            string query = $"Update Signup SET Image='{b.Image}' WHERE Id={b.ID}";

            SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();

            int insertedRows = cmd.ExecuteNonQuery();

            connection.Close();

        }
    }
}
