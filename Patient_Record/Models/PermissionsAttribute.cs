using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Patient_Record.Models
{
        public class PermissionsAttribute
        {

            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly ISession _session;
            public PermissionsAttribute(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
                _session = _httpContextAccessor.HttpContext.Session;
                Auth();
            }

            public void Auth()
            {

                bool Authenticated = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

                string username = _httpContextAccessor.HttpContext.Session.GetString("USER_FULL_NAME");
                string USER_ID = _httpContextAccessor.HttpContext.Session.GetString("USER_ID");

                if (!Authenticated)
                    {
                        //Through here HttpContext.User.Claims Can we Login this Action Stored in cookie All in
                        //claims Read out the key-value pairs, like the one we just defined UserName Value of Wangdacui It's here that I read it
                        //var userName = HttpContext.User.Claims.First().Value;
                        _httpContextAccessor.HttpContext.Session.SetString("USER_LANG", "NA");
                        _httpContextAccessor.HttpContext.Session.SetString("UserID", "1");
                        Task.Run(async () =>
                        {
                            //Log off user, equivalent to ASP.NET In FormsAuthentication.SignOut  
                            await _httpContextAccessor.HttpContext.SignOutAsync();
                        }).Wait();

                        _httpContextAccessor.HttpContext.Response.Redirect("/Permissions/Auth/Index");
                    }


            }

        }

}
