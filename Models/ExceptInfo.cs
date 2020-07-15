using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstChe.Models
{
    public class ExceptInfo
    {
        public int Id { get; set; }
        public string ExceptName { get; set; }    
        public string Url { get; set; }
        public string MethodType { get; set; }
        public string StackTrace { get; set; }  
    }


    public class ExceptContext : DbContext 
    {
        public ExceptContext() : base("DefaultConnection") { }
        public DbSet<ExceptInfo> ExceptInfos { get; set; }
    }
}