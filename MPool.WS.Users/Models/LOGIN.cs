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
    
    public partial class LOGIN
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    
        public virtual USER USER { get; set; }
    }
}
