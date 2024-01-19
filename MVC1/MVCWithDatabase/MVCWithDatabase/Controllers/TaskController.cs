using MVCWithDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithDatabase.Controllers
{
    public class TaskController : Controller
    {
        
            // Assume tasks is a list of Task objects for demonstration purposes.
            private List<Task> tasks = new List<Task>
    {
        new Task { ID = 1, Title = "Task 1", Description = "Description 1" },
        new Task { ID = 2, Title = "Task 2", Description = "Description 2" },
        // Add more tasks as needed.
    };

            // Action to display the form for updating a task.
            public ActionResult Update(int id)
            {
                Task taskToUpdate = tasks.FirstOrDefault(t => t.ID == id);

                if (taskToUpdate != null)
                {
                    return View(taskToUpdate);
                }
                else
                {
                    return HttpNotFound(); // Or another appropriate result for a not found task.
                }
            }

            // Action to handle the form submission for updating a task.
            [HttpPost]
            public ActionResult Update(Task updatedTask)
            {
                Task taskToUpdate = tasks.FirstOrDefault(t => t.ID == updatedTask.ID);

                if (taskToUpdate != null)
                {
                    // Update task details.
                    taskToUpdate.Title = updatedTask.Title;
                    taskToUpdate.Description = updatedTask.Description;

                    // Redirect to a view or action method for displaying tasks.
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound(); // Or another appropriate result for a not found task.
                }
            }

            // Other actions for adding, deleting, and displaying tasks can be added here.
        

    }
}