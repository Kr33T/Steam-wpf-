//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Steam_wpf_
{
    using System;
    using System.Collections.Generic;
    
    public partial class users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public users()
        {
            this.userLibrary = new HashSet<userLibrary>();
        }
    
        public int idUser { get; set; }
        public string nickname { get; set; }
        public string userSurname { get; set; }
        public string userName { get; set; }
        public string userMidname { get; set; }
        public double userBalance { get; set; }
        public string userLogin { get; set; }
        public string userPassword { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userLibrary> userLibrary { get; set; }
    }
}
