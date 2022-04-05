using EntreHojas.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntreHojas.WebAdmin.Controllers
{
    [Authorize]
    public class CategoriasController : Controller
    {
        CategoriasBL _categoriasBL;

        public CategoriasController()
        {
            _categoriasBL = new CategoriasBL();
        }

        // GET: Categorias
        public ActionResult Index()
        {
            var listadeCategorias = _categoriasBL.ObtenerCategorias();

            return View(listadeCategorias);
        }

        public ActionResult Crear()
        {
            var nuevaCategoria = new Categoria();


            return View(nuevaCategoria);
        }

        [HttpPost]
        public ActionResult Crear(Categoria categoria)   //
        {
            if (ModelState.IsValid)  //Esto permite revisar si la categoria cumple con todos los requisitos de validaciones, si es así lo guarda
            {                           // sino, me regresa al principio de lo que trataba de crear hasta cumplir con todas las validaciones.

                if (categoria.Descripcion != categoria.Descripcion.Trim())  //Esto nos sirve para que la descripcion no tenga espacios, si es así 
                {                                       //nos envía un mensaje de error
                    ModelState.AddModelError("Descripcion", "La descripción no debe contener espacios al inicio o al final");
                    return View(categoria);
                }
                _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }




        public ActionResult Editar(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Editar(Categoria categoria) //Lo mismo con editar 
        {
            if (ModelState.IsValid)  // Esto permite revisar si la categoria cumple con todos los requisitos de validaciones, si es así lo guarda
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim()) //Esto nos sirve para que la descripcion no tenga espacios, sie s así 
                {                                                           //nos envía un mensaje de error
                    ModelState.AddModelError("Descripcion", "La descripción no debe contener espacios al inicio o al final");
                    return View(categoria);
                }
                _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }


        public ActionResult Detalle(int id)
        {
            var producto = _categoriasBL.ObtenerCategoria(id);

            return View(producto);
        }


        public ActionResult Eliminar(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);

            return View(categoria);
        }


        [HttpPost]
        public ActionResult Eliminar(Categoria producto)
        {
            _categoriasBL.EliminarCategoria(producto.Id);

            return RedirectToAction("Index");
        }

    }
}