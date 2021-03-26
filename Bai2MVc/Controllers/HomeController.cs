using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bai2MVc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Bai2MVc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        static List<User> _user = new List<User>(){
            new User{UserId=1,UserName="Duyet",Password="12345",RoleId=1},
            new User{UserId=2,UserName="Quan",Password="12345",RoleId=2},
            new User{UserId=3,UserName="Thanh",Password="12345",RoleId=3},
            new User{UserId=4,UserName="Tuan",Password="12345",RoleId=2},
        };
        static List<Role> _roles = new List<Role>(){
            new Role{RoleId=1,RoleName="Admin"},
            new Role{RoleId=2,RoleName="Member"},
            new Role{RoleId=3,RoleName="Customer"},
        };

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {

            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("username","");
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(MemberLoginInfo model)
        {
            var user = _user.SingleOrDefault(x => x.UserName == model.UserName&&x.Password==model.Password);
            if (user == null) return BadRequest("Không tìm thấy");
            //var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, model.UserName, ClaimValueTypes.String)
            //};
            //var role = _roles.SingleOrDefault(x => x.RoleId == user.RoleId);
            //if (role != null)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role.RoleName, ClaimValueTypes.String));
            //}
            //var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //var userPrincipal = new ClaimsPrincipal(userIdentity);
            //await HttpContext.SignInAsync(userPrincipal);
            var roleid = user.RoleId;
            var role = _roles.FirstOrDefault(x => x.RoleId == roleid);
            var rolename = role.RoleName;
            HttpContext.Session.SetString("rolename", rolename);
            return RedirectToAction("Index","Home");
        }

    }
}
