//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MPool.WS.Users.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PoolerDeparture
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Name { get; set; }
        public Nullable<int> RoutingID { get; set; }
        public Nullable<int> SeatsAvailable { get; set; }
        public Nullable<System.DateTime> TimeOfDeparture { get; set; }
    
        public virtual USER USER { get; set; }
    }
}
