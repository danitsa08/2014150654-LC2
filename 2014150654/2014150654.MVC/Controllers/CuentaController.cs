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
    public class CuentaController : Controller
    {
        //private _2014150654DbContext db = new _2014150654DbContext();
        private readonly IUnityOfWork _UnityOfWork;


        // GET: /Cuenta/
        public CuentaController()
        {

        }
    public CuentaController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;

        }

        public ActionResult Index()
        {
           // return View(db.Cuenta.ToList());
            return View(_UnityOfWork.Cuenta.GetAll());
        }

        // GET: /Cuenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cuenta cuenta = db.Cuenta.Find(id);
            Cuenta cuenta = (Cuenta)_UnityOfWork.Cuenta.Get(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // GET: /Cuenta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Cuenta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Pin,NumeroCuenta")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Cuenta.Add(cuenta);
                // db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");

                //db.Cuenta.Add(cuenta);
                //db.SaveChanges();
                
            }

            return View(cuenta);
        }

        // GET: /Cuenta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cuenta cuenta = db.Cuenta.Find(id);
            Cuenta cuenta = (Cuenta)_UnityOfWork.Cuenta.Get(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // POST: /Cuenta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Pin,NumeroCuenta")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                
                _UnityOfWork.StateModified(cuenta);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View(cuenta);
        }

        // GET: /Cuenta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Cuenta cuenta = db.Cuenta.Find(id);
            Cuenta cuenta = (Cuenta)_UnityOfWork.Cuenta.Get(id);

            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // POST: /Cuenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Cuenta cuenta = db.Cuenta.Find(id);
            Cuenta cuenta = (Cuenta)_UnityOfWork.Cuenta.Get(id);
            //db.Cuenta.Remove(cuenta);
            _UnityOfWork.Cuenta.Delete(cuenta);
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
