using StudentClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentClass.Controllers
{
    [BasicAuthentication]
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

        public List<Class> GetClassList(Class classes)
        {
            List<Class> classList = new List<Class>();
            try
            {
                string searchText = classes.Search;
                Expression<Func<Class, object>> orderBy = x => x.ClassId;
                if (classes.SortBy == "ClassId")
                {
                    orderBy = x => x.ClassId;

                }
                else if (classes.SortBy == "Name")
                {
                    orderBy = x => x.Name;
                }
                if (classes.SortOrder != null)
                {
                    if (classes.SortBy.ToLower() == "asc")
                    {
                        classList = db.Classes.Where(x => x.Name.Contains(searchText != null ? searchText : x.Name)).OrderBy(orderBy).Skip((classes.PageIndex - 1) * classes.PageSize).Take(classes.PageSize).ToList();

                    }
                    else if (classes.SortBy.ToLower() == "desc")
                    {
                        classList = db.Classes.Where(x => x.Name.Contains(searchText != null ? searchText : x.Name)).OrderByDescending(orderBy).Skip((classes.PageIndex - 1) * classes.PageSize).Take(classes.PageSize).ToList();

                    }
                }
                else
                {
                    classList = db.Classes.Where(x => x.Name.Contains(searchText != null ? searchText : x.Name)).OrderByDescending(orderBy).ToList();
                }

            }
            catch (Exception ex)
            {

            }
            return classList;
        }

    }
}
