using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservBigBird.APIModel
{
    public class ModelAPI
    {
    }
    public class Article
    {
        public string articleId { get; set; }
        public string articleIdAlias { get; set; }
        public string articleName { get; set; }
        public string brand { get; set; }
        public string color { get; set; }
        public string department { get; set; }
        public string departmentType { get; set; }
        public string gender { get; set; }
        public int id { get; set; }
        public int price { get; set; }
        public string size { get; set; }
        public string unit { get; set; }
    }

    public class Login
    {
        public int id { get; set; }
        public String username { get; set; }
        public String email { get; set; }
        public String pass { get; set; }
    }
}