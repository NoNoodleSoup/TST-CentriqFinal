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
    public class TicketsController : Controller
    {
        private TSTEntities db = new TSTEntities();

        // GET: Tickets
        public ActionResult Index()
        {
            var tSTTickets = db.TSTTickets.Include(t => t.TSTEmployee).Include(t => t.TSTEmployee1).Include(t => t.TSTPriority).Include(t => t.TSTTicketStatus);
            return View(tSTTickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTTicket tSTTicket = db.TSTTickets.Find(id);
            if (tSTTicket == null)
            {
                return HttpNotFound();
            }
            return View(tSTTicket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.TechID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID");
            ViewBag.SubmittedByID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID");
            ViewBag.PriorityID = new SelectList(db.TSTPriorities, "PriorityID", "PriorityName");
            ViewBag.TicketStatusID = new SelectList(db.TSTTicketStatuses, "TicketStatusID", "TicketStatusName");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketID,TicketSubject,TicketDescription,TicketImage,SubmittedByID,DateSubmitted,TicketStatusID,TechID,PriorityID,DateResolved")] TSTTicket tSTTicket)
        {
            if (ModelState.IsValid)
            {
                db.TSTTickets.Add(tSTTicket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TechID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID", tSTTicket.TechID);
            ViewBag.SubmittedByID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID", tSTTicket.SubmittedByID);
            ViewBag.PriorityID = new SelectList(db.TSTPriorities, "PriorityID", "PriorityName", tSTTicket.PriorityID);
            ViewBag.TicketStatusID = new SelectList(db.TSTTicketStatuses, "TicketStatusID", "TicketStatusName", tSTTicket.TicketStatusID);
            return View(tSTTicket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTTicket tSTTicket = db.TSTTickets.Find(id);
            if (tSTTicket == null)
            {
                return HttpNotFound();
            }
            ViewBag.TechID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID", tSTTicket.TechID);
            ViewBag.SubmittedByID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID", tSTTicket.SubmittedByID);
            ViewBag.PriorityID = new SelectList(db.TSTPriorities, "PriorityID", "PriorityName", tSTTicket.PriorityID);
            ViewBag.TicketStatusID = new SelectList(db.TSTTicketStatuses, "TicketStatusID", "TicketStatusName", tSTTicket.TicketStatusID);
            return View(tSTTicket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketID,TicketSubject,TicketDescription,TicketImage,SubmittedByID,DateSubmitted,TicketStatusID,TechID,PriorityID,DateResolved")] TSTTicket tSTTicket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tSTTicket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TechID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID", tSTTicket.TechID);
            ViewBag.SubmittedByID = new SelectList(db.TSTEmployees, "EmployeeID", "UserID", tSTTicket.SubmittedByID);
            ViewBag.PriorityID = new SelectList(db.TSTPriorities, "PriorityID", "PriorityName", tSTTicket.PriorityID);
            ViewBag.TicketStatusID = new SelectList(db.TSTTicketStatuses, "TicketStatusID", "TicketStatusName", tSTTicket.TicketStatusID);
            return View(tSTTicket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSTTicket tSTTicket = db.TSTTickets.Find(id);
            if (tSTTicket == null)
            {
                return HttpNotFound();
            }
            return View(tSTTicket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TSTTicket tSTTicket = db.TSTTickets.Find(id);
            db.TSTTickets.Remove(tSTTicket);
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
