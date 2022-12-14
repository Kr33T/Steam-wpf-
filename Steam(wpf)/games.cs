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
    
    public partial class games
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public games()
        {
            this.developersForGame = new HashSet<developersForGame>();
            this.genresForGame = new HashSet<genresForGame>();
            this.languagesForGame = new HashSet<languagesForGame>();
            this.publishersForGame = new HashSet<publishersForGame>();
            this.reviews = new HashSet<reviews>();
            this.tagsForGame = new HashSet<tagsForGame>();
            this.userLibrary = new HashSet<userLibrary>();
        }
    
        public int idGame { get; set; }
        public string gameName { get; set; }
        public string gameDescription { get; set; }
        public System.DateTime releaseDate { get; set; }
        public int gamePrice { get; set; }
        public bool isDiscounted { get; set; }
        public Nullable<int> priceWithDiscount { get; set; }
        public byte[] gameImage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<developersForGame> developersForGame { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<genresForGame> genresForGame { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<languagesForGame> languagesForGame { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<publishersForGame> publishersForGame { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reviews> reviews { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tagsForGame> tagsForGame { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userLibrary> userLibrary { get; set; }
    }
}
