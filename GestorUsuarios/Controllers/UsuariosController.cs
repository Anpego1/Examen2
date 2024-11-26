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
    public class UsuariosController : Controller
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            usuario.Id = usuarios.Any() ? usuarios.Max(u => u.Id) + 1 : 1;
            usuarios.Add(usuario);
            return RedirectToAction("Index");
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return HttpNotFound();
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            var existente = usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (existente != null)
            {
                existente.Nombre = usuario.Nombre;
                existente.Correo = usuario.Correo;
                existente.Telefono = usuario.Telefono;
            }
            return RedirectToAction("Index");
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return HttpNotFound();
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null) usuarios.Remove(usuario);
            return RedirectToAction("Index");
        }
    }
}
