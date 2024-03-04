using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass.Domain.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Range(1000000000, 9999999999, ErrorMessage = "Phone Number should be of 10 digits")]
        public Nullable<int> PhoneNumber { get; set; }

        [RegularExpression(@"[a-z0-0.%+-]+@[]a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]

        public string EmailId { get; set; }
        public Nullable<int> ClassIds { get; set; }
        [NotMapped]
        public string Search { get; set; }
        [NotMapped]
        public string SortBy { get; set; }

        [NotMapped]

        public string SortOrder { get; set; }
        [NotMapped]
        public int PageIndex { get; set; }
        [NotMapped]
        public int PageSize { get; set; }
    }
}

