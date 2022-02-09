﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntreHojas.BL
{
    public class ProductosBL
    {
        Contexto _contexto = new Contexto();
        public List<Producto> ListadeProductos { get; set; }

        public ProductosBL()
        {
            _contexto = new Contexto();
            ListadeProductos = new List<Producto>();
        }

        public List<Producto> ObtenerProductos()
        {
            ListadeProductos = _contexto.Productos.ToList();
            return _contexto.Productos.ToList();
        }
    }
}
