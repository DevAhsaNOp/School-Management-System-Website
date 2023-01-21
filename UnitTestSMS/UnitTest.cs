using BLL.Repositories;
using BOL.Validation_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestSMS
{
    [TestClass]
    public class UnitTest
    {
        StudentRepo repo = new StudentRepo();

        [TestMethod()]
        public void GetAllCLassesCount()
        {
            var reas = repo.GetAllClassC();
            Assert.AreEqual(3, reas);
        }

        [TestMethod()]
        public void GetAllStudentsCount()
        {
            var reas = repo.GetAllStudents();
            Assert.AreEqual(4, reas.Count());
        }

        [TestMethod()]
        public void GetAllStudentById()
        {
            var reas = repo.GetStudentByID(2);
            Assert.AreEqual("Muhammad Ahsan", reas.std_Fname + " " + reas.std_Lname);
        }

        [TestMethod()]
        public void GetAllStudentsFilter()
        {
            var reas = repo.GetAllStudentsFilter("Muhammad", null, null);
            var reasA = reas.FirstOrDefault().std_Fname + " " + reas.FirstOrDefault().std_Lname + " student of class " + reas.FirstOrDefault().@class.name + " " + reas.FirstOrDefault().@class.section;
            Assert.AreEqual("Muhammad Ahsan student of class 1 A", reasA);
        }

        [TestMethod()]
        public void InsertStudent()
        {
            ValidateStudent student = new ValidateStudent()
            {
                std_Fname = "Fahad",
                std_Lname = "Khan",
                std_Fathername = "Zohaib Khan",
                std_Mothername = "Reham Khan",
                std_class_id = 1,
                std_address = "Karachi",
                std_age = 7,
                std_doa = Convert.ToDateTime("2022-05-02"),
                std_dob = Convert.ToDateTime("2015-12-02"),
                std_email = "fahadkahn@gmail.com",
                std_gender = "1",
                std_nationality = "Pakistani",
                std_phone = "02112345873",
                std_religion = "Islam"
            };
            var reas = repo.InsertStudent(student);
            Assert.AreEqual(true, reas);
        }

        [TestMethod()]
        public void UpdateStudent()
        {
            ValidateStudent student = new ValidateStudent()
            {
                std_id= 7,
                std_Fname = "Muhammad Fahad",
                std_Lname = "Khan",
                std_Fathername = "Zohaib Ali Khan",
                std_Mothername = "Reham Zohaib ALi Khan",
                std_class_id = 2,
                std_address = "Sherpao Sec 2 Landhi Karachi",
                std_age = 7,
                std_doa = Convert.ToDateTime("2022-05-08"),
                std_dob = Convert.ToDateTime("2015-01-25"),
                std_email = "fahad123@#@mail.com",
                std_gender = "1",
                std_nationality = "Pakistani",
                std_phone = "02112341243",
                std_religion = "Islam"
            };
            var reas = repo.UpdateStudent(student);
            Assert.AreEqual(true, reas);
        }
    }
}
