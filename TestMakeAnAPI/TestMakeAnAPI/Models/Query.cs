using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMakeAnAPI.Models
{
    public class Query
    {
        public string Category { get; set; }
        public int Amount { get; set; }
        public string Title { get; set; }
        public string ExactTitle { get; set; }
    }
}