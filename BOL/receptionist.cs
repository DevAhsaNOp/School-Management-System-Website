//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class receptionist
    {
        public int rep_id { get; set; }
        public Nullable<int> rep_emp_id { get; set; }
        public string rep_username { get; set; }
        public string rep_password { get; set; }
    
        public virtual employee employee { get; set; }
    }
}
