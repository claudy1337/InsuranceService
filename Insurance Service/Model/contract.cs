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
    
    public partial class Contract
    {
        public int idContract { get; set; }
        public Nullable<int> idCar { get; set; }
        public Nullable<int> Experience { get; set; }
        public Nullable<int> ProcentAccidents { get; set; }
        public Nullable<int> Price { get; set; }
    
        public virtual Car Car { get; set; }
    }
}
