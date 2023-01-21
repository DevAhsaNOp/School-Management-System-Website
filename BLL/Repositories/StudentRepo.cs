using BOL;
using BOL.Validation_Classes;
using DAL.DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BLL.Repositories
{
    public class StudentRepo
    {
        private StudentDb DbObj;
        public StudentRepo()
        {
            DbObj = new StudentDb();
        }

        public bool InsertStudent(ValidateStudent model)
        {
            try
            {
                if (model != null)
                {
                    if (model.std_gender == "1")
                        model.std_gender = "Male";
                    else if (model.std_gender == "2")
                        model.std_gender = "Female";
                    else
                        model.std_gender = "Other";
                    student obj = new student()
                    {
                        std_address = model.std_address,
                        std_age = model.std_age,
                        std_class_id = model.std_class_id,
                        std_doa = model.std_doa.Date,
                        std_dob = model.std_dob.Date,
                        std_email = model.std_email,
                        std_Fathername = model.std_Fathername,
                        std_gender = model.std_gender,
                        std_Fname = model.std_Fname,
                        std_Lname = model.std_Lname,
                        std_Mothername = model.std_Mothername,
                        std_nationality = model.std_nationality,
                        std_phone = model.std_phone,
                        std_religion = model.std_religion,
                    };
                    var reas = DbObj.InsertStudent(obj);
                    if (reas)
                        return true;
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateStudent(ValidateStudent model)
        {
            try
            {
                if (model != null)
                {
                    if (model.std_gender == "1")
                        model.std_gender = "Male";
                    else if (model.std_gender == "2")
                        model.std_gender = "Female";
                    else
                        model.std_gender = "Other";
                    student obj = new student()
                    {
                        std_id = model.std_id,
                        std_address = model.std_address,
                        std_age = model.std_age,
                        std_class_id = model.std_class_id,
                        std_doa = model.std_doa,
                        std_dob = model.std_dob,
                        std_email = model.std_email,
                        std_Fathername = model.std_Fathername,
                        std_gender = model.std_gender,
                        std_Fname = model.std_Fname,
                        std_Lname = model.std_Lname,
                        std_Mothername = model.std_Mothername,
                        std_nationality = model.std_nationality,
                        std_phone = model.std_phone,
                        std_religion = model.std_religion,
                    };
                    DbObj.UpdateStudent(obj);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ValidateStudent> GetAllStudents()
        {
            return DbObj.GetAllStudents();
        }

        public IEnumerable<@class> GetAllClass()
        {
            return DbObj.GetAllClasses();
        }
        
        public int GetAllClassC()
        {
            return DbObj.GetAllClasses().Count();
        }

        public ValidateStudent GetStudentByID(int StudentId)
        {
            if (StudentId <= 0)
            {
                return null;
            }
            else
            {
                return DbObj.GetStudentByID(StudentId);
            }
        }

        public IEnumerable<ValidateStudent> GetAllStudentsFilter(string studentName, string phoneNumber, string className)
        {
            if (string.IsNullOrEmpty(studentName) && string.IsNullOrEmpty(phoneNumber) && string.IsNullOrEmpty(className))
            {
                return DbObj.GetAllStudents();
            }
            else
            {
                return DbObj.GetAllStudentsFilter(studentName, phoneNumber, className);
            }
        }

        public List<SelectListItem> GetAllClasses()
        {
            var AllClasses = GetAllClass();
            var classes = new List<SelectListItem>
            {
                new SelectListItem() { Text = "---Select Class---", Value = "0", Disabled = true, Selected = true }
            };
            foreach (var item in AllClasses)
            {
                classes.Add(new SelectListItem() { Text = (item.name + " " + item.section), Value = item.id.ToString() });
            }
            return classes;
        }

        public List<SelectListItem> GetAllGenders()
        {
            var condition = new List<SelectListItem>
            {
                new SelectListItem() { Text = "---Select Gender---", Value = "0", Disabled = true, Selected = true },
                new SelectListItem() { Text = "Male", Value = "1" },
                new SelectListItem() { Text = "Female", Value = "2" },
                new SelectListItem() { Text = "Other", Value = "3" }
            };
            return condition;
        }
    }
}
