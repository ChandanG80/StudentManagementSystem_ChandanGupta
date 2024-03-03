using StudentClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentClass.Controllers
{
    public class StudentController : ApiController
    {
        StudentClassEntities db = new StudentClassEntities();

        //Adding a student
        public string AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return "Student Added";
        }


        //Get list of all students
        public IEnumerable<Student> GetStudents()
        {
            return db.Students.ToList();
        }


        //Get student by id
        public Student GetStudentById(int id)
        {
            Student user = db.Students.Find(id);
            return user;
        }


        //Edit a student
        public string UpdateStudent(int id, Student student)
        {
            Student _student = db.Students.Find(id);
            _student.FirstName = student.FirstName;
            _student.LastName = student.LastName;
            _student.PhoneNumber = student.PhoneNumber;
            _student.EmailId = student.EmailId;
            _student.ClassIds = student.ClassIds;
            db.Entry(_student).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "Student Updated successfully";
        }


        //Delete a student
        public string DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return "Student Deleted successfully";
        }

    }
}
