//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LABA2_SERVER_PART
{
    using System;
    using System.Collections.Generic;
    
    public partial class CLIENTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTS()
        {
            this.ROOMS_CLIENTS = new HashSet<ROOMS_CLIENTS>();
        }
    
        public int ID { get; set; }
        public string FIO { get; set; }
        public string PHONE_NUMBER { get; set; }
        public Nullable<int> AGE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROOMS_CLIENTS> ROOMS_CLIENTS { get; set; }
    }
}
