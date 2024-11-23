using A2_Req_ToDo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace A2_Req_ToDo.Controllers
{
    public class HomeController : Controller
    {
        // Simulate a task list in-memory (replace with a database in a real application)
        private static List<Models.Task> _taskList = new List<Models.Task>
        {
            new Models.Task { TaskID = 1, TaskName = "Complete Homework", DueDate = new DateTime(2024, 11, 25), Tag = "School", PriorityLevel = "High" },
            new Models.Task { TaskID = 2, TaskName = "Grocery Shopping", DueDate = new DateTime(2024, 11, 22), Tag = "Personal", PriorityLevel = "Medium" },
            new Models.Task { TaskID = 3, TaskName = "Doctor's Appointment", DueDate = new DateTime(2024, 11, 23), Tag = "Health", PriorityLevel = "Low" }
        };

        // Action to view the list of tasks
        public IActionResult Index()
        {
            return View(_taskList);
        }

        // Action to display the Add Task page
        public IActionResult AddTask()
        {
            return View();  // Return the AddTask view without any initial data
        }

        // Action to handle adding a task
        [HttpPost]
        public IActionResult AddTask(Models.Task newTask)
        {
            if (ModelState.IsValid)
            {
                // Set TaskID based on the current list count
                newTask.TaskID = _taskList.Count + 1;

                // Add the new task to the list
                _taskList.Add(newTask);

                // Store the task name in TempData for confirmation on Index page
                TempData["TaskName"] = newTask.TaskName;
                return RedirectToAction("Index");
            }

            // If validation fails, return to the Add Task view with the current model
            return View(newTask);
        }

        // Action to display the Edit Task page
        public IActionResult EditTask(int id)
        {
            var task = _taskList.FirstOrDefault(t => t.TaskID == id);
            if (task == null)
            {
                return NotFound(); // Return 404 if task not found
            }

            return View(task); // Return the Edit view with the task data
        }

        // POST action to handle editing a task
        [HttpPost]
        public IActionResult EditTask(int id, Models.Task updatedTask)
        {
            if (ModelState.IsValid)
            {
                var task = _taskList.FirstOrDefault(t => t.TaskID == id);
                if (task == null)
                {
                    return NotFound(); // Return 404 if task not found
                }

                // Update the task details
                task.TaskName = updatedTask.TaskName;
                task.DueDate = updatedTask.DueDate;
                task.Tag = updatedTask.Tag;
                task.PriorityLevel = updatedTask.PriorityLevel;

                return RedirectToAction("Index"); // Redirect back to the task list
            }

            return View(updatedTask); // Return the view with validation errors if any
        }

        // Action to handle deleting a task
        public IActionResult DeleteTask(int id)
        {
            var task = _taskList.FirstOrDefault(t => t.TaskID == id);
            if (task == null)
            {
                return NotFound(); // Return 404 if task not found
            }

            _taskList.Remove(task); // Remove the task from the list
            return RedirectToAction("Index"); // Redirect back to the task list
        }
    }
}
