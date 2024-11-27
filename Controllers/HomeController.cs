using Microsoft.AspNetCore.Mvc;
using MiApi2.Models;
using System.Collections.Generic;

namespace MiApi2.Controllers
{
    public class HomeController : Controller
    {

        private static List<DirectorioTelefonicoModel> directorio = new List<DirectorioTelefonicoModel>
        {
            new DirectorioTelefonicoModel
            {
                Dependencia = "Dependenciaags",
                Direccion = "Direccion",
                Departamento = "Departamentoags",
                Nombre = "Nombre",
                Cargo = "Cargos",
                Telefono = "4491929292",
                Extension = "101",
                Ubicacion = "Ubicacion",
                Correo = "correo1@example.com"
            }
        };

        public IActionResult Directorio()
        {
            return View(directorio);
        }

        [HttpPost]
        public IActionResult Add(DirectorioTelefonicoModel nuevoContacto)
        {
            directorio.Add(nuevoContacto);
            return RedirectToAction("Directorio");
        }

        public IActionResult Delete(string correo)
        {
            var contacto = directorio.Find(c => c.Correo == correo);
            if (contacto != null)
            {
                directorio.Remove(contacto);
            }
            return RedirectToAction("Directorio");
        }


        public IActionResult Edit(string correo)
        {
            var contacto = directorio.Find(c => c.Correo == correo);
            return View(contacto);
        }

        [HttpPost]
        public IActionResult Edit(DirectorioTelefonicoModel contactoActualizado)
        {
            var contacto = directorio.Find(c => c.Correo == contactoActualizado.Correo);
            if (contacto != null)
            {
                contacto.Dependencia = contactoActualizado.Dependencia;
                contacto.Direccion = contactoActualizado.Direccion;
                contacto.Departamento = contactoActualizado.Departamento;
                contacto.Nombre = contactoActualizado.Nombre;
                contacto.Cargo = contactoActualizado.Cargo;
                contacto.Telefono = contactoActualizado.Telefono;
                contacto.Extension = contactoActualizado.Extension;
                contacto.Ubicacion = contactoActualizado.Ubicacion;
                contacto.Correo = contactoActualizado.Correo;
            }
            return RedirectToAction("Directorio");
        }
    }
}
