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
    public class JourneysController : Controller
    {
        IJourneyServices service = null;
        ILocationServices locationService = null;
        IOperatingCompanyServices operatingCompanyService = null;

        public JourneysController(IJourneyServices js, ILocationServices ls, IOperatingCompanyServices ops)
        {
            service = js;
            locationService = ls;
            operatingCompanyService = ops;
        }

        // GET: Journeys
        public ActionResult Index()
        {
        }


        // POST: Journeys/Journeys/5
        public ActionResult Journeys(int idCustomer)
        {
        }


        // GET: Journeys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journey journey = service.GetJourneyById(id.Value);
            if (journey == null)
            {
                return HttpNotFound();
            }
            return View(journey);
        }

        // GET: Journeys/Create
        public ActionResult Create()
        {
            ViewBag.DestinationLocationCode = new SelectList(locationService.GetAllLocations(), "LocationCode", "LocationName");
            ViewBag.OperatingCompanyId = new SelectList(operatingCompanyService.GetAllOperatingCompanies(), "OperatingCompanyId", "OperatingCompanyName");
            ViewBag.OriginLocationCode = new SelectList(locationService.GetAllLocations(), "LocationCode", "LocationName");
            return View();
        }

        // POST: Journeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JourneyId,OriginLocationCode,DestinationLocationCode,OperatingCompanyId,StartDateAndTime,EndDateAndTime,OtherDetails")] Journey journey)
        {
            if (ModelState.IsValid)
            {
                service.CreateJourney(journey);
                return RedirectToAction("Index");
            }

            ViewBag.DestinationLocationCode = new SelectList(locationService.GetAllLocations(), "LocationCode", "LocationName", journey.DestinationLocationCode);
            ViewBag.OperatingCompanyId = new SelectList(operatingCompanyService.GetAllOperatingCompanies(), "OperatingCompanyId", "OperatingCompanyName", journey.OperatingCompanyId);
            ViewBag.OriginLocationCode = new SelectList(locationService.GetAllLocations(), "LocationCode", "LocationName", journey.OriginLocationCode);
            return View(journey);
        }

        // GET: Journeys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journey journey = service.GetJourneyById(id.Value);
            if (journey == null)
            {
                return HttpNotFound();
            }
            ViewBag.DestinationLocationCode = new SelectList(locationService.GetAllLocations(), "LocationCode", "LocationName", journey.DestinationLocationCode);
            ViewBag.OperatingCompanyId = new SelectList(operatingCompanyService.GetAllOperatingCompanies(), "OperatingCompanyId", "OperatingCompanyName", journey.OperatingCompanyId);
            ViewBag.OriginLocationCode = new SelectList(locationService.GetAllLocations(), "LocationCode", "LocationName", journey.OriginLocationCode);
            return View(journey);
        }

        // POST: Journeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JourneyId,OriginLocationCode,DestinationLocationCode,OperatingCompanyId,StartDateAndTime,EndDateAndTime,OtherDetails")] Journey journey)
        {
            if (ModelState.IsValid)
            {
                service.EditJourney(journey);
                return RedirectToAction("Index");
            }
            ViewBag.DestinationLocationCode = new SelectList(locationService.GetAllLocations(), "LocationCode", "LocationName", journey.DestinationLocationCode);
            ViewBag.OperatingCompanyId = new SelectList(operatingCompanyService.GetAllOperatingCompanies(), "OperatingCompanyId", "OperatingCompanyName", journey.OperatingCompanyId);
            ViewBag.OriginLocationCode = new SelectList(locationService.GetAllLocations(), "LocationCode", "LocationName", journey.OriginLocationCode);
            return View(journey);
        }

        // GET: Journeys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journey journey = service.GetJourneyById(id.Value);
            if (journey == null)
            {
                return HttpNotFound();
            }
            return View(journey);
        }

        // POST: Journeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.DeleteJourney(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                service.Dispose();
                locationService.Dispose();
                operatingCompanyService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
