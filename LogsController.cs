using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC2cStore.Data;

namespace MVC2cStore.Controllers
{
    public class LogsController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();

        // GET: Logs
        public ActionResult Index()
        {
            return View(uow.LogRepository.Get());
        }

        // GET: Logs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log log = uow.LogRepository.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // GET: Logs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log log = uow.LogRepository.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // POST: Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Log log = uow.LogRepository.Find(id);
            uow.LogRepository.Remove(log);
            uow.Save();
            return RedirectToAction("Index");
        }

        // Methods for use with jQuery AJAX calls

        // Delete via AJAX
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AjaxDelete(int id)
        {
            Log log = uow.LogRepository.Find(id);
            uow.LogRepository.Remove(log);
            uow.Save();

            var message = string.Format("Deleted Log '{0}' from the database!", log.Message);
            return Json(new
            {
                id = id,
                message = message
            });
        }

        // Get PartialView of Details for AJAX display
        [HttpGet]
        public PartialViewResult LogDetails(int id)
        {
            Log log = uow.LogRepository.Find(id);
            return PartialView(log);
        }



    }
}
