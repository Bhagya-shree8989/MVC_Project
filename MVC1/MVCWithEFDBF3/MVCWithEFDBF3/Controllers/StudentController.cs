using MVCWithEFDBF3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithEFDBF3.Controllers
{
    public class StudentController : Controller
    {
        MVCDBEntities dc = new MVCDBEntities();
        public ViewResult DisplayStudents()
        {
            return View(dc.Student_Select(null, true));
        }
        public ViewResult DisplayStudent(int sid)
        {
            return View(dc.Student_Select(sid, true).Single());
        }
        public ViewResult AddStudent()
        {
            Student_Select_Result student = new Student_Select_Result();
            return View(student);
        }
        [HttpPost]
        public RedirectToRouteResult AddStudent(Student_Select_Result student, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                string PhysicalPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(PhysicalPath))
                    Directory.CreateDirectory(PhysicalPath);
                selectedFile.SaveAs(PhysicalPath + selectedFile.FileName);
                student.Photo = selectedFile.FileName;
            }
            dc.Student_Insert(student.Sid, student.Name, student.Class, student.Fees, student.Photo);
            return RedirectToAction("DisplayStudents");
        }
        public ViewResult EditStudent(int sid)
        {
            var student = dc.Student_Select(sid, true).Single();
            TempData["Photo"] = student.Photo;
            return View(student);
        }
        public RedirectToRouteResult UpdateStudent(Student_Select_Result student, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                string PhysicalPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(PhysicalPath))
                    Directory.CreateDirectory(PhysicalPath);
                selectedFile.SaveAs(PhysicalPath + selectedFile.FileName);
                student.Photo = selectedFile.FileName;
            }
            else if (TempData["Photo"] != null)
            {
                student.Photo = TempData["Photo"].ToString();
            }
            dc.Student_Update(student.Sid, student.Name, student.Class, student.Fees, student.Photo);
            return RedirectToAction("DisplayStudents");
        }
        public ViewResult DeleteStudent(int sid)
        {
            return View(dc.Student_Select(sid, true).Single());
        }
        [HttpPost]
        public RedirectToRouteResult DeleteStudent(Student_Select_Result student)
        {
            dc.Student_Delete(student.Sid);
            return RedirectToAction("DisplayStudents");
        }
    }
}