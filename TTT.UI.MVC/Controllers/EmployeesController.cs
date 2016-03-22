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
    public class EmployeesController : Controller
    {
        private TSTEntities db = new TSTEntities();

        // GET: Employees
        public ActionResult Index()
        {
            var tSTEmployees = db.TSTEmployees.Include(t => t.TSTDepartment).Include(t => t.TSTEmpStatus);
            return View(tSTEmployees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTEmployee tSTEmployee = db.TSTEmployees.Find(id);
            if (tSTEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tSTEmployee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DeptID = new SelectList(db.TSTDepartments, "DeptID", "DeptName");
            ViewBag.EmpStatusID = new SelectList(db.TSTEmpStatuses, "EmpStatusID", "EmpStatusName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,UserID,EmpStatusID,EmpImage,FName,LName,DeptID,JobTitle,DateOfBirth,StreetAddress,Address2,City,State,Zip,Email,CellPhone,DateOfHire,DateOfSeparation,EmpNotes")] TSTEmployee tSTEmployee)
        {
            if (ModelState.IsValid)
            {
                db.TSTEmployees.Add(tSTEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptID = new SelectList(db.TSTDepartments, "DeptID", "DeptName", tSTEmployee.DeptID);
            ViewBag.EmpStatusID = new SelectList(db.TSTEmpStatuses, "EmpStatusID", "EmpStatusName", tSTEmployee.EmpStatusID);
            return View(tSTEmployee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTEmployee tSTEmployee = db.TSTEmployees.Find(id);
            if (tSTEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptID = new SelectList(db.TSTDepartments, "DeptID", "DeptName", tSTEmployee.DeptID);
            ViewBag.EmpStatusID = new SelectList(db.TSTEmpStatuses, "EmpStatusID", "EmpStatusName", tSTEmployee.EmpStatusID);
            return View(tSTEmployee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,UserID,EmpStatusID,EmpImage,FName,LName,DeptID,JobTitle,DateOfBirth,StreetAddress,Address2,City,State,Zip,Email,CellPhone,DateOfHire,DateOfSeparation,EmpNotes")] TSTEmployee tSTEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tSTEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptID = new SelectList(db.TSTDepartments, "DeptID", "DeptName", tSTEmployee.DeptID);
            ViewBag.EmpStatusID = new SelectList(db.TSTEmpStatuses, "EmpStatusID", "EmpStatusName", tSTEmployee.EmpStatusID);
            return View(tSTEmployee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTEmployee tSTEmployee = db.TSTEmployees.Find(id);
            if (tSTEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tSTEmployee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TSTEmployee tSTEmployee = db.TSTEmployees.Find(id);
            db.TSTEmployees.Remove(tSTEmployee);
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
