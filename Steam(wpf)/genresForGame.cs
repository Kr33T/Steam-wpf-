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
    
    public partial class genresForGame
    {
        public int idGenresForGame { get; set; }
        public int idGenre { get; set; }
        public int idGame { get; set; }
    
        public virtual games games { get; set; }
        public virtual genres genres { get; set; }
    }
}
