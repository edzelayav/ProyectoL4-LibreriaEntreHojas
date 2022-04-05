using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntreHojas.BL
{
    public class Cliente
    {
      
 
            public int Id { get; set; }

            [Required(ErrorMessage = "Ingrese el nombre del cliente")]
            [MinLength(2, ErrorMessage = "Ingrese mínimo 2 caracteres")]
            public string Nombre { get; set; }

            [Required(ErrorMessage = "Ingrese el teléfono")]
            [MinLength(8, ErrorMessage = "El Numero de teléfono debe ser de 8 digitos")]
            [MaxLength(8, ErrorMessage = "El Numero de teléfono debe ser de 8 digitos")]
            public string Telefono { get; set; }

            [Required(ErrorMessage = "Ingrese su dirección")]
            [MinLength(50, ErrorMessage = "Ingrese mínimo 6 caracteres")]
            public string Direccion { get; set; }
            public bool Activo { get; set; }
        }
    }







