using StudentClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentClass.Controllers
{
    public class ClassController : ApiController
    {
        StudentClassEntities db = new StudentClassEntities();

        //Add a class
        public string AddClass(Class classes)
        {
            db.Classes.Add(classes);
            db.SaveChanges();
            return "Class Added Successfully";
        }

        //Get list of all stuclassesdents
        public IEnumerable<Class> GetClasses()
        {
            return db.Classes.ToList();
        }


        //Get class by id
        public Class GetClassById(int id)
        {
            Class classes = db.Classes.Find(id);
            return classes;
        }


        //Edit a class
        public string UpdateClass(int id, Class classes)
        {
            Class _classes = db.Classes.Find(id);
            _classes.Name = classes.Name;
            _classes.Description = classes.Description;
            _classes.StudentIds = classes.StudentIds;
            db.Entry(_classes).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "Class Updated successfully";
        }


        //Delete a class
        public string DeleteClass(int id)
        {
            Class classes = db.Classes.Find(id);
            db.Classes.Remove(classes);
            db.SaveChanges();
            return "Class Deleted successfully";
        }
    }
}
