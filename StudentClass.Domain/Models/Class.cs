using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass.Domain.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Name { get; set; }

        [StringLength(100)]

        public string Description { get; set; }
        public Nullable<int> StudentIds { get; set; }

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
