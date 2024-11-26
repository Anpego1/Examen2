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
    public class EquiposController : Controller
    {
        private static List<Equipo> equipos = new List<Equipo>();
        private static List<Usuario> usuarios = new List<Usuario>(); // Referencia a los usuarios

        // GET: Equipos
        public ActionResult Index()
        {
            return View(equipos);
        }

        // GET: Equipos/Create
        public ActionResult Create()
        {
            ViewBag.Usuarios = usuarios; // Pasar usuarios para seleccionar
            return View();
        }

        // POST: Equipos/Create
        [HttpPost]
        public ActionResult Create(Equipo equipo)
        {
            equipo.Id = equipos.Any() ? equipos.Max(e => e.Id) + 1 : 1;
            equipos.Add(equipo);
            return RedirectToAction("Index");
        }

        // GET: Equipos/Edit/5
        public ActionResult Edit(int id)
        {
            var equipo = equipos.FirstOrDefault(e => e.Id == id);
            if (equipo == null) return HttpNotFound();

            ViewBag.Usuarios = usuarios; // Pasar usuarios para seleccionar
            return View(equipo);
        }

        // POST: Equipos/Edit/5
        [HttpPost]
        public ActionResult Edit(Equipo equipo)
        {
            var existente = equipos.FirstOrDefault(e => e.Id == equipo.Id);
            if (existente != null)
            {
                existente.Tipo = equipo.Tipo;
                existente.Modelo = equipo.Modelo;
                existente.UsuarioId = equipo.UsuarioId;
            }
            return RedirectToAction("Index");
        }

        // GET: Equipos/Delete/5
        public ActionResult Delete(int id)
        {
            var equipo = equipos.FirstOrDefault(e => e.Id == id);
            if (equipo == null) return HttpNotFound();
            return View(equipo);
        }

        // POST: Equipos/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var equipo = equipos.FirstOrDefault(e => e.Id == id);
            if (equipo != null) equipos.Remove(equipo);
            return RedirectToAction("Index");
        }
    }
}
