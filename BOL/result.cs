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
    
    public partial class result
    {
        public int RES_id { get; set; }
        public Nullable<int> RES_class_id { get; set; }
        public Nullable<int> RES_std_id { get; set; }
        public string Exam_type { get; set; }
        public Nullable<int> RES_maths_marks { get; set; }
        public Nullable<int> RES_englishliterature_marks { get; set; }
        public Nullable<int> RES_englishgrammar_marks { get; set; }
        public Nullable<int> RES_urdu_marks { get; set; }
        public Nullable<int> RES_islamiyat_marks { get; set; }
        public Nullable<int> RES_Science_marks { get; set; }
        public Nullable<int> RES_Physics_marks { get; set; }
        public Nullable<int> RES_Chemistry_marks { get; set; }
        public Nullable<int> RES_History_marks { get; set; }
        public Nullable<int> RES_Geography_marks { get; set; }
        public Nullable<int> RES_Computer_marks { get; set; }
        public Nullable<int> RES_activity_marks { get; set; }
        public int RES_obtain_marks { get; set; }
        public int RES_total_marks { get; set; }
        public double RES_percentage { get; set; }
        public string RES_grade { get; set; }
        public string RES_REmarks { get; set; }
    
        public virtual @class @class { get; set; }
        public virtual student student { get; set; }
    }
}
