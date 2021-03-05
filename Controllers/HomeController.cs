using BlogApplication_Mcsf19a002.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
namespace BlogApplication_Mcsf19a002.Controllers
{
       public static class Gmail
       {
        public static List<Blog> lst = new List<Blog>();
        public static string gmail;
       }

    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _iwebHost;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _iwebHost = webHostEnvironment;
        }
        public ViewResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ViewResult SignUp(Blog d)
        {
            if (ModelState.IsValid)
            {
                string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(connString);
                try
                {
                    string query = $"Select * from Signup where Email='{d.Email}' and Password='{d.Password}'";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        ModelState.AddModelError(string.Empty, "Account already exixts!");
                        return View();
                    }
                    else
                    {
                        string connString1 = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                        SqlConnection con1 = new SqlConnection(connString1);
                        try
                        {
                            string query1 = $"insert into Signup(Name,Age,Email,Password) values('{d.Name}','{d.Age}','{d.Email}','{d.Password}')";
                            con1.Open();
                            SqlCommand cmd1 = new SqlCommand(query1, con1);
                            cmd1.ExecuteNonQuery();
                            List<Post> post = new List<Post>();
                            BlogRepository b = new BlogRepository();
                            post = b.AddPost();
                            return View("BlogView", post);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            con1.Close();
                        }

                    }
                }
                catch (Exception)
                {
                    return View();
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please enter correct data!");
                return View();
            }
        }
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Login(Login d)
        {
            if (ModelState.IsValid)
            {
                string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(connString);
                try
                {
                    string query = $"Select * from Signup where Email='{d.Email}' and Password='{d.Password}'";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Gmail.gmail = "";
                        Gmail.gmail = d.Email;
                        if (Gmail.gmail == "admin@gmail.com")
                        {
                            List<Post> post = new List<Post>();
                            BlogRepository b = new BlogRepository();
                            post = b.AddPost();
                            return View("Admin", post);
                        }
                        else
                        {
                            List<Post> post = new List<Post>();
                            BlogRepository b = new BlogRepository();
                            post = b.AddPost();
                            return View("BlogView", post);
                        }

                    }
                    else
                    {
                        return View();
                    }

                }
                catch (Exception)
                {
                    return View();
                }
                finally
                {
                    con.Close();
                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please enter correct data!");
                return View();
            }
        }
        public ViewResult Admin()
        {
            return View();
        }
        public ViewResult BlogView()
        {
            List<Post> post = new List<Post>();
            BlogRepository b = new BlogRepository();
            post = b.AddPost();
            return View("BlogView", post);
        }
        [HttpGet]
        public ViewResult ProfileView()
        {

            Profile p = new Profile();
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            try
            {
                string query = $"Select * from Signup where Email='{Gmail.gmail}'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    p.Name = dr["Name"].ToString();
                    p.Email = dr["Email"].ToString();
                    p.Password = dr["Password"].ToString();
                    return View("ProfileView", p);
                }
                else
                {
                    return View();
                }

            }
            catch (Exception)
            {
                return View();
            }
            finally
            {
                con.Close();
            }

        }
        [HttpPost]
        public ViewResult ProfileView(Profile p)
        {
            if (p.Password != null && p.Name != null && p.Email != null)
            {
                if (p.NewPassword == null && p.ConfirmPassword == null)
                {
                    string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    SqlConnection con = new SqlConnection(connString);
                    con.Open();
                    try
                    {
                        string query = $"UPDATE Signup SET Name = '{p.Name}',  Password = '{p.Password}' where Email = '{Gmail.gmail}'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (Gmail.gmail == "admin@gmail.com")
                        {
                            List<Post> post = new List<Post>();
                            BlogRepository b = new BlogRepository();
                            post = b.AddPost();
                            return View("Admin", post);
                        }
                        else
                        {
                            List<Post> post = new List<Post>();
                            BlogRepository b = new BlogRepository();
                            post = b.AddPost();
                            return View("BlogView", post);
                        }
                        //return View("BlogView");

                    }
                    catch (Exception)
                    {
                        throw; //return View();
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    if (p.ConfirmPassword == p.NewPassword)
                    {
                        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                        SqlConnection con = new SqlConnection(connString);
                        con.Open();
                        try
                        {
                            p.Password = p.NewPassword;
                            string query = $"UPDATE Signup SET Name = '{p.Name}',  Password = '{p.Password}' where Email = '{Gmail.gmail}'";
                            SqlCommand cmd = new SqlCommand(query, con);
                            SqlDataReader dr = cmd.ExecuteReader();
                            return View("BlogView");

                        }
                        catch (Exception)
                        {
                            throw; //return View();
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Password doesn't match!");
                        return View();
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to Update.");
                return View();
            }

        }
        [HttpGet]
        public ViewResult About()
        {
            return View();
        }
        [HttpPost]
        public ViewResult About(Post p)
        {
            if (Gmail.gmail == "admin@gmail.com")
            {
                List<Post> post = new List<Post>();
                BlogRepository b = new BlogRepository();
                post = b.AddPost();
                return View("Admin", post);
            }
            else
            {
                List<Post> post = new List<Post>();
                BlogRepository b = new BlogRepository();
                post = b.AddPost();
                return View("BlogView", post);
            }
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Create(Post p)
        {
            BlogRepository blog = new BlogRepository();
            p.Name = blog.GetName();
            if (ModelState.IsValid)
            {
                string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(connString);
                try
                {
                    string query = $"insert into Post(Name,Title,Content,Email) values('{p.Name}','{p.Title}','{p.Content}','{Gmail.gmail}')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    List<Post> post = new List<Post>();
                    BlogRepository b = new BlogRepository();
                    post = b.AddPost();
                    return View("BlogView", post);
                }
                catch (Exception)
                {
                    
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please enter correct data!");
                return View();
            }
        }

        [HttpGet]
        public ViewResult Update()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Update(Post p)
        {
            if (ModelState.IsValid)
            {
                if (Gmail.gmail == "admin@gmail.com")
                {
                    List<Post> post = new List<Post>();
                    BlogRepository b = new BlogRepository();
                    post = b.AddPost();
                    return View("Admin", post);
                }
                else
                {
                    List<Post> post = new List<Post>();
                    BlogRepository b = new BlogRepository();
                    post = b.AddPost();
                    return View("BlogView", post);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please enter correct data!");
                return View();
            }
        }
        [HttpGet]
        public ViewResult Edit(int id)
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
                    Post p = new Post();
                    p.ID = (int)dr["Id"];
                    if (p.ID == id)
                    {
                        p.Title = dr["Title"].ToString();
                        p.Content = dr["Content"].ToString();
                        return View("Edit", p);
                    }

                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }
        [HttpPost]

        //public async Task<IActionResult> Edit(IFormFile image,Post p)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //        SqlConnection connection = new SqlConnection(conString);
        //        connection.Open();
        //        try
        //        {
        //            if (image!= null)
        //            {
        //                string imgtext = Path.GetExtension(image.FileName);
        //                var path = Path.Combine(_iwebHost.WebRootPath, "images", image.FileName);
        //                var stream = new FileStream(path, FileMode.Create);

        //                await image.CopyToAsync(stream);
        //                BlogRepository b = new BlogRepository();
        //                Blog.Image = image.FileName;
        //                BlogRepository.Blog = o.getAllUserBlogsList();
        //                foreach (Blog blog in BlogRepository.myBlog)
        //                {
        //                    if (blog.ID == Obj.ID)
        //                    {
        //                        blog.Image= Profile.Image;
        //                        o.Image(blog);
        //                    }
        //                }

        //            }
        //            string query = $"UPDATE Post SET Title='{p.Title}',Content='{p.Content}' where Id='{p.ID}'";
        //            SqlCommand cmd = new SqlCommand(query, connection);
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            BlogRepository b = new BlogRepository();
        //            List<Post> l = new List<Post>();
        //            l = b.AddPost();
        //            return View("BlogView", l);
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //        finally { connection.Close(); }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "Enter Data");
        //        return View();
        //    }
        //}
        public ViewResult Edit(Post p)
        {
            if (ModelState.IsValid)
            {
                string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();
                try
                {
                    string query = $"UPDATE Post SET Title='{p.Title}',Content='{p.Content}' where Id='{p.ID}'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    BlogRepository b = new BlogRepository();
                    List<Post> l = new List<Post>();
                    l = b.AddPost();
                    return View("BlogView", l);
                }
                catch (Exception)
                {
                    throw;
                }
                finally { connection.Close(); }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Enter Data");
                return View();
            }
        }
        public ViewResult PostView(int id)
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
                    Post p = new Post();
                    p.ID = (int)dr["Id"];
                    if (p.ID == id)
                    {
                        p.Title = dr["Title"].ToString();
                        p.Content = dr["Content"].ToString();
                        return View("PostView", p);
                    }

                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }
        public ViewResult Remove(int id)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            try
            {
                string query = $"Delete from Post Where Id='{id}'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                BlogRepository b = new BlogRepository();
                List<Post> p = new List<Post>();
                p = b.AddPost();
                return View("BlogView", p);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public ViewResult RemoveAccount(int id)
        {
            Admin a = new Admin();
            Post np = new Post();
            np.Email = a.GetEmail(id);
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            try
            {
                a.DeleteAccount(np.Email);
                string query = $"DELETE FROM Post where Email='{np.Email}'";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                List<Post> post = new List<Post>();
                BlogRepository obj = new BlogRepository();
                post = obj.AddPost();
                return View("Admin", post);
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }
        [HttpGet]
        public ViewResult EditProfile(int id)
        {
            Admin a = new Admin();
            Post np = new Post();
            np.Email = a.GetEmail(id);
            Profile p = new Profile();
            p = a.UserAccountData(np.Email);
            return View("EditProfile", p);

        }
        [HttpPost]
        public ViewResult EditProfile(Profile p)
        {
            if (p.Email != null && p.Name != null && p.Password != null)
            {
                bool flag;
                Admin obj = new Admin();
                obj.UpdatePost(p);
                flag = obj.UpdateUserAccount(p);
                if (flag == true)
                {
                    List<Post> post = new List<Post>();
                    BlogRepository obj1 = new BlogRepository();
                    post = obj1.AddPost();
                    return View("Admin", post);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Password Doesn't match ");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Unable to update");
                return View();
            }
        }

        [HttpGet]
        public ViewResult UserProfile(int id)
        {
            Admin a = new Admin();
            Post np = new Post();
            np.Email = a.GetEmail(id);
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            try
            {
                string query = $"Select * from Signup";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Blog p = new Blog();
                    p.Email = dr["Email"].ToString();

                    if (p.Email == np.Email)
                    {
                        p.ID = (int)dr["Id"];
                        p.Name = dr["Name"].ToString();
                        p.Password = dr["Password"].ToString();
                        return View("UserProfile", p);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { connection.Close(); }
            return View("UserProfile");
        }
        [HttpPost]
        public ViewResult UserProfile()
        {
            if (Gmail.gmail == "admin@gmail.com")
            {
                List<Post> post = new List<Post>();
                BlogRepository b = new BlogRepository();
                post = b.AddPost();
                return View("Admin", post);
            }
            else
            {
                List<Post> post = new List<Post>();
                BlogRepository b = new BlogRepository();
                post = b.AddPost();
                return View("BlogView", post);
            }
        }
        [HttpGet]
        public ViewResult AllUsers()
        {
            List<Blog> blog = new List<Blog>();
            BlogRepository b = new BlogRepository();
            blog = b.AllUsers();
            return View("AllUsers",blog);
        }
        
    }
}
