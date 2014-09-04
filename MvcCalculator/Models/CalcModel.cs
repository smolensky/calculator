using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCalculator.Models
{
    public class CalcModel
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public string Action { get; set; }
    }
}