using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoArtesano.EN
{
    public class Role
    {
        #region Entity's Attribute
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Nombre")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "El Nombre debe contener solo Letras")] // Validamos el tipo de dato
        public string Name { get; set; } = string.Empty;

        #endregion

        // Propiedades no mapeables
        [NotMapped]
        public int Top_Aux { get; set; } //Propiedad auxiliar
    }
}