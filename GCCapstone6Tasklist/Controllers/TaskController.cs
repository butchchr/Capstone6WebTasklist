using GCCapstone6Tasklist.Data;
using GCCapstone6Tasklist.Domain.Models;
using GCCapstone6Tasklist.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GCCapstone6Tasklist.Controllers
{
    //[Authorize]
    public class TaskController : Controller
    {
        private Capstone6Context db = new Capstone6Context();

        // GET: Task
        public ActionResult Index()
        {
            var taskToDos = db.TaskToDos.Include(t => t.AssignedTeamMember);
            var tasks = new List<TaskModel>();
            foreach(var toDo in taskToDos)
            {
                tasks.Add(new TaskModel
                {
                    Id = toDo.Id,
                    Description = toDo.Description,
                    DueDate = toDo.DueDate,
                    IsDone = toDo.IsDone
                });
            }
            return View(tasks.ToList());
        }

        // GET: Task/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskToDo taskToDo = db.TaskToDos.Find(id);
            if (taskToDo == null)
            {
                return HttpNotFound();
            }
            return View(taskToDo);
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Name");
            return View();
        }

        // POST: Task/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamMemberId,Description,DueDate,IsDone")] TaskToDo taskToDo)
        {
            if (ModelState.IsValid)
            {
                db.TaskToDos.Add(taskToDo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Name", taskToDo.TeamMemberId);
            return View(taskToDo);
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskToDo taskToDo = db.TaskToDos.Find(id);
            if (taskToDo == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Name", taskToDo.TeamMemberId);
            return View(taskToDo);
        }

        // POST: Task/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamMemberId,Description,DueDate,IsDone")] TaskToDo taskToDo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskToDo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Name", taskToDo.TeamMemberId);
            return View(taskToDo);
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskToDo taskToDo = db.TaskToDos.Find(id);
            if (taskToDo == null)
            {
                return HttpNotFound();
            }
            return View(taskToDo);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskToDo taskToDo = db.TaskToDos.Find(id);
            db.TaskToDos.Remove(taskToDo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}