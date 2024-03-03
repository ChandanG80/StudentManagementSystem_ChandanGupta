using StudentClass.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentClass.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        OleDbConnection Econ;
        StudentClassEntities db = new StudentClassEntities();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Index(HttpPostedFileBase file)
        {
            string filename=Guid.NewGuid()+Path.GetExtension(file.FileName);
            string filepath = "/excelfolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
            InsertData(filepath, filename);
            return View();
        }

        private void ExcelConn(string filepath)
        {
            string con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties""Excel 12.0 Xml;HDR=YES;""", filepath);
            Econ = new OleDbConnection(con);
        }


        private void InsertData(string filepath, string filename)
        {
            string fullpath = Server.MapPath("/filefolder/") + filename;
            ExcelConn(fullpath);
            string query = string.Format("select * from [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(query, Econ);
            Econ.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable dt = ds.Tables[0];
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            objbulk.DestinationTableName = "Student";
            objbulk.ColumnMappings.Add("StudentId", "StudentId");
            objbulk.ColumnMappings.Add("FirstName", "FirstName");
            objbulk.ColumnMappings.Add("LastName", "LastName");
            objbulk.ColumnMappings.Add("PhoneNumber", "PhoneNumber");
            objbulk.ColumnMappings.Add("EmailId", "EmailId");
            objbulk.ColumnMappings.Add("ClassIds", "ClassIds");
            con.Open();
            objbulk.WriteToServer(dt);
            con.Close();




        }
    }
}
