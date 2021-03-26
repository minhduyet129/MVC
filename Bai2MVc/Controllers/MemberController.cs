using System;
using System.Collections.Generic;
using System.Linq;
using Bai2MVc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bai2MVc.Controllers
{
    public class MemberController : Controller
    {
       
        static List<Members> members = new List<Members>(){
                new Members{FirstName ="Tran",
                LastName ="Duyet",
                Gender ="Male",
                DateOfBirth =DateTime.Parse("1999-09-12"),
                Phone =12323213,
                BirthPlace="Bac Giang"}
                
            };
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        public IActionResult Create(Members abc){
            members.Add(abc);
            return RedirectToAction("Details");
        }
        public IActionResult Details(){

                                                           
            return View(members);
        }
        public IActionResult Edit(string firstname,string lastname){
            Members a = members.SingleOrDefault(x=> x.FirstName == firstname&&x.LastName == lastname);
            return View(a);
        }
        [HttpPost]
        public IActionResult Edit(Members abc){
            Members a = members.SingleOrDefault(x=> x.FirstName == abc.FirstName&&x.LastName == abc.LastName);
            if(a!=null){
                a.FirstName=abc.FirstName;
                a.LastName=abc.LastName;
                a.DateOfBirth=abc.DateOfBirth;
                a.Gender=abc.Gender;
                a.Phone=abc.Phone;
                a.BirthPlace=abc.BirthPlace;
                return RedirectToAction("Details");
            }
            return View(abc);
        }
        public IActionResult Delete(string firstname,string lastname){
            Members a=members.Find(x => x.FirstName==firstname&&x.LastName==lastname);
            members.Remove(a);
            
            return RedirectToAction("Details");
        }
        [HttpPost]
        public IActionResult Find(string keyword){
            if(keyword==null){
                return RedirectToAction("Details");
            }
            var a = members.Where(x => x.FirstName.Contains(keyword));
            return View(a);
        }
        
    }
}