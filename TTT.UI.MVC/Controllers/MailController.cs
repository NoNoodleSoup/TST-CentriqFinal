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
    public class MailController : Controller
    {
        private TSTEntities db = new TSTEntities();

        // GET: Mail
        public ActionResult Index()
        {
            var tSTMails = db.TSTMails.Include(t => t.TSTEmployee).Include(t => t.TSTEmployee1).Include(t => t.TSTPriority);
            return View(tSTMails.ToList());
        }

        // GET: Mail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTMail tSTMail = db.TSTMails.Find(id);
            if (tSTMail == null)
            {
                return HttpNotFound();
            }
            return View(tSTMail);
        }

        // GET: Mail/Create
        public ActionResult Create()
        {
            ViewBag.SentByID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID");
            ViewBag.RecipientID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID");
            ViewBag.PriorityID = new SelectList(db.TSTPriorities, "PriorityID", "PriorityName");
            return View();
        }

        // POST: Mail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MailID,MailSubject,MailMessage,SentByID,DateSent,PriorityID,RecipientID,IsActive")] TSTMail tSTMail)
        {
            if (ModelState.IsValid)
            {
                db.TSTMails.Add(tSTMail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SentByID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID", tSTMail.SentByID);
            ViewBag.RecipientID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID", tSTMail.RecipientID);
            ViewBag.PriorityID = new SelectList(db.TSTPriorities, "PriorityID", "PriorityName", tSTMail.PriorityID);
            return View(tSTMail);
        }

        // GET: Mail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTMail tSTMail = db.TSTMails.Find(id);
            if (tSTMail == null)
            {
                return HttpNotFound();
            }
            ViewBag.SentByID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID", tSTMail.SentByID);
            ViewBag.RecipientID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID", tSTMail.RecipientID);
            ViewBag.PriorityID = new SelectList(db.TSTPriorities, "PriorityID", "PriorityName", tSTMail.PriorityID);
            return View(tSTMail);
        }

        // POST: Mail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MailID,MailSubject,MailMessage,SentByID,DateSent,PriorityID,RecipientID,IsActive")] TSTMail tSTMail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tSTMail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SentByID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID", tSTMail.SentByID);
            ViewBag.RecipientID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID", tSTMail.RecipientID);
            ViewBag.PriorityID = new SelectList(db.TSTPriorities, "PriorityID", "PriorityName", tSTMail.PriorityID);
            return View(tSTMail);
        }

        // GET: Mail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTMail tSTMail = db.TSTMails.Find(id);
            if (tSTMail == null)
            {
                return HttpNotFound();
            }
            return View(tSTMail);
        }

        // POST: Mail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TSTMail tSTMail = db.TSTMails.Find(id);
            db.TSTMails.Remove(tSTMail);
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
