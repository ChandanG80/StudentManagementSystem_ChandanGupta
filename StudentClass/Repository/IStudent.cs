using StudentClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentClass.Repository
{
    public interface IStudent
    {
        string AddStudent(Student student);
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
        string UpdateStudent(int id, Student student);
        string DeleteStudent(int id);
        IEnumerable<Student> GetStudentByClass(int id);
        List<Student> GetStudentList(Student student);
    }
}