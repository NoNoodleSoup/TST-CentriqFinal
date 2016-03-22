using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TTT.DATA.EF;

namespace TTT.UI.MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        private TSTEntities db = new TSTEntities();

        // GET: Departments
        public ActionResult Index()
        {
            return View(db.TSTDepartments.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTDepartment tSTDepartment = db.TSTDepartments.Find(id);
            if (tSTDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tSTDepartment);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeptID,DeptName,DeptDescription,IsActive")] TSTDepartment tSTDepartment)
        {
            if (ModelState.IsValid)
            {
                db.TSTDepartments.Add(tSTDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tSTDepartment);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTDepartment tSTDepartment = db.TSTDepartments.Find(id);
            if (tSTDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tSTDepartment);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeptID,DeptName,DeptDescription,IsActive")] TSTDepartment tSTDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tSTDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tSTDepartment);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTDepartment tSTDepartment = db.TSTDepartments.Find(id);
            if (tSTDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tSTDepartment);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TSTDepartment tSTDepartment = db.TSTDepartments.Find(id);
            db.TSTDepartments.Remove(tSTDepartment);
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
