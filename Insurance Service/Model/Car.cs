//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insurance_Service.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            this.STS = new HashSet<STS>();
        }
    
        public int idCar { get; set; }
        public string idCategory { get; set; }
        public string StateNumber { get; set; }
        public string Stamp { get; set; }
        public string Model { get; set; }
        public Nullable<System.DateTime> YearRelease { get; set; }
        public Nullable<int> EnginePower { get; set; }
        public string VIN { get; set; }
        public string BodyNumber { get; set; }
        public string ChassisNumber { get; set; }
        public int IdClient { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
    
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STS> STS { get; set; }
    }
}
