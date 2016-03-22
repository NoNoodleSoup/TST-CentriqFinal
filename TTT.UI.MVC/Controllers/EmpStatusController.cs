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
    public class EmpStatusController : Controller
    {
        private TSTEntities db = new TSTEntities();

        // GET: EmpStatus
        public ActionResult Index()
        {
            return View(db.TSTEmpStatuses.ToList());
        }

        // GET: EmpStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTEmpStatus tSTEmpStatus = db.TSTEmpStatuses.Find(id);
            if (tSTEmpStatus == null)
            {
                return HttpNotFound();
            }
            return View(tSTEmpStatus);
        }

        // GET: EmpStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpStatusID,EmpStatusName,EmpStatusDescription")] TSTEmpStatus tSTEmpStatus)
        {
            if (ModelState.IsValid)
            {
                db.TSTEmpStatuses.Add(tSTEmpStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tSTEmpStatus);
        }

        // GET: EmpStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTEmpStatus tSTEmpStatus = db.TSTEmpStatuses.Find(id);
            if (tSTEmpStatus == null)
            {
                return HttpNotFound();
            }
            return View(tSTEmpStatus);
        }

        // POST: EmpStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpStatusID,EmpStatusName,EmpStatusDescription")] TSTEmpStatus tSTEmpStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tSTEmpStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tSTEmpStatus);
        }

        // GET: EmpStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTEmpStatus tSTEmpStatus = db.TSTEmpStatuses.Find(id);
            if (tSTEmpStatus == null)
            {
                return HttpNotFound();
            }
            return View(tSTEmpStatus);
        }

        // POST: EmpStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TSTEmpStatus tSTEmpStatus = db.TSTEmpStatuses.Find(id);
            db.TSTEmpStatuses.Remove(tSTEmpStatus);
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
