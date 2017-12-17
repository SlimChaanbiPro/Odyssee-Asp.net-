using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Odyssey.Domain.Entities;
using Odyssey.Services;

namespace Odyssey.Web.Controllers
{
    public class OperatingCompaniesController : Controller
    {
        IOperatingCompanyServices service = null;

        public OperatingCompaniesController(IOperatingCompanyServices ocs)
        {
            service = ocs;
        }

        // GET: OperatingCompanies
        public ActionResult Index()
        {
            return View(service.GetAllOperatingCompanies());
        }

        // GET: OperatingCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperatingCompany operatingCompany = service.GetOperatingCompanyById(id.Value);
            if (operatingCompany == null)
            {
                return HttpNotFound();
            }
            return View(operatingCompany);
        }

        // GET: OperatingCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OperatingCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OperatingCompanyId,OperatingCompanyName,OperatingCompanyDetails")] OperatingCompany operatingCompany)
        {
            if (ModelState.IsValid)
            {
                service.CreateOperatingCompany(operatingCompany);
                return RedirectToAction("Index");
            }

            return View(operatingCompany);
        }

        // GET: OperatingCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperatingCompany operatingCompany = service.GetOperatingCompanyById(id.Value);
            if (operatingCompany == null)
            {
                return HttpNotFound();
            }
            return View(operatingCompany);
        }

        // POST: OperatingCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OperatingCompanyId,OperatingCompanyName,OperatingCompanyDetails")] OperatingCompany operatingCompany)
        {
            if (ModelState.IsValid)
            {
                service.EditOperatingCompany(operatingCompany);
                return RedirectToAction("Index");
            }
            return View(operatingCompany);
        }

        // GET: OperatingCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperatingCompany operatingCompany = service.GetOperatingCompanyById(id.Value);
            if (operatingCompany == null)
            {
                return HttpNotFound();
            }
            return View(operatingCompany);
        }

        // POST: OperatingCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.DeleteOperatingCompany(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
