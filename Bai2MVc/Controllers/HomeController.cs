using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bai2MVc.Models;
using Microsoft.AspNetCore.Http;

namespace Bai2MVc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        static List<User> _user =new List<User>(){
            new User{UserId=1,UserName="Duyet",Password="12345",RoleId=1},
            new User{UserId=1,UserName="Quan",Password="12345",RoleId=2},
            new User{UserId=1,UserName="Thanh",Password="12345",RoleId=3},
            new User{UserId=1,UserName="Tuan",Password="12345",RoleId=2},
        };
        static List<Role> _role=new List<Role>(){
            new Role{RoleId=1,RoleName="Admin"},
            new Role{RoleId=1,RoleName="Member"},
            new Role{RoleId=1,RoleName="Customer"},
        };

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login(){
            
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username,string password){

            User user= _user.SingleOrDefault(x => x.UserName == username&&x.Password == password);
            if(user !=null){
                HttpContext.Session.SetString("username",user.UserName);
                return RedirectToAction("Index");
            }


            return View();

        }
        public IActionResult Logout(){
            HttpContext.Session.SetString("username",null);
            return RedirectToAction("Login");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
