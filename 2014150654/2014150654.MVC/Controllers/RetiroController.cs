using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2014150654_ENT.Entities;
using _2014150654_PER;
using _2014150654_ENT.IRepository;

namespace _2014150654.MVC.Controllers
{
    public class RetiroController : Controller
    {
        //private _2014150654DbContext db = new _2014150654DbContext();
        private readonly IUnityOfWork _UnityOfWork;


        // GET: /Retiro/
         public RetiroController()
        {

        }
        public RetiroController (IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;

        }

        public ActionResult Index()
        {
           // return View(db.Retiro.ToList());
            return View(_UnityOfWork.Retiro.GetAll());

        }

        // GET: /Retiro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Retiro retiro = db.Retiro.Find(id);
            Retiro retiro = (Retiro)_UnityOfWork.Retiro.Get(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);

        }

        // GET: /Retiro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Retiro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RetiroId")] Retiro retiro)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Retiro.Add(retiro);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");

                //db.Retiro.Add(retiro);
                //db.SaveChanges();

            }

            return View(retiro);
        }

        // GET: /Retiro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Retiro retiro = db.Retiro.Find(id);
            Retiro retiro = (Retiro)_UnityOfWork.Retiro.Get(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);
        }

        // POST: /Retiro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RetiroId")] Retiro retiro)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(retiro);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(retiro);
        }

        // GET: /Retiro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Retiro retiro = db.Retiro.Find(id);
            Retiro retiro = (Retiro)_UnityOfWork.Retiro.Get(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);
        }

        // POST: /Retiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Retiro retiro = db.Retiro.Find(id);
            Retiro retiro = (Retiro)_UnityOfWork.Retiro.Get(id);
            //db.Retiro.Remove(retiro);
            _UnityOfWork.Retiro.Delete(retiro);
            //db.SaveChanges();
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
