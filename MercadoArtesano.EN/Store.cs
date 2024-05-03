using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoArtesano.EN
{
    public class Store
    {
        #region Personal Data
        [Key]
        public int Id { get; set; }

        [ForeignKey("Role")] //Indica que es una llave Foranea
        [Required(ErrorMessage = "El rol es requerido")] //Indica que es un campo requerido
        [Display(Name = "Rol")] // Una tipo traduccion (esto lo vera el cliente) 
        public int IdRole { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Nombre")] //Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "Debe contener solo Letras")] // Validamos el tipo de dato
        public string Name { get; set; } = string.Empty;

        [ForeignKey("City")] //Indica que es una llave Foranea
        [Required(ErrorMessage = "El Departamento es requerido")] //Indica que es un campo requerido
        [Display(Name = "Departamento")] // Una tipo traduccion (esto lo vera el cliente) 
        public string IdCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Telefono es requerido")] //Indica que es un campo requerido
        [StringLength(9, ErrorMessage = "Maximo 9 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Telefono")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[0-9-]+$", ErrorMessage = "El Telefono debe contener solo números")] // Validamos el tipo de dato
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Correo")] // Una tipo traduccion (esto lo vera el cliente) 
        public string EMail { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripcion es requerido")] //Indica que es un campo requerido
        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Descripcion")] // Una tipo traduccion (esto lo vera el cliente) 
        public string Description { get; set; } = string.Empty;
        #endregion

        #region User Data 
        [Required(ErrorMessage = "El nombre de Usuario es requerido")] //Indica que es un campo requerido
        [StringLength(20, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Nombre de Usuario")] // Una tipo traduccion (esto lo vera el cliente) 
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ. ]+$", ErrorMessage = "El Nombre debe contener solo Letras")] // Validamos el tipo de dato
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contrasena de Usuario es requerido")] //Indica que es un campo requerido
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")] // Indica la longitud maxima para dicho campo
        [Display(Name = "Nombre de Usuario")] // Una tipo traduccion (esto lo vera el cliente) 
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es requerido")]
        [Display(Name = "Estado")]
        public byte Status { get; set; }
        #endregion

        #region Dates
        [Required(ErrorMessage = "La Fecha de Creacion es requerida")] //Indica que es un campo requerido
        [Display(Name = "Fecha de Creacion")] // Una tipo traduccion (esto lo vera el cliente) 
        [DataType(DataType.Date, ErrorMessage = "Por favor, introduce una fecha válida")]
        public DateTime CreationDate { get; set; } = DateTime.MinValue;

        [Required(ErrorMessage = "La Fecha de Modificacion es requerida")] //Indica que es un campo requerido
        [Display(Name = "Fecha de Modificacion")] // Una tipo traduccion (esto lo vera el cliente) 
        [DataType(DataType.Date, ErrorMessage = "Por favor, introduce una fecha válida")]
        public DateTime ModificationDate { get; set; } = DateTime.MinValue;
        #endregion

        #region Not Mapped Data
        [NotMapped]
        [Required(ErrorMessage = "La confirmación de la contraseña es requerida")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        [StringLength(32, ErrorMessage = "La contraseña debe tener entre 6 y 32 caracteres", MinimumLength = 6)]
        [Display(Name = "Confirmar la contraseña")]
        public string ConfirmPassword_Aux { get; set; } = string.Empty; //propiedad auxiliar

        [NotMapped]
        public Role? Role { get; set; } // Propiedad de Navegacion

        [NotMapped]
        public City? City { get; set; } // Propiedad de Navegacion

        [NotMapped]
        public int Top_Aux { get; set; } // propiedad auxiliar
        #endregion
    }

    public enum Stores_Status
    {
        ACTIVO = 1, INACTIVO = 2
    }
}