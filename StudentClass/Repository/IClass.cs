using StudentClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentClass.Repository
{
    public interface IClass
    {
        string AddClass(Class classes);

        IEnumerable<Class> GetClasses();

        Class GetClassById(int id);

        string UpdateClass(int id, Class classes);

        string DeleteClass(int id);
    }
}