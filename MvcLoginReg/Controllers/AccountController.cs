//Michael Lawrence BSc (HONS). 
//DataBase access connection requires a "DB Context Class", add a class in the Model folder from here. 
//My Controller complete with View() and Views.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//add line below:
using MvcLoginReg.Models;

namespace MvcLoginReg.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            //right click here inside the brackets, and "Add View".

            //return View(); "you could type this, or..."
            //Return a list of the registered users:
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.userAccount.ToList());
            }

        }

        //After the user has completed the registration form, they will be directed to a blank web page below: 
        public ActionResult Register()
        {
            //inside the brackets here, right click and select "Add View", by selecting the following:
            //View Name: Register, Template: Create, Model class: UserAccount(MvcLoginReg.Models), Data context class: OurDbContext(MvcLoginReg.Models), then click the Add button. 
            
            //this is a blank web page.
            return View();
        }

        [HttpPost] public ActionResult Register(UserAccount account)
        {
            if(ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.userAccount.Add(account);
                    //must save the changes to the database:
                    db.SaveChanges();
                }
                //clear the page/form details.
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " Sucessfully registered."; 
            }
            return View();
        }
        //Login 
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.userAccount.Single(u => u.Username == user.Username && u.Password == user.Password);
                if(usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    //page to show users info:
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }
            return View(); 
        }
        //add method for Login Page:
        public ActionResult LoggedIn()
        {
            if(Session["UserId"] != null)
            {
                //right click here inside the brackets, and "Add View".
                return View(); 
            }
            else
            {
                return RedirectToAction("Login"); 
            }
        }
    }
}