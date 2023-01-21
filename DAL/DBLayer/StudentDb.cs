using BOL;
using BOL.Validation_Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DBLayer
{
    public class StudentDb
    {
        private studentmanagementsystem_Entities _context;

        public StudentDb()
        {
            _context = new studentmanagementsystem_Entities();
        }

        public bool InsertStudent(student model)
        {
            try
            {
                _context.students.Add(model);
                Save();
                if (model.std_id > 0)
                {
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

        public IEnumerable<@class> GetAllClasses()
        {
            return _context.classes.ToList();
        }

        public void UpdateStudent(student model)
        {
            try
            {
                _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ValidateStudent> GetAllStudents()
        {
            var reas = _context.students.Select(s => new ValidateStudent()
            {
                std_address = s.std_address,
                std_age = s.std_age,
                std_class_id = s.std_class_id,
                std_doa = s.std_doa,
                std_dob = s.std_dob,
                std_email = s.std_email,
                std_Fathername = s.std_Fathername,
                std_gender = s.std_gender,
                std_Fname = s.std_Fname,
                std_Lname = s.std_Lname,
                std_id = s.std_id,
                std_Mothername = s.std_Mothername,
                std_nationality = s.std_nationality,
                std_phone = s.std_phone,
                std_religion = s.std_religion,
                @class = s.@class
            }).ToList();
            return reas;
        }

        public ValidateStudent GetStudentByID(int StudentId)
        {
            var reas = _context.students.Find(StudentId);
            ValidateStudent student = new ValidateStudent()
            {
                std_id = reas.std_id,
                std_address = reas.std_address,
                std_age = reas.std_age,
                std_class_id = reas.std_class_id,
                std_doa = reas.std_doa,
                std_dob = reas.std_dob,
                std_email = reas.std_email,
                std_Fathername = reas.std_Fathername,
                std_gender = reas.std_gender,
                std_Fname = reas.std_Fname,
                std_Lname = reas.std_Lname,
                std_Mothername = reas.std_Mothername,
                std_nationality = reas.std_nationality,
                std_phone = reas.std_phone,
                std_religion = reas.std_religion,
                fees = reas.fees,
                results = reas.results,
                @class = reas.@class
            };
            return student;
        }

        public IEnumerable<ValidateStudent> GetAllStudentsFilter(string studentName, string phoneNumber, string className)
        {
            var reas = _context.students.Select(s => new ValidateStudent()
            {
                std_address = s.std_address,
                std_age = s.std_age,
                std_class_id = s.std_class_id,
                std_doa = s.std_doa,
                std_dob = s.std_dob,
                std_email = s.std_email,
                std_Fathername = s.std_Fathername,
                std_gender = s.std_gender,
                std_Fname = s.std_Fname,
                std_Lname = s.std_Lname,
                std_id = s.std_id,
                std_Mothername = s.std_Mothername,
                std_nationality = s.std_nationality,
                std_phone = s.std_phone,
                std_religion = s.std_religion,
                @class = s.@class
            }).ToList();
            if (!string.IsNullOrEmpty(studentName))
            {
                reas = reas.Where(x => x.std_Fname.ToLower().Contains(studentName.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                reas = reas.Where(x => (x.std_phone).Contains(phoneNumber)).ToList();
            }
            if (!string.IsNullOrEmpty(className))
            {
                reas = reas.Where(x => x.@class.name.Contains(className)).ToList();
            }
            return reas;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
