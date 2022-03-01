using EntreHojas.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntreHojas.WebAdmin.Controllers
{
    public class ProductosController : Controller
    {
        ProductosBL _productosBL;
        CategoriasBL _categoriasBL;

        public ProductosController()
        {
            _productosBL = new ProductosBL();
            _categoriasBL = new CategoriasBL();
        }
        // GET: Productos
        public ActionResult Index()
        {
            var listadeProductos = _productosBL.ObtenerProductos();

            return View(listadeProductos);
        }

        public ActionResult Crear()
        {
            var nuevoProducto = new Producto();
            var categorias = _categoriasBL.ObtenerCategorias();


            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");

            return View(nuevoProducto);
        }

       [HttpPost]
        public ActionResult Crear(Producto producto, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid) // Esto permite revisar si el producto cumple con todos los requisitos de validaciones, si es así lo guarda
            {
                if (producto.CategoriaId == 0) //Sirve para cuando no existen categoias creadas, nos hace saber para poder crear el producto completo
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }


                if (imagen != null) //Nos permite guardar la imagen del producto
                {
                    producto.UrlImagen = GuardarImagen(imagen);
                }


                _productosBL.GuardarProducto(producto);

                return RedirectToAction("Index");
            }
            var categorias = _categoriasBL.ObtenerCategorias();


            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");

            return View(producto);
                
        }



        public ActionResult Editar(int id)
        {
           var producto = _productosBL.ObtenerProducto(id);
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);


            return View(producto);
        }



        [HttpPost]
        public ActionResult Editar(Producto producto, HttpPostedFileBase imagen) //Lo mismo con editar
        {
            if (ModelState.IsValid) // Esto permite revisar si el producto cumple con todos los requisitos de validaciones, si es así lo guarda
            {
                if (producto.CategoriaId == 0)  //Sirve para cuando no existen categoias creadas, nos hace saber para poder crear el producto completo
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }

                if (imagen != null) //Nos permite guardar la imagen del producto 
                {
                    producto.UrlImagen = GuardarImagen(imagen);
                }

                _productosBL.GuardarProducto(producto); 

                return RedirectToAction("Index");
            }
            var categorias = _categoriasBL.ObtenerCategorias();


            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");

            return View(producto);
        }




        public ActionResult Detalle(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);

            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _productosBL.EliminarProducto(producto.Id);

            return RedirectToAction("Index");
        }


        private string GuardarImagen(HttpPostedFileBase imagen)  //NOS permite guardar imagenes con los productos
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName); //Busca toda la ruta de la imagen y la guarda
            imagen.SaveAs(path);
                                                            //para guardar imagenes ya denemos tener creada una carpeta "Imagenes" en WebAdmin.
            return "/Imagenes/" + imagen.FileName;
        }



    }
}