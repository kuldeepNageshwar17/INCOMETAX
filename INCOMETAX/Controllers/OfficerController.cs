﻿using INCOMETAX.DbModel;
using INCOMETAX.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INCOMETAX.Controllers
{
    public class OfficerController : Controller
    {
        // GET: Officer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddOfficer()
        {
            return View();
        }
        public ActionResult GetOfficerDetails()
        {
            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var user = (from u in db.USERs where (u.ID.Equals(Session["userid"])) select u).FirstOrDefault();
                    var userdetails = new UserModel();
                    userdetails.ID = user.ID;

                    userdetails.FirstName = user.FirstName;
                    userdetails.LastName = user.LastName;
                    userdetails.Email = user.Email;
                    userdetails.UserName = user.UserName;
                    userdetails.Password = user.Password;
                    userdetails.MobileNo = user.MobileNo;
                    return View(userdetails);
                }
                catch (Exception ex)
                {

                }


                return View();
            }
        }
        //End
        public ActionResult EditOfficerDetails()
        {
            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var user = (from u in db.USERs where (u.ID.Equals(Session["userid"])) select u).FirstOrDefault();
                    var userdetails = new UserModel();
                    userdetails.ID = user.ID;

                    userdetails.FirstName = user.FirstName;
                    userdetails.LastName = user.LastName;
                    userdetails.Email = user.Email;
                    userdetails.UserName = user.UserName;
                    userdetails.Password = user.Password;
                    userdetails.MobileNo = user.MobileNo;
                    return View(userdetails);
                }
                catch (Exception ex)
                {

                }


                return View();
            }
        }
        [HttpPost]
        public ActionResult EditOfficerDetails(UserModel user)
        {
            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var userdetails = (from u in db.USERs where (u.ID.Equals(Session["userid"])) select u).FirstOrDefault();
                   
                    userdetails.ID = user.ID;

                    userdetails.FirstName = user.FirstName;
                    userdetails.LastName = user.LastName;
                    userdetails.Email = user.Email;
                    userdetails.UserName = user.UserName;
                    userdetails.Password = user.Password;
                    userdetails.MobileNo = user.MobileNo;
                    db.SubmitChanges();
                    return RedirectToAction("staff","dashboard");
                }
                catch (Exception ex)
                {

                }


                return Json(0, JsonRequestBehavior.AllowGet);

            }
        }
    }
}