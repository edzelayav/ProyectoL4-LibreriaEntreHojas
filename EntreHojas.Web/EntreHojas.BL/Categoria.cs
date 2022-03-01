using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntreHojas.BL
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese la categoria")]  //Esto nos indica que no puede estar nulo, que es un campo obligatorio.
        public string Descripcion { get; set; }             //Sino ingresamos la descripción nos manda un mensaje de error
    }
}
