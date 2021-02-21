using ProjectCovid_19.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectCovid_19.Controllers
{
    public class MainHomeController : Controller
    {
        // GET: MainHome
        public ActionResult Registration()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Registration(Register r)
        {
            SqlConnection con = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=Covid-19DB;trusted_connection=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("RegistrationSave", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", r.Name);
            cmd.Parameters.AddWithValue("@Email", r.Email);
            cmd.Parameters.AddWithValue("@MobileNumber", r.MobileNumber);
            cmd.Parameters.AddWithValue("@Password", r.Password);
            cmd.Parameters.AddWithValue("@ConfirmPassword", r.ConfirmPassword);
            cmd.ExecuteNonQuery();
            con.Close();
            return View();
        
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            Login dbLogin = new Login();
            SqlConnection con = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=Covid-19DB;trusted_connection=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("LoginUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", login.Username);
            cmd.Parameters.AddWithValue("@Password", login.Password);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dbLogin.Username = dr["Username"].ToString();
                dbLogin.Password = dr["Password"].ToString();
            }
            if (login.Username == dbLogin.Username && login.Password == dbLogin.Password )
            {
                FormsAuthentication.SetAuthCookie(login.Username,false);
                return Redirect("UserHome/Home");
            }
            else
            {
                ViewBag.Message = "Invalid Username and Password";

            }
           // con.Close();
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/MainHome/Login");
        }
    }
}