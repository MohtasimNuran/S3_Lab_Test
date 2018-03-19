using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S3_WebApplication.Models
{
    public class ViewList
    {
        public int Id { get; set; }
        public string SyllabusName { get; set; }
        public string TradeName { get; set; }
        public string LevelName { get; set; }
        public string SylDoc { get; set; }
        public string TestDoc { get; set; }
        public string Language { get; set; }
    }
}