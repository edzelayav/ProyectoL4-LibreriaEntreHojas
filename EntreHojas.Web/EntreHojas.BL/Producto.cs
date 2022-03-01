using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntreHojas.BL
{
    public class Producto
    {

        public Producto()
        {
            Activo = true;
        }


        public int Id { get; set; }

        [Display(Name = "Descripcion")]//Esto nos indica que no puede estar nulo, que es un campo obligatorio,Sino ingresamos la descripción nos manda un mensaje de error
        [Required(ErrorMessage = "Ingrese la descripción")]
        [MinLength(3, ErrorMessage = "Ingrese minimo 3 caracteres")] //necesito ingresar minimo 3 caracteres
        [MaxLength(20, ErrorMessage = "Ingrese un maximo de 20 caracteres")] //ingresar máximo 20 caracteres
        public string Descripcion { get; set; }


        public string Autor { get; set; }


        [Required(ErrorMessage = "Ingrese el precio")] //Esto nos indica que no puede estar nulo, que es un campo obligatorio
        [Range(0, 1000, ErrorMessage = "Ingrese un precio entre 0 y 1000")] // nos permite ingresar números entre 0 y 1000
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }


        [Display(Name = "Imagen")] //
        public string UrlImagen { get; set; }

        public bool Activo { get; set; }
    }
}
