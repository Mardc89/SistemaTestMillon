//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Psicologos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Psicologos()
        {
            this.Citas = new HashSet<Citas>();
        }
    
        public int IdPsicologo { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public int IdUsuario { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public string Profesion { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
