using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using IntellectsPodium2.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity;
namespace IntellectsPodium2.Controllers
{
    public class AccountsController : Controller
    {
        private IPContext db = new IPContext();


        // GET: Accounts

        //public ActionResult Index(string Email)
        //{
        //    Account account = db.Accounts.Find(Email);
        //    return View(account);
        //}

        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult IndexLogin()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account model)
        {
            bool isValid = db.Accounts.Any(x => x.Email == model.Email && x.Password == model.Password);
            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(model.Email, true);
                //var details = db.Accounts.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
                //TempData["UserId"] = userId;
                Session["Email"] = model.Email.ToString();
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Invalid Username or Password");

            return View();
        }


        /*public ActionResult MyProfile(string Email)
        {
            if (Email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(Email);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }*/
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }
        public ActionResult MyProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        //SIGNUP     
        public ActionResult Signup()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup([Bind(Include = "UserId,FirstName,LastName,Qualification,Email,Password,ConfirmPassword")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                ViewBag.AccountCreationMessage = "Your Account has been created Successfully! Please Login Below";
                
            }

            return View(account);
        }

        //EDIT USER PROFILE
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,Qualification,Email,Password,ConfirmPassword")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }        

        // DELETE USER PROFILE
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("IndexLogin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }//class ends
}//namespace ends
