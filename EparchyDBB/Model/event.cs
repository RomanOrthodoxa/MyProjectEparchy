//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EparchyDBB.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class @event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> IdChurch { get; set; }
        public Nullable<int> IdSpiritualMinister { get; set; }
    
        public virtual Church Church { get; set; }
        public virtual SpiritualMinister SpiritualMinister { get; set; }
    }
}
