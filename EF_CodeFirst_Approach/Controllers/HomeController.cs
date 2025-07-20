using EF_CodeFirst_Approach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_CodeFirst_Approach.Controllers
{
    public class HomeController : Controller
    {
        StudentContext studentContext = new StudentContext();    
        // GET: Home
        public ActionResult Index(string SearchBy, string search) 
        {
            if(SearchBy=="Name")
            {
                var row = studentContext.Students.Where(model => model.Name.StartsWith(search)).ToList();
                return View(row);
            }
            else if(SearchBy=="Gender")
            {
                var row = studentContext.Students.Where(model => model.Gender == search).ToList();
                return View(row);
            }
            else
            {
                var data = studentContext.Students.ToList();
                return View(data);
            }
            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid == true)
            {

                studentContext.Students.Add(s);
                int a = studentContext.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Data Save Successfully !')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data not Saved Successfully')</script>";
                }
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = studentContext.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid == true)
            {
                studentContext.Entry(s).State = System.Data.Entity.EntityState.Modified;
                int a = studentContext.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Updated Data Successfully')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data Not Update Successfully')</script>";

                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
          var row = studentContext.Students.Where(model => model.Id == id).FirstOrDefault();
            if(row!=null)
            {
                //studentContext.Entry(row).State = EntityState.Deleted;
                //row.IsDeleted = true;
                var a =studentContext.SaveChanges();
                if (a > 0)
                {
                    TempData["DeleteMessate"] = "<script>alert('Data Deleted Successfully !')</script>";
                }
                else
                {
                    ViewBag.DeletedMessage = "<script>alert('Data Not Deleted !')</script>";

                }
            }
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Delete(Student s)
        //{
        //    if(ModelState.IsValid==true)
        //    {
        //      studentContext.Entry(s).State = EntityState.Deleted;
        //      var a=  studentContext.SaveChanges();
        //        if(a>0)
        //        {
        //            TempData["DeleteMessate"] = "<script>alert('Data Deleted Successfully !')</script>";
        //            return RedirectToAction("Index");   
        //        }
        //        else
        //        {
        //            ViewBag.DeletedMessage= "<script>alert('Data Deleted Successfully !')</script>";
        //        }
        //    }
        //    return View();
        //}

        public ActionResult Details(int id)
        {
               var row = studentContext.Students.Where(model=>model.Id == id).FirstOrDefault();
            
              return View(row);  
        }
    }
}