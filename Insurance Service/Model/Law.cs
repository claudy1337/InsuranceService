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
    
    public partial class Law
    {
        public int idLaw { get; set; }
        public int idClient { get; set; }
        public System.DateTime DateIssue { get; set; }
        public string Number { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public string Region { get; set; }
        public string TPAuthority { get; set; }
        public string Category { get; set; }
        public string image { get; set; }
        public byte[] images { get; set; }
    
        public virtual Client Client { get; set; }
    }
}
