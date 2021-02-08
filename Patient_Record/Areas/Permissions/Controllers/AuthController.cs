
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace Patient_Record.Areas.Permissions.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration configuration;
        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult index(string username, string password)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                HttpContext.Session.SetString("USER_LANG", "NA");
                HttpContext.Session.SetString("UserID", "1");
                Task.Run(async () =>
                {
                    await HttpContext.SignOutAsync();
                }).Wait();
                return View("login");
            }
            else
            {
                return Redirect("~/Home/Index");
            }
        }


        public IActionResult Authentication()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                HttpContext.Session.SetString("USER_LANG", "NA");
                HttpContext.Session.SetString("UserID", "1");
                Task.Run(async () =>
                {
                    await HttpContext.SignOutAsync();
                }).Wait();
                return View("login");
            }
            else
            {
                return Redirect("~/Home/Index");
            }
        }

        public IActionResult logout()
        {

            string strRole = String.Empty;
            Task.Run(async () =>
            {
                await HttpContext.SignOutAsync();
            }).Wait();
            return RedirectToAction("Index", "Auth");
        }


        [HttpPost]
        [AllowAnonymous]
        public JsonResult login(string username, string password)
        {
            string conString = configuration.GetConnectionString("PatientDbConnection");
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            var chk = 0;
            string USER_ID ="";
            
            string user_data = null;
            if (username != null && password != null)
            {
                try
                {
                                        
                    if (connection.State == ConnectionState.Open)
                    {

                        if (user_data != null)
                        {
                            string userData = user_data;
                            string[] result = Regex.Split(userData, "&&&");
                            HttpContext.Session.SetString("USER_ID", result[0].ToString());
                            HttpContext.Session.SetString("USER_FULL_NAME", result[1].ToString());
                            HttpContext.Session.SetString("USER_NA", result[8].ToString());
                            HttpContext.Session.SetString("PASSWORD_CHECK", result[10].ToString());
                            HttpContext.Session.SetString("SYSDATE", result[12].ToString());
                            HttpContext.Session.SetString("USER_P", result[4].ToString());

                            chk = 1;
                            var claims = new[] { new Claim("UserName", result[1].ToString()) };

                            var claimsIdentity = new ClaimsIdentity(
                            claims,
                            CookieAuthenticationDefaults.AuthenticationScheme);

                            ClaimsPrincipal user = new ClaimsPrincipal(claimsIdentity);

                            Task.Run(async () =>
                            {
                                await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                user, new AuthenticationProperties()
                                {
                                    IsPersistent = true,
                                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(90),
                                    AllowRefresh = true
                                });


                            }).Wait();
                        }
                        else
                        {
                            var claims = new[] { new Claim("UserName", "") };

                            var claimsIdentity = new ClaimsIdentity(
                            claims,
                            CookieAuthenticationDefaults.AuthenticationScheme);

                            ClaimsPrincipal user = new ClaimsPrincipal(claimsIdentity);

                            Task.Run(async () =>
                            {
                                await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                user, new AuthenticationProperties()
                                {
                                    IsPersistent = true,
                                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(90),
                                    AllowRefresh = true
                                });


                            }).Wait();
                            //HttpContext.Session.SetString("USER_P", "1");
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid Username Or Password");
                    }
                }
                catch (Exception er)
                {
                    connection.Close();
                    HttpContext.Session.Clear();
                    Response.StatusCode = 500;
                    return Json("Invalid username or password");
                }
                finally
                {
                    connection.Close();
                }

            }
            connection.Close();
            return Json(1);

        }


        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }


    }

    

}



