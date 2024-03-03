using StudentClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using System.Web.Mvc;

namespace StudentClass.Controllers
{
    public class StudentController : ApiController
    {
        SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        OleDbConnection Econ;
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

        
        public IEnumerable<Student> GetStudentByClass(int id)
        {
            var classes=db.Classes.Find(id);
            
            
            var listOfStudents=db.Students.Where(x=>x.ClassIds==id).ToList();
            
            return listOfStudents;

        }

        public List<Student> GetStudentList(Student student)
        {
            List<Student> studentList = new List<Student>();
            try
            {
                string searchText = student.Search;
                Expression<Func<Student, object>> orderBy = x => x.StudentId;
                if (student.SortBy == "StudentId")
                {
                    orderBy = x => x.StudentId;

                }
                else if(student.SortBy == "FirstName")
                {
                    orderBy = x => x.FirstName;
                }
                else if (student.SortBy == "LastName")
                {
                    orderBy = x => x.LastName;
                }
                else if (student.SortBy == "PhoneNumber")
                {
                    orderBy = x => x.PhoneNumber;
                }
                if (student.SortOrder != null)
                {
                    if (student.SortBy.ToLower() == "asc")
                    {
                        studentList = db.Students.Where(x => x.FirstName.Contains(searchText != null ? searchText : x.FirstName)).OrderBy(orderBy).Skip((student.PageIndex-1)*student.PageSize).Take(student.PageSize).ToList();

                    }
                    else if (student.SortBy.ToLower() == "desc")
                    {
                        studentList = db.Students.Where(x => x.FirstName.Contains(searchText != null ? searchText : x.FirstName)).OrderByDescending(orderBy).Skip((student.PageIndex - 1) * student.PageSize).Take(student.PageSize).ToList();

                    }
                }
                else
                {
                    studentList = db.Students.Where(x => x.FirstName.Contains(searchText != null ? searchText : x.FirstName)).OrderByDescending(orderBy).ToList();
                }
                
            }
            catch (Exception ex)
            {

            }
            return studentList;
        }

        

       



    }
}
