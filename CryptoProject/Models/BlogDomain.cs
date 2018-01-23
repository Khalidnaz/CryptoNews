using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoProject.Models
{
    public class BlogDomain
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public string Review { get; set; }


        public string Price { get; set; }


    }
}