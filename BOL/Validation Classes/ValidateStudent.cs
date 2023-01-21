using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BOL.Validation_Classes
{
    public class ValidateStudent
    {
        public int std_id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets are allow")]
        [MaxLength(50, ErrorMessage = "First Name Max Length should be under 50")]
        [MinLength(3, ErrorMessage = "First Name Min Length should be 3")]
        public string std_Fname { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets are allow")]
        [MaxLength(50, ErrorMessage = "Last Name Max Length should be under 50")]
        [MinLength(3, ErrorMessage = "Last Name Min Length should be 3")]
        public string std_Lname { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Father Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets are allow")]
        [MaxLength(50, ErrorMessage = "Father Name Max Length should be under 50")]
        [MinLength(5, ErrorMessage = "Father Name Min Length should be 5")]
        public string std_Fathername { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Mother Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets are allow")]
        [MaxLength(50, ErrorMessage = "Mother Name Max Length should be under 50")]
        [MinLength(5, ErrorMessage = "Mother Name Min Length should be 5")]
        public string std_Mothername { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Gender")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Must select a Gender")]
        public string std_gender { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"03[0-9]{2}(?!1234567)(?!1111111)(?!7654321)[0-9]{7}", ErrorMessage = "Invalid Phone Number")]
        public string std_phone { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Address")]
        [MaxLength(100, ErrorMessage = "Address Length should be under 100")]
        [MinLength(5, ErrorMessage = "Address Min Length should be 5")]
        public string std_address { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Email Address")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Invalid Email Address")]
        public string std_email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Nationality")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets are allow")]
        [MaxLength(25, ErrorMessage = "Nationality Max Length should be under 25")]
        [MinLength(5, ErrorMessage = "Nationality Min Length should be 5")]
        public string std_nationality { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Date of Birth")]
        public System.DateTime std_dob { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Date of Admission")]
        public System.DateTime std_doa { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Age")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Age")]
        public int std_age { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Religion")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets are allow")]
        [MaxLength(25, ErrorMessage = "Religion Max Length should be under 25")]
        [MinLength(4, ErrorMessage = "Religion Min Length should be 4")]
        public string std_religion { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Class")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Must select a Class")]
        public Nullable<int> std_class_id { get; set; }

        public virtual @class @class { get; set; }
        public virtual ICollection<fee> fees { get; set; }
        public virtual ICollection<result> results { get; set; }

    }
}
