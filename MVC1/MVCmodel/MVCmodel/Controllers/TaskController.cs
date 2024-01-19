using MVCmodel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCmodel.Controllers
{
    public class TaskController : Controller
    {
        
        
            private readonly TaskDataContext _db = new TaskDataContext("tempdbConnectionString");

            public ActionResult Update(int id)
            {
                Task taskToUpdate = _db.Tasks.SingleOrDefault(t => t.IDD == id);

                if (taskToUpdate == null)
                {
                    return HttpNotFound();
                }

                return View(taskToUpdate);
            }

            [HttpPost]
            public ActionResult Update(Task updatedTask)
            {
                if (ModelState.IsValid)
                {
                    Task taskToUpdate = _db.Tasks.SingleOrDefault(t => t.IDD == updatedTask.IDD);

                    if (taskToUpdate != null)
                    {
                        taskToUpdate.Titles = updatedTask.Titles;
                        taskToUpdate.Descriptions = updatedTask.Descriptions;

                        _db.SubmitChanges();

                        return RedirectToAction("Index"); 
                    }
                }

                return View(updatedTask);
            }
    }

    
}