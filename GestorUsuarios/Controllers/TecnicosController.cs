using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GestorUsuarios.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GestorUsuarios.Controllers
{
    public class TecnicosController : Controller
    {
        private static List<Tecnico> tecnicos = new List<Tecnico>();

        // GET: Tecnicos
        public ActionResult Index()
        {
            return View(tecnicos);
        }

        // GET: Tecnicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tecnicos/Create
        [HttpPost]
        public ActionResult Create(Tecnico tecnico)
        {
            tecnico.Id = tecnicos.Any() ? tecnicos.Max(t => t.Id) + 1 : 1;
            tecnicos.Add(tecnico);
            return RedirectToAction("Index");
        }

        // GET: Tecnicos/Edit/5
        public ActionResult Edit(int id)
        {
            var tecnico = tecnicos.FirstOrDefault(t => t.Id == id);
            if (tecnico == null) return HttpNotFound();
            return View(tecnico);
        }

        // POST: Tecnicos/Edit/5
        [HttpPost]
        public ActionResult Edit(Tecnico tecnico)
        {
            var existente = tecnicos.FirstOrDefault(t => t.Id == tecnico.Id);
            if (existente != null)
            {
                existente.Nombre = tecnico.Nombre;
                existente.Especialidad = tecnico.Especialidad;
            }
            return RedirectToAction("Index");
        }

        // GET: Tecnicos/Delete/5
        public ActionResult Delete(int id)
        {
            var tecnico = tecnicos.FirstOrDefault(t => t.Id == id);
            if (tecnico == null) return HttpNotFound();
            return View(tecnico);
        }

        // POST: Tecnicos/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var tecnico = tecnicos.FirstOrDefault(t => t.Id == id);
            if (tecnico != null) tecnicos.Remove(tecnico);
            return RedirectToAction("Index");
        }
    }
}

