using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.MODEL.Database
{
    public class Plan
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
    }

 
}
